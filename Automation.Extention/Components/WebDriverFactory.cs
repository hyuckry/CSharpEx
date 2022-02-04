using Automation.Extention.DataContract;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Extention.Components
{
    public class WebDriverFactory
    {
        readonly DriverParams driverParams;
        //public WebDriverFactory(string driverParamsJson)
        //{
        //    driverParams = LoadParam(driverParamsJson);
        //}
        public WebDriverFactory(string driverParamsJson) : this(LoadParam(driverParamsJson)) { }
        public WebDriverFactory(DriverParams driverParams)
        {
            this.driverParams = driverParams;
            if (string.IsNullOrEmpty(driverParams.Binaries) || driverParams.Binaries == ".")
            {
                this.driverParams.Binaries = Environment.CurrentDirectory;
            }
        }

        /// <summary>
        /// Generates web-driver based on input params
        /// </summary>
        /// <returns>web-driver instance</returns>
        public IWebDriver Get()
        {
            if (!string.Equals(this.driverParams.Source, "REMOTE", StringComparison.OrdinalIgnoreCase))
            {
                return GetDriver();
            }
            return GetRemoteDriver();
        }

        //local web-drivers
        IWebDriver GetChrome() => new ChromeDriver(driverParams.Binaries);
        IWebDriver GetFirefox() => new FirefoxDriver(driverParams.Binaries);
        IWebDriver GetEdge() => new EdgeDriver(driverParams.Binaries);
        IWebDriver GetIExplorer() => new InternetExplorerDriver(driverParams.Binaries);
        IWebDriver GetDriver()
        {
            switch (driverParams.Driver.ToUpper())
            {
                case "FIREFOX": return GetFirefox();
                case "IE": return GetIExplorer();
                case "EDGE": return GetFirefox();
                case "CHROME":
                default: return GetChrome();
            }
        }
        //remote web-drivers
        IWebDriver GetRemoteChrome() => new RemoteWebDriver(new Uri(driverParams.Binaries), new ChromeOptions());
        IWebDriver GetRemoteFirefox() => new RemoteWebDriver(new Uri(driverParams.Binaries), new FirefoxOptions());
        IWebDriver GetRemoteEdge() => new RemoteWebDriver(new Uri(driverParams.Binaries), new EdgeOptions());
        IWebDriver GetRemoteIExplorer() => new RemoteWebDriver(new Uri(driverParams.Binaries), new InternetExplorerOptions());
        IWebDriver GetRemoteDriver()
        {
            switch (driverParams.Driver.ToUpper())
            {
                case "FIREFOX": return GetRemoteFirefox();
                case "IE": return GetRemoteIExplorer();
                case "EDGE": return GetRemoteEdge();
                case "CHROME":
                default: return GetRemoteChrome();
            }
        }

        //load json into driver.params object
        static DriverParams LoadParam(string driverParamsJson)
        {
            if (string.IsNullOrEmpty(driverParamsJson))
            {
                return new DriverParams { Source = "Local", Driver = "Chrome", Binaries = "." };

            }
            return JsonConvert.DeserializeObject<DriverParams>(driverParamsJson);
        }
    }
}
