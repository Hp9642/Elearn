using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Elearn.Models
{
    public partial class User
    {
        public User()
        {
            Courses = new HashSet<Course>();
            Enrollments = new HashSet<Enrollment>();
            ForumPosts = new HashSet<ForumPost>();
            ForumThreads = new HashSet<ForumThread>();
            QuizAttempts = new HashSet<QuizAttempt>();
        }

        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(255)]
        public string Password { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string Role { get; set; } = null!;

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<ForumPost> ForumPosts { get; set; }
        public virtual ICollection<ForumThread> ForumThreads { get; set; }
        public virtual ICollection<QuizAttempt> QuizAttempts { get; set; }
    }
}
