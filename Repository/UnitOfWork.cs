using Core.Domain;
using Core.Models;
using Core.Repository;
using Core.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IDoctorsRepository Doctors { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }
        public ICouponsRepository DiscountCodeCoupons { get; private set; }
        public IAppointmentRepository Appointments { get; private set; }
        public IAppointmentTimeRepository AppointmentTimes { get; private set; }
        public IBookingRepository Bookings { get; private set; }
        public ISpecializationRepository Specializations { get; private set; }
        public IPatientsRepository Patients { get; private set; }


        public UnitOfWork(ApplicationContext context, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager) {
            
            #region initializations
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            #endregion

            #region DI
            Doctors = new DoctorsRepository(_context, userManager);
            ApplicationUser = new ApplicationUserRepository(_context, _userManager,
                _roleManager, _signInManager);

            DiscountCodeCoupons = new CouponsRepository(_context);
            Appointments = new AppointmentRepository(_context);
            Bookings = new BookingRepository(_context);
            Specializations = new SpecializationRepository(_context);
            AppointmentTimes = new AppointmentTimeRepository(_context);  
            Patients = new PatientsRepository(_context,_userManager, _roleManager, _signInManager);
            #endregion
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
