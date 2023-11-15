using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using abcde.Data.Services;
using abcde.Model;
using abcde.Model.Identity;
using Microsoft.AspNetCore.Identity;

namespace abcde.Data
{
    public class DataContext : IdentityDbContext<
        ApplicationUser, ApplicationRole, Guid,
        ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin,
        ApplicationRoleClaim, ApplicationUserToken>
    {
        private string _tenant;
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<Audit> Audits { get; set; }

        public DbSet<LoginAudit> LoginAudits { get; set; }

        public DbSet<Tenant> Tenants { get; set; }

        public DbSet<TenantSettings> TenantSettings { get; set; }

        public DbSet<Note> Notes { get; set; }

        public DbSet<Translation> Translations { get; set; }

        public DbSet<WorkItem> WorkItems { get; set; }

        public DbSet<Domain> Domains { get; set; }

        public DbSet<DomainUser> DomainUsers { get; set; }
        public DbSet<WorkItemCategories> WorkItemCategories { get; set; }

        public DbSet<WorkItemProgress> WorkItemProgress { get; set; }

        public static string ConnectionString { get; set; } = string.Empty;

        public DataContext(DbContextOptions<DataContext> opts, ITenantHandlerService service) : base(opts)
        {
            _tenant = service.Tenant;

            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            if (!string.IsNullOrEmpty(ConnectionString) && ConnectionString != Database.GetConnectionString())
            {
                Database.SetConnectionString(ConnectionString);
            }
        }

        public void SetConnectionString(string connectionString)
        {
            ConnectionString = connectionString;
            if (!string.IsNullOrEmpty(connectionString))
            {
                Database.SetConnectionString(connectionString);
            }
        }

        public void SetTenentId(string tenantId)
        {
            _tenant = tenantId;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

#if DEBUG
#else
            modelBuilder.HasDatabaseMaxSize("100 MB");
            modelBuilder.HasServiceTier("Basic");
            modelBuilder.HasPerformanceLevel("Basic");
#endif

            modelBuilder.Entity<Note>()
                        .HasQueryFilter(mt => mt.TenantId == _tenant);
            modelBuilder.Entity<WorkItem>()
                        .HasQueryFilter(mt => mt.TenantId == _tenant);
            modelBuilder.Entity<Domain>().HasMany(p => p.DomainUsers).WithOne(b => b.Domain).HasForeignKey(x => x.DomainID);
            modelBuilder.Entity<Domain>().HasQueryFilter(mt => mt.TenantId == _tenant);
            modelBuilder.Entity<WorkItem>()
                        .HasOne(p => p.Parent)
                        .WithMany(b => b.Children)
                        .HasForeignKey(b => b.ParentId);
            modelBuilder.Entity<WorkItem>()
                        .HasMany(p => p.Notes)
                        .WithOne(b => b.WorkItem);
            modelBuilder.Entity<Note>().HasOne(p => p.WorkItem).WithMany(b => b.Notes);

            modelBuilder.Entity<Domain>()
                       .HasOne(p => p.Parent)
                       .WithMany(b => b.Children)
                       .HasForeignKey(b => b.ParentId);

            modelBuilder.Entity<DomainUser>()
                        .HasKey(du => new { du.DomainID, du.UserID });

            //create foregin key relationship between workitem and workitemprogress
            modelBuilder.Entity<WorkItemProgress>()
                        .HasOne(p => p.WorkItem)
                        .WithMany(b => b.WorkItemProgress)
                        .HasForeignKey(b => b.WorkItemId);

            modelBuilder.Entity<ApplicationUserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });
            modelBuilder.Entity<Tenant>().HasMany(p => p.Users).WithOne(b => b.Tenant).HasForeignKey(x => x.TenantId);
            modelBuilder.Entity<ApplicationUser>().HasOne(p => p.Tenant).WithMany(b => b.Users).HasForeignKey(x => x.TenantId);
        }
    }
}