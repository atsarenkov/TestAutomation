using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Playbook.BaseClasses;
using System;

namespace Playbook.Pages
{
    public class ReportPage : BasePage
    {
        public ReportPage(IWebDriver driver) : base(driver) { }

        readonly WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

        #region WebElements
        IWebElement OrganizationDropdown => Driver.FindElement(By.XPath("//*[@class='dropdown-toggler']"));
        IWebElement SearchField => Driver.FindElement(By.XPath("//*[@placeholder='Start typing']"));
        IWebElement Organization => Driver.FindElement(By.XPath("//*[@class='h-dropdown-item--search-find']"));
        IWebElement CreateInitiativeButton => Driver.FindElement(By.XPath("//*[text()='Create Initiative']"));
        IWebElement SavingInitiativeMessage => Driver.FindElement(By.XPath("//*[text()='Saving initiative...']"));
        IWebElement InitiativeSavedMessage => Driver.FindElement(By.XPath("//*[text()='Initiative saved successfully']"));
        // "Initiatives" tab
        IWebElement InitiativesTab => Driver.FindElement(By.XPath("//*[text()='Initiatives']"));
        IWebElement RevenueIncreaseButton => Driver.FindElement(By.XPath("//*[text()='Revenue Increase']"));
        IWebElement TargetPercentButton => Driver.FindElement(By.XPath("//*[text()='Target Percent']"));
        IWebElement TargetValueButton => Driver.FindElement(By.XPath("//*[text()='Target Value']"));
        IWebElement InitiativeFilterField => Driver.FindElement(By.XPath("//*[@class='au-table']//input"));
        IWebElement FilteredInitiative => Driver.FindElement(By.XPath("//*[@class='au-table']//a"));
        #endregion

        #region Actions
        public void SelectOrganization(string organization)
        {
            wait.Until(Driver => OrganizationDropdown.Displayed);
            OrganizationDropdown.Click();
            wait.Until(Driver => SearchField.Displayed);
            SearchField.SendKeys(organization);
            Organization.Click();
        }

        public InitiativeModal OpenInitiativeModal()
        {
            CreateInitiativeButton.Click();
            return new InitiativeModal(Driver);
        }

        public bool InitiativeSavedSuccessfully()
        {
            wait.Until(Driver => SavingInitiativeMessage.Displayed);
            return wait.Until(Driver => InitiativeSavedMessage.Displayed);
        }

        public void SelectInitiavesTab()
        {
            wait.Until(Driver => InitiativesTab.Displayed);
            InitiativesTab.Click();
        }

        public void NavigateToRevenueIncreaseInitiatives()
        {
            wait.Until(Driver => RevenueIncreaseButton.Displayed);
            RevenueIncreaseButton.Click();
        }

        public void NavigateToTargetPercentInitiatives()
        {
            wait.Until(Driver => TargetPercentButton.Displayed);
            TargetPercentButton.Click();
        }

        public void NavigateToTargetValueInitiatives()
        {
            wait.Until(Driver => TargetValueButton.Displayed);
            TargetValueButton.Click();
        }

        public ManageInitiativePage OpenInitiave(string initiative)
        {
            InitiativeFilterField.SendKeys(initiative);
            FilteredInitiative.Click();
            return new ManageInitiativePage(Driver);
        }
        #endregion
    }
}