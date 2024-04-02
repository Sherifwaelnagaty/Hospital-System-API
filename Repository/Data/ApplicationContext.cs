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
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Doctors>()
            .Property(d => d.Price)
            .HasColumnType("decimal(18,2)")
            .HasDefaultValue((decimal)0.0);

            modelBuilder.Entity<Specialization>()
            .HasIndex(p => p.Name)
            .IsUnique();

            modelBuilder.Entity<ApplicationUser>()
            .HasIndex(u => u.Email)
            .IsUnique();

            modelBuilder.Entity<Coupons>()
            .HasIndex(c => c.Code)
            .IsUnique();

            modelBuilder.Entity<Booking>()
            .HasOne<AppointmentTime>()
            .WithMany()
            .HasForeignKey(p => p.AppointmentTimeId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Bookings_AppointmentTimes_AppointmentTimeId");

            modelBuilder.Entity<Booking>()
            .HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(p => p.PatientId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Bookings_AspNetUsers_PatientId");


            modelBuilder.Entity<Booking>()
            .HasOne<Coupons>()
            .WithMany()
            .HasForeignKey(b => b.DiscountCodeCouponId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Bookings_DiscountCodeCoupons_DiscountCodeCouponId");


            modelBuilder.Entity<Booking>()
           .HasOne<Doctors>()
           .WithMany()
           .HasForeignKey(b => b.DoctorId)
           .OnDelete(DeleteBehavior.Restrict)
           .HasConstraintName("FK_Bookings_Doctors_DoctorId");

            modelBuilder.Entity<Appointment>()
            .HasOne<Doctors>()
            .WithMany()
            .HasForeignKey(a => a.DoctorId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_Appointments_Doctors_DoctorId");

            modelBuilder.Entity<AppointmentTime>()
            .HasOne<Appointment>()
            .WithMany()
            .HasForeignKey(a => a.AppointmentId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}