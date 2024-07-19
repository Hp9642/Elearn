using System;
using System.Collections.Generic;

namespace Elearn.Models
{
    public partial class QuizQuestion
    {
        public int QuizquestionId { get; set; }
        public int QuizId { get; set; }
        public string? Question { get; set; }
        public string OptionA { get; set; } = null!;
        public string OptionB { get; set; } = null!;
        public string OptionC { get; set; } = null!;
        public string OptionD { get; set; } = null!;
        public string Answer { get; set; } = null!;

        public virtual Quiz Quiz { get; set; } = null!;
    }
}
