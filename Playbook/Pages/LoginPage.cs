using OpenQA.Selenium;
using Playbook.BaseClasses;
using System.Configuration;

namespace Playbook.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver _driver) : base(_driver) { }

        #region WebElements
        private readonly By EmailField = By.Name("email");
        private readonly By LoginButton = By.Name("submit");
        private readonly By PasswordField = By.Name("Password");
        private readonly By SignInButton = By.Id("next");
        #endregion

        #region Actions
        public ReportPage Login()
        {
            EmailField.SendKeys(ConfigurationManager.AppSettings["Email"], Driver);
            LoginButton.Click(Driver);
            WaitUntilElementIsVisible(PasswordField);
            PasswordField.SendKeys(ConfigurationManager.AppSettings["Password"], Driver);
            SignInButton.JSExecutorClick(Driver);
            return new ReportPage(Driver);
        }
        #endregion
    }
}