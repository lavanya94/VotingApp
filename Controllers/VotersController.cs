using Application.Features.Voter.Commands.AddNewVoter;
using Application.Features.Voter.Commands.CastVote;
using Application.Features.Voter.Queries.GetVoters;
using Domain.Entities;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VotingAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class VotersController : ControllerBase
  {
    private readonly ILogger<VotersController> _logger;
    private readonly IMediator _mediator;

    public VotersController(ILogger<VotersController> logger,
                            IMediator mediator)
    {
      _logger = logger;
      _mediator = mediator; 
    }

    /// <summary>
    /// Return list of voters
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<List<VotersVm>>> Get()
    {
      try
      {
        _logger.LogInformation("Fetching list of voters");
        GetVoterQuery getVoterQuery = new();
        List<VotersVm> voters = await _mediator.Send(getVoterQuery);
        return Ok(voters);
      }
      catch (Exception ex) 
      {
        _logger.LogError("Error in fetching list of voters" + ex.Message);
        throw;
      }
    }

    /// <summary>
    /// Add new voter
    /// </summary>
    /// <param name="voter"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<AddVoterCommandResponse>> Post([FromBody] Voter voter)
    {
      try
      {
        _logger.LogInformation("Adding new voter in voters list");
        AddVoterCommand addVoterCommand = new();
        addVoterCommand.NewVoter = voter;
        AddVoterCommandResponse newVoterVm = await _mediator.Send(addVoterCommand);
        return Ok(newVoterVm);
      }
     catch(Exception ex) 
     {
        _logger.LogError("Error in adding new voter" + ex.Message);
        throw;
      }
    }

    /// <summary>
    /// Voter casting vote
    /// </summary>
    /// <param name="castVote"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("CastVote")]
    public async Task<ActionResult<CastVoteCommandResponse>> CastVote([FromBody] CastVote castVote)
    {
      try
      {
        _logger.LogInformation("Voter casting vote for a candidate");
        CastVoteCommand castVoteCommand = new()
        {
          VoterId = castVote.VoterId,
          CandidateId = castVote.CandidateId
        };
        CastVoteCommandResponse response = await _mediator.Send(castVoteCommand);
        return Ok(response);
      }
      catch(Exception ex) 
      {
        _logger.LogError("Error in casting vote" + ex.Message);
        throw;
      }

    }
  }
}
