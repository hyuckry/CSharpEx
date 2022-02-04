using System;
using System.Collections.Generic;

#nullable disable

namespace EFCoreTutorials.Models
{
    public partial class TourCrawlingDatum
    {
        public int Id { get; set; }
        public int Title { get; set; }
        public decimal Price { get; set; }
        public string Area { get; set; }
        public string Contents { get; set; }
        public string Keyword { get; set; }
    }
}
