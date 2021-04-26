using NUnit.Framework;
using Playbook.BaseClasses;
using Playbook.Pages;

namespace FunctionalTests
{
    [TestFixture, Category("Functional Tests"), Order(2)]
    public class VerifyInitiativeDetails : BaseClass
    {
        [SetUp]
        public void NavigateToInitiativeTab()
        {
            var loginPage = new LoginPage(Driver);
            var reportPage = loginPage.Login();
            reportPage.SelectOrganization("DEMO - Sample Facility");
            reportPage.SelectInitiativesTab();
            reportPage.SelectInitiativeYear(CurrentYear);
        }

        [TearDown]
        public void CommonDetails()
        {
            var manageInitiativePage = new ManageInitiativePage(Driver);
            Assert.AreEqual("On Track", manageInitiativePage.InitiativeStatus());
            Assert.AreEqual("Standart User", manageInitiativePage.CreatedBy());
            Assert.AreEqual(CurrentDate, manageInitiativePage.CreatedDate());
        }

        [Test, Category("Smoke Tests")]
        public void CostReductionInitiativeDetails()
        {
            var reportPage = new ReportPage(Driver);
            var manageInitiativePage = reportPage.OpenInitiave("Cost Reduction Initiative");
            Assert.AreEqual("Cost Reduction Initiative", manageInitiativePage.InitiativeName());
            Assert.AreEqual("Needs Finance Approval", manageInitiativePage.FinanceApprovalStatus());
            Assert.That(manageInitiativePage.EnterRealizedImpactButtonEnabled(), Is.False, "The Enter Realized Impact Button Was Enabled");
            Assert.AreEqual("Cost Reduction", manageInitiativePage.InitiativeType());
            Assert.AreEqual("SRT- Supplies", manageInitiativePage.InitiativeCategory());
            Assert.AreEqual(CurrentYear + " Estimated $1M", manageInitiativePage.CurrentYearEstimatedImpact());
            Assert.AreEqual(NextYear + " Estimated $1.1M", manageInitiativePage.NextYearEstimatedImpact());
            Assert.AreEqual("Cost Reduction", manageInitiativePage.InitiativeDescription());
            Assert.AreEqual("There are no leads assigned to this initiative", manageInitiativePage.InitiativeLead());
            Assert.AreEqual("There are no stakeholders assigned to this initiative", manageInitiativePage.InitiativeStakeholder());
            Assert.AreEqual("Standart User", manageInitiativePage.ModifiedBy());
            Assert.AreEqual(CurrentDate, manageInitiativePage.ModifiedDate());
        }

        [Test]
        public void RevenueIncreaseInitiativeDetails()
        {
            var reportPage = new ReportPage(Driver);
            reportPage.SelectInitiativeType(ReportPage.RevenueIncrease);
            var manageInitiativePage = reportPage.OpenInitiave("Revenue Increase Initiative");
            Assert.AreEqual("Revenue Increase Initiative", manageInitiativePage.InitiativeName());
            Assert.AreEqual("Needs Finance Approval", manageInitiativePage.FinanceApprovalStatus());
            Assert.That(manageInitiativePage.EnterRealizedImpactButtonEnabled(), Is.False, "The Enter Realized Impact Button Was Enabled");
            Assert.AreEqual("Revenue Increase", manageInitiativePage.InitiativeType());
            Assert.AreEqual("SRT- LOS Strategy", manageInitiativePage.InitiativeCategory());
            Assert.AreEqual(CurrentYear + " Estimated $560.6K", manageInitiativePage.CurrentYearEstimatedImpact());
            Assert.AreEqual("Revenue Increase", manageInitiativePage.InitiativeDescription());
            Assert.AreEqual("SU, Standart User, QA", manageInitiativePage.InitiativeLead());
            Assert.AreEqual("There are no stakeholders assigned to this initiative", manageInitiativePage.InitiativeStakeholder());
            Assert.AreEqual("Standart User", manageInitiativePage.ModifiedBy());
            Assert.AreEqual(CurrentDate, manageInitiativePage.ModifiedDate());
        }

        [Test]
        public void TargetPercentInitiativeDetails()
        {
            var reportPage = new ReportPage(Driver);
            reportPage.SelectInitiativeType(ReportPage.TargetPercent);
            var manageInitiativePage = reportPage.OpenInitiave("Target Percent Initiative");
            Assert.AreEqual("Target Percent Initiative", manageInitiativePage.InitiativeName());
            Assert.AreEqual("Approved by Finance", manageInitiativePage.FinanceApprovalStatus());
            Assert.That(manageInitiativePage.EnterRealizedImpactButtonEnabled(), Is.True, "The Enter Realized Impact Button Was Disabled");
            Assert.AreEqual("Target Percent", manageInitiativePage.InitiativeType());
            Assert.AreEqual("Select value", manageInitiativePage.InitiativeCategory());
            Assert.AreEqual(NextYear + " Estimated 6%", manageInitiativePage.NextYearEstimatedImpact());
            Assert.That(manageInitiativePage.InitiativeDescription(), Is.Empty);
            Assert.AreEqual("There are no leads assigned to this initiative", manageInitiativePage.InitiativeLead());
            Assert.AreEqual("AU, Admin User, QA", manageInitiativePage.InitiativeStakeholder());
        }

        [Test]
        public void TargetValueInitiativeDetails()
        {
            var reportPage = new ReportPage(Driver);
            reportPage.SelectInitiativeType(ReportPage.TargetValue);
            var manageInitiativePage = reportPage.OpenInitiave("Target Value Initiative");
            Assert.AreEqual("Target Value Initiative", manageInitiativePage.InitiativeName());
            Assert.AreEqual("Approved by Finance", manageInitiativePage.FinanceApprovalStatus());
            Assert.That(manageInitiativePage.EnterRealizedImpactButtonEnabled(), Is.True, "The Enter Realized Impact Button Was Disabled");
            Assert.AreEqual("Target Value", manageInitiativePage.InitiativeType());
            Assert.AreEqual("Select value", manageInitiativePage.InitiativeCategory());
            Assert.AreEqual(CurrentYear + " 878.3K of 988.3K", manageInitiativePage.CurrentYearEstimatedImpact());
            Assert.AreEqual(NextYear + " 878.3K of 1.6M", manageInitiativePage.NextYearEstimatedImpact());
            Assert.That(manageInitiativePage.InitiativeDescription(), Is.Empty);
            Assert.AreEqual("SU, Standart User, QA", manageInitiativePage.InitiativeLead());
            Assert.AreEqual("AU, Admin User, QA", manageInitiativePage.InitiativeStakeholder());
        }
    }
}