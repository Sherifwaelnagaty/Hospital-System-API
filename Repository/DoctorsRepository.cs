
using Microsoft.EntityFrameworkCore;
using Core.Domain;
using Core.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
namespace Repository;
public class DoctorsRepository<T> : IDoctorsRepository<T> where T : Doctors
{
    private readonly ApplicationContext _context;
    private DbSet<T> entities;

    public DoctorsRepository(ApplicationContext context)
    {
        _context = context;
        entities = context.Set<T>();
    }
    public async Task<List<Doctors>> GetAllDoctors()
    {
        var doctors = await entities.Select(x => new Doctors()
        {
            gender = x.gender,
            FirstName = x.FirstName,
            LastName = x.LastName,
            Specialize = x.Specialize,
            Phone = x.Phone,
            Image = x.Image,
            Dateofbirth = x.Dateofbirth
        }).ToListAsync();
        return doctors;
    }
    public async Task<Doctors> GetDoctorById(string id)
    {
        var doctor = await entities.Where(x => x.Id == id).Select(x => new Doctors()
        {
            gender = x.gender,
            FirstName = x.FirstName,
            LastName = x.LastName,
            Specialize = x.Specialize,
            Phone = x.Phone,
            Image = x.Image,
            Dateofbirth = x.Dateofbirth
        }).FirstOrDefaultAsync();
        return doctor;
    }
    public async Task<Doctors> AddDoctor(Doctors doctorModel)
    {
        var doctor = new Doctors()
        {

            gender = doctorModel.gender,
            FirstName = doctorModel.FirstName,
            LastName = doctorModel.LastName,
            Specialize = doctorModel.Specialize,
            Phone = doctorModel.Phone,
            Image = doctorModel.Image,
            Dateofbirth = doctorModel.Dateofbirth
        };
        entities.Add((T) doctor);
        await _context.SaveChangesAsync();
        return doctor;
    }
    public async Task<bool> UpdateDoctorById(string id, Doctors doctorModel)
    {
        var doctor = await entities.FindAsync(id);
        if (doctor != null)
        {
            var Updated_doctor = new Doctors()
            {
                gender = doctorModel.gender,
                FirstName = doctorModel.FirstName,
                LastName = doctorModel.LastName,
                Specialize = doctorModel.Specialize,
                Phone = doctorModel.Phone,
                Image = doctorModel.Image,
                Dateofbirth = doctorModel.Dateofbirth
            };
            entities.Update((T)Updated_doctor);
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