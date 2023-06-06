using Sozluk.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sozluk.Api.Application.Interfaces.Repositories;
using Sozluk.Infrastructure.Persistence.Repositories;

namespace Sozluk.Infrastructure.Persistence.Extensions;
public static class Registration
{
    public static IServiceCollection AddInfrastructureRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<SozlukContext>(conf =>
        {
            var connStr = configuration["SozlukDbConnectionString"].ToString();
            conf.UseSqlServer(connStr, opt =>
            {		

                opt.EnableRetryOnFailure();
            });
        });
        //var seedData = new SeedData();
        //seedData.SeedAsync(configuration).GetAwaiter().GetResult();

        services.AddScoped<IUserRepository, UserRepository>();



        return services;
    }
}