using Application.Contracts.Persistence;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Voter.Commands.CastVote
{
  public class CastVoteCommandHandler : IRequestHandler<CastVoteCommand, CastVoteCommandResponse>
  {
    private readonly IVoterRepository _voterRepository;
    private readonly ICandidateRepository _candidateRepository;
    private readonly ILogger<CastVoteCommandHandler> _logger;

    public CastVoteCommandHandler(IVoterRepository voterRepository, ICandidateRepository candidateRepository, ILogger<CastVoteCommandHandler> logger)
    {
      _voterRepository = voterRepository;
      _candidateRepository = candidateRepository;
      _logger = logger;
    }
    public async Task<CastVoteCommandResponse> Handle(CastVoteCommand request, CancellationToken cancellationToken)
    {
      CastVoteCommandResponse response = new();
      try
      {
        //update Voter
        Domain.Entities.Voter voter = await _voterRepository.GetByIdAsync(request.VoterId);
        voter.IsVoted = true;
        await _voterRepository.UpdateAsync(voter);

        //update Candidate
        Candidate candidate = await _candidateRepository.GetByIdAsync(request.CandidateId);
        candidate.NoOfVotes = candidate.NoOfVotes + 1;
        await _candidateRepository.UpdateAsync(candidate);

        //Get Response
        var voter1 = await _voterRepository.GetByIdAsync(request.VoterId);
        var candidate1 = await _candidateRepository.GetByIdAsync(request.CandidateId);
        response.NoOfVotes = candidate1.NoOfVotes;
        response.CandidateName = candidate1.Name;
        response.VoterName = voter1.Name;
        response.VoterStatus = voter1.IsVoted? "v": "x";
        return response;
      }
      catch (Exception ex)
      { 
        _logger.LogError("Error while casting vote: " + ex.Message);
        throw;
      }
    }
  }
}
