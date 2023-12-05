using Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Core.Repository;
public interface IDoctorsRepository<T> where T : Doctors
{
    Task<List<Doctors>> GetAllDoctors();
    Task<Doctors> GetDoctorById(string id);
    Task<Doctors> AddDoctor(Doctors doctorModel);
    Task<bool> UpdateDoctorById(string id, Doctors doctorModel);
    Task<bool> DeleteDoctorById(string id);
}