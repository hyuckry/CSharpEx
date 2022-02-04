using System;
using System.Collections.Generic;

#nullable disable

namespace EFCoreTutorials.Models
{
    public partial class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Sns { get; set; }
        public string Token { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
