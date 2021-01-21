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
            option.AddArgument("start-maximized");
            //option.AddArgument("window-size=1920,1080");
            //option.AddArgument("--headless");
            return option;
        }

        private static IWebDriver Firefox()
        {
            IWebDriver driver = new FirefoxDriver();
            return driver;
        }
    }
}