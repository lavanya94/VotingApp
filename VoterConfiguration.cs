using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
  public class VoterConfiguration : IEntityTypeConfiguration<Voter>
  {
    public void Configure(EntityTypeBuilder<Voter> builder)
    {
      builder.ToTable("Voter");

      builder.Property(a => a.Id).IsRequired();
      builder.Property(a => a.Name).IsRequired();
      builder.Property(a => a.IsVoted).IsRequired();
    }
  }
}
