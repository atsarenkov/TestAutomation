using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Playbook.Configuration
{
    public class WebDriverFactory
    {
        public IWebDriver Create(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    return ChromeDriver();
                case BrowserType.Firefox:
                    return Firefox();
                default:
                    throw new ArgumentOutOfRangeException("No such browser exists");
            }
        }
        private static IWebDriver ChromeDriver()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            IWebDriver driver = new ChromeDriver(GetChromeOptions());
            return driver;
        }

        private static ChromeOptions GetChromeOptions()
        {
            var option = new ChromeOptions();
            //option.AddArgument("start-maximized");
            option.AddArgument("window-size=1920,1080");
            option.AddArgument("--headless");
            return option;
        }

        private static IWebDriver Firefox()
        {
            new DriverManager().SetUpDriver(new FirefoxConfig());
            IWebDriver driver = new FirefoxDriver(GetFirefoxOptions());
            //driver.Manage().Window.Maximize();
            return driver;
        }

        private static FirefoxOptions GetFirefoxOptions()
        {
            var option = new FirefoxOptions();
            option.AddArgument("--width=1920,height=1080");
            option.AddArgument("--headless");
            return option;
        }
    }
}