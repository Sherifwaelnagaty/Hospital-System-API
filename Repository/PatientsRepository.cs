using Core.Models;
using Core.Repository;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PatientsRepository<T>:IPatientsRepository<T> where T : Patients
    {
        private readonly ApplicationContext _context;
        private DbSet<T> entities;
        public PatientsRepository(ApplicationContext context) 
        {
            _context = context;
            entities = context.Set<T>();
        }

        public IEnumerable<T> GetAllPatients(int pageNumber, int pageSize)
        {
            if (pageNumber < 1)
            {
                throw new ArgumentException("Page number should be greater than or equal to 1.", nameof(pageNumber));
            }

            if (pageSize < 1)
            {
                throw new ArgumentException("Page size should be greater than or equal to 1.", nameof(pageSize));
            }

            // Calculate the number of items to skip
            int itemsToSkip = (pageNumber - 1) * pageSize;

            // Use Skip and Take for pagination
            return entities.Skip(itemsToSkip).Take(pageSize).AsEnumerable();
        }

        public T GetPatientById(string id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }
    }
}
