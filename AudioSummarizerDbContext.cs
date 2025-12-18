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
        public virtual DbSet<AudioModel> Audios { get; set; }
        public virtual DbSet<ActionItemModel> ActionItems { get; set; }


        // Configures entity relationships and seeding data.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configures entity relationships

            modelBuilder.Entity<ActionItemModel>()
                .HasOne(t => t.Audio)
                .WithMany()
                .HasForeignKey(t => t.AudioId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

            // Seeding the data

            modelBuilder.Entity<AudioModel>().HasData(
                new AudioModel { Id = 1, CreatedDateTime = new DateTime(2025, 1, 1, 12, 0, 0), Name = "Audio 1", AudioFilePath = "audio file path test 1", Topic = "Booking", Summary = "Client wants to make a booking" },
                new AudioModel { Id = 2, CreatedDateTime = new DateTime(2025, 1, 1, 12, 0, 0), Name = "Audio 2", AudioFilePath = "audio file path test 2", Topic = "Refund", Summary = "Client wants refund asap" }
            );


            modelBuilder.Entity<ActionItemModel>().HasData(
                new ActionItemModel { Id = 1, CreatedDateTime = new DateTime(2025, 1, 1, 12, 0, 0), Description = "Make a reservation", AudioId = 1, AssignedTo = "Reservation department", IsCompleted = false },
                new ActionItemModel { Id = 2, CreatedDateTime = new DateTime(2025, 1, 1, 12, 0, 0), Description = "Send invoice", AudioId = 1, AssignedTo = null, IsCompleted = false },
                new ActionItemModel { Id = 3, CreatedDateTime = new DateTime(2025, 1, 1, 12, 0, 0), Description = "request bank details", AudioId = 2, AssignedTo = "Billings department", IsCompleted = true }
            ); 
        }
    }
}
