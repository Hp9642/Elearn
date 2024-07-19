using System;
using System.Collections.Generic;

namespace Elearn.Models
{
    public partial class ForumPost
    {
        public int PostId { get; set; }
        public int ThreadId { get; set; }
        public string? Content { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual User? CreatedByNavigation { get; set; }
        public virtual ForumThread Thread { get; set; } = null!;
    }
}
