using ADONET_Samples.BaseClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONET_Samples.Models
{
    public class Product : CommonBase
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public DateTime IntroductionDate { get; set; }
        public string Url { get; set; }
        public decimal Price { get; set; }
        public DateTime? RetireDate { get; set; }
        public int? ProductCategoryId { get; set; }
    }
}
