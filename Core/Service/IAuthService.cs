using Core.Domain;
using Microsoft.AspNetCore.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Core.Service
{
    public interface IAuthService
    {
        Task<Auth> RegisterAsync(Register model);
        Task<Auth> LoginAsync(Login model);
        Task<string> AddRoleAsync(AddRole model);
       
    }
}
