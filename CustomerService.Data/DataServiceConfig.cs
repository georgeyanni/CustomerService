using CustomerService.Data.Repositories;
using CustomerService.Data.Services;
using CustomerService.Domain.Interfaces;
using CustomerService.Domain.Interfaces.Common;
using CustomerService.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Data
{
    public static class DataServiceConfig
    {
        public static void Load(this IServiceCollection services)
        {


            services.AddDbContext<DataContext>(
                  options => options.UseSqlServer("Server =.; Database = CustomerService; Trusted_Connection = True")
                  .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
                

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddHttpContextAccessor();

            services.AddSingleton<IUriService>(o =>
            {
                var accessor = o.GetRequiredService<IHttpContextAccessor>();
                var request = accessor.HttpContext.Request;
                var uri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriService(uri);
            });


            services.AddAutoMapper(typeof(CustomerService.Data.DtoMappings.MappingProfile));
        }
    }
}
