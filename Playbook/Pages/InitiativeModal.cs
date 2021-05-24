using OpenQA.Selenium;
using Playbook.BaseClasses;

namespace Playbook.Pages
{
    public class InitiativeModal : BasePage
    {
        public InitiativeModal(IWebDriver driver) : base(driver) { }
        
        #region WebElements
        private readonly By NextButton = By.XPath("//*[text()='Next']");
        private readonly By CreateButton = By.XPath("//*[text()='Create']");
        // "Describe The Initiative" tab
        private readonly By NameField = By.XPath("//*[@placeholder='Enter a short name']");
        private readonly By InitiativeTypeDropdown = By.XPath("//*[@class='playbook-new-initiative-form__field']//*[@class='dropdown-toggler__value ellipsis']");
        public static By CostReduction = By.XPath("//*[text()='Cost Reduction ($)']");
        public static By RevenueIncrease = By.XPath("//*[text()='Revenue Increase ($)']");
        public static By TargetPercent = By.XPath("//*[text()='Target Percent (%)']");
        public static By TargetValue = By.XPath("//*[text()='Target Value']");
        private readonly By DescriptionField = By.XPath("//*[@class='textarea-field']//textarea");
        private readonly By AddLeadButton = By.XPath("//*[text()='lead']");
        private readonly By TeamMembersDropdown = By.XPath("//*[text()='Find team members']");
        private readonly By TeamMembersSearchField = By.XPath("//*[@class='plain-dropdown-menu-with-search']//descendant::input");
        private readonly By TeamMember = By.XPath("//*[@class='plain-dropdown-option plain-dropdown-option--focused']");
        private readonly By AddStakeholderButton = By.XPath("//*[text()='stakeholder']");
        // "Estimate Impact" tab
        private readonly By CurrentImpactField = By.Id("current_budget_impact_amount");
        private readonly By AddYearButton = By.XPath("//*[text()='Add Year']");
        private readonly By CurrentYearEstimatedImpactField = By.XPath("//*[text()='" + BaseClass.CurrentYear + "']/following-sibling::div//input");
        private readonly By CurrentYear = By.XPath("//*[@class='dropdown-menu']//*[text()='"+ BaseClass.CurrentYear + "']");
        private readonly By NextYearEstimatedImpactField = By.XPath("//*[text()='" + BaseClass.NextYear + "']/following-sibling::div//input");
        private readonly By NextYear = By.XPath("//*[@class='dropdown-menu']//*[text()='" + BaseClass.NextYear + "']");
        private readonly By FinanceApprovalCheckbox = By.XPath("//*[@class='react-checkbox playbook-budget-impact-form__checkbox']");
        // "Set Milestones" tab
        private readonly By CustomMilestoneDropdown = By.XPath("//*[@class='milestone-list']/descendant::div[19]");
        private readonly By AddCustomMilestoneButton = By.XPath("//*[text()='Add Custom Milestone']");
        private readonly By CustomMilestoneField = By.XPath("//*[@class='milestone-list']/descendant::input[2]");
        private readonly By CustomMilestoneDate = By.XPath("//*[@class='milestone-list']/descendant::input[3]");
        private readonly By DefaultMilestoneDropdown = By.XPath("//*[@class='milestone-list']/descendant::button[6]");
        private readonly By DefaultMilestoneSearchField = By.XPath("//*[@class='plain-dropdown-menu-with-search']/descendant::input");
        private readonly By Milestone = By.XPath("//*[@class='plain-dropdown-option']");
        private readonly By RemoveMilestoneButton = By.CssSelector("div > div:nth-of-type(5) .icon-close");
        private readonly By AddAnotherMilestoneButton = By.XPath("//*[text()='Add Another Milestone']");
        private readonly By AdditionalMilestoneDropdown = By.XPath("//*[@class='milestone-list']/descendant::div[74]");
        private readonly By AdditionalMilestoneSearchField = By.CssSelector("div:nth-child(15) input");
        // "Initiative Settings" tab
        private readonly By RealizedImpactCheckbox = By.XPath("//*[@class='react-checkbox']");
        private readonly By InitiativeCategoryDropdown = By.XPath("//*[text()='Choose a category']");
        private readonly By InitiativeCategorySearchField = By.XPath("//*[@class='plain-dropdown-menu-with-search']//input");
        private readonly By InitiativeCategory = By.XPath("//*[@class='plain-dropdown-option--search-find']");
        #endregion

        #region Actions
        public void EnterInitiativeName(string initiativeName)
        {
            WaitUntilElementIsVisible(NameField);
            NameField.SendKeys(initiativeName, Driver);
        }

        public void EnterInitiativeDescription(string initiativeDescription)
        {
            DescriptionField.SendKeys(initiativeDescription, Driver);
        }

        public void SelectInitiativeType(By InitiativeType)
        {
            WaitUntilElementIsClickable(InitiativeTypeDropdown);
            InitiativeTypeDropdown.Click(Driver);
            WaitUntilElementIsClickable(InitiativeType);
            InitiativeType.Click(Driver);
        }

        public void SelectTeamLeads(string teamLead)
        {
            WaitUntilElementIsClickable(AddLeadButton);
            AddLeadButton.JSExecutorClick(Driver);
            SelectTeamMember(teamLead);
        }

        public void SelectStakeholders(string stakeholder)
        {
            WaitUntilElementIsClickable(AddStakeholderButton);
            AddStakeholderButton.JSExecutorClick(Driver);
            SelectTeamMember(stakeholder);
        }

        private void SelectTeamMember(string teamMember)
        {
            TeamMembersDropdown.Click(Driver);
            try
            {
                WaitUntilElementIsVisible(TeamMembersSearchField);
                TeamMembersSearchField.SendKeys(teamMember, Driver);
                IAlert alert = Driver.SwitchTo().Alert();
                for (int i = 0; i <= 6; i++)
                {
                    alert.Dismiss();
                }
            }
            catch (NoAlertPresentException) { }
            TeamMember.JSExecutorClick(Driver);
        }

        public void EnterCurrentImpactValue(string impactValue)
        {
            CurrentImpactField.SendKeys(impactValue, Driver);
        }

        public void EnterCurrentYearEstimatedImpactValue(string impactValue)
        {
            AddYearButton.Click(Driver);
            WaitUntilElementIsClickable(CurrentYear);
            CurrentYear.Click(Driver);
            CurrentYearEstimatedImpactField.SendKeys(impactValue, Driver);
        }

        public void EnterNextYearEstimatedImpactValue(string impactValue)
        {
            AddYearButton.Click(Driver);
            WaitUntilElementIsClickable(NextYear);
            NextYear.Click(Driver);
            NextYearEstimatedImpactField.SendKeys(impactValue, Driver);
        }

        public void SelectFinanceApproval()
        {
            FinanceApprovalCheckbox.Click(Driver);
        }

        public void SetCustomMilestone(string customMilestone, string date)
        {
            for (int i = 0; i <= 2; i++)
            {
                try
                {
                    WaitUntilElementIsClickable(CustomMilestoneDropdown);
                    CustomMilestoneDropdown.JSExecutorClick(Driver);
                    AddCustomMilestoneButton.JSExecutorClick(Driver);
                    break;
                }
                catch (NoSuchElementException) { }
            }
            CustomMilestoneField.Clear(Driver);
            CustomMilestoneField.SendKeys(customMilestone, Driver);
            CustomMilestoneDate.SendKeys(date, Driver);
        }

        public void ChangeDefaultMilestone(string defaultMilestone)
        {
            DefaultMilestoneDropdown.Click(Driver);
            DefaultMilestoneSearchField.SendKeys(defaultMilestone, Driver);
            Milestone.Click(Driver);
        }

        public void RemoveMilestone()
        {
            RemoveMilestoneButton.Click(Driver);
        }

        public void SetAdditionalMilestone(string additionalMilestone)
        {
            AddAnotherMilestoneButton.Click(Driver);
            AdditionalMilestoneDropdown.Click(Driver);
            WaitUntilElementIsVisible(AdditionalMilestoneSearchField);
            AdditionalMilestoneSearchField.SendKeys(additionalMilestone, Driver);
            Milestone.Click(Driver);
        }

        public void SelectSumRealizedImpact()
        {
            RealizedImpactCheckbox.Click(Driver);
        }

        public void SelectInitiativeCategory(string initiativeCategory)
        {
            InitiativeCategoryDropdown.Click(Driver);
            WaitUntilElementIsVisible(InitiativeCategorySearchField);
            InitiativeCategorySearchField.SendKeys(initiativeCategory, Driver);
            InitiativeCategory.JSExecutorClick(Driver);
        }

        public void ProceedToNextTab()
        {
            NextButton.Click(Driver);
        }

        public ReportPage CreateInitiative()
        {
            CreateButton.Click(Driver);
            return new ReportPage(Driver);
        }
        #endregion
    }
}