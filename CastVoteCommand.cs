using MediatR;

namespace Application.Features.Voter.Commands.CastVote
{
  public class CastVoteCommand: IRequest<CastVoteCommandResponse>
  {
    /// <summary>
    /// Voter Id of the voter
    /// </summary>
    public int VoterId { get; set; }  
    /// <summary>
    /// Candidate Id of the candidate
    /// </summary>
    public int CandidateId { get; set; }  
  }
}
