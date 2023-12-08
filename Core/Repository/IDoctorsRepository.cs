using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Core.Service;
public interface IDoctorsRepository<T> where T : Doctors
{
    IEnumerable<T> GetAllDoctors(int pageNumber, int pageSize);
    T GetDoctorById(string id);
    T AddDoctor(T doctorModel);
    Task<bool> UpdateDoctorById(string id, T doctorModel);
    Task<bool> DeleteDoctorById(string id);
    Task<int> GetNumberOfDoctors();
    IEnumerable<T> GetTopDoctors(int count);
}