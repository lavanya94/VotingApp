using Application.Contracts.Persistence;
using Microsoft.AspNetCore.Mvc;
using Persistence.Repositories;
using Persistence;
using Domain.Entities;

namespace VotingAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CandidatesController : ControllerBase
  {
    private readonly ICandidateRepository _candidateRepository;
    private readonly ILogger<CandidatesController> _logger;
    public CandidatesController(ILogger<CandidatesController> logger)
    {
      _candidateRepository = new CandidateRepository(new VotingDbContext());
      _logger = logger; 
    }

    /// <summary>
    /// Fetch candidate list
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IEnumerable<Candidate> Get()
    {
      try
      {
        var candidates =  _candidateRepository.Get();
        return candidates;
      }
      catch (Exception ex)
      {
        _logger.LogError("Error in getting candidate list " + ex.Message);
        throw;
      }  
    }

    /// <summary>
    /// Add new candidate
    /// </summary>
    /// <param name="candidate"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<Candidate>> Post([FromBody] Candidate candidate)
    {
      Candidate newCandidate = new();
      try
      {
        newCandidate = await _candidateRepository.AddAsync(candidate);
        return Ok(newCandidate);
      }
      catch (Exception ex)
      {
        _logger.LogError("Error in adding new candidate " + ex.Message);
        return newCandidate;
      }
    }
  }
}
