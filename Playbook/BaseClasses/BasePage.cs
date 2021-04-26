using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Playbook.BaseClasses
{
    public class BasePage
    {
        public static IWebDriver Driver;

        public BasePage(IWebDriver _driver) => Driver = _driver;

        public void WaitUntilElementIsVisible(By locator)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.IgnoreExceptionTypes(
                typeof(NoSuchElementException),
                typeof(ElementNotVisibleException),
                typeof(StaleElementReferenceException),
                typeof(ElementNotInteractableException));
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public void WaitUntilElementIsClickable(By locator)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.IgnoreExceptionTypes(
                typeof(NoSuchElementException),
                typeof(ElementNotVisibleException),
                typeof(StaleElementReferenceException),
                typeof(ElementNotInteractableException));
            wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }
    }
}