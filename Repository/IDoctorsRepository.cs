using Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Core.Repository;
public interface IDoctorsRepository<T> where T : Doctors
{
    Task<List<Doctors>> GetAllDoctors();
    Task<Doctors> GetDoctorById(int id);
    Task<Doctors> AddDoctor(Doctors doctorModel);
    Task UpdateDoctorById(int id, Doctors doctorModel);
    Task DeleteDoctorById(int id);
}