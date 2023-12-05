using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IDoctorService
    {
        Task<List<Doctors>> GetAllDoctors();
        Task<Doctors> GetDoctorById(string id);
        Task<Doctors> AddDoctor(Doctors doctorModel);
        Task<bool> UpdateDoctorById(string id, Doctors doctorModel);
        Task<bool> DeleteDoctorById(string id);
    }
}
