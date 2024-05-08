using Application.Contracts.Persistence;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
  public class VoterRepository : BaseRepository<Voter>, IVoterRepository
  {
    public VoterRepository(VotingDbContext context) : base(context)
    {
    }
  }
}
