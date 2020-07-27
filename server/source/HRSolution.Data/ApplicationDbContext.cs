using HRSolution.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HRSolution.Data
{
    public interface IApplicationDbContext
    {
        public DbSet<Race> Races { get; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Language> Languages { get; }
        public DbSet<Province> Provinces { get; }
        public DbSet<Citizenship> Citizenships { get; }
        public DbSet<DisabledType> DisabledTypes { get; set; }
        public DbSet<ContactDetails> ContactDetails { get; set; }
        public DbSet<EmployeeDetails> EmployeeDetails { get; set; }
        public DbSet<EmergencyContactDetails> EmergencyContactDetails { get; set; }
        Task<int> SaveChangesAsync();
    }
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Status> Statuses { get; set; }
        public DbSet<Race> Races { get; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Language> Languages { get; }
        public DbSet<Province> Provinces { get; }
        public DbSet<Citizenship> Citizenships { get; }
        public DbSet<DisabledType> DisabledTypes { get; set; }
        public DbSet<ContactDetails> ContactDetails { get; set; }
        public DbSet<EmployeeDetails> EmployeeDetails { get; set; }
        public DbSet<EmergencyContactDetails> EmergencyContactDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                .UseSqlServer("DataSource=app.db");
            }

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Person>()
                .ToTable("People");

            builder.Entity<Status>()
                .ToTable("Statuses");

            builder.Entity<Race>()
                .ToTable("Races");

            builder.Entity<Attachment>()
                .ToTable("Attachments");

            builder.Entity<Leave>()
                .ToTable("Leaves");

            builder.Entity<Address>()
                .ToTable("Addresses");

            builder.Entity<Language>()
                .ToTable("Languages");

            builder.Entity<Province>()
                .ToTable("Provinces");

            builder.Entity<Citizenship>()
                .ToTable("Citizenships");

            builder.Entity<DisabledType>()
                .ToTable("DisabledTypes");

            builder.Entity<ContactDetails>()
                .ToTable("ContactDetails");

            builder.Entity<EmployeeDetails>()
                .ToTable("EmployeeDetails");

            builder.Entity<EmergencyContactDetails>()
                .ToTable("EmergencyContactDetails");
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
