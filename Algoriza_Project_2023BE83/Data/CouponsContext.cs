using Algoriza_Project_2023BE83.Models;
using Microsoft.EntityFrameworkCore;

namespace Algoriza_Project_2023BE83.Data
{
    public class CouponsContext : DbContext
    {
        public CouponsContext(DbContextOptions<CouponsContext> options) : base(options)
        {

        }

        public DbSet<CouponsModel> Coupons { get; set; }

    }
}
