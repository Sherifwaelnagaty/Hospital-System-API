﻿using Core;
using Core.Domain;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new UsersMap(modelBuilder.Entity<Users>());
            new DoctorsMap(modelBuilder.Entity<Doctors>());
            new CouponsMap(modelBuilder.Entity<Coupons>());

        }
    }
}