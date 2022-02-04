using Automation.Extention.Components;
using Automation.Extention.DataContract;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Automation.Testing
{
    [TestClass]
    public class SeleniumSamples
    { 
        [TestMethod]
        public void webDriverSamples()
        {
            IWebDriver driver = new ChromeDriver();
            Thread.Sleep(1000);
            driver.Dispose();

            driver = new FirefoxDriver();
            Thread.Sleep(1000);
            driver.Dispose();

            driver = new InternetExplorerDriver();
            Thread.Sleep(1000);
            driver.Dispose();

            driver = new EdgeDriver();
            Thread.Sleep(1000);
            driver.Dispose();
        }

        [TestMethod] 
        public void webElementSamples()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("naver.com");
            driver.FindElement(By.XPath("//a")).Click();
            Thread.Sleep(1000);
            driver.Dispose();
        }

        [TestMethod]
        public void selectElementSamples()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://www.way2automation.com/");
            var element = driver.FindElement(By.XPath("//a"));
            var selectElement = new SelectElement(element);
            selectElement.SelectByValue("4");

            Thread.Sleep(1000);
            driver.Dispose();
        }

        [TestMethod]
        public void WebDriverFactorySample()
        {
            var driver = new WebDriverFactory(new DriverParams { Driver = "chrome", Binaries = @"D:\automation-env\web-drivers" }).Get();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://www.way2automation.com/");
            var element = driver.FindElement(By.XPath("//a"));
            var selectElement = new SelectElement(element);
            selectElement.SelectByValue("4");

            Thread.Sleep(1000);
            driver.Dispose();
        }

    }
}