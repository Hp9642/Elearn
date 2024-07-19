using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Elearn.Models
{
    public partial class Course
    {
        public Course()
        {
            Enrollments = new HashSet<Enrollment>();
            ForumThreads = new HashSet<ForumThread>();
            Lectures = new HashSet<Lecture>();
            Quizzes = new HashSet<Quiz>();
        }

        [Key]
        public int CourseId { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public int InstructorId { get; set; }

        public virtual User Instructor { get; set; } = null!;
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<ForumThread> ForumThreads { get; set; }
        public virtual ICollection<Lecture> Lectures { get; set; }
        public virtual ICollection<Quiz> Quizzes { get; set; }
    }
}
