﻿using OpenQA.Selenium;
using Playbook.Configuration;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using System.Configuration;
using Applitools.Selenium;

namespace Playbook.BaseClasses
{
    [Binding]
    [TestFixture]
    public class BaseClass
    {
        public static IWebDriver Driver { get; set; }

        public static Eyes Eyes { get; set; }
        
        public static string DueDate = DateTime.Now.AddDays(180).ToString();
        public static string CurrentDate = DateTime.Now.ToString("MMM dd, yyyy");
        public static string CurrentYear = DateTime.Now.ToString("yyyy");
        public static string NextYear = DateTime.Now.AddYears(1).ToString("yyyy");

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

        [BeforeScenario()]
        [SetUp, Order(0)]
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
            Driver.Close();
            Driver.Quit();
            if (Eyes.IsOpen is true) 
            { 
                Eyes.Close(); 
            };
        }
    }
}