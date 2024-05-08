﻿using Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
  public static class PersistenceServiceRegistration
  {
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
      services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
      services.AddScoped<IVoterRepository, VoterRepository>();
      services.AddScoped<ICandidateRepository, CandidateRepository>();
      return services;
    }
  }
}
