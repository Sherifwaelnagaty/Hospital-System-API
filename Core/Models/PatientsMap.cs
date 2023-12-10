using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class PatientsMap
    {
        public PatientsMap(EntityTypeBuilder<Patients> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Email).IsRequired();
            entityBuilder.Property(t => t.FirstName).IsRequired();
            entityBuilder.Property(t => t.LastName).IsRequired();
            entityBuilder.Property(t => t.gender).IsRequired();
            entityBuilder.Property(t => t.Phone).IsRequired();
            entityBuilder.Property(t => t.Dateofbirth).IsRequired();
            entityBuilder.Property(t=>t.Image).IsRequired();
            entityBuilder.Property(t=>t.UserName).IsRequired();
            entityBuilder.Property(t=>t.PhoneNumber).IsRequired();
            entityBuilder.Property(t => t.password).IsRequired();
        }
    }
}
