using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Autofac;
using AutoMapper;
using Autofac.Extensions.DependencyInjection;
using Infrastructure.IoC.MapperConfig;
using Infrastructure.MemoryCache.Redis;
using Infrastructure.Common.RepositoryTool;
using Infrastructure.Repository.RepositoryImplement;
using Infrastructure.MemoryCache.Redis.ConnectionFactory;

namespace Infrastructure.IoC.IoC
{
    public class IoCConfig
    {
        public static AutofacServiceProvider ImplementDI(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddAutoMapper(typeof(AutoMapperConfiguration));
            services.Configure<RedisConfiguration>(redisConfiguration => Configuration.GetSection("RedisCache").Bind(redisConfiguration));
            services.AddSingleton<IRedisConnectionFactory, RedisConnectionFactory>();
            services.AddDbContext<EFContext>(options => options.UseMySql(Configuration.GetConnectionString("DBConnection")));
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterGeneric(typeof(Repository<,>)).As(typeof(IRepository<,>)).InstancePerDependency();

            Assembly servicesRepository = Assembly.Load("Infrastructure.Repository");
            Type[] servicesRepositorytypes = servicesRepository.GetTypes();
            builder.RegisterTypes(servicesRepositorytypes).AsImplementedInterfaces().InstancePerLifetimeScope();

            Assembly servicesCommon = Assembly.Load("Infrastructure.Common");
            Type[] servicesCommontypes = servicesCommon.GetTypes();
            builder.RegisterTypes(servicesCommontypes).AsImplementedInterfaces().InstancePerLifetimeScope();

            Assembly servicesDomain = Assembly.Load("Domain");
            Type[] servicesDomainRepositorytypes = servicesDomain.GetTypes();
            builder.RegisterTypes(servicesDomainRepositorytypes).AsImplementedInterfaces().InstancePerLifetimeScope();

            Assembly servicesApplication = Assembly.Load("Application");
            Type[] servicesApplicationtypes = servicesApplication.GetTypes();
            builder.RegisterTypes(servicesApplicationtypes).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.Populate(services);
            IContainer container = builder.Build();
            return new AutofacServiceProvider(container);
        }
    }
}
