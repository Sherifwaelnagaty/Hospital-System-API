using Microsoft.AspNetCore.Mvc;
using Core.Domain;
namespace Core.Service;
public interface IUsersService
{
    Task<List<Users>> GetAllPatients();
    Task<Users> GetPatientByIdAsync(int id);
    Task<bool> Register(Users usersmodel);
    Task<bool> Login(Users usersmodel);
}