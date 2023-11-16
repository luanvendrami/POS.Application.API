﻿using Data.Infra.Context;
using Data.Infra.Repository;
using Domain.Dto.Request;
using Domain.Interface.Repository;
using Domain.Interface.Service;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Service;

namespace IoC.infra
{
    public static class DependencyInjections
    {
        public static void Injections(this IServiceCollection services)
        {
            services.Context();
            services.Repository();
            services.Service();
        }

        private static void Context(this IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseInMemoryDatabase(databaseName: "YourInMemoryDatabase");
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking); // optional, for read-only scenarios
            });
        }

        private static void Repository(this IServiceCollection services)
        {
            services.AddTransient<IRabbitMQRepository, RabbitMQRepository>();
            services.AddTransient<IDrinkOrderRepository, DrinkOrderRepository>();
            services.AddTransient<IFriesOrderRepository, FriesOrderRepository>();
            services.AddTransient<IGrillOrderRepository, GrillOrderRepository>();
            services.AddTransient<ISaladOrderRepository, SaladOrderRepository>();
        }

        private static void Service(this IServiceCollection services)
        {
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IDrinkOrderService, DrinkOrderService>();
            services.AddTransient<IFriesOrderService, FriesOrderService>();
            services.AddTransient<IGrillOrderService, GrillOrderService>();
            services.AddTransient<ISaladOrderService, SaladOrderService>();
        }
    }
}
