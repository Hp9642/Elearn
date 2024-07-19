using System;
using System.Collections.Generic;

namespace Elearn.Models
{
    public partial class Lecture
    {
        public int LectureId { get; set; }
        public int CourseId { get; set; }
        public string? Title { get; set; }
        public TimeSpan? Duration { get; set; }
        public string LectureVideoUrl { get; set; } = null!;

        public virtual Course Course { get; set; } = null!;
    }
}
