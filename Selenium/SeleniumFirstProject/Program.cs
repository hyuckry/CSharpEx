// See https://aka.ms/new-console-template for more information
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

Console.WriteLine("Hello, World!");

new DriverManager().SetUpDriver(new ChromeConfig());
IWebDriver driver = new ChromeDriver();
driver.Navigate().GoToUrl("https://github.com");

IWebElement searchInput = driver.FindElement(By.CssSelector("[name='q']"));

string searchPhrase = "selenium";
searchInput.SendKeys(searchPhrase);
searchInput.SendKeys(Keys.Enter);

IList<string> actualItems=driver.FindElements(By.CssSelector(".repo-list-item"))
    .Select(x => x.Text.ToLower())
    .ToList();

Assert.True(actualItems.All(item=>item.ToLower().Contains(searchPhrase)));


driver.Quit();

