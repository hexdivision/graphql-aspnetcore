using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PathWays.Common.Utilities;
using PathWays.Data.Model.Base;
using PathWays.UserResolverService;

namespace PathWays.Data.Model
{
    public class PathWaysContext : DbContext
    {
        private IUserResolver _userResolver;

        #region Constructor

        public PathWaysContext(DbContextOptions<PathWaysContext> options, IUserResolver userResolver)
            : base(options)
        {
            _userResolver = userResolver;
        }

        #endregion

        #region DBSets

        public virtual DbSet<SystemUserRole> SystemUserRoles { get; set; }

        public virtual DbSet<SystemUser> SystemUsers { get; set; }

        public virtual DbSet<UserToken> UserTokens { get; set; }

        public virtual DbSet<SystemSettings> SystemSettings { get; set; }

        public virtual DbSet<UserExploration> UserExplorations { get; set; }

        public virtual DbSet<UserExplorationToken> UserExplorationTokens { get; set; }

        public virtual DbSet<AccessCodeExcludeWord> AccessCodeExcludeWords { get; set; }

        #endregion

        #region Fluent API

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            AddTimestamps();
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ApplyIsDeletedFilter(modelBuilder);
            AddDefaultValues(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging(true);
        }

        #endregion

        #region Private member methods

        private void AddDefaultValues(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SystemUserRole>().Property(r => r.SessionDuration).HasDefaultValue(900);

            ////modelBuilder.Entity<UserExploration>().Property(r => r.ExplorationStatus).HasDefaultValue(0);
            ////modelBuilder.Entity<UserExploration>().Property(r => r.IsDeleted).HasDefaultValue(0);
        }

        private void ApplyIsDeletedFilter(ModelBuilder modelBuilder)
        {
        }

        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
            if (entities != null)
            {
                var userId = _userResolver.GetUserId();

                foreach (var entity in entities)
                {
                    if (entity.State == EntityState.Added)
                    {
                        ((BaseEntity)entity.Entity).CreatedDate = DateTime.UtcNow.GetUtcDateTime();
                    }

                    ((BaseEntity)entity.Entity).ModifiedDate = DateTime.UtcNow.GetUtcDateTime();
                }
            }
        }

        #endregion
    }
}
