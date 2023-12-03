using Algoriza_Project_2023BE83.Models;
using Core.Domain;
using Microsoft.AspNetCore.Mvc;
namespace Core.Service;
public interface IDoctorsService
{
    Task Login(Doctors doctorModel);
    Task<List<Doctors>> GetAllDoctors();
    Task<Doctors> GetDoctorById(int id);
    Task<int> AddDoctor(Doctors doctorModel);
    Task UpdateDoctorById(int id,Doctors doctorModel);
    Task DeleteDoctorById(int id);
}