using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Core.Models;
namespace Repository.Data;
public class UsersContext : IdentityDbContext<Base>
{
    public UsersContext(DbContextOptions<UsersContext> options) : base(options)
    {

    }
}