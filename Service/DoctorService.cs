using AutoMapper;
using Core.Domain;
using Core.DTO;
using Core.Enums;
using Core.Models;
using Core.Repository;
using Core.Service;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Service
{
    public class DoctorService : ApplicationUserService,IDoctorService
    {
        private readonly IAppointmentService _appointmentServices;
        private readonly IEmailServices _emailService;

        public DoctorService(IUnitOfWork UnitOfWork, IMapper mapper,
            IAppointmentService appointmentServices, IEmailServices emailServices) :
            base(UnitOfWork, mapper)
        {
            _appointmentServices = appointmentServices;
            _emailService = emailServices;
        }
        public async Task<IActionResult> AddDoctor(UserDTO userDTO, UserRole patient, string specialize)
        {
            try
            {
                Specialization specialization = _unitOfWork.Specializations.GetByName(specialize);
                if (specialization == null)
                {
                    return new NotFoundObjectResult($"There is no Specialization called {specialize}");
                }

                var result = await AddUser(userDTO, UserRole.Doctor);

                if (result is not OkObjectResult okResult)
                {
                    return result;
                }


                ApplicationUser User = okResult.Value as ApplicationUser;
                Doctors doctor = new()
                {
                    DoctorUser = User,
                    Specialization = specialization,
                };

                await _unitOfWork.Doctors.Add(doctor);
                await _emailService.SendEmailAsync(User.Email, "Hospital",
                    $"You are now a Doctor. \n Your userName: {User.FullName}" +
                    $" \n Your Password: {userDTO.Password}");

                _unitOfWork.Complete();

                return new OkObjectResult(doctor);
            }
            catch (Exception ex)
            {
                return new ObjectResult($"An error occurred while Adding Doctor \n: {ex.Message}" +
                    $"\n {ex.InnerException?.Message}")
                {
                    StatusCode = 500
                };
            }
        }
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            // delete doctor (it will delete user also because the delete action is on cascade
            try
            {
                Doctors doctor = _unitOfWork.Doctors.GetById(id);
                if (doctor == null)
                {
                    return new NotFoundObjectResult($"Id {id} is not found");
                }

                bool HasHistory = _unitOfWork.Bookings.IsExist(b => b.DoctorId == id);
                if (HasHistory)
                {
                    return new BadRequestObjectResult("You cant delete this doctor");
                }

                _unitOfWork.Doctors.Delete(doctor);
                ApplicationUser User = await _unitOfWork.Doctors.GetDoctorUser(doctor.DoctorUserId);
                await _unitOfWork.ApplicationUser.DeleteUser(User);
                _unitOfWork.Complete();
                return new OkObjectResult("Deleted successfully");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
        public IActionResult GetAllDoctors(int pageNumber, int pageSize, string search)
        {
            try
            {
                Func<DoctorDTO, bool> criteria = null;

                if (!string.IsNullOrEmpty(search))
                    criteria = (d => d.Email.Contains(search) || d.Phone.Contains(search) ||
                                d.FullName.Contains(search) || d.Gender.Contains(search) ||
                                d.Specialization.Contains(search));

                // get doctors
                var gettingDoctorsResult = _unitOfWork.Doctors.GetAllDoctors(pageNumber, pageSize, criteria);
                if (gettingDoctorsResult is not OkObjectResult doctorsResult)
                {
                    return gettingDoctorsResult;
                }
                List<DoctorDTO> doctorsInfoList = doctorsResult.Value as List<DoctorDTO>;

                if (doctorsInfoList == null || doctorsInfoList.Count == 0)
                {
                    return new NotFoundObjectResult("There is no doctor");
                }

                // Load doctor images
                var doctorsInfo = doctorsInfoList.Select(d => new
                {
                    Image = GetImage(d.ImagePath),
                    d.FullName,
                    d.Phone,
                    d.Email,
                    d.Gender,
                    d.Specialization
                }).ToList();

                return new OkObjectResult(doctorsInfo);
            }
            catch (Exception ex)
            {
                return new ObjectResult($"An error occurred while Getting Doctors info \n: {ex.Message}" +
                    $"\n {ex.InnerException?.Message}")
                {
                    StatusCode = 500
                };
            }
        }
        public IActionResult GetDoctorById(int id)
        {
            try
            {
                // check Id Existence
                bool IfFound = _unitOfWork.Doctors.IsExist(doctor => doctor.Id == id);
                if (!IfFound)
                {
                    return new NotFoundObjectResult($"No doctor found with id {id}");
                }

                var result = _unitOfWork.Doctors.GetSpecificDoctorInfo(id);
                if (result is not OkObjectResult okResult)
                {
                    return result;
                }


                DoctorDTO doctorInfo = okResult.Value as DoctorDTO;

                doctorInfo.Image = GetImage(doctorInfo.ImagePath);
                var CompleteDoctorInfo = new
                {
                    doctorInfo.Image,
                    doctorInfo.FullName,
                    doctorInfo.Email,
                    doctorInfo.Phone,
                    doctorInfo.Gender,
                    doctorInfo.Specialization
                };

                return new OkObjectResult(CompleteDoctorInfo);
            }
            catch (Exception ex)
            {
                return new ObjectResult($"An error occurred while Getting Doctor info \n: {ex.Message}" +
                   $"\n {ex.InnerException?.Message}")
                {
                    StatusCode = 500
                };
            }
        }
        public Task<IActionResult> UpdateDoctorById(int id, UserDTO userDTO, string specialize)
        {
            try
            {
                // Get Old Data
                Doctor doctor = _unitOfWork.Doctors.GetById(id);
                if (doctor == null)
                {
                    return new NotFoundObjectResult($"There is no Doctor with id: {id}.");
                }

                // Get & Set new specializeId
                Specialization specialization = _unitOfWork.Specializations.GetByName(specialize);
                if (specialization == null)
                {
                    return new NotFoundObjectResult($"There is no Specialization called {specialize}");
                }
                doctor.SpecializationId = specialization.Id;

                // Update User
                ApplicationUser user = await _unitOfWork.ApplicationUser.GetUser(doctor.DoctorUserId);
                var result = await UpdateUser(user, userDTO);

                //User Creation Failed
                if (result is not OkResult)
                {
                    return result;
                }

                _unitOfWork.Doctors.Update(doctor);
                _unitOfWork.Complete();
                return new OkObjectResult(doctor);
            }
            catch (Exception ex)
            {
                return new ObjectResult($"An error occurred while Adding Doctor \n: {ex.Message}" +
                    $"\n {ex.InnerException?.Message}")
                {
                    StatusCode = 500
                };
            }
        }
        public IActionResult GetTopDoctors()
        {
            return _unitOfWork.Doctors.GetTopDoctors();
        }
    }
}
