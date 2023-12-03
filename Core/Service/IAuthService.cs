using Core.Domain;
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
    }
}
