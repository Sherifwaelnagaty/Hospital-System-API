using Core;
using Core.Domain;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new DoctorsMap(modelBuilder.Entity<Doctors>());
            new CouponsMap(modelBuilder.Entity<Coupons>());
            new AppointmentMap(modelBuilder.Entity<Appointment>());
            new BookingMap(modelBuilder.Entity<Booking>());
            modelBuilder.Entity<Doctors>()
            .Property(d => d.Image)
            .HasConversion(new ValueConverter<IFormFile, string>(
                v => v.FileName,
                v => null
            ));
            modelBuilder.Entity<Patients>()
            .Property(p => p.Image)
            .HasConversion(new ValueConverter<IFormFile, string>(
            v => v.FileName,
            v => null));
            modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Patient)
            .WithMany(p => p.Appointments)
            .HasForeignKey(a => a.PatientId)
            .IsRequired();
            modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Doctor)
            .WithMany(d => d.Appointments)
            .HasForeignKey(a => a.DoctorId)
            .IsRequired();
            base.OnModelCreating(modelBuilder);
        }
    }
}
