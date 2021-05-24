using OpenQA.Selenium;
using Playbook.BaseClasses;

namespace Playbook.Pages
{
    public class ReportPage : BasePage
    {
        public ReportPage(IWebDriver driver) : base(driver) { }

        #region WebElements
        private readonly By CreateInitiativeButton = By.XPath("//*[text()='Create Initiative']");
        private readonly By InitiativeSavedMessage = By.XPath("//*[text()='Initiative saved successfully']");
        // Report navigation
        private readonly By OrganizationDropdown = By.XPath("//*[text()='Organization']//parent::*//following-sibling::button");
        private readonly By OrganizationSearchField = By.XPath("//*[@placeholder='Start typing']");
        private readonly By Organization = By.XPath("//*[@class='h-dropdown-item--search-find']");
        private readonly By InitiativeInclusionDropdown = By.XPath("//*[text()='Initiative Inclusion']//parent::*//following-sibling::button");
        public static By ExcludePreliminaryInitiatives = By.XPath("//*[@class='ellipsis'][text()='Exclude preliminary initiatives']");
        public static By ExcludeApprovedInitiatives = By.XPath("//*[@class='ellipsis'][text()='Exclude approved initiatives']");
        private readonly By InitiativeYearDropdown = By.XPath("//*[text()='Initiative Year']//parent::*//following-sibling::button");
        private readonly By YearSearchField = By.XPath("//*[@class='plain-dropdown-menu-with-search']/descendant::input");
        private readonly By Year = By.XPath("//*[@class='plain-dropdown-option--search-find']");
        // "Progress" tab
        private readonly By ProgressReport = By.XPath("//*[@class='playbook-goal-report__progress']");
        // "Initiatives" tab
        private readonly By InitiativesTab = By.XPath("//*[text()='Initiatives']");
        public static By RevenueIncrease = By.XPath("//*[text()='Revenue Increase']");
        public static By TargetPercent = By.XPath("//*[text()='Target Percent']");
        public static By TargetValue = By.XPath("//*[text()='Target Value']");
        private readonly By InitiativeSearchField = By.XPath("//*[@class='au-table']//input");
        private readonly By Initiative = By.XPath("//*[@class='au-table']//a");
        #endregion

        #region Actions
        public void SelectOrganization(string organization)
        {
            WaitUntilElementIsClickable(OrganizationDropdown);
            OrganizationDropdown.Click(Driver);
            WaitUntilElementIsVisible(OrganizationSearchField);
            OrganizationSearchField.SendKeys(organization, Driver);
            Organization.Click(Driver);
        }

        public void SelectInitiativeInclusionOption(By InclusionOption)
        {
            WaitUntilElementIsClickable(InitiativeInclusionDropdown);
            InitiativeInclusionDropdown.Click(Driver);
            WaitUntilElementIsClickable(InclusionOption);
            InclusionOption.Click(Driver);
        }

        public void SelectInitiativeYear(string year)
        {
            InitiativeYearDropdown.Click(Driver);
            WaitUntilElementIsVisible(YearSearchField);
            YearSearchField.SendKeys(year, Driver);
            Year.Click(Driver);
        }

        public InitiativeModal OpenInitiativeModal()
        {
            CreateInitiativeButton.Click(Driver);
            return new InitiativeModal(Driver);
        }

        public bool InitiativeSavedSuccessfully()
        {
            WaitUntilElementIsVisible(ProgressReport);
            return InitiativeSavedMessage.Displayed(Driver);
        }

        public void SelectInitiativesTab()
        {
            WaitUntilElementIsClickable(InitiativesTab);
            InitiativesTab.Click(Driver);
        }

        public void SelectInitiativeType(By InitiativeType)
        {
            InitiativeType.Click(Driver);
        }

        public ManageInitiativePage OpenInitiave(string initiativeName)
        {
            InitiativeSearchField.SendKeys(initiativeName, Driver);
            Initiative.Click(Driver);
            return new ManageInitiativePage(Driver);
        }
        #endregion
    }
}