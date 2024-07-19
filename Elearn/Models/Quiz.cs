using System;
using System.Collections.Generic;

namespace Elearn.Models
{
    public partial class Quiz
    {
        public Quiz()
        {
            QuizAttempts = new HashSet<QuizAttempt>();
            QuizQuestions = new HashSet<QuizQuestion>();
        }

        public int QuizId { get; set; }
        public int CourseId { get; set; }
        public string? Title { get; set; }
        public int TotalQuestions { get; set; }

        public virtual Course Course { get; set; } = null!;
        public virtual ICollection<QuizAttempt> QuizAttempts { get; set; }
        public virtual ICollection<QuizQuestion> QuizQuestions { get; set; }
    }
}
