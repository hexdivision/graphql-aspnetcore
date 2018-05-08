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

        public virtual DbSet<Organization> Organizations { get; set; }

        public virtual DbSet<Domain> Domains { get; set; }

        public virtual DbSet<Pathway> Pathways { get; set; }

        public virtual DbSet<Question> Questions { get; set; }

        public virtual DbSet<Answer> Answers { get; set; }

        public virtual DbSet<Ending> Endings { get; set; }

        public virtual DbSet<InlineResource> InlineResources { get; set; }

        public virtual DbSet<UserReport> UserReports { get; set; }

        public virtual DbSet<ReportItem> ReportItems { get; set; }

        #endregion

        #region Fluent API

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            AddTimestamps();
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ApplyDomainRelations(modelBuilder);
            ApplyPathwayRelations(modelBuilder);
            ApplyQuestionRelations(modelBuilder);
            ApplyAnswerRelations(modelBuilder);
            ApplyInlineResourceRelations(modelBuilder);
            ApplyEndingRelations(modelBuilder);
            ApplyUserReportRelations(modelBuilder);
            ApplyReportItemRelations(modelBuilder);

            ApplyIsDeletedFilter(modelBuilder);
            AddDefaultValues(modelBuilder);
            ApplyColumnsCustomTypes(modelBuilder);
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
            modelBuilder.Entity<UserExploration>().HasQueryFilter(r => r.IsDeleted == false);
        }

        private void ApplyColumnsCustomTypes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organization>().Property(r => r.PerVisitFee).HasColumnType("decimal(8,2)");
            modelBuilder.Entity<Organization>().Property(r => r.PerComplationFee).HasColumnType("decimal(8,2)");
            modelBuilder.Entity<Organization>().Property(r => r.PerServiceAccessFee).HasColumnType("decimal(8,2)");
            modelBuilder.Entity<Organization>().Property(r => r.FlatMonthlyFee).HasColumnType("decimal(8,2)");
        }

        private void ApplyDomainRelations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain>()
                .HasOne(d => d.Organization)
                .WithMany(d => d.Domains)
                .HasForeignKey(ds => ds.OrganizationId)
                .HasPrincipalKey(d => d.OrganizationId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void ApplyPathwayRelations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pathway>()
                .HasOne(d => d.Domain)
                .WithMany(d => d.Pathways)
                .HasForeignKey(ds => ds.DomainId)
                .HasPrincipalKey(d => d.DomainId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void ApplyQuestionRelations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>()
                .HasOne(d => d.Domain)
                .WithMany(d => d.Questions)
                .HasForeignKey(ds => ds.DomainId)
                .HasPrincipalKey(d => d.DomainId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Question>()
                .HasOne(d => d.Pathway)
                .WithMany(d => d.Questions)
                .HasForeignKey(ds => ds.PathwayId)
                .HasPrincipalKey(d => d.PathwayId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void ApplyAnswerRelations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>()
                .HasOne(d => d.Question)
                .WithMany(d => d.Answers)
                .HasForeignKey(ds => ds.QuestionId)
                .HasPrincipalKey(d => d.QuestionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Answer>()
                .HasOne(d => d.Pathway)
                .WithMany(d => d.Answers)
                .HasForeignKey(ds => ds.PathwayToCreate)
                .HasPrincipalKey(d => d.PathwayId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void ApplyInlineResourceRelations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InlineResource>()
                .HasOne(d => d.Domain)
                .WithMany(d => d.InlineResources)
                .HasForeignKey(ds => ds.DomainId)
                .HasPrincipalKey(d => d.DomainId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<InlineResource>()
                .HasOne(d => d.Pathway)
                .WithMany(d => d.InlineResources)
                .HasForeignKey(ds => ds.PathwayId)
                .HasPrincipalKey(d => d.PathwayId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void ApplyEndingRelations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ending>()
                .HasOne(d => d.Domain)
                .WithMany(d => d.Endings)
                .HasForeignKey(ds => ds.DomainId)
                .HasPrincipalKey(d => d.DomainId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ending>()
                .HasOne(d => d.Pathway)
                .WithMany(d => d.Endings)
                .HasForeignKey(ds => ds.PathwayId)
                .HasPrincipalKey(d => d.PathwayId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void ApplyUserReportRelations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserReport>()
                .HasOne(d => d.UserExploration)
                .WithMany(d => d.UserReports)
                .HasForeignKey(ds => ds.UserExplorationId)
                .HasPrincipalKey(d => d.UserExplorationId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void ApplyReportItemRelations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReportItem>()
                .HasOne(d => d.UserReport)
                .WithMany(d => d.ReportItems)
                .HasForeignKey(ds => ds.UserReportId)
                .HasPrincipalKey(d => d.UserReportId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ReportItem>()
                .HasOne(d => d.Ending)
                .WithMany(d => d.ReportItems)
                .HasForeignKey(ds => ds.EndingId)
                .HasPrincipalKey(d => d.EndingId)
                .OnDelete(DeleteBehavior.Restrict);
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
                        ((BaseEntity)entity.Entity).CreatedBy = userId;
                    }

                    ((BaseEntity)entity.Entity).ModifiedDate = DateTime.UtcNow.GetUtcDateTime();
                    ((BaseEntity)entity.Entity).ModifiedBy = userId;
                }
            }
        }
        #endregion
    }
}
