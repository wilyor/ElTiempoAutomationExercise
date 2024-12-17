using AventStack.ExtentReports;
using ElTiempoAutomation.Drivers;
using ElTiempoAutomation.Pages;
using ElTiempoAutomation.Support;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ElTiempoAutomation.StepDefinitions
{
    [Binding]
    public class VerifyClimateStepDefinitions
    {
        private IWebDriver _driver;
        private HomePage _homePage;
        private ZonePage _zonePage;

        private ExtentTest _test;

        public VerifyClimateStepDefinitions()
        {
            _driver = WebDriverManager.driver;
            _homePage = new HomePage(_driver);
            _test = ReportManager._test;
        }

        [Given(@"climate page is open")]
        public void GivenClimatePageIsOpen()
        {
            _homePage.NavigateToPage();
        }

        [When(@"I search for ""([^""]*)""")]
        public void WhenISearchFor(string city)
        {
            _test.CreateNode("Given", $"I search for {city}");
            _homePage.SearchCity(city);
        }

        [When(@"I select ""([^""]*)"" zone")]
        public void WhenISelectZone(string zone)
        {
            _test.CreateNode("When", $"I select {zone}");
            _zonePage = _homePage.SelectZone(zone);
            //Verify I´m in the Zone page
            _zonePage.VerifyZoneTitle(zone);
        }

        [When(@"I select ""([^""]*)"" hour")]
        public void WhenISelectHour(string hour)
        {
            _test.CreateNode("When", $"I select {hour}");
            _zonePage.SelectHour(hour);
        }


        [Then(@"Information related to the zone and hour will be shown")]
        public void ThenInformationRelatedToTheZoneAndHourWillBeShown()
        {
            _test.CreateNode("Then", $"The operation succeded");
            _zonePage.VerifyClimateInformation();
        }

    }
}
