﻿using TechTalk.SpecFlow;
using Playbook.Pages;
using Playbook.BaseClasses;
using NUnit.Framework;

namespace Playbook.StepDefinition
{
    [Binding]
    public sealed class VerifyInitiativeDetails : BaseClass
    {
        [Given("A user opens the initiative tab")]
        public void NavigateToInitiativeTab()
        {
            var loginPage = new LoginPage(Driver);
            var reportPage = loginPage.Login();
            reportPage.SelectOrganization("DEMO - Sample Facility");
            reportPage.SelectInitiativesTab();
        }

        [When(@"A user navigates to the revenue increase initiative page")]
        public void SelectRevenueIncreaseInitiativeType()
        {
            new ReportPage(Driver).SelectInitiativeType(ReportPage.RevenueIncrease);
        }

        [When(@"A user navigates to the target percent initiative page")]
        public void SelectTargetPercentInitiativeType()
        {
            new ReportPage(Driver).SelectInitiativeType(ReportPage.TargetPercent);
        }

        [When(@"A user navigates to the target value initiative page")]
        public void SelectTargetValueInitiativeType()
        {
            new ReportPage(Driver).SelectInitiativeType(ReportPage.TargetValue);
        }

        [Then("A user verifies the initiative details")]
        public void InitiativeDetails(Table table)
        {
            foreach (var row in table.Rows)
            {
                var reportPage = new ReportPage(Driver);
                var manageInitiativePage = reportPage.OpenInitiave(row["Initiative Name"]);
                Assert.AreEqual(row["Initiative Name"], manageInitiativePage.InitiativeName());
                Assert.AreEqual(row["Finance Approval Status"], manageInitiativePage.FinanceApprovalStatus());
                Assert.AreEqual(row["Initiative Type"], manageInitiativePage.InitiativeType());
                Assert.AreEqual(row["Initiative Status"], manageInitiativePage.InitiativeStatus());
                Assert.AreEqual(row["Initiative Category"], manageInitiativePage.InitiativeCategory());
                Assert.AreEqual(row["Current Year Estimated Impact"], manageInitiativePage.CurrentYearEstimatedImpact());
                Assert.AreEqual(row["Next Year Estimated Impact"], manageInitiativePage.NextYearEstimatedImpact());
                Assert.AreEqual(row["Initiative Description"], manageInitiativePage.InitiativeDescription());
            }
        }

        [Then(@"A user verifies the created date")]
        public void CreatedDate()
        {
            Assert.AreEqual(CurrentDate, new ManageInitiativePage(Driver).CreatedDate());
        }
    }
}