using System;
using System.Collections.Generic;

#nullable disable

namespace EFCoreTutorials.Models
{
    public partial class RawDatum
    {
        public int RawId { get; set; }
        public string Req { get; set; }
        public string Result { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
