using System;
using System.Collections.Generic;

#nullable disable

namespace EFCoreTutorials.Models
{
    public partial class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreatedAt1 { get; set; }
        public DateTime UpdatedAt1 { get; set; }
    }
}
