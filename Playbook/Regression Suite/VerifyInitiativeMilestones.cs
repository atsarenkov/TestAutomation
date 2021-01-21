using NUnit.Framework;
using Playbook.BaseClasses;
using Playbook.Pages;

namespace Playbook.Regression_Suite
{
    [TestFixture, Order(3)]
    public class VerifyInitiativeMilestones : BaseClass
    {
        [SetUp]
        public void NavigateToInitiativeTab()
        {
            var loginPage = new LoginPage(Driver);
            var reportPage = loginPage.Login();
            reportPage.SelectOrganization("DEMO - Sample Facility");
            reportPage.SelectInitiavesTab();
        }

        [TearDown]
        public void CommonInitiativeMilestones()
        {
            var manageInitiativePage = new ManageInitiativePage(Driver);
            Assert.AreEqual("Initiative Launch Due: " + CurrentDate + " To Do", manageInitiativePage.FirstMilestone());
            Assert.AreEqual("Impact Assessment, No Due Date, To Do", manageInitiativePage.FourthMilestone());
        }

        [Test, Category("Smoke Test")]
        public void CostReductionInitiativeMilestones()
        {
            var reportPage = new ReportPage(Driver);
            var manageInitiativePage = reportPage.OpenInitiave("Cost Reduction Initiative");
            Assert.AreEqual("Capacity Utilization Due: " + DueDate + " To Do", manageInitiativePage.SecondMilestone());
            Assert.AreEqual("Implementation Planning, No Due Date, To Do", manageInitiativePage.ThirdMilestone());
            Assert.AreEqual("Implementation, No Due Date, To Do", manageInitiativePage.FifthMilestone());
            Assert.AreEqual("Information / Data Collection, No Due Date, To Do", manageInitiativePage.SixthMilestone());
            Assert.AreEqual("Post-Implementation Review, No Due Date, To Do", manageInitiativePage.SeventhMilestone());
        }

        [Test]
        public void RevenueIncreaseInitiativeMilestones()
        {
            var reportPage = new ReportPage(Driver);
            reportPage.NavigateToRevenueIncreaseInitiatives();
            var manageInitiativePage = reportPage.OpenInitiave("Revenue Increase Initiative");
            Assert.AreEqual("Budget Variance Due: " + DueDate + " To Do", manageInitiativePage.SecondMilestone());
            Assert.AreEqual("Pilot / Demo Project Review, No Due Date, To Do", manageInitiativePage.ThirdMilestone());
            Assert.AreEqual("Implementation Planning, No Due Date, To Do", manageInitiativePage.FifthMilestone());
            Assert.AreEqual("Implementation, No Due Date, To Do", manageInitiativePage.SixthMilestone());
            Assert.AreEqual("Information / Data Collection, No Due Date, To Do", manageInitiativePage.SeventhMilestone());
        }

        [Test]
        public void TargetPercentInitiativeMilestones()
        {
            var reportPage = new ReportPage(Driver);
            reportPage.NavigateToTargetPercentInitiatives();
            var manageInitiativePage = reportPage.OpenInitiave("Target Percent Initiative");
            Assert.AreEqual("Process / Practice Variation Due: " + DueDate + " To Do", manageInitiativePage.SecondMilestone());
            Assert.AreEqual("Go-Live, No Due Date, To Do", manageInitiativePage.ThirdMilestone());
            Assert.AreEqual("Implementation, No Due Date, To Do", manageInitiativePage.FifthMilestone());
            Assert.AreEqual("Information / Data Collection, No Due Date, To Do", manageInitiativePage.SixthMilestone());
            Assert.AreEqual("Execution Complete, No Due Date, To Do", manageInitiativePage.SeventhMilestone());
        }

        [Test]
        public void TargetValueInitiativeMilestones()
        {
            var reportPage = new ReportPage(Driver);
            reportPage.NavigateToTargetValueInitiatives();
            var manageInitiativePage = reportPage.OpenInitiave("Target Value Initiative");
            Assert.AreEqual("Root Cause Analysis Due: " + DueDate + " To Do", manageInitiativePage.SecondMilestone());
            Assert.AreEqual("Solution Development, No Due Date, To Do", manageInitiativePage.ThirdMilestone());
            Assert.AreEqual("Implementation, No Due Date, To Do", manageInitiativePage.FifthMilestone());
            Assert.AreEqual("Information / Data Collection, No Due Date, To Do", manageInitiativePage.SixthMilestone());
        }
    }
}