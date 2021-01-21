using OpenQA.Selenium;
using Playbook.BaseClasses;
using System.Configuration;

namespace Playbook.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver _driver) : base(_driver) { }

        #region WebElements
        IWebElement EmailField => Driver.FindElement(By.Name("email"));
        IWebElement LoginButton => Driver.FindElement(By.Name("submit"));
        IWebElement PasswordField => Driver.FindElement(By.Name("Password"));
        IWebElement SignInButton => Driver.FindElement(By.Id("next"));
        #endregion

        #region Actions
        public ReportPage Login()
        {
            EmailField.SendKeys(ConfigurationManager.AppSettings["Email"]);
            LoginButton.Click();
            PasswordField.SendKeys(ConfigurationManager.AppSettings["Password"]);
            SignInButton.Click();
            return new ReportPage(Driver);
        }
        #endregion
    }
}