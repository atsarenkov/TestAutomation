using NUnit.Framework;
using Playbook.BaseClasses;
using Playbook.Pages;
using System;

namespace Playbook.Regression_Suite
{
    [TestFixture, Order(1)]
    public class CreateInitiative : BaseClass
    {
        new readonly string DueDate = DateTime.Now.AddDays(180).ToString();

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

        [Test, Category("Smoke Test")]
        public void CostReductionInitiative()
        {
            var initiativeModal = new InitiativeModal(Driver);
            initiativeModal.EnterInitiativeName("Cost Reduction Initiative");
            initiativeModal.EnterInitiativeDescription("Cost Reduction");
            initiativeModal.ProceedToNextTab();
            initiativeModal.EnterFirstFiscalYearImpactValue("1000000");
            initiativeModal.EnterSecondFiscalYearImpactValue("1125580");
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
        public void RevenueIncreaseInitiative()
        {
            var initiativeModal = new InitiativeModal(Driver);
            initiativeModal.EnterInitiativeName("Revenue Increase Initiative");
            initiativeModal.EnterInitiativeDescription("Revenue Increase");
            initiativeModal.SelectRevenueIncreaseInitiative();
            initiativeModal.SelectTeamLeads("Standart User");
            initiativeModal.ProceedToNextTab();
            initiativeModal.EnterFirstFiscalYearImpactValue("560595");
            initiativeModal.ProceedToNextTab();
            initiativeModal.SetCustomMilestone("Budget Variance", DueDate);
            initiativeModal.ChangeDefaultMilestone("Pilot / Demo Project Review");
            initiativeModal.ProceedToNextTab();
            initiativeModal.SelectInitiativeCategory("SRT- LOS Strategy");
        }

        [Test]
        public void TargetPercentInitiative()
        {
            var initiativeModal = new InitiativeModal(Driver);
            initiativeModal.EnterInitiativeName("Target Percent Initiative");
            initiativeModal.SelectTargetPercentInitiative();
            initiativeModal.SelectStakeholders("Admin User");
            initiativeModal.ProceedToNextTab();
            initiativeModal.EnterCurrentImpactValue("5.3");
            initiativeModal.EnterFirstFiscalYearImpactValue("6");
            initiativeModal.SelectFinanceApproval();
            initiativeModal.ProceedToNextTab();
            initiativeModal.SetCustomMilestone("Process / Practice Variation", DueDate);
            initiativeModal.ChangeDefaultMilestone("Go-Live");
            initiativeModal.RemoveMilestone();
            initiativeModal.SetAdditionalMilestone("Execution Complete");
            initiativeModal.ProceedToNextTab();
        }

        [Test]
        public void TargetValueInitiative()
        {
            var initiativeModal = new InitiativeModal(Driver);
            initiativeModal.EnterInitiativeName("Target Value Initiative");
            initiativeModal.SelectTargetValueInitiative();
            initiativeModal.SelectTeamLeads("Standart User");
            initiativeModal.SelectStakeholders("Admin User");
            initiativeModal.ProceedToNextTab();
            initiativeModal.EnterCurrentImpactValue("878300");
            initiativeModal.EnterFirstFiscalYearImpactValue("988255");
            initiativeModal.EnterSecondFiscalYearImpactValue("1550000");
            initiativeModal.SelectFinanceApproval();
            initiativeModal.ProceedToNextTab();
            initiativeModal.SetCustomMilestone("Root Cause Analysis", DueDate);
            initiativeModal.RemoveMilestone();
            initiativeModal.ProceedToNextTab();
            initiativeModal.SelectSumRealizedImpact();
        }
    }
}