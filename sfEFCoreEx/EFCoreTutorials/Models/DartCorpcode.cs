using System;
using System.Collections.Generic;

#nullable disable

namespace EFCoreTutorials.Models
{
    public partial class DartCorpcode
    {
        public string CorpCode { get; set; }
        public string CorpName { get; set; }
        public string StockCode { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
