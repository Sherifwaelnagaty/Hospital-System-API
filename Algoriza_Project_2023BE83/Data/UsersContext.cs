using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Algoriza_Project_2023BE83.Models;
using Core.Domain;
namespace Algoriza_Project_2023BE83.Data;
public class UsersContext : IdentityDbContext
{
    public UsersContext(DbContextOptions<UsersContext> options) : base(options)
    {

    }
    public DbSet<Users> User { get; set; }

}