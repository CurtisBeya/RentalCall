using Microsoft.EntityFrameworkCore;
using AudioSummarizer.Models;

namespace AudioSummarizer
{
    public class AudioSummarizerDbContext : DbContext
    {
        // Default constructor.
        public AudioSummarizerDbContext()
        {
        }

        // Constructor that accepts DbContext options.
        public AudioSummarizerDbContext(DbContextOptions<AudioSummarizerDbContext> options)
         : base(options)
        {

        }

        // Configures the context to use a specific database connection if not already configured.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ShareTrustDvDb;Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True;Encrypt=false;");
            }
        }

        // Database representations
        public virtual DbSet<CallModel> Calls { get; set; }
        public virtual DbSet<ActionItemModel> ActionItems { get; set; }

        public virtual DbSet<CallCategoryModel> CallCategories { get; set; }


        // Configures entity relationships and seeding data.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configures entity relationships

            modelBuilder.Entity<ActionItemModel>()
                .HasOne(t => t.Call)
                .WithMany()
                .HasForeignKey(t => t.CallId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CallModel>()
               .HasOne(t => t.Category)
               .WithMany()
               .HasForeignKey(t => t.CallCategoryId)
               .IsRequired(true)
               .OnDelete(DeleteBehavior.Restrict);

            // Seeding the data

            modelBuilder.Entity<CallModel>().HasData(
                new CallModel { Id = 1L, CreatedDateTime = new DateTime(2025, 1, 1, 12, 0, 0), AudioFileName = "Audio 1", AudioFilePath = "audio file path test 1", CallCategoryId = 2L, CallCategoryConfidence = 0.7, Summary = "Client wants to make a booking" },
                new CallModel { Id = 2L, CreatedDateTime = new DateTime(2025, 1, 1, 12, 0, 0), AudioFileName = "Audio 2", AudioFilePath = "audio file path test 2", CallCategoryId = 1L, CallCategoryConfidence = 0.6, Summary = "Client wants refund asap" },
                new CallModel { Id = 3L, CreatedDateTime = new DateTime(2025, 1, 1, 12, 0, 0), AudioFileName = "Audio 3", AudioFilePath = "audio file path test 3", CallCategoryId = 12L, CallCategoryConfidence = 0.0, Summary = "Client asking for a donation" }
            );


            modelBuilder.Entity<ActionItemModel>().HasData(
                new ActionItemModel { Id = 1L, CreatedDateTime = new DateTime(2025, 1, 1, 12, 0, 0), Description = "Make a reservation", CallId = 1L, AssignedToDepartment = true, IsCompleted = false },
                new ActionItemModel { Id = 2L, CreatedDateTime = new DateTime(2025, 1, 1, 12, 0, 0), Description = "Send invoice", CallId = 1L, AssignedToDepartment = false, IsCompleted = false },
                new ActionItemModel { Id = 3L, CreatedDateTime = new DateTime(2025, 1, 1, 12, 0, 0), Description = "request bank details", CallId = 2L, AssignedToDepartment = true, IsCompleted = true, CompletedDateTime = new DateTime(2025, 1, 2, 12, 0, 0), UpdatedDateTime = new DateTime(2025, 1, 2, 12, 0, 0) }
            );

            modelBuilder.Entity<CallCategoryModel>().HasData(
                new CallCategoryModel { Id = 1L, CreatedDateTime = new DateTime(2025, 1, 1, 12, 0, 0), Name = "Bookings" },
                new CallCategoryModel { Id = 2L, CreatedDateTime = new DateTime(2025, 1, 1, 12, 0, 0), Name = "Billings" },
                new CallCategoryModel { Id = 3L, CreatedDateTime = new DateTime(2025, 1, 1, 12, 0, 0), Name = "Claims" },
                new CallCategoryModel { Id = 4L, CreatedDateTime = new DateTime(2025, 1, 1, 12, 0, 0), Name = "Maintenance" },
                new CallCategoryModel { Id = 5L, CreatedDateTime = new DateTime(2025, 1, 1, 12, 0, 0), Name = "Other" }
            );
        }
    }
}
