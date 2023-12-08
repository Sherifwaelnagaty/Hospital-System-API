using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IDoctorService
    {
        IEnumerable<Doctors> GetAllDoctors(int pageNumber, int pageSize);
        Doctors GetDoctorById(string id);
        Doctors AddDoctor(Doctors doctorModel);
        Task<bool> UpdateDoctorById(string id, Doctors doctorModel);
        Task<bool> DeleteDoctorById(string id);
        Task<int> GetNumberOfDoctors();
        IEnumerable<Doctors> GetTopDoctors();
    }
}
