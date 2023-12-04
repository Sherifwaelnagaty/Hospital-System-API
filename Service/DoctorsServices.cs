using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Algoriza_Project_2023BE83.Data;
using Core.Service;
using Core.Domain;
namespace Service.Service;
public class DoctorsServices : IDoctorsService
{
    private readonly DoctorsContext _context;

    public DoctorsServices(DoctorsContext context)
    {
        _context = context;
    }
    public async Task<List<Doctors>> GetAllDoctors()
    {
        var doctors = await _context.Doctors.Select(x => new Doctors()
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
    public async Task<Doctors> GetDoctorById(int id)
    {
        var doctor = await _context.Doctors.Where(x => x == x).Select(x => new Doctors()
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
        _context.Doctors.Add(doctor);
        await _context.SaveChangesAsync();
        return doctor;
    }
    public async Task UpdateDoctorById(int id, Doctors doctorModel)
    {
        var doctor = await _context.Doctors.FindAsync(id);
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
            _context.Doctors.Update(Updated_doctor);
            await _context.SaveChangesAsync();
        }
    }
    public async Task DeleteDoctorById(int id)
    {
        var doctor = await _context.Doctors.FindAsync(id);
        if (doctor != null)
        {
            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
        }
    }

}