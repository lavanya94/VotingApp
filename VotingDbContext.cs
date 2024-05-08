using Microsoft.EntityFrameworkCore;

namespace Persistence
{
  public class VotingDbContext : DbContext
  {
    public VotingDbContext()
    {
    }
    public VotingDbContext(DbContextOptions<VotingDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfigurationsFromAssembly(typeof(VotingDbContext).Assembly);

      base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Voting;Integrated Security=True");
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
      return base.SaveChangesAsync(cancellationToken);
    }

  }
}
