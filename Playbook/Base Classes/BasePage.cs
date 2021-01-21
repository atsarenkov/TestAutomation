using OpenQA.Selenium;

namespace Playbook.BaseClasses
{
    public class BasePage
    {
        public static IWebDriver Driver;
        public BasePage(IWebDriver _driver) => Driver = _driver;
    }
}