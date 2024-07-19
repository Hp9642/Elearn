using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Elearn.Models
{
    public partial class OnlineLearningPlatformDBContext : DbContext
    {
        public OnlineLearningPlatformDBContext()
        {
        }

        public OnlineLearningPlatformDBContext(DbContextOptions<OnlineLearningPlatformDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Enrollment> Enrollments { get; set; } = null!;
        public virtual DbSet<ForumPost> ForumPosts { get; set; } = null!;
        public virtual DbSet<ForumThread> ForumThreads { get; set; } = null!;
        public virtual DbSet<Lecture> Lectures { get; set; } = null!;
        public virtual DbSet<Quiz> Quizzes { get; set; } = null!;
        public virtual DbSet<QuizAttempt> QuizAttempts { get; set; } = null!;
        public virtual DbSet<QuizQuestion> QuizQuestions { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.CourseId).HasColumnName("courseId");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.InstructorId).HasColumnName("instructorId");

                entity.Property(e => e.Title)
                    .HasMaxLength(200)
                    .HasColumnName("title");

                entity.HasOne(d => d.Instructor)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.InstructorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Courses__instruc__3C69FB99");
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.Property(e => e.EnrollmentId).HasColumnName("enrollmentId");

                entity.Property(e => e.CourseId).HasColumnName("courseId");

                entity.Property(e => e.EnrollmentDate)
                    .HasColumnType("datetime")
                    .HasColumnName("enrollmentDate");

                entity.Property(e => e.Progress).HasColumnName("progress");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Enrollmen__cours__403A8C7D");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Enrollmen__userI__3F466844");
            });

            modelBuilder.Entity<ForumPost>(entity =>
            {
                entity.HasKey(e => e.PostId)
                    .HasName("PK__ForumPos__DD0C739AD3C46FC3");

                entity.Property(e => e.PostId).HasColumnName("postId");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.ThreadId).HasColumnName("threadId");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ForumPosts)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK__ForumPost__creat__5441852A");

                entity.HasOne(d => d.Thread)
                    .WithMany(p => p.ForumPosts)
                    .HasForeignKey(d => d.ThreadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ForumPost__threa__534D60F1");
            });

            modelBuilder.Entity<ForumThread>(entity =>
            {
                entity.HasKey(e => e.ThreadId)
                    .HasName("PK__ForumThr__9A31E2DC4DC159B5");

                entity.Property(e => e.ThreadId).HasColumnName("threadId");

                entity.Property(e => e.CourseId).HasColumnName("courseId");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.Title)
                    .HasMaxLength(200)
                    .HasColumnName("title");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.ForumThreads)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ForumThre__cours__4F7CD00D");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ForumThreads)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK__ForumThre__creat__5070F446");
            });

            modelBuilder.Entity<Lecture>(entity =>
            {
                entity.Property(e => e.LectureId).HasColumnName("lectureId");

                entity.Property(e => e.CourseId).HasColumnName("courseId");

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.Property(e => e.LectureVideoUrl).HasColumnName("lectureVideoURL");

                entity.Property(e => e.Title)
                    .HasMaxLength(200)
                    .HasColumnName("title");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Lectures)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Lectures__course__4316F928");
            });

            modelBuilder.Entity<Quiz>(entity =>
            {
                entity.Property(e => e.QuizId).HasColumnName("quizId");

                entity.Property(e => e.CourseId).HasColumnName("courseId");

                entity.Property(e => e.Title)
                    .HasMaxLength(200)
                    .HasColumnName("title");

                entity.Property(e => e.TotalQuestions).HasColumnName("totalQuestions");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Quizzes)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Quizzes__courseI__45F365D3");
            });

            modelBuilder.Entity<QuizAttempt>(entity =>
            {
                entity.HasKey(e => e.AttemptId)
                    .HasName("PK__quizAtte__93048006A01F35DF");

                entity.ToTable("quizAttempts");

                entity.Property(e => e.AttemptId).HasColumnName("attemptId");

                entity.Property(e => e.AttemptTime)
                    .HasColumnType("datetime")
                    .HasColumnName("attemptTime");

                entity.Property(e => e.QuizId).HasColumnName("quizId");

                entity.Property(e => e.Score).HasColumnName("score");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.QuizAttempts)
                    .HasForeignKey(d => d.QuizId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__quizAttem__quizI__4BAC3F29");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.QuizAttempts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__quizAttem__userI__4CA06362");
            });

            modelBuilder.Entity<QuizQuestion>(entity =>
            {
                entity.Property(e => e.QuizquestionId).HasColumnName("quizquestionId");

                entity.Property(e => e.Answer)
                    .HasMaxLength(1)
                    .HasColumnName("answer");

                entity.Property(e => e.OptionA)
                    .HasMaxLength(1)
                    .HasColumnName("optionA");

                entity.Property(e => e.OptionB)
                    .HasMaxLength(1)
                    .HasColumnName("optionB");

                entity.Property(e => e.OptionC)
                    .HasMaxLength(1)
                    .HasColumnName("optionC");

                entity.Property(e => e.OptionD)
                    .HasMaxLength(1)
                    .HasColumnName("optionD");

                entity.Property(e => e.Question).HasColumnName("question");

                entity.Property(e => e.QuizId).HasColumnName("quizId");

                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.QuizQuestions)
                    .HasForeignKey(d => d.QuizId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__QuizQuest__quizI__48CFD27E");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ__Users__AB6E616418113CBA")
                    .IsUnique();

                entity.HasIndex(e => e.Username, "UQ__Users__F3DBC5725FE8BCB2")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password");

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .HasColumnName("role");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
