using Core.DTO;
using Core.Models;
using Core.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
namespace Core.Service;
public interface IDoctorsRepository: IDataOperationsRepository<Doctors>
{
    IActionResult GetAllDoctors(int pageNumber, int pageSize,Func<DoctorDTO, bool> criteria = null);
    int GetDoctorById(string UserId);
    IActionResult GetSpecificDoctorInfo(int doctorId);
    Task<int> GetNumberOfDoctors();
    public IActionResult GetTopDoctors();
}