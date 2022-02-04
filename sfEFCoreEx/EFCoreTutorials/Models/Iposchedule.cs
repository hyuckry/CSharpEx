using System;
using System.Collections.Generic;

#nullable disable

namespace EFCoreTutorials.Models
{
    public partial class Iposchedule
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public decimal? LowPrice { get; set; }
        public string CompanyType { get; set; }
        public string Underwriter { get; set; }
        public string State { get; set; }
        public string Competition { get; set; }
        public DateTime? ListDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime RegDate { get; set; }
    }
}
