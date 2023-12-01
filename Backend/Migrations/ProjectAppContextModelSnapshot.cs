﻿// <auto-generated />
using System;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backend.Migrations
{
    [DbContext(typeof(ProjectAppContext))]
    partial class ProjectAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("Backend.Models.Course", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("InstructorID")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("InstructorID");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Backend.Models.CourseDiscount", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("CourseID")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Discount")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("CourseID");

                    b.ToTable("CourseDiscounts");
                });

            modelBuilder.Entity("Backend.Models.CourseProgress", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CourseID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastProgressDate")
                        .HasColumnType("TEXT");

                    b.Property<double>("Progress")
                        .HasColumnType("REAL");

                    b.Property<int>("StudentCoursesID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UserID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("CourseID");

                    b.HasIndex("StudentCoursesID");

                    b.HasIndex("UserID");

                    b.ToTable("CourseProgress");
                });

            modelBuilder.Entity("Backend.Models.CourseVideo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CourseID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ThumbnailURL")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("VideoURL")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("CourseID");

                    b.ToTable("CourseVideos");
                });

            modelBuilder.Entity("Backend.Models.CourseVideoLikes", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CourseVideoID")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Disliked")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Liked")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("CourseVideoID");

                    b.HasIndex("UserID");

                    b.ToTable("CourseVideoLikes");
                });

            modelBuilder.Entity("Backend.Models.Instructor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("About")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AccountDetails")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AccountNo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("EarnedAmount")
                        .HasColumnType("REAL");

                    b.Property<int>("UserID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("Backend.Models.Interests", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Interests");
                });

            modelBuilder.Entity("Backend.Models.Notification", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CourseVideoID")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsRead")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VideoCommentID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("CourseVideoID");

                    b.HasIndex("UserID");

                    b.HasIndex("VideoCommentID");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Backend.Models.Payment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Amount")
                        .HasColumnType("REAL");

                    b.Property<int>("CourseID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("StudentID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("CourseID");

                    b.HasIndex("StudentID");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Backend.Models.StudentCourses", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CourseID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateJoined")
                        .HasColumnType("TEXT");

                    b.Property<int>("Rating")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Review")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("StudentID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("CourseID");

                    b.HasIndex("StudentID");

                    b.ToTable("StudentCourses");
                });

            modelBuilder.Entity("Backend.Models.Tags", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Tag")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Backend.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("About")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ProfileURL")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Backend.Models.VideoComments", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CommentDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("ReplyToID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("ReplyToID");

                    b.ToTable("VideoComments");
                });

            modelBuilder.Entity("CourseTags", b =>
                {
                    b.Property<int>("CoursesID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TagsID")
                        .HasColumnType("INTEGER");

                    b.HasKey("CoursesID", "TagsID");

                    b.HasIndex("TagsID");

                    b.ToTable("CourseTags");
                });

            modelBuilder.Entity("InterestsUser", b =>
                {
                    b.Property<int>("InterestsID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsersID")
                        .HasColumnType("INTEGER");

                    b.HasKey("InterestsID", "UsersID");

                    b.HasIndex("UsersID");

                    b.ToTable("InterestsUser");
                });

            modelBuilder.Entity("Backend.Models.Course", b =>
                {
                    b.HasOne("Backend.Models.Instructor", "Instructor")
                        .WithMany()
                        .HasForeignKey("InstructorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("Backend.Models.CourseDiscount", b =>
                {
                    b.HasOne("Backend.Models.Course", "Course")
                        .WithMany("CourseDiscounts")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Backend.Models.CourseProgress", b =>
                {
                    b.HasOne("Backend.Models.Course", "Course")
                        .WithMany("CourseProgress")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.StudentCourses", "StudentCourses")
                        .WithMany()
                        .HasForeignKey("StudentCoursesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.User", null)
                        .WithMany("CourseProgress")
                        .HasForeignKey("UserID");

                    b.Navigation("Course");

                    b.Navigation("StudentCourses");
                });

            modelBuilder.Entity("Backend.Models.CourseVideo", b =>
                {
                    b.HasOne("Backend.Models.Course", "Course")
                        .WithMany("CourseVideos")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Backend.Models.CourseVideoLikes", b =>
                {
                    b.HasOne("Backend.Models.CourseVideo", "CourseVideo")
                        .WithMany("CourseVideoLikes")
                        .HasForeignKey("CourseVideoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.User", "User")
                        .WithMany("CourseVideoLikes")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseVideo");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Backend.Models.Instructor", b =>
                {
                    b.HasOne("Backend.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Backend.Models.Notification", b =>
                {
                    b.HasOne("Backend.Models.CourseVideo", "CourseVideo")
                        .WithMany("Notifications")
                        .HasForeignKey("CourseVideoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.User", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.VideoComments", "VideoComment")
                        .WithMany("Notifications")
                        .HasForeignKey("VideoCommentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseVideo");

                    b.Navigation("User");

                    b.Navigation("VideoComment");
                });

            modelBuilder.Entity("Backend.Models.Payment", b =>
                {
                    b.HasOne("Backend.Models.Course", "Course")
                        .WithMany("Payments")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.User", "Student")
                        .WithMany("Payments")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Backend.Models.StudentCourses", b =>
                {
                    b.HasOne("Backend.Models.Course", "Course")
                        .WithMany("StudentCourses")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.User", "Student")
                        .WithMany("StudentCourse")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Backend.Models.VideoComments", b =>
                {
                    b.HasOne("Backend.Models.CourseVideo", "CourseVideo")
                        .WithMany("VideoComments")
                        .HasForeignKey("ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.User", "CommentBy")
                        .WithMany("VideoComments")
                        .HasForeignKey("ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.User", "ReplyTo")
                        .WithMany()
                        .HasForeignKey("ReplyToID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CommentBy");

                    b.Navigation("CourseVideo");

                    b.Navigation("ReplyTo");
                });

            modelBuilder.Entity("CourseTags", b =>
                {
                    b.HasOne("Backend.Models.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.Tags", null)
                        .WithMany()
                        .HasForeignKey("TagsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InterestsUser", b =>
                {
                    b.HasOne("Backend.Models.Interests", null)
                        .WithMany()
                        .HasForeignKey("InterestsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Backend.Models.Course", b =>
                {
                    b.Navigation("CourseDiscounts");

                    b.Navigation("CourseProgress");

                    b.Navigation("CourseVideos");

                    b.Navigation("Payments");

                    b.Navigation("StudentCourses");
                });

            modelBuilder.Entity("Backend.Models.CourseVideo", b =>
                {
                    b.Navigation("CourseVideoLikes");

                    b.Navigation("Notifications");

                    b.Navigation("VideoComments");
                });

            modelBuilder.Entity("Backend.Models.User", b =>
                {
                    b.Navigation("CourseProgress");

                    b.Navigation("CourseVideoLikes");

                    b.Navigation("Notifications");

                    b.Navigation("Payments");

                    b.Navigation("StudentCourse");

                    b.Navigation("VideoComments");
                });

            modelBuilder.Entity("Backend.Models.VideoComments", b =>
                {
                    b.Navigation("Notifications");
                });
#pragma warning restore 612, 618
        }
    }
}
