﻿using OpenQA.Selenium;
using Playbook.Configuration;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using System.Configuration;
using Applitools.Selenium;
using System.Data.SqlClient;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Support.Extensions;

namespace Playbook.BaseClasses
{
    [Binding]
    [TestFixture]
    public class BaseClass
    {
        public static IWebDriver Driver { get; set; }

        public static Eyes Eyes { get; set; }

        public static SqlConnection SqlConnection { get; set; }

        public static string DueDate = DateTime.Now.AddDays(180).ToString("MM/dd/yyyy");
        public static string CurrentDate = DateTime.Now.ToString("MMM dd, yyyy");
        public static string CurrentYear = DateTime.Now.Year.ToString();
        public static string NextYear = DateTime.Now.AddYears(1).Year.ToString();

        private void OpenEyes(string testName)
        {
            Eyes.Open(Driver, "Playbook", testName);
        }

        public void CheckWindow(string testName)
        {
            OpenEyes(testName); 
            Eyes.Check(Target.Window().Fully());
        }

        public void CheckRegion(string testName, By locator)
        {
            OpenEyes(testName);
            Eyes.Check(Target.Region(locator).Fully());
        }

        public void DeleteInitiativeFromDB(string initiativeName)
        {
            SqlConnection.ExecuteQuery("DELETE FROM " + ConfigurationManager.AppSettings["InitiativesTable"] + " WHERE Name = '" + initiativeName + "'");
        }

        [BeforeScenario()]
        [SetUp]
        public static void SetUp()
        {
            Driver = new WebDriverFactory().Create(BrowserType.Chrome);
            Driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["URL"]);
            Eyes = new Eyes 
            { 
                ApiKey = ConfigurationManager.AppSettings["ApiKey"] 
            };
        }

        [AfterScenario()]
        [TearDown]
        public static void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                var screenshot = Driver.TakeScreenshot();
                screenshot.SaveAsFile(@"C:\screenshots\screenshot" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".jpeg", ScreenshotImageFormat.Jpeg);
            }
            Driver.Close();
            Driver.Quit();
            if (Eyes.IsOpen is true) 
            { 
                Eyes.Close(); 
            };
        }
    }
}