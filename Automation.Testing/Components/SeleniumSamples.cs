using Microsoft.VisualStudio.TestTools.UnitTesting;
using Automation.Extention.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Extention.DataContract;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Threading;

namespace Automation.Extention.Components.Tests
{
    [TestClass()]
    public class SeleniumSamples
    {
        [TestMethod()]
        public void GoToUrlTest()
        {
            var driver = new WebDriverFactory(new DriverParams { Driver = "chrome", Binaries = @"D:\automation-env\web-drivers" }).Get();
            driver.GoToUrl("https://www.way2automation.com/");

            Thread.Sleep(1000);
            driver.Dispose();
        }

        [TestMethod()]
        public void GetElementTest()
        {
            var driver = new WebDriverFactory(new DriverParams { Driver = "chrome", Binaries = @"D:\automation-env\web-drivers" }).Get();
            driver.GoToUrl("https://www.way2automation.com/");
            driver.GetElement(By.XPath("//a")).Click();

            Thread.Sleep(1000);
            driver.Dispose();
        }

        [TestMethod()]
        public void AsSelectTest()
        {
            var driver = new WebDriverFactory(new DriverParams { Driver = "chrome", Binaries = @"D:\automation-env\web-drivers" }).Get();
            driver.GoToUrl("https://www.way2automation.com/");

            driver.GetElement(By.XPath("//a")).AsSelect().SelectByValue("4");

            Thread.Sleep(1000);
            driver.Dispose();
        }

        [TestMethod()]
        public void GetElementsTest()
        {
            var driver = new WebDriverFactory(new DriverParams { Driver = "chrome", Binaries = @"D:\automation-env\web-drivers" }).Get();
            driver.GoToUrl("https://www.way2automation.com/");

            var elements = driver.GetElements(By.XPath("//ul/li"));

            Thread.Sleep(1000);
            driver.Dispose();
        }
        [TestMethod()]
        public void GetVisibleElementsTest()
        {
            var driver = new WebDriverFactory(new DriverParams { Driver = "chrome", Binaries = @"D:\automation-env\web-drivers" }).Get();
            driver.GoToUrl("https://www.way2automation.com/");

            var elements = driver.GetVisibleElements(By.XPath("//ul/li"));

            Thread.Sleep(1000);
            driver.Dispose();
        }
    }
}