using Core.Models;
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
        private readonly PatientsRepository <Patients> _patientsRepository;

        public PatientService(PatientsRepository<Patients> patientsRepository) 
        {
            patientsRepository = _patientsRepository;
        }
        public IEnumerable<Patients> GetAllPatients(int pageNumber, int pageSize)
        {
            return _patientsRepository.GetAllPatients(pageNumber, pageSize);
        }

        public Patients GetPatientById(string id)
        {
            return _patientsRepository.GetPatientById(id);

        }
    }
}
