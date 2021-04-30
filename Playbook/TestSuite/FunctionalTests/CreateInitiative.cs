using NUnit.Framework;
using Playbook.BaseClasses;
using Playbook.Pages;

namespace FunctionalTests
{
    [TestFixture, Category("Functional Tests"), Order(1)]
    public class CreateInitiative : BaseClass
    {
        [SetUp]
        public void NavigateToInitiativeModal()
        {
            var loginPage = new LoginPage(Driver);
            var reportPage = loginPage.Login();
            reportPage.SelectOrganization("DEMO - Sample Facility");
            reportPage.OpenInitiativeModal();
        }

        [TearDown]
        public void InitiativeCreated()
        {
            var initiativeModal = new InitiativeModal(Driver);
            var reportPage = initiativeModal.CreateInitiative();
            Assert.That(reportPage.InitiativeSavedSuccessfully(), Is.True);
        }

        [Test, Category("Smoke Tests")]
        public void CreateCostReductionInitiative()
        {
            DeleteInitiativeFromDB("Cost Reduction Initiative"); // Deletes the initiative from the database, before creating a new one
            var initiativeModal = new InitiativeModal(Driver);
            initiativeModal.EnterInitiativeName("Cost Reduction Initiative");
            initiativeModal.EnterInitiativeDescription("Cost Reduction");
            initiativeModal.ProceedToNextTab();
            initiativeModal.EnterCurrentYearEstimatedImpactValue("1000000");
            initiativeModal.EnterNextYearEstimatedImpactValue("1125580");
            initiativeModal.ProceedToNextTab();
            initiativeModal.SetCustomMilestone("Capacity Utilization", DueDate);
            initiativeModal.ChangeDefaultMilestone("Implementation Planning");
            initiativeModal.RemoveMilestone();
            initiativeModal.SetAdditionalMilestone("Post-Implementation Review");
            initiativeModal.ProceedToNextTab();
            initiativeModal.SelectSumRealizedImpact();
            initiativeModal.SelectInitiativeCategory("SRT- Supplies");
        }

        [Test]
        public void CreateRevenueIncreaseInitiative()
        {
            DeleteInitiativeFromDB("Revenue Increase Initiative");
            var initiativeModal = new InitiativeModal(Driver);
            initiativeModal.EnterInitiativeName("Revenue Increase Initiative");
            initiativeModal.EnterInitiativeDescription("Revenue Increase");
            initiativeModal.SelectInitiativeType(InitiativeModal.RevenueIncrease);
            initiativeModal.SelectTeamLeads("Standart User");
            initiativeModal.ProceedToNextTab();
            initiativeModal.EnterCurrentYearEstimatedImpactValue("560595");
            initiativeModal.ProceedToNextTab();
            initiativeModal.SetCustomMilestone("Budget Variance", DueDate);
            initiativeModal.ChangeDefaultMilestone("Pilot / Demo Project Review");
            initiativeModal.ProceedToNextTab();
            initiativeModal.SelectInitiativeCategory("SRT- LOS Strategy");
        }

        [Test]
        public void CreateTargetPercentInitiative()
        {
            DeleteInitiativeFromDB("Target Percent Initiative");
            var initiativeModal = new InitiativeModal(Driver);
            initiativeModal.EnterInitiativeName("Target Percent Initiative");
            initiativeModal.SelectInitiativeType(InitiativeModal.TargetPercent);
            initiativeModal.SelectStakeholders("Admin User");
            initiativeModal.ProceedToNextTab();
            initiativeModal.EnterCurrentImpactValue("5.3");
            initiativeModal.EnterNextYearEstimatedImpactValue("6");
            initiativeModal.SelectFinanceApproval();
            initiativeModal.ProceedToNextTab();
            initiativeModal.SetCustomMilestone("Process / Practice Variation", DueDate);
            initiativeModal.ChangeDefaultMilestone("Go-Live");
            initiativeModal.RemoveMilestone();
            initiativeModal.SetAdditionalMilestone("Execution Complete");
            initiativeModal.ProceedToNextTab();
        }

        [Test]
        public void CreateTargetValueInitiative()
        {
            DeleteInitiativeFromDB("Target Value Initiative");
            var initiativeModal = new InitiativeModal(Driver);
            initiativeModal.EnterInitiativeName("Target Value Initiative");
            initiativeModal.SelectInitiativeType(InitiativeModal.TargetValue);
            initiativeModal.SelectTeamLeads("Standart User");
            initiativeModal.SelectStakeholders("Admin User");
            initiativeModal.ProceedToNextTab();
            initiativeModal.EnterCurrentImpactValue("878300");
            initiativeModal.EnterCurrentYearEstimatedImpactValue("988255");
            initiativeModal.EnterNextYearEstimatedImpactValue("1550000");
            initiativeModal.SelectFinanceApproval();
            initiativeModal.ProceedToNextTab();
            initiativeModal.SetCustomMilestone("Root Cause Analysis", DueDate);
            initiativeModal.RemoveMilestone();
            initiativeModal.ProceedToNextTab();
            initiativeModal.SelectSumRealizedImpact();
        }
    }
}