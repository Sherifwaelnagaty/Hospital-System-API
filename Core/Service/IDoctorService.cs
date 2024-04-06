using Core.DTO;
using Core.Enums;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IDoctorService
    {
        public IActionResult GetTopDoctors();
        Task<IActionResult> AddDoctor(UserDTO userDTO, UserRole patient, string specialize);
        Task<IActionResult> DeleteDoctor(int id);
        IActionResult GetDoctorById(int id);
        IActionResult GetAllDoctors(int pageNumber, int pageSize, string search);
    }
}
