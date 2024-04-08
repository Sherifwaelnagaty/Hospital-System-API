using Core.DTO;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public interface IPatientsRepository:IApplicationUserRepository
    {
        Task<IActionResult> GetAllPatients(int pageNumber, int pageSize,
                                Func<PatientDTO, bool> criteria = null);
        bool IsExist(string id);
    }
}
