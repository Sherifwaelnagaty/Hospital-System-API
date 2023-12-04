using Microsoft.EntityFrameworkCore;
namespace Algoriza_Project_2023BE83.Data;
using Algoriza_Project_2023BE83.Models;
using Core.Domain;

public class DoctorsContext: DbContext
{
    public DoctorsContext(DbContextOptions<DoctorsContext> options) : base(options)
    {

    }

    public DbSet<Doctors> Doctors { get; set; }

}