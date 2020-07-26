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
        public DbSet<Person> People { get; set; } //TODO: config on model startup setup for db not to rename this 
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Language> Languages { get;  }
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

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
