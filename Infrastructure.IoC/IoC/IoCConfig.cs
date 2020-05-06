using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Autofac;
using AutoMapper;
using Autofac.Extensions.DependencyInjection;
using Domain.Common;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using Infrastructure.Config.MapperConfig;
using Infrastructure.MemoryCache.Redis;
using Infrastructure.Common.RepositoryTool;
using Infrastructure.EventBus.EventBus.Subscript;
using Infrastructure.EventBus.EventBusRabbitMQ;
using Infrastructure.EventBus.EventBus.Abstractions;
using Infrastructure.Repository.RepositoryImplement;
using Application.BlogApplication.Event;

namespace Infrastructure.Config.IoC
{
    public class IoCConfig
    {
        public static AutofacServiceProvider ImplementDI(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddAutoMapper(typeof(AutoMapperConfiguration));
            services.Configure<RedisConfiguration>(redisConfiguration => Configuration.GetSection("RedisCache").Bind(redisConfiguration));
            services.AddSingleton<IRedisConnectionFactory, RedisConnectionFactory>();
            services.AddDbContext<EFContext>(options => options.UseMySql(Configuration.GetConnectionString("DBConnection")));
            ConfigRabbitMQPersistentConnection(services, Configuration);
            RegisterEventBus(services, Configuration);
            RegisterEventHandler(services);
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterGeneric(typeof(Repository<,>)).As(typeof(IRepository<,>));

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

        public static void ConfigRabbitMQPersistentConnection(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddSingleton<IRabbitMQPersistentConnection>(sp =>
            {
                var logger = sp.GetRequiredService<ILogger<DefaultRabbitMQPersistentConnection>>();

                var factory = new ConnectionFactory()
                {
                    HostName = Configuration["EventBusConnection"],
                    DispatchConsumersAsync = true
                };

                if (!string.IsNullOrEmpty(Configuration["EventBusUserName"]))
                {
                    factory.UserName = Configuration["EventBusUserName"];
                }

                if (!string.IsNullOrEmpty(Configuration["EventBusPassword"]))
                {
                    factory.Password = Configuration["EventBusPassword"];
                }

                var retryCount = 5;
                if (!string.IsNullOrEmpty(Configuration["EventBusRetryCount"]))
                {
                    retryCount = int.Parse(Configuration["EventBusRetryCount"]);
                }

                return new DefaultRabbitMQPersistentConnection(factory, logger, retryCount);
            });
        }

        public static void RegisterEventBus(IServiceCollection services, IConfiguration Configuration)
        {
            var subscriptionClientName = Configuration["SubscriptionClientName"];
            services.AddSingleton<IEventBus, EventBusRabbitMQ>(sp =>
            {
                var rabbitMQPersistentConnection = sp.GetRequiredService<IRabbitMQPersistentConnection>();
                var iLifetimeScope = sp.GetRequiredService<ILifetimeScope>();
                var logger = sp.GetRequiredService<ILogger<EventBusRabbitMQ>>();
                var eventBusSubcriptionsManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();

                var retryCount = 5;
                if (!string.IsNullOrEmpty(Configuration["EventBusRetryCount"]))
                {
                    retryCount = int.Parse(Configuration["EventBusRetryCount"]);
                }

                return new EventBusRabbitMQ(rabbitMQPersistentConnection, logger, iLifetimeScope, eventBusSubcriptionsManager, subscriptionClientName, retryCount);
            });
            services.AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();
        }

        public static void RegisterEventHandler(IServiceCollection services)
        {
            services.AddTransient<BlogIntegrationEventHandler>();
        }
    }
}
