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
        Task<IActionResult> UpdateDoctorById(int id, UserDTO userDTO, string specialize);
        Task<IActionResult> DeleteDoctorById(int id);
        IActionResult GetDoctorById(int id);
        IActionResult GetAllDoctors(int pageNumber, int pageSize, string search);
        IActionResult AddAppointments(int DoctorId, AppointmentsDTO appointments);
        IActionResult ConfirmCheckUp(int BookingId);
        IActionResult GetDoctorBookings(string DoctorUserId, int Page, int PageSize,
                                        string search);

    }
}
