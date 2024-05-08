﻿using Application.Contracts.Persistence;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
  public class CandidateRepository : BaseRepository<Candidate>, ICandidateRepository
  {
    public CandidateRepository(VotingDbContext context) : base(context)
    {
    }
  }
}
