using Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Core.Repository;
public interface IUsersRepository
{
    Task<List<Users>> GetAllPatients();
    Task<Users> GetPatientByIdAsync(int id);
    Task<bool> Register(Users usersmodel);
    Task<bool> Login(Users usersmodel);
}