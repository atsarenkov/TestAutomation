using NUnit.Framework;
using Playbook.BaseClasses;
using Playbook.Pages;

namespace VisualTests
{
    [TestFixture, Category("Visual Tests")]
    public class VerifyProgressTab : BaseClass
    {
        [SetUp]
        public void NavigateToProgressTab()
        {
            var loginPage = new LoginPage(Driver);
            var reportPage = loginPage.Login();
            reportPage.SelectOrganization("DEMO - Sample Facility");
        }

        [Test]
        public void IncludeAllInitiatives()
        {
            CheckWindow("Include all initiatives");
        }

        [Test]
        public void ExcludePreliminaryInitiatives()
        {
            var reportPage = new ReportPage(Driver);
            reportPage.SelectInitiativeInclusionOption(ReportPage.ExcludePreliminaryInitiatives);
            CheckWindow("Exclude preliminary initiatives");
        }

        [Test]
        public void ExcludeApprovedInitiatives()
        {
            var reportPage = new ReportPage(Driver);
            reportPage.SelectInitiativeInclusionOption(ReportPage.ExcludeApprovedInitiatives);
            CheckWindow("Exclude approved initiatives");
        }
    }
}
