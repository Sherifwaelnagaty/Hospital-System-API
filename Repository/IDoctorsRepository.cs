using Core.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Core.Service;
public interface IDoctorsRepository<T> where T : Doctors
{
    IEnumerable<T> GetAllDoctors();
    T GetDoctorById(string id);
    T AddDoctor(T doctorModel);
    Task<bool> UpdateDoctorById(string id, T doctorModel);
    Task<bool> DeleteDoctorById(string id);
}