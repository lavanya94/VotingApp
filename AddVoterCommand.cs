using Application.Features.Voter.Queries.GetVoters;
using MediatR;

namespace Application.Features.Voter.Commands.AddNewVoter
{
  public class AddVoterCommand : IRequest<AddVoterCommandResponse>
  {
    public Domain.Entities.Voter NewVoter { get; set; }  
  }
}
