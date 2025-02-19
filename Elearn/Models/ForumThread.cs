﻿using System;
using System.Collections.Generic;

namespace Elearn.Models
{
    public partial class ForumThread
    {
        public ForumThread()
        {
            ForumPosts = new HashSet<ForumPost>();
        }

        public int ThreadId { get; set; }
        public int CourseId { get; set; }
        public string? Title { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Course Course { get; set; } = null!;
        public virtual User? CreatedByNavigation { get; set; }
        public virtual ICollection<ForumPost> ForumPosts { get; set; }
    }
}
