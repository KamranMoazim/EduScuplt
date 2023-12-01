﻿// <auto-generated />
using System;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backend.Migrations
{
    [DbContext(typeof(ProjectAppContext))]
    [Migration("20231201154030_MakeFewFieldsNullableInUser")]
    partial class MakeFewFieldsNullableInUser
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("Backend.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("Backend.Models.Course", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ApprovedById")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("InstructorId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ThumbnailURL")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("ApprovedById");

                    b.HasIndex("InstructorId");

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

                    b.Property<int>("CourseId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Discount")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("InstructorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("CourseId");

                    b.HasIndex("InstructorId");

                    b.ToTable("CourseDiscounts");
                });

            modelBuilder.Entity("Backend.Models.CourseFolders", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CourseId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FolderName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("CourseId");

                    b.ToTable("CourseFolders");
                });

            modelBuilder.Entity("Backend.Models.CourseMarketing", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AdminId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CourseDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("AdminId");

                    b.ToTable("CourseMarketing");
                });

            modelBuilder.Entity("Backend.Models.CourseVideo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CourseFoldersID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CourseId")
                        .HasColumnType("INTEGER");

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

                    b.HasIndex("CourseFoldersID");

                    b.HasIndex("CourseId");

                    b.ToTable("CourseVideos");
                });

            modelBuilder.Entity("Backend.Models.Instructor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AccountDetails")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AccountNo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ApprovedById")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("INTEGER");

                    b.Property<double>("PendingAmount")
                        .HasColumnType("REAL");

                    b.Property<double>("TotalEarnedAmount")
                        .HasColumnType("REAL");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("WithdrawnAmount")
                        .HasColumnType("REAL");

                    b.HasKey("ID");

                    b.HasIndex("ApprovedById");

                    b.HasIndex("UserId");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("Backend.Models.InstructorPayment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("InstructorId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("PaidAmount")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("PayingDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("StripePaymentID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("InstructorId");

                    b.ToTable("InstructorPayments");
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

                    b.Property<bool>("IsRead")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NotificationType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("RelatedEntityId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("RelatedEntityId");

                    b.HasIndex("UserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Backend.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("Backend.Models.StudentCourseVideoLikes", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CourseVideoId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsLiked")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("CourseVideoId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentCourseVideoLikes");
                });

            modelBuilder.Entity("Backend.Models.StudentCourses", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CourseCompleteDate")
                        .HasColumnType("TEXT");

                    b.Property<double>("CourseCompleteProgressPercentage")
                        .HasColumnType("REAL");

                    b.Property<int>("CourseId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CourseStartDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastProgressDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Rating")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Review")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentPaymentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.HasIndex("StudentPaymentId");

                    b.ToTable("StudentCourses");
                });

            modelBuilder.Entity("Backend.Models.StudentInterests", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("InterestId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("InterestId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentInterests");
                });

            modelBuilder.Entity("Backend.Models.StudentPayment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("ActualAmount")
                        .HasColumnType("REAL");

                    b.Property<int>("CourseDiscountId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CourseId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("DiscountedAmount")
                        .HasColumnType("REAL");

                    b.Property<bool>("IsDiscounted")
                        .HasColumnType("INTEGER");

                    b.Property<double>("PaidAmount")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("PayingDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("StripePaymentID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("CourseDiscountId");

                    b.HasIndex("CourseId");

                    b.ToTable("StudentPayment");
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
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ProfileURL")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Backend.Models.VideoComments", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("CommentById")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CommentDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("CourseVideoId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ReplyToId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("CommentById");

                    b.HasIndex("CourseVideoId");

                    b.HasIndex("ReplyToId");

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

            modelBuilder.Entity("Backend.Models.Admin", b =>
                {
                    b.HasOne("Backend.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Backend.Models.Course", b =>
                {
                    b.HasOne("Backend.Models.Admin", "ApprovedBy")
                        .WithMany("Courses")
                        .HasForeignKey("ApprovedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.Instructor", "Instructor")
                        .WithMany("Courses")
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApprovedBy");

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("Backend.Models.CourseDiscount", b =>
                {
                    b.HasOne("Backend.Models.Course", "Course")
                        .WithMany("CourseDiscounts")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.Instructor", "Instructor")
                        .WithMany("CourseDiscounts")
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("Backend.Models.CourseFolders", b =>
                {
                    b.HasOne("Backend.Models.Course", "Course")
                        .WithMany("CourseFolders")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Backend.Models.CourseMarketing", b =>
                {
                    b.HasOne("Backend.Models.Admin", "Admin")
                        .WithMany("CourseMarketings")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("Backend.Models.CourseVideo", b =>
                {
                    b.HasOne("Backend.Models.CourseFolders", null)
                        .WithMany("CourseVideos")
                        .HasForeignKey("CourseFoldersID");

                    b.HasOne("Backend.Models.Course", "Course")
                        .WithMany("CourseVideos")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Backend.Models.Instructor", b =>
                {
                    b.HasOne("Backend.Models.Admin", "ApprovedBy")
                        .WithMany("Instructors")
                        .HasForeignKey("ApprovedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApprovedBy");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Backend.Models.InstructorPayment", b =>
                {
                    b.HasOne("Backend.Models.Instructor", "Instructor")
                        .WithMany("InstructorPayments")
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("Backend.Models.Notification", b =>
                {
                    b.HasOne("Backend.Models.CourseMarketing", "CourseMarketing")
                        .WithMany()
                        .HasForeignKey("RelatedEntityId");

                    b.HasOne("Backend.Models.VideoComments", "VideoComments")
                        .WithMany()
                        .HasForeignKey("RelatedEntityId");

                    b.HasOne("Backend.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseMarketing");

                    b.Navigation("User");

                    b.Navigation("VideoComments");
                });

            modelBuilder.Entity("Backend.Models.Student", b =>
                {
                    b.HasOne("Backend.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Backend.Models.StudentCourseVideoLikes", b =>
                {
                    b.HasOne("Backend.Models.CourseVideo", "CourseVideo")
                        .WithMany("StudentCourseVideoLikes")
                        .HasForeignKey("CourseVideoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.Student", "Student")
                        .WithMany("StudentCourseVideoLikes")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseVideo");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Backend.Models.StudentCourses", b =>
                {
                    b.HasOne("Backend.Models.Course", "Course")
                        .WithMany("StudentCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.Student", "Student")
                        .WithMany("StudentCourse")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.StudentPayment", "StudentPayment")
                        .WithMany()
                        .HasForeignKey("StudentPaymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");

                    b.Navigation("StudentPayment");
                });

            modelBuilder.Entity("Backend.Models.StudentInterests", b =>
                {
                    b.HasOne("Backend.Models.Interests", "Interest")
                        .WithMany("StudentInterests")
                        .HasForeignKey("InterestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.Student", "Student")
                        .WithMany("StudentInterests")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Interest");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Backend.Models.StudentPayment", b =>
                {
                    b.HasOne("Backend.Models.CourseDiscount", "CourseDiscount")
                        .WithMany()
                        .HasForeignKey("CourseDiscountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("CourseDiscount");
                });

            modelBuilder.Entity("Backend.Models.VideoComments", b =>
                {
                    b.HasOne("Backend.Models.User", "CommentBy")
                        .WithMany()
                        .HasForeignKey("CommentById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.CourseVideo", "CourseVideo")
                        .WithMany("VideoComments")
                        .HasForeignKey("CourseVideoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.User", "ReplyTo")
                        .WithMany()
                        .HasForeignKey("ReplyToId");

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

            modelBuilder.Entity("Backend.Models.Admin", b =>
                {
                    b.Navigation("CourseMarketings");

                    b.Navigation("Courses");

                    b.Navigation("Instructors");
                });

            modelBuilder.Entity("Backend.Models.Course", b =>
                {
                    b.Navigation("CourseDiscounts");

                    b.Navigation("CourseFolders");

                    b.Navigation("CourseVideos");

                    b.Navigation("StudentCourses");
                });

            modelBuilder.Entity("Backend.Models.CourseFolders", b =>
                {
                    b.Navigation("CourseVideos");
                });

            modelBuilder.Entity("Backend.Models.CourseVideo", b =>
                {
                    b.Navigation("StudentCourseVideoLikes");

                    b.Navigation("VideoComments");
                });

            modelBuilder.Entity("Backend.Models.Instructor", b =>
                {
                    b.Navigation("CourseDiscounts");

                    b.Navigation("Courses");

                    b.Navigation("InstructorPayments");
                });

            modelBuilder.Entity("Backend.Models.Interests", b =>
                {
                    b.Navigation("StudentInterests");
                });

            modelBuilder.Entity("Backend.Models.Student", b =>
                {
                    b.Navigation("StudentCourse");

                    b.Navigation("StudentCourseVideoLikes");

                    b.Navigation("StudentInterests");
                });
#pragma warning restore 612, 618
        }
    }
}