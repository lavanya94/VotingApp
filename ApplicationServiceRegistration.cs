﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
  public static class ApplicationServiceRegistration
  {
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
      services.AddMediatR(Assembly.GetExecutingAssembly());
      return services;
    }
  }
}