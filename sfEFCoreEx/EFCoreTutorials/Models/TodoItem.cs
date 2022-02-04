using System;
using System.Collections.Generic;

#nullable disable

namespace EFCoreTutorials.Models
{
    public partial class TodoItem
    {
        public int TodoId { get; set; }
        public string TodoTitle { get; set; }
        public string TodoDesc { get; set; }
        public int Completed { get; set; }
        public DateTime Due { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
