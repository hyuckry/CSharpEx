using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONET_Samples.Components
{
    public static class AppSettings
    {
        public static string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["ADONETSamples"].ConnectionString; }
        }
    }
}
