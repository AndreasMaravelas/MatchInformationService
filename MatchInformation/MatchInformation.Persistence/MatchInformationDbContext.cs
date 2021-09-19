using MatchInformation.Domain.Common;
using MatchInformation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MatchInformation.Persistence
{
    public class MatchInformationDbContext : DbContext
    {
        public MatchInformationDbContext(DbContextOptions<MatchInformationDbContext> options) : base(options)
        {
        }

        public DbSet<MatchEntity> Matches { get; set; }
        public DbSet<MatchOddsEntity> MatchesOdds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MatchInformationDbContext).Assembly);

            modelBuilder.Entity<MatchEntity>(entity =>
            {
                entity.ToTable("Match");

                entity.HasKey(e => e.ID);

                entity.HasMany(e => e.Odds)
                      .WithOne(e => e.Match)
                      .HasForeignKey(e => e.MatchId);
  
            });

            modelBuilder.Entity<MatchOddsEntity>(entity =>
            {
                entity.ToTable("MatchOdds");

                entity.HasKey(e => e.ID);

                entity.HasOne(e => e.Match)
                      .WithMany(e => e.Odds)
                      .HasForeignKey(e => e.MatchId);

            });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.UtcNow;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
