using System;
using OpenQA.Selenium;
using Playbook.BaseClasses;

namespace Playbook.Pages
{
    public class ManageInitiativePage : BasePage
    {
        public ManageInitiativePage(IWebDriver driver) : base(driver) { }

        #region WebElements
        private readonly By DeleteInitiativeButton = By.XPath("//*[text()='Delete Initiative']");
        private readonly By DeleteButton = By.XPath("//*[text()='Delete']");
        private readonly By EditInitiativeButton = By.XPath("//*[text()='Edit Initiative']");
        // Initiative details
        private readonly By Name = By.XPath("//*[@class='description-title']");
        private readonly By FinanceStatus = By.XPath("//*[@class='description-finance-status']");
        private readonly By EnterRealizedImpactButton = By.XPath("//*[text()='Enter Realized Impact']");
        private readonly By Type = By.XPath("//*[contains(text(),'Type')]/following-sibling::*");
        private readonly By Status = By.XPath("//*[contains(text(),'Status')]/following-sibling::*");
        private readonly By Categoty = By.XPath("//*[contains(text(),'Category')]/following-sibling::*");
        private readonly By CurrentYearEstimatedImpactValue = By.XPath("//*[text()='" + BaseClass.CurrentYear + "']/parent::*");
        private readonly By NextYearEstimatedImpactValue = By.XPath("//*[text()='" + BaseClass.NextYear + "']/parent::*");
        private readonly By Description = By.XPath("//*[contains(text(),'Description')]/following-sibling::*");
        private readonly By Lead = By.XPath("//*[contains(text(),'Leads')]/following-sibling::*");
        private readonly By Stakeholder = By.XPath("//*[contains(text(),'Stakeholders')]/following-sibling::*");
        private readonly By CreatedByValue = By.XPath("//*[normalize-space() = 'Created By']/following-sibling::*");
        private readonly By CreatedDateValue = By.XPath("//*[normalize-space() = 'Created Date']/following-sibling::*");
        private readonly By ModifiedByValue = By.XPath("//*[normalize-space() = 'Modified By']/following-sibling::*");
        private readonly By ModifiedDateValue = By.XPath("//*[normalize-space() = 'Modified Date']/following-sibling::*");
        // "Reporting" tab
        private readonly By ReportingButton = By.XPath("//*[text()='Reporting']");
        public static By ReportingSection = By.XPath("//*[@class='playbook-initiative__reporting']");
        #endregion

        #region Actions
        public string InitiativeName()
        {
            WaitUntilElementIsVisible(Name);
            return Name.Text(Driver);
        }

        public string FinanceApprovalStatus()
        {
            return FinanceStatus.Text(Driver);
        }

        public bool EnterRealizedImpactButtonEnabled()
        {
            return EnterRealizedImpactButton.Enabled(Driver);
        }

        public string InitiativeType()
        {
            return Type.Text(Driver);
        }

        public string InitiativeStatus()
        {
            return Status.Text(Driver);
        }

        public string InitiativeCategory()
        {
            return Categoty.Text(Driver);
        }

        public string CurrentYearEstimatedImpact()
        {
            return CurrentYearEstimatedImpactValue.Text(Driver).Replace(Environment.NewLine, " ");
        }

        public string NextYearEstimatedImpact()
        {
            return NextYearEstimatedImpactValue.Text(Driver).Replace(Environment.NewLine, " ");
        }

        public string InitiativeDescription()
        {
            return Description.Text(Driver);
        }

        public string InitiativeLead()
        {
            return Lead.Text(Driver).Replace(Environment.NewLine, ", ");
        }

        public string InitiativeStakeholder()
        {
            return Stakeholder.Text(Driver).Replace(Environment.NewLine, ", ");
        }

        public string CreatedBy()
        {
            return CreatedByValue.Text(Driver);
        }

        public string CreatedDate()
        {
            return CreatedDateValue.Text(Driver);
        }

        public string ModifiedBy()
        {
            return ModifiedByValue.Text(Driver);
        }

        public string ModifiedDate()
        {
            return ModifiedDateValue.Text(Driver);
        }

        public void NavigateToReportingTab()
        {
            WaitUntilElementIsClickable(ReportingButton);
            ReportingButton.Click(Driver);
        }

        public void DeleteInitiative()
        {
            WaitUntilElementIsClickable(DeleteInitiativeButton);
            DeleteInitiativeButton.Click(Driver);
            DeleteButton.Click(Driver);
        }
        #endregion
    }
}