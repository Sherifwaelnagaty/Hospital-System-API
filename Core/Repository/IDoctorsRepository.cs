using Core.DTO;
using Core.Models;
using Core.Repository;
using Microsoft.AspNetCore.Mvc;
namespace Core.Service;
public interface IDoctorsRepository: IDataOperationsRepository<Doctors>
{
    IActionResult GetAllDoctors(int pageNumber, int pageSize, Func<DoctorDTO, bool> criteria = null);
    int GetDoctorIdByUserId(string UserId);
    IActionResult GetDoctorById(int doctorId);
    Task<int> GetNumberOfDoctors();
    public IActionResult GetTopDoctors();
    Task<ApplicationUser> GetDoctorUser(string userId);
    Task<string> GetDoctorIdFromClaim(ApplicationUser user);


}