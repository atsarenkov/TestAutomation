using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Playbook.BaseClasses;
using System;

namespace Playbook.Pages
{
    public class InitiativeModal : BasePage
    {
        public InitiativeModal(IWebDriver driver) : base(driver) { }

        readonly IJavaScriptExecutor executor = ((IJavaScriptExecutor)Driver);

        readonly Actions action = new Actions(Driver);

        readonly WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

        #region WebElements
        IWebElement NextButton => Driver.FindElement(By.XPath("//*[text()='Next']"));
        IWebElement CreateButton => Driver.FindElement(By.XPath("//*[text()='Create']"));
        // "Describe The Initiative" Tab
        IWebElement NameField => Driver.FindElement(By.XPath("//*[@placeholder='Enter a short name']"));
        IWebElement InitiativeTypeDropdown => Driver.FindElement(By.XPath("//*[@class='playbook-new-initiative-form__field']//*[@class='dropdown-toggler__value ellipsis']"));
        IWebElement RevenueIncreaseInitiative => Driver.FindElement(By.XPath("//*[text()='Revenue Increase ($)']"));
        IWebElement TargetPercentInitiative => Driver.FindElement(By.XPath("//*[text()='Target Percent (%)']"));
        IWebElement TargetValueInitiative => Driver.FindElement(By.XPath("//*[text()='Target Value']"));
        IWebElement DescriptionField => Driver.FindElement(By.XPath("//*[@class='textarea-field']//textarea"));
        IWebElement AddLeadButton => Driver.FindElement(By.XPath("//*[text()='lead']"));
        IWebElement TeamMembersDropdown => Driver.FindElement(By.XPath("//*[text()='Find team members']"));
        IWebElement TeamMembersSearchField => Driver.FindElement(By.XPath("//*[@class='plain-dropdown-menu-with-search']//descendant::input"));
        IWebElement TeamMember => Driver.FindElement(By.XPath("//*[@class='plain-dropdown-option plain-dropdown-option--focused']"));
        IWebElement AddStakeholderButton => Driver.FindElement(By.XPath("//*[text()='stakeholder']"));
        // "Estimate Impact" tab
        IWebElement CurrentImpactValue => Driver.FindElement(By.Id("current_budget_impact_amount"));
        IWebElement FirstFiscalYearImpactValue => Driver.FindElement(By.XPath("//*[@class='playbook-budget-impact-form']/descendant::input[1]"));
        IWebElement AddYearButton => Driver.FindElement(By.XPath("//*[text()='Add Year']"));
        IWebElement SelectYear => Driver.FindElement(By.XPath("//*[@class='plain-dropdown-option']"));
        IWebElement SecondFiscalYearImpactValue => Driver.FindElement(By.XPath("//*[@class='playbook-budget-impact-form']/descendant::input[2]"));
        IWebElement FinanceApprovalCheckbox => Driver.FindElement(By.XPath("//*[@class='react-checkbox playbook-budget-impact-form__checkbox']"));
        // "Set Milestones" tab
        IWebElement CustomMilestoneDropdown => Driver.FindElement(By.XPath("//*[@class='milestone-list']/descendant::div[19]"));
        IWebElement AddCustomMilestoneButton => Driver.FindElement(By.XPath("//*[text()='Add Custom Milestone']"));
        IWebElement CustomMilestoneField => Driver.FindElement(By.XPath("//*[@class='milestone-list']/descendant::input[2]"));
        IWebElement CustomMilestoneDate => Driver.FindElement(By.XPath("//*[@class='milestone-list']/descendant::input[3]"));
        IWebElement DefaultMilestoneDropdown => Driver.FindElement(By.XPath("//*[@class='milestone-list']/descendant::button[6]"));
        IWebElement DefaultMilestoneSearchField => Driver.FindElement(By.CssSelector("div:nth-child(14) input"));
        IWebElement FilteredMilestone => Driver.FindElement(By.XPath("//*[@class='plain-dropdown-option']"));
        IWebElement RemoveMilestoneButton => Driver.FindElement(By.CssSelector("div > div:nth-of-type(5) .icon-close"));
        IWebElement AddAnotherMilestoneButton => Driver.FindElement(By.XPath("//*[text()='Add Another Milestone']"));
        IWebElement AdditionalMilestoneDropdown => Driver.FindElement(By.XPath("//*[@class='milestone-list']/descendant::div[74]"));
        IWebElement AdditionalMilestoneSearchField => Driver.FindElement(By.CssSelector("div:nth-child(15) input"));
        // "Initiative Settings" tab
        IWebElement RealizedImpactCheckbox => Driver.FindElement(By.XPath("//*[@class='react-checkbox']"));
        IWebElement InitiativeCategoryDropdown => Driver.FindElement(By.XPath("//*[text()='Choose a category']"));
        IWebElement InitiativeCategorySearchField => Driver.FindElement(By.XPath("//*[@class='plain-dropdown-menu-with-search']//input"));
        IWebElement InitiativeCategory => Driver.FindElement(By.XPath("//*[@class='plain-dropdown-option--search-find']"));
        #endregion

        #region Actions
        public void EnterInitiativeName(string initiativeName)
        {
            wait.Until(Driver => NameField.Displayed);
            NameField.SendKeys(initiativeName);
        }

        public void EnterInitiativeDescription(string initiativeDescription)
        {
            DescriptionField.SendKeys(initiativeDescription);
        }

        public void SelectRevenueIncreaseInitiative()
        {
            wait.Until(Driver => InitiativeTypeDropdown.Displayed);
            InitiativeTypeDropdown.Click();
            wait.Until(Driver => RevenueIncreaseInitiative.Displayed);
            RevenueIncreaseInitiative.Click();
        }

        public void SelectTargetPercentInitiative()
        {
            wait.Until(Driver => InitiativeTypeDropdown.Displayed);
            InitiativeTypeDropdown.Click();
            wait.Until(Driver => TargetPercentInitiative.Displayed);
            TargetPercentInitiative.Click();
        }

        public void SelectTargetValueInitiative()
        {
            wait.Until(Driver => InitiativeTypeDropdown.Displayed);
            InitiativeTypeDropdown.Click();
            wait.Until(Driver => TargetValueInitiative.Displayed);
            TargetValueInitiative.Click();
        }

        public void SelectTeamLeads(string teamLead)
        {
            wait.Until(Driver => AddLeadButton.Enabled);
            executor.ExecuteScript("arguments[0].click();", AddLeadButton);
            SelectTeamMember(teamLead);
        }

        public void SelectStakeholders(string stakeholder)
        {
            wait.Until(Driver => AddStakeholderButton.Enabled);
            executor.ExecuteScript("arguments[0].click();", AddStakeholderButton);
            SelectTeamMember(stakeholder);
        }

        public void SelectTeamMember(string teamMember)
        {
            TeamMembersDropdown.Click();
            try
            {
                wait.Until(Driver => TeamMembersSearchField.Displayed);
                TeamMembersSearchField.SendKeys(teamMember);
                IAlert alert = Driver.SwitchTo().Alert();
                alert.Accept();
                alert.Dismiss();
            }
            catch (NoAlertPresentException)
            {
                Console.WriteLine("No such alert");
            }
            executor.ExecuteScript("arguments[0].click();", TeamMember);
        }

        public void EnterCurrentImpactValue(string impactValue)
        {
            CurrentImpactValue.SendKeys(impactValue);
        }

        public void EnterFirstFiscalYearImpactValue(string impactValue)
        {
            FirstFiscalYearImpactValue.SendKeys(impactValue);
        }

        public void EnterSecondFiscalYearImpactValue(string impactValue)
        {
            AddYearButton.Click();
            wait.Until(Driver => SelectYear.Displayed);
            SelectYear.Click();
            SecondFiscalYearImpactValue.SendKeys(impactValue);
        }

        public void SelectFinanceApproval()
        {
            FinanceApprovalCheckbox.Click();
        }

        public void SetCustomMilestone(string customMilestone, string date)
        {
            for (int i = 0; i <= 2; i++)
            {
                try
                {
                    executor.ExecuteScript("arguments[0].click();", CustomMilestoneDropdown);
                    executor.ExecuteScript("arguments[0].click();", AddCustomMilestoneButton);
                    break;
                }
                catch (StaleElementReferenceException)
                {
                    Console.WriteLine("Element is not attached to the page document");
                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine("No such element");
                }
            }
            CustomMilestoneField.Clear();
            CustomMilestoneField.SendKeys(customMilestone);
            CustomMilestoneDate.SendKeys(date);
        }

        public void ChangeDefaultMilestone(string defaultMilestone)
        {
            DefaultMilestoneDropdown.Click();
            wait.Until(Driver => DefaultMilestoneSearchField.Displayed);
            DefaultMilestoneSearchField.SendKeys(defaultMilestone);
            executor.ExecuteScript("arguments[0].click();", FilteredMilestone);
        }

        public void RemoveMilestone()
        {
            action.SendKeys(Keys.PageDown).Build().Perform();
            action.MoveToElement(RemoveMilestoneButton).Build().Perform();
            RemoveMilestoneButton.Click();
        }

        public void SetAdditionalMilestone(string additionalMilestone)
        {
            AddAnotherMilestoneButton.Click();
            AdditionalMilestoneDropdown.Click();
            wait.Until(Driver => AdditionalMilestoneSearchField.Displayed);
            AdditionalMilestoneSearchField.SendKeys(additionalMilestone);
            executor.ExecuteScript("arguments[0].click();", FilteredMilestone);
        }

        public void SelectSumRealizedImpact()
        {
            RealizedImpactCheckbox.Click();
        }

        public void SelectInitiativeCategory(string initiativeCategory)
        {
            InitiativeCategoryDropdown.Click();
            wait.Until(Driver => InitiativeCategorySearchField.Displayed);
            InitiativeCategorySearchField.SendKeys(initiativeCategory);
            executor.ExecuteScript("arguments[0].click();", InitiativeCategory);
        }

        public void ProceedToNextTab()
        {
            NextButton.Click();
        }

        public ReportPage CreateInitiative()
        {
            CreateButton.Click();
            return new ReportPage(Driver);
        }
        #endregion
    }
}