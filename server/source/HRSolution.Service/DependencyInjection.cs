﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HRSolution.Service
{
    public static class DependencyInjection
    {
        public static void AddMediatorCQRS(this IServiceCollection services)
        {
            // or you can use assembly in Extension method in Infra layer with below command
            // var assembly = AppDomain.CurrentDomain.Lrentalportald("RentalPortal.Service");
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}