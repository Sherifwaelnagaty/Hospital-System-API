using Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Core.Repository;
public interface IUsersRepository<T> where T : Users
{
    Task<List<Users>> GetAllUsers();
    Task<Users> GetUserByIdAsync(string id);
}