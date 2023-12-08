using Core.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class BookingMap
    {
        public BookingMap(EntityTypeBuilder<Booking> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Price).IsRequired();
            entityBuilder.Property(t => t.Appointment).IsRequired();
            entityBuilder.Property(t => t.Date).IsRequired();
            entityBuilder.Property(t => t.Patient).IsRequired();
            entityBuilder.Property(t => t.PatientId).IsRequired();
            
        }
    }
}
