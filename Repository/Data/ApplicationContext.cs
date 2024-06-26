﻿using Core;
using Core.Domain;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
            .HasForeignKey(b => b.CouponId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Bookings_Coupons_CouponId");


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

            modelBuilder.Entity<Specialization>()
             .HasData(new List<Specialization>
                {
                            new Specialization
                            {
                                Id =  1,
                                Name="Psychiatry(Mental, Emotional or Behavioral Disorders)"
                            },
                            new Specialization
                            {
                                Id =  2,
                                Name="Dentistry(Teeth)"
                            },
                            new Specialization
                            {
                                Id =  3,
                                Name="Pediatrics and New Born(Child)"
                            },
                           new Specialization
                            {
                               Id =  4,
                               Name="Orthopedics(Bones)"
                            },
                            new Specialization
                            {
                                Id =  5,
                                Name="Genecology and Infertility"
                            },
                            new Specialization
                            {
                                Id =  6,
                                Name="Ear, Nose and Throat"
                            },
                           new Specialization
                            {
                                Id =  7,
                                Name="Andrology and Male Infertility"
                            },
                            new Specialization
                            {
                                Id =  8,
                                Name="Allergy and Immunology(Sensitivity and Immunity)"
                            },
                            new Specialization
                            {
                                Id =  9,
                                Name="Cardiology and Vascular Disease(Heart)"
                            },
                           new Specialization
                            {
                                Id = 10,
                                Name="Audiology"
                            },
                            new Specialization
                            {
                                Id =  11,
                                Name="Cardiology and Thoracic Surgery(Heart & Chest)"
                            },
                            new Specialization
                            {
                                Id = 12,
                                Name="Chest and Respiratory"
                            },
                            new Specialization
                            {
                                Id =  13,
                                Name="Dietitian and Nutrition"
                            },
                            new Specialization
                            {
                                Id =  14,
                                Name="Diagnostic Radiology(Scan Centers)"
                            },
                            new Specialization
                            {
                                Id =  15,
                                Name="Diabetes and Endocrinology"
                            }
    });

            modelBuilder.Entity<IdentityRole>()
            .HasData(new List<IdentityRole>
            {
                            new IdentityRole { Id = "b2553eda-413b-4e99-a7fc-a3ca40222cc0", Name = "Patient",
                                NormalizedName = "PATIENT" , ConcurrencyStamp = "fdd82728-7e31-4772-b001-5c69e3715f96"},

                            new IdentityRole { Id = "cef07a16-e4a5-453e-bc81-0d195fedd872", Name = "Doctor",
                            NormalizedName = "Doctor", ConcurrencyStamp = "8669de0a-0fb4-47eb-a33c-effd0b40e9b2" },

                            new IdentityRole { Id = "09066f40-d9df-493a-91be-b82e71f8353a", Name = "Admin"
                            , NormalizedName = "ADMIN", ConcurrencyStamp= "603c920e-82a9-4063-b01a-5838bc05e585"}
            });

            modelBuilder.Entity<ApplicationUser>()
            .HasData(new ApplicationUser
            {
                Id = "6c787944-dead-41d2-8860-510044fe2e6f",
                UserName = "1ebffac2-2724-4fb4-a451-b636e0187739",
                NormalizedUserName = "1EBFFAC2-2724-4FB4-A451-B636E0187739",
                FullName = "Admin Admin",
                DateOfBirth = new DateTime(2001, 5, 8),
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                PhoneNumber = "123456",
                Gender = Core.Enums.Gender.Female,
                PasswordHash = "AQAAAAIAAYagAAAAEFZLbjvV3kx9YHhpTY7IvtibpWcT6GI0INUoyl2EXNd131Uevkm9fGsJ96OUnCQHzw==",
                ConcurrencyStamp = "d4c3b47b-6203-46be-ba07-12e98d2c3a76",
                SecurityStamp = "BMLQB2ECOZPWZIBM42KHWK4XOC4WRX7U"
            });

            modelBuilder.Entity<IdentityUserRole<string>>()
            .HasData(new IdentityUserRole<string>
            {
                RoleId = "09066f40-d9df-493a-91be-b82e71f8353a",
                UserId = "6c787944-dead-41d2-8860-510044fe2e6f"
            });
        }
        public DbSet<AppointmentTime> AppointmentTimes { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Doctors> Doctors { get; set; }
        public DbSet<Coupons> Coupons { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
    }
}