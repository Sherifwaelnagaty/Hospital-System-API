using AutoMapper;
using Core.Models;
using Core.Repository;
using Core.Service;
using Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Repository.Data;
using Service;
using Services;
using Services.Helpers;


namespace DependencyInjection
{
    public static class DependencyConfig
    {
        public static IServiceCollection ConfigureDependencies(IServiceCollection Services)
        {
            Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            Services.AddEndpointsApiExplorer();


            Services.AddIdentity<ApplicationUser, IdentityRole>(
                options => options.Password.RequireDigit = true
                ).
                AddEntityFrameworkStores<ApplicationContext>();


            Services.AddTransient<IUnitOfWork, UnitOfWork>();
            Services.AddTransient<IApplicationUserService, ApplicationUserService>();
            Services.AddTransient<IAppointmentTimeServices, AppointmentTimeServices>();
            Services.AddTransient<IAppointmentService, AppointmentService>();
            Services.AddTransient<IPatientsService, PatientService>();
            Services.AddTransient<IDoctorService, DoctorService>();
            Services.AddTransient<IBookingService, BookingService>();
            Services.AddTransient<ICouponService, CouponsService>();
            Services.AddTransient<ISpecializationServices, SpecializationServices>();
            Services.AddTransient<IEmailServices, EmailServices>();

            // inject auto mapper
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingUserDtTOProfile>();
            });
            IMapper _mapper = mapperConfig.CreateMapper();
            Services.AddSingleton(_mapper);

            // patch
            Services.AddControllers().AddNewtonsoftJson();

            return Services;
        }
    }
}
