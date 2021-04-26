using OpenQA.Selenium;

namespace Playbook.BaseClasses
{
    public static class ExtensionMethods
    {
        public static void Click(this By locator, IWebDriver Driver)
        {
            Driver.FindElement(locator).Click();
        }

        public static void SendKeys(this By locator, string text, IWebDriver Driver)
        {
            Driver.FindElement(locator).SendKeys(text);
        }

        public static void Clear(this By locator, IWebDriver Driver)
        {
            Driver.FindElement(locator).Clear();
        }

        public static string Text(this By locator, IWebDriver Driver)
        {
            return Driver.FindElement(locator).Text;
        }

        public static bool Displayed(this By locator, IWebDriver Driver)
        {
            return Driver.FindElement(locator).Displayed;
        }

        public static bool Enabled(this By locator, IWebDriver Driver)
        {
            return Driver.FindElement(locator).Enabled;
        }

        public static void JSExecutorClick(this By locator, IWebDriver Driver)
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click();", Driver.FindElement(locator));
        }
    }
}
