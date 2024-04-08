using Core.DTO;
using Core.Enums;
using Core.Models;
using Core.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class PatientsRepository : ApplicationUserRepository, IPatientsRepository
    {

        public PatientsRepository(ApplicationContext context,
            UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signInManager) :
            base(context, userManager, roleManager, signInManager)
        {

        }

        public bool IsExist(string id)
        {
            string PatientRoleName = UserRole.Patient.ToString();
            string PatientRoleId = _context.Roles.
                                        Where(r => r.Name == PatientRoleName)
                                        .Select(r => r.Id).SingleOrDefault().ToString();

            return _context.UserRoles.Any(x => x.UserId == id && x.RoleId == PatientRoleId);
        }
        public async Task<IActionResult> GetAllPatients(int pageNumber, int pageSize, Func<PatientDTO, bool> criteria = null)
        {
            // Get All patients
            try
            {
                // Get patients
                var patients = (await _userManager.
                         GetUsersInRoleAsync(Enum.GetName(UserRole.Patient))).AsEnumerable();

                // Drop unnecessary columns
                IEnumerable<PatientDTO> DesiredPatients = patients.Select(p => new PatientDTO
                {
                    ImagePath = p.Image,
                    FullName = p.FullName,
                    Email = p.Email,
                    Phone = p.PhoneNumber,
                    Gender = p.Gender.ToString(),
                    DateOfBirth = p.DateOfBirth.ToString()
                });

                // Apply criteria - if exists -
                if (criteria != null)
                {
                    DesiredPatients = DesiredPatients.Where(criteria);
                }

                // Apply Pagination 
                if (pageNumber != 0)
                    DesiredPatients = DesiredPatients.Skip((pageNumber - 1) * pageSize);

                if (pageSize != 0)
                    DesiredPatients = DesiredPatients.Take(pageSize);

                return new OkObjectResult(DesiredPatients.ToList());
            }
            catch (Exception ex)
            {
                return new ObjectResult($"There is a problem during getting the data {ex.Message}")
                {
                    StatusCode = 500
                };
            }

        }
    }
}
