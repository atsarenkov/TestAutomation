using OpenQA.Selenium;
using Playbook.Configuration;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using System.Configuration;

namespace Playbook.BaseClasses
{
    [Binding]
    [TestFixture]
    public class BaseClass
    {
        public static IWebDriver Driver { get; set; }

        // Due date for the custom milestones
        public string DueDate = DateTime.Now.AddDays(180).ToString("MMM dd, yyyy");

        public string CurrentDate = DateTime.Now.ToString("MMM dd, yyyy");

        [BeforeScenario()]
        [SetUp, Order(0)]
        public static void SetUp()
        {
            Driver = new WebDriverFactory().Create(BrowserType.Chrome);
            Driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["URL"]);
        }

        [AfterScenario()]
        [TearDown]
        public static void TearDown()
        {
            Driver.Close();
            Driver.Quit();
        }
    }
}