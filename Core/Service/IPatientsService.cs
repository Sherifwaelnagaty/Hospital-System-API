using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IPatientsService
    {
        IEnumerable<ApplicationUser> GetAllPatients(int pageNumber, int pageSize);
        ApplicationUser GetPatientById(string id);
        Task<int> GetNumbersofPatients();
    }
}
