using Core.Service;
using System.Collections.Generic;
using System.Linq;
using Core.Models;
using Repository.Data;
using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Core.DTO;
using System.Threading.Tasks;
namespace Repository;
public class DoctorsRepository : DataOperationsRepository<Doctors>, IDoctorsRepository
{
    private UserManager<ApplicationUser> _userManager;

    public DoctorsRepository(ApplicationContext context, UserManager<ApplicationUser> userManager) : base(context)
    {
        _userManager = userManager;
    }
    public IActionResult GetAllDoctors(int pageNumber, int pageSize, Func<DoctorDTO, bool> criteria = null)
    {
        try
        {
            IEnumerable<DoctorDTO> fullDoctorsInfo = _context.Set<Doctors>()
            .Join
                                         (
                                            _context.Users,
                                            doctor => doctor.DoctorUserId,
                                            user => user.Id,
                                            (doctor, user) => new
                                            {
                                                Image = user.Image,
                                                FullName = user.FullName,
                                                Email = user.Email,
                                                Phone = user.PhoneNumber,
                                                Gender = Enum.GetName(user.Gender),
                                                SpecializationId = doctor.SpecializationId
                                            }
                                        ).Join
            (
                                            _context.Specializations,
                                            doctor => doctor.SpecializationId,
                                            specialization => specialization.Id,
                                            (doctor, specialization) => new DoctorDTO
                                            {
                                                ImagePath = doctor.Image,
                                                FullName = doctor.FullName,
                                                Email = doctor.Email,
                                                Phone = doctor.Phone,
                                                Gender = doctor.Gender,
                                                Specialization = specialization.Name
                                            }
                                        );
            if (criteria != null)
            {
                fullDoctorsInfo = fullDoctorsInfo.Where(criteria);
            }

            if (pageNumber != 0)
                fullDoctorsInfo = fullDoctorsInfo.Skip((pageNumber - 1) * pageSize);

            if (pageSize != 0)
                fullDoctorsInfo = fullDoctorsInfo.Take(pageSize);

            return new OkObjectResult(fullDoctorsInfo.ToList());
        }
        catch (Exception ex)
        {
            return new ObjectResult($"There is a problem during getting the data {ex.Message}")
            {
                StatusCode = 500
            };
        }
    }

    int IDoctorsRepository.GetDoctorById(string UserId)
    {
        throw new NotImplementedException();
    }

    public IActionResult GetSpecificDoctorInfo(int doctorId)
    {
        throw new NotImplementedException();
    }

    IActionResult IDoctorsRepository.GetTopDoctors()
    {
        throw new NotImplementedException();
    }

    public Task<int> GetNumberOfDoctors()
    {
        throw new NotImplementedException();
    }
}