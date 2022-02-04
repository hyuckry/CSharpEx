using System;
using System.Collections.Generic;

#nullable disable

namespace EFCoreTutorials.Models
{
    public partial class WiseSaying
    {
        public int Wsid { get; set; }
        public string Wscontent { get; set; }
        public DateTime UpdateTime { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
