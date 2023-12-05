using Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Core.Service;
public interface IPatientsRepository<T> where T : Patients
{
    Task<List<Users>> GetAllUsers();
    Task<Users> GetUserByIdAsync(string id);
}