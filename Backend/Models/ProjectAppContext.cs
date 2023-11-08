using Microsoft.EntityFrameworkCore;


namespace Backend.Models
{
    public class ProjectAppContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseDiscount> CourseDiscounts { get; set; }
        public DbSet<CourseProgress> CourseProgress { get; set; }
        public DbSet<CourseVideo> CourseVideos { get; set; }
        public DbSet<CourseVideoLikes> CourseVideoLikes { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Interests> Interests { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<StudentCourses> StudentCourses { get; set; }
        public DbSet<Tags> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<VideoComments> VideoComments { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseSqlite("Data Source=LocalDatabase.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<VideoComments>()
                .HasOne(m => m.CourseVideo)
                .WithMany(u => u.VideoComments)
                .HasForeignKey(m => m.ID);

            modelBuilder.Entity<VideoComments>()
                .HasOne(m => m.CommentBy)
                .WithMany(u => u.VideoComments)
                .HasForeignKey(m => m.ID);
        }
    }
}


