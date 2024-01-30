using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Backend.Models
{
    public class ProjectAppContext : DbContext
    // public class ProjectAppContext : IdentityDbContext<ProjectAppContext>
    // public class ProjectAppContext : IdentityDbContext<User, IdentityRole<int>, int>
    // public class ProjectAppContext : IdentityDbContext<User, IdentityRole, string>
    {
        public ProjectAppContext(DbContextOptions<ProjectAppContext> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseDiscount> CourseDiscounts { get; set; }
        public DbSet<CourseFolders> CourseFolders { get; set; }
        // public DbSet<CourseProgress> CourseProgress { get; set; } // adjusted in StudentCourses
        public DbSet<CourseVideo> CourseVideos { get; set; }
        public DbSet<Interests> Interests { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        // public DbSet<Payment> Payments { get; set; } // adjusted in StudentCourses
        public DbSet<Tags> Tags { get; set; }
        public DbSet<CourseMarketing> CourseMarketing { get; set; }




        public DbSet<User> Users { get; set; }


        public DbSet<Admin> Admin { get; set; }


        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<InstructorPayment> InstructorPayments { get; set; }



        public DbSet<Student> Student { get; set; }
        public DbSet<StudentInterests> StudentInterests { get; set; }
        public DbSet<StudentCourses> StudentCourses { get; set; }
        // public DbSet<StudentCourseVideoLikes> StudentCourseVideoLikes { get; set; }
        public DbSet<StudentPayment> StudentPayment { get; set; }



        public DbSet<VideoComments> VideoComments { get; set; }


        

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseSqlite("Data Source=MySqliteLocalDatabase.db");
            // options.UseSqlServer("server=localhost;database=edusculpt_db;trusted_connection=false;User Id=sa;Password=Contraseña12345678;Persist Security Info=False;Encrypt=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // modelBuilder.Entity<StudentCourses>()
            //     .HasOne(sc => sc.StudentPayment)
            //     .WithOne(sp => sp.StudentCourses)
            //     .HasForeignKey<StudentPayment>(sp => sp.StudentCoursesId);

            // modelBuilder.Entity<VideoComments>()
            //     .HasOne(m => m.CourseVideo)
            //     .WithMany(u => u.VideoComments)
            //     .HasForeignKey(m => m.ID);

            // modelBuilder.Entity<VideoComments>()
            //     .HasOne(m => m.CommentBy)
            //     .WithMany(u => u.VideoComments)
            //     .HasForeignKey(m => m.ID);


            // modelBuilder.Entity<User>().ToTable("AspNetUsers");
            // modelBuilder.Entity<IdentityRole<int>>().ToTable("AspNetRoles");
            // modelBuilder.Entity<IdentityUserRole<int>>().ToTable("AspNetUserRoles");
            // modelBuilder.Entity<IdentityUserClaim<int>>().ToTable("AspNetUserClaims");
            // modelBuilder.Entity<IdentityUserLogin<int>>().ToTable("AspNetUserLogins");
            // modelBuilder.Entity<IdentityRoleClaim<int>>().ToTable("AspNetRoleClaims");
            // modelBuilder.Entity<IdentityUserToken<int>>().ToTable("AspNetUserTokens");


            // modelBuilder.Entity<Student>()
            //     .HasOne(s => s.User)
            //     .WithOne(u => u.Student)
            //     .HasForeignKey<Student>(s => s.UserId); // Assuming you have a UserId property in the Student class


            base.OnModelCreating(modelBuilder);

            // SeedRoles(modelBuilder);
        }

        // private void SeedRoles(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<IdentityRole<int>>().HasData(
        //         new IdentityRole<int> { Id = 1, Name = ProjectEnums.UserType.Admin.ToString(), NormalizedName = "Admin" },
        //         new IdentityRole<int> { Id = 2, Name = ProjectEnums.UserType.Student.ToString(), NormalizedName = "Student" },
        //         new IdentityRole<int> { Id = 3, Name = ProjectEnums.UserType.Instructor.ToString(), NormalizedName = "Instructor" }
        //     );
        // }
    }
}


