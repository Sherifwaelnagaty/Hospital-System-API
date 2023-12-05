using Microsoft.EntityFrameworkCore;
using Core.Domain;
using Core.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
namespace Repository;
class UsersRepository<T> : IUsersRepository<T> where T : Users
{
    private readonly ApplicationContext _context;
    private DbSet<T> entities;

    public UsersRepository(ApplicationContext context)
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
            Phone = x.Phone,
            Image = x.Image,
            Dateofbirth = x.Dateofbirth
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
            Phone = x.Phone,
            Image = x.Image,
            Dateofbirth = x.Dateofbirth,
            gender = x.gender
        }).FirstOrDefaultAsync();
        return patient;
    }

}