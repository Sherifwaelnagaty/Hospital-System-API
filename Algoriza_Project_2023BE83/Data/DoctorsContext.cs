using Microsoft.EntityFrameworkCore;
namespace Algoriza_Project_2023BE83.Data;
using Algoriza_Project_2023BE83.Models;
public class DoctorsContext: DbContext
{
    public DoctorsContext(DbContextOptions<DoctorsContext> options) : base(options)
    {

    }

    public DbSet<Doctorsmodel> Doctors { get; set; }

}