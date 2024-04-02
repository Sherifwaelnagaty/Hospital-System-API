﻿using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public interface IPatientsRepository<T> where T : ApplicationUser
    {
        T AddPatient(T patientmodel);
        IEnumerable<T> GetAllPatients(int pageNumber, int pageSize);
        T GetPatientById(string id);
        Task<int> GetNumbersofPatients();
    }
}
