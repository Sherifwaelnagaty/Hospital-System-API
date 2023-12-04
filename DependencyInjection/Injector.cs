using Core.Repository;
using Core.Service;
using Repository;
using Service.Service;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.ComponentModel;
using System.Web.Mvc;
using Container = SimpleInjector.Container;

namespace DependencyInjection
{
    public class Injector
    {
        public void Injection() { 

            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            container.Register<IAuthService, AuthService>(Lifestyle.Transient);
            container.Register(typeof(ICouponsRepository), typeof(CouponsRepository), Lifestyle.Scoped);
            container.Register(typeof(IDoctorsRepository), typeof(CouponsRepository), Lifestyle.Scoped);
            container.Register(typeof(IUsersRepository), typeof(CouponsRepository), Lifestyle.Scoped);
            container.Verify();
            DependencyResolver.SetResolver(
                new SimpleInjectorDependencyResolver(container));
        }


    }
}
