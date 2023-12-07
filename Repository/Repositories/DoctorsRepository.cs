using Microsoft.EntityFrameworkCore;
using Core.Service;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Repository;
using Core.Models;
using Repository.Data;
using System;
namespace Service;
public class DoctorsRepository<T> : IDoctorsRepository<T> where T : Doctors
{
    private readonly ApplicationContext _context;
    private DbSet<T> entities;

    public DoctorsRepository(ApplicationContext context)
    {
        _context = context;
        entities = context.Set<T>();
    }
    public IEnumerable<T> GetAllDoctors()
    {
        return entities.AsEnumerable();
        
    }
    public T GetDoctorById(string id)
    {
        return entities.SingleOrDefault(s => s.Id == id);
    }
    public  T AddDoctor(T doctorModel)
    {
        if (doctorModel == null)
        {
            throw new ArgumentNullException("entity");
        }
        entities.Add(doctorModel);
        _context.SaveChanges();
        return doctorModel;
        
    }
    public async Task<bool> UpdateDoctorById(string id, T doctorModel)
    {
        var doctor = entities.FindAsync(id);
        if (doctor != null)
        {
            entities.Update(doctorModel as T );
            await _context.SaveChangesAsync();
            return true;
        }
        return false; 
    }
    public async Task<bool> DeleteDoctorById(string id)
    {
        var doctor = await entities.FindAsync(id);
        if (doctor != null)
        {
            entities.Remove(doctor);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }
}