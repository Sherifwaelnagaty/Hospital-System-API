using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IPatientsService
    {
        Task<List<Users>> GetAllUsers();
        Task<Users> GetUserByIdAsync(string id);
    }
}
