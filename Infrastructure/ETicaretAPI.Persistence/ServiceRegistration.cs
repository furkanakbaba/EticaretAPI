using ETicaretAPI.Application.Abstraction;
using Microsoft.EntityFrameworkCore;
using ETicaretAPI.Persistence.Concretes;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ETicaretAPI.Persistence.Repositories;
using ETicaretAPI.Application.Repositories;

namespace ETicaretAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {


            services.AddSingleton<IProductService, ProductService>();
            services.AddDbContext<ETicaretAPIDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
            services.AddScoped<ICutsomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IProductWriteRpository, ProductWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();

            //IProductService Türünden bir şey istenirse productservice türünden ver diye burda tanımladık.
            //addsingleton tam olarak bu işi yaptı.

        }
    }
}
