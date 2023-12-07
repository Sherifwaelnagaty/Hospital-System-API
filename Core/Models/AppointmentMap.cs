using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class AppointmentMap
    {
        public AppointmentMap(EntityTypeBuilder<Appointment> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Days).IsRequired();
            entityBuilder.Property(t => t.Date).IsRequired();
            entityBuilder.Property(t => t.Time).IsRequired();
            entityBuilder.Property(t => t.Price).IsRequired();
            entityBuilder.Property(t => t.UsersId).IsRequired();
            entityBuilder.Property(t=>t.DoctorsId).IsRequired();
        }
    }
}
