using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.Interfaces;
using AppPersistence.Context;
using AppPersistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppPersistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
  IConfiguration configuration)
        {

            services.AddDbContext<MyDbContext>(options =>
                {
                    options.UseMySQL(configuration.GetConnectionString("myConn"), b => b.MigrationsAssembly("Server"));
                });

            //Auto Mapper
            services.AddAutoMapper(System.AppDomain.CurrentDomain.GetAssemblies());

            //Services
            services.AddScoped<IExtenstions, ExtenstionsRepo>();
            services.AddScoped<IDepartment, DepartmentRepository>();
            services.AddScoped<IPrivilege, PrivilegeRepository>();
            services.AddScoped<IDTMF, DTMFRepository>();
            services.AddScoped<IGlobalSetting, GlobalSettingRepo>();
            services.AddScoped<ICodec, CodecRepository>();
            services.AddScoped<IJitterBuffer, JitterBufferRepository>();
            services.AddScoped<ITrunk, TrunkRepository>();
            services.AddScoped<ISIPSettingInterface, SIPSettingReposiroty>();
            services.AddScoped<IFileInterface, VoicePromptsRepository>();


            return services;
        }


    }
}