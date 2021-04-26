using NUnit.Framework;
using Playbook.BaseClasses;
using Playbook.Pages;

namespace VisualTests
{
    [TestFixture, Category("Visual Tests")]
    public class VerifyReportingTab : BaseClass
    {
        [SetUp]
        public void NavigateToProgressTab()
        {
            var loginPage = new LoginPage(Driver);
            var reportPage = loginPage.Login();
            reportPage.SelectOrganization("DEMO - Sample Facility");
            reportPage.SelectInitiativesTab();
        }

        [Test]
        public void CostReductionInitiativeReporting()
        {
            var reportPage = new ReportPage(Driver);
            var manageInitiativePage = reportPage.OpenInitiave("Cost Reduction Initiative");
            manageInitiativePage.NavigateToReportingTab();
            CheckRegion("Cost Reduction Initiative Reporting", ManageInitiativePage.ReportingSection);
        }

        [Test]
        public void RevenueIncreaseInitiativeReporting()
        {
            var reportPage = new ReportPage(Driver);
            reportPage.SelectInitiativeType(ReportPage.RevenueIncrease);
            var manageInitiativePage = reportPage.OpenInitiave("Revenue Increase Initiative");
            manageInitiativePage.NavigateToReportingTab();
            CheckRegion("Revenue Increase Initiative Reporting", ManageInitiativePage.ReportingSection);
        }

        [Test]
        public void TargetPercentInitiativeReporting()
        {
            var reportPage = new ReportPage(Driver);
            reportPage.SelectInitiativeType(ReportPage.TargetPercent);
            var manageInitiativePage = reportPage.OpenInitiave("Target Percent Initiative");
            manageInitiativePage.NavigateToReportingTab();
            CheckRegion("Target Percent Initiative Reporting", ManageInitiativePage.ReportingSection);
        }

        [Test]
        public void ToTargetValueInitiativeReporting()
        {
            var reportPage = new ReportPage(Driver);
            reportPage.SelectInitiativeType(ReportPage.TargetValue);
            var manageInitiativePage = reportPage.OpenInitiave("Target Value Initiative");
            manageInitiativePage.NavigateToReportingTab();
            CheckRegion("Target Value Initiative Reporting", ManageInitiativePage.ReportingSection);
        }
    }
}
