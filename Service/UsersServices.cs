using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Algoriza_Project_2023BE83.Models;
using Algoriza_Project_2023BE83.Data;
using Core.Service;
using Core.Domain;
namespace Service.Data;
class UsersServices : IUsersService
{
    private readonly UsersContext _context;

    public UsersServices(UsersContext context)
    {
        _context = context;
    }
    public async Task<bool> Register(Users usersmodel)
    {
        if(usersmodel != null){
            var user = new Users(){
                Id = usersmodel.Id,
                FirstName = usersmodel.FirstName,
                LastName = usersmodel.LastName,
                Password = usersmodel.Password,
                ConfirmPassword = usersmodel.ConfirmPassword,
                Phone = usersmodel.Phone,
                Image = usersmodel.Image,
                Dateofbirth = usersmodel.Dateofbirth
            };
            var result = _context.Users.Add(user);
            if(result != null){
                await _context.SaveChangesAsync();
                return true;
            }
        }
        return false;
    }
    public async Task<List<Users>> GetAllUsers()
    {
        var patients = await _context.Users.Select(x=>new Users(){
            Id = x.Id,
            FirstName = x.FirstName,
            LastName = x.LastName,
            Phone = x.Phone,
            Image = x.Image,
            Dateofbirth = x.Dateofbirth
        }).ToListAsync();
        return patients;
    }
    public async Task<Users> GetPatientByIdAsync(string id)
    {
        var patient = await _context.Users.Where(x=>x.Id==id).Select(x=>new Users(){
            Id = x.Id,
            FirstName = x.FirstName,
            LastName = x.LastName,
            Phone = x.Phone,
            Image = x.Image,
            Dateofbirth = x.Dateofbirth,
            gender = x.gender
        }).FirstOrDefaultAsync();
        return patient;
    }

    public Task<bool> Login(Users usersmodel)
    {
        throw new NotImplementedException();
    }

    public Task<List<Users>> GetAllPatients()
    {
        throw new NotImplementedException();
    }

    public Task<Users> GetPatientByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}