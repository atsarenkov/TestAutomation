using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Playbook.BaseClasses;

namespace Playbook.Pages
{
    public class ManageInitiativePage : BasePage
    {
        public ManageInitiativePage(IWebDriver driver) : base(driver) { }

        readonly WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

        #region WebElements
        IWebElement DeleteInitiativeButton => Driver.FindElement(By.XPath("//*[text()='Delete Initiative']"));
        IWebElement DeleteButton => Driver.FindElement(By.XPath("//*[text()='Delete']"));
        IWebElement EditInitiativeButton => Driver.FindElement(By.XPath("//*[text()='Edit Initiative']"));
        // Initiative Details
        IWebElement Name => Driver.FindElement(By.XPath("//*[@class='description-title']"));
        IWebElement FinanceStatus => Driver.FindElement(By.XPath("//*[@class='description-finance-status']"));
        IWebElement EnterRealizedImpactButton => Driver.FindElement(By.XPath("//*[text()='Enter Realized Impact']"));
        IWebElement Type => Driver.FindElement(By.XPath("//*[contains(text(),'Type')]/following-sibling::*"));
        IWebElement Status => Driver.FindElement(By.XPath("//*[contains(text(),'Status')]/following-sibling::*"));
        IWebElement Categoty => Driver.FindElement(By.XPath("//*[contains(text(),'Category')]/following-sibling::*"));
        IWebElement FirstFiscalYearImpactValue => Driver.FindElement(By.XPath("//*[@class='impact-year__row']"));
        IWebElement SecondFiscalYearImpactValue => Driver.FindElement(By.XPath("//*[@class='impact-year__row']/following-sibling::*"));
        IWebElement Description => Driver.FindElement(By.XPath("//*[contains(text(),'Description')]/following-sibling::*"));
        IWebElement Lead => Driver.FindElement(By.XPath("//*[contains(text(),'Leads')]/following-sibling::*"));
        IWebElement Stakeholder => Driver.FindElement(By.XPath("//*[contains(text(),'Stakeholders')]/following-sibling::*"));
        IWebElement CreatedByValue => Driver.FindElement(By.XPath("//*[normalize-space() = 'Created By']/following-sibling::*"));
        IWebElement CreatedDateValue => Driver.FindElement(By.XPath("//*[normalize-space() = 'Created Date']/following-sibling::*"));
        IWebElement ModifiedByValue => Driver.FindElement(By.XPath("//*[normalize-space() = 'Modified By']/following-sibling::*"));
        IWebElement ModifiedDateValue => Driver.FindElement(By.XPath("//*[normalize-space() = 'Modified Date']/following-sibling::*"));
        // "Milestones" tab
        IWebElement FirstMilestoneValue => Driver.FindElement(By.XPath("//*[@class='playbook-initiative__milestones__steps']/descendant::div[1]"));
        IWebElement SecondMilestoneValue => Driver.FindElement(By.XPath("//*[@class='playbook-initiative__milestones__steps']/descendant::div[6]"));
        IWebElement ThirdMilestoneValue => Driver.FindElement(By.XPath("//*[@class='playbook-initiative__milestones__steps']/descendant::div[11]"));
        IWebElement FourthMilestoneValue => Driver.FindElement(By.XPath("//*[@class='playbook-initiative__milestones__steps']/descendant::div[16]"));
        IWebElement FifthMilestoneValue => Driver.FindElement(By.XPath("//*[@class='playbook-initiative__milestones__steps']/descendant::div[21]"));
        IWebElement SixthMilestoneValue => Driver.FindElement(By.XPath("//*[@class='playbook-initiative__milestones__steps']/descendant::div[26]"));
        IWebElement SeventhMilestoneValue => Driver.FindElement(By.XPath("//*[@class='playbook-initiative__milestones__steps']/descendant::div[31]"));
        #endregion

        #region Actions
        public string InitiativeName()
        {
            return wait.Until(driver => Name.Text);
        }

        public string FinanceApprovalStatus()
        {
            return FinanceStatus.Text;
        }

        public bool EnterRealizedImpactButtonEnabled()
        {
            return EnterRealizedImpactButton.Enabled;
        }

        public string InitiativeType()
        {
            return Type.Text;
        }

        public string InitiativeStatus()
        {
            return Status.Text;
        }

        public string InitiativeCategory()
        {
            return Categoty.Text;
        }

        public string FirstFiscalYearImpact()
        {
            return FirstFiscalYearImpactValue.Text.Replace(Environment.NewLine, " ");
        }

        public string SecondFiscalYearImpact()
        {
            return SecondFiscalYearImpactValue.Text.Replace(Environment.NewLine, " ");
        }

        public string InitiativeDescription()
        {
            return Description.Text;
        }

        public string InitiativeLead()
        {
            return Lead.Text.Replace(Environment.NewLine, ", ");
        }

        public string InitiativeStakeholder()
        {
            return Stakeholder.Text.Replace(Environment.NewLine, ", ");
        }

        public string CreatedBy()
        {
            return CreatedByValue.Text;
        }

        public string CreatedDate()
        {
            return CreatedDateValue.Text;
        }

        public string ModifiedBy()
        {
            return ModifiedByValue.Text;
        }

        public string ModifiedDate()
        {
            return ModifiedDateValue.Text;
        }

        public string FirstMilestone()
        {
            return FirstMilestoneValue.Text.Replace(Environment.NewLine, " ");
        }

        public string SecondMilestone()
        {
            wait.Until(driver => SecondMilestoneValue.Displayed);
            return SecondMilestoneValue.Text.Replace(Environment.NewLine, " ");
        }

        public string ThirdMilestone()
        {
            return ThirdMilestoneValue.Text.Replace(Environment.NewLine, ", ");
        }

        public string FourthMilestone()
        {
            return FourthMilestoneValue.Text.Replace(Environment.NewLine, ", ");
        }

        public string FifthMilestone()
        {
            return FifthMilestoneValue.Text.Replace(Environment.NewLine, ", ");
        }

        public string SixthMilestone()
        {
            return SixthMilestoneValue.Text.Replace(Environment.NewLine, ", ");
        }

        public string SeventhMilestone()
        {
            return SeventhMilestoneValue.Text.Replace(Environment.NewLine, ", ");
        }

        public void DeleteInitiative()
        {
            wait.Until(driver => DeleteInitiativeButton.Displayed);
            DeleteInitiativeButton.Click();
            DeleteButton.Click();
        }
        #endregion
    }
}