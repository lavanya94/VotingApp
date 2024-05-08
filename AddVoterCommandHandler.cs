using Application.Contracts.Persistence;
using Application.Features.Voter.Commands.CastVote;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Voter.Commands.AddNewVoter
{
  public class AddVoterCommandHandler : IRequestHandler<AddVoterCommand, AddVoterCommandResponse>
  {
    private readonly IVoterRepository _voterRepository;
    private readonly ILogger<AddVoterCommandHandler> _logger;

    public AddVoterCommandHandler(IVoterRepository voterRepository, ILogger<AddVoterCommandHandler> logger)
    {
      _voterRepository = voterRepository;
      _logger = logger;
    }

    public async Task<AddVoterCommandResponse> Handle(AddVoterCommand request, CancellationToken cancellationToken)
    {
      AddVoterCommandResponse response = new();
      try
      {
        var newVoter = await _voterRepository.AddAsync(request.NewVoter);
        response.Name = newVoter.Name;
        response.HasVoted = "x";       
        return response;
      }
      catch (Exception ex)
      {
        _logger.LogError("Error while adding vnew voter: " + ex.Message);
        throw;
      }
    }
  }
}
