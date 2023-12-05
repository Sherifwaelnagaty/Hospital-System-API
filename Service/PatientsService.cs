using Core;
using Core.Domain;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class PatientsService : IPatientsService
    {
        private readonly IPatientsRepository<Patients> _patientsRepository;
        public PatientsService(IPatientsRepository<Patients> patientsRepository) 
        {
            _patientsRepository = patientsRepository;
        }
        public Task<List<Users>> GetAllUsers()
        {
            return _patientsRepository.GetAllUsers();
        }

        public Task<Users> GetUserByIdAsync(string id)
        {
            return _patientsRepository.GetUserByIdAsync(id);
        }
    }
}
