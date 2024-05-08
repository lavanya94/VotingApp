using Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Voter.Commands.CastVote
{
  public class CastVoteCommandResponse :BaseResponse
  {
    public string VoterName { get; set; }
    public string VoterStatus { get; set; }

    public string CandidateName { get; set; }
    public int NoOfVotes { get; set; }
  }
}
