using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Core.Domain;
namespace Repository;
public class UsersContext : IdentityDbContext<Users>
{
    public UsersContext(DbContextOptions<UsersContext> options) : base(options)
    {
       
    }
}