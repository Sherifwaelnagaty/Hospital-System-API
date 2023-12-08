using Core.Models;
using Core.Service;

namespace Service
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorsRepository<Doctors> _doctorsRepository;
        public DoctorService(IDoctorsRepository<Doctors> doctorsRepository)
        {
            _doctorsRepository = doctorsRepository;
        }
        public Doctors AddDoctor(Doctors doctorModel)
        {
            return _doctorsRepository.AddDoctor(doctorModel);
        }
        public Task<bool> DeleteDoctorById(string id)
        {
            return _doctorsRepository.DeleteDoctorById(id);
        }
        public IEnumerable<Doctors> GetAllDoctors(int pageNumber, int pageSize)
        {
            return  _doctorsRepository.GetAllDoctors(pageNumber, pageSize);
        }
        public Doctors GetDoctorById(string id)
        {
            return _doctorsRepository.GetDoctorById(id);
        }
        public Task<bool> UpdateDoctorById(string id, Doctors doctorModel)
        {
            return _doctorsRepository.UpdateDoctorById(id, doctorModel);
        }
        public Task<int> GetNumberOfDoctors()
        {
            return _doctorsRepository.GetNumberOfDoctors();
        }
        public IEnumerable<Doctors> GetTopDoctors()
        {
            return _doctorsRepository.GetTopDoctors();
        }
    }
}
