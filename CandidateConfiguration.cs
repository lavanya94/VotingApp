using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
  public class CandidateConfiguration : IEntityTypeConfiguration<Candidate>
  {
    public void Configure(EntityTypeBuilder<Candidate> builder)
    {
      builder.ToTable("Candidate");

      builder.Property(a => a.Id).IsRequired();
      builder.Property(a => a.Name).IsRequired();
      builder.Property(a => a.NoOfVotes).IsRequired();
    }
  }
}
