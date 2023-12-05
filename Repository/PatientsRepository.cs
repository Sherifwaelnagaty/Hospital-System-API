using Microsoft.EntityFrameworkCore;
using Core.Domain;
using Core.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Core.Service;
namespace Repository;
class PatientsRepository<T> : IPatientsRepository<T> where T : Users
{
    private readonly UsersContext _context;
    private DbSet<T> entities;

    public PatientsRepository(UsersContext context)
    {
        _context = context;
        entities = context.Set<T>();
    }
    public async Task<List<Users>> GetAllUsers()
    {
        var patients = await entities.Select(x => new Users()
        {
            Id = x.Id,
            FirstName = x.FirstName,
            LastName = x.LastName,
            PhoneNumber = x.PhoneNumber,
        }).ToListAsync();
        return patients;
    }
    public async Task<Users> GetUserByIdAsync(string id)
    {
        var patient = await entities.Where(x => x.Id == id).Select(x => new Users()
        {
            Id = x.Id,
            FirstName = x.FirstName,
            LastName = x.LastName,
            PhoneNumber = x.PhoneNumber,
        }).FirstOrDefaultAsync();
        return patient;
    }

}