using TechTalk.SpecFlow;
using Playbook.Pages;
using Playbook.BaseClasses;
using NUnit.Framework;

namespace Playbook.StepDefinition
{
    [Binding]
    public sealed class CreateInitiative : BaseClass
    {
        [Given("A user opens the initiative modal")]
        public void NavigateToInitiativeModal()
        {
            var loginPage = new LoginPage(Driver);
            var reportPage = loginPage.Login();
            reportPage.SelectOrganization("DEMO - Sample Facility");
            reportPage.OpenInitiativeModal();
        }

        [Given(@"A user selects cost reduction initiative type")]
        public void SelectCostReductionInitiativeType()
        {
            DeleteInitiativeFromDB("Cost Reduction Initiative"); // Deletes the initiative from the database, before creating a new one
            new InitiativeModal(Driver).SelectInitiativeType(InitiativeModal.CostReduction);
        }

        [Given(@"A user selects revenue increase initiative type")]
        public void SelectRevenueIncreaseInitiativeType()
        {
            DeleteInitiativeFromDB("Revenue Increase Initiative");
            new InitiativeModal(Driver).SelectInitiativeType(InitiativeModal.RevenueIncrease);
        }

        [Given(@"A user selects target percent initiative type")]
        public void SelectTargetPercentInitiativeType()
        {
            DeleteInitiativeFromDB("Target Percent Initiative");
            new InitiativeModal(Driver).SelectInitiativeType(InitiativeModal.TargetPercent);
        }

        [Given(@"A user selects target value initiative type")]
        public void SelectTargetValueInitiativeType()
        {
            DeleteInitiativeFromDB("Target Value Initiative");
            new InitiativeModal(Driver).SelectInitiativeType(InitiativeModal.TargetValue);
        }

        [When("A user enters the initiative details")]
        public void EnterInitiativeDetails(Table table)
        {
            foreach (var row in table.Rows)
            {
                var initiativeModal = new InitiativeModal(Driver);
                initiativeModal.EnterInitiativeName(row["Initiative Name"]);
                initiativeModal.EnterInitiativeDescription(row["Description"]);
                initiativeModal.ProceedToNextTab();
                initiativeModal.EnterCurrentYearEstimatedImpactValue(row["Current Year Estimated Impact"]);
                initiativeModal.EnterNextYearEstimatedImpactValue(row["Next Year Estimated Impact"]);
                initiativeModal.ProceedToNextTab();
                initiativeModal.SetCustomMilestone(row["Custom Milestone Name"], DueDate);
                initiativeModal.ProceedToNextTab();
                initiativeModal.SelectInitiativeCategory(row["Initiative Category"]);
                initiativeModal.CreateInitiative();
            }
        }

        [Then("A user verifies the the initiative has been created")]
        public void InitiativeCreated()
        {
            Assert.That(new ReportPage(Driver).InitiativeSavedSuccessfully(), Is.True);
        }
    }
}