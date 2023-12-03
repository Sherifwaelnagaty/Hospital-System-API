using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Algoriza_Project_2023BE83.Models;
using Algoriza_Project_2023BE83.Data;
using Core.Service;
using Core.Domain;
namespace Service;
public class DoctorsServices : IDoctorsService
{
    private readonly DoctorsContext _context;

        public DoctorsServices(DoctorsContext context)
        {
            _context = context;
        }
        public async Task<List<Doctorsmodel>> GetAllDoctors(){
        var doctors = await _context.Doctors.Select(x=> new Doctorsmodel(){
            gender = x.gender,
            Id = x.Id,
            FirstName = x.FirstName,
            LastName = x.LastName,
            Specialize = x.Specialize,
            Phone = x.Phone,
            Image = x.Image,
            Dateofbirth = x.Dateofbirth
        }).ToListAsync();
        return doctors;
        }
        public async Task<Doctorsmodel> GetDoctorById(int id){
            var doctor = await _context.Doctors.Where(x=>x.Id == id).Select(x=> new Doctorsmodel(){
                gender = x.gender,
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Specialize = x.Specialize,
                Phone = x.Phone,
                Image = x.Image,
                Dateofbirth = x.Dateofbirth
            }).FirstOrDefaultAsync();
            return doctor;
        }
        public async Task<int> AddDoctor(Doctorsmodel doctorModel){
            var doctor = new Doctorsmodel(){

                gender = doctorModel.gender,
                Id = doctorModel.Id,
                FirstName = doctorModel.FirstName,
                LastName = doctorModel.LastName,
                Specialize = doctorModel.Specialize,
                Phone = doctorModel.Phone,
                Image = doctorModel.Image,
                Dateofbirth = doctorModel.Dateofbirth
            };
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
            return doctor.Id;
        }
        public async Task UpdateDoctorById(int id,Doctorsmodel doctorModel){
            var doctor = await _context.Doctors.FindAsync(id);
            if(doctor != null){
                var Updated_doctor = new Doctorsmodel(){
                gender = doctorModel.gender,
                Id = doctorModel.Id,
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
        public async Task DeleteDoctorById(int id){
            var doctor = await _context.Doctors.FindAsync(id);
            if(doctor != null){
                _context.Doctors.Remove(doctor);
                await _context.SaveChangesAsync();
            }
        }

    public Task Login(Doctors doctorModel)
    {
        throw new NotImplementedException();
    }


    public Task<int> AddDoctor(Doctors doctorModel)
    {
        throw new NotImplementedException();
    }

    public Task UpdateDoctorById(int id, Doctors doctorModel)
    {
        throw new NotImplementedException();
    }

    Task<List<Doctors>> IDoctorsService.GetAllDoctors()
    {
        throw new NotImplementedException();
    }

    Task<Doctors> IDoctorsService.GetDoctorById(int id)
    {
        throw new NotImplementedException();
    }
}