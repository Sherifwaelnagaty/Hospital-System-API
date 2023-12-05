using Core.Domain;
using Core.Repository;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class DoctorService:IDoctorService
    {
        private readonly IDoctorsRepository<Doctors> _doctorsRepository;
        public DoctorService(IDoctorsRepository<Doctors> doctorsRepository) 
        {
            _doctorsRepository = doctorsRepository;
        }

        public Task<Doctors> AddDoctor(Doctors doctorModel)
        {
            return _doctorsRepository.AddDoctor(doctorModel);
        }

        public Task<bool> DeleteDoctorById(string id)
        {
            return _doctorsRepository.DeleteDoctorById(id);
        }

        public Task<List<Doctors>> GetAllDoctors()
        {
            return _doctorsRepository.GetAllDoctors();
        }

        public Task<Doctors> GetDoctorById(string id)
        {
            return _doctorsRepository.GetDoctorById(id);
        }

        public Task<bool> UpdateDoctorById(string id, Doctors doctorModel)
        {
            return _doctorsRepository.UpdateDoctorById(id, doctorModel);
        }
    }
}
