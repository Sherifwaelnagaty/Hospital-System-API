using Core.Models;
using Core.Repository;
using Core.Service;
using Repository;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class PatientService : IPatientsService
    {
        private readonly IPatientsRepository <ApplicationUser> _patientsRepository;

        public PatientService(IPatientsRepository<ApplicationUser> patientsRepository) 
        {
            patientsRepository = _patientsRepository;
        }
        public IEnumerable<ApplicationUser> GetAllPatients(int pageNumber, int pageSize)
        {
            return _patientsRepository.GetAllPatients(pageNumber, pageSize);
        }

        public ApplicationUser GetPatientById(string id)
        {
            return _patientsRepository.GetPatientById(id);

        }
        public Task<int> GetNumbersofPatients()
        {
            return _patientsRepository.GetNumbersofPatients();
        }
    }
}
