using ElTiempoAutomation.Drivers;
using ElTiempoAutomation.Support;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElTiempoAutomation.Pages
{
    public class ZonePage : BasePage
    {
        private IWebElement headerCity => driver.FindElement(By.Id("headerCity"));
        private IWebElement hourButton => driver.FindElement(By.XPath("//Section[@id='cityPoisTable']//a[text()='Horas']"));
        private List<IWebElement> timeSlots => driver.FindElements(By.XPath("//Section[@class='modules m24']//p[@class='time']")).ToList();
        private IWebElement climateMoreInfo => driver.FindElement(By.ClassName("more-info-list"));

        public ZonePage(IWebDriver driver) : base(driver) { }

        public void VerifyZoneTitle(string zone)
        {
            wait.Until(driver => headerCity.Displayed);
            Assert.IsTrue(headerCity.Text.Contains($"{zone}"), $"expected zone to be {zone}");
        }

        public void SelectHour(string hour)
        {
            wait.Until(driver => hourButton.Enabled);
            hourButton.Click();

            try
            {
                //Search for the time Slot of the given hour if visible
                var timeElement = timeSlots.Single(x => x.Text.Contains(hour));
                wait.Until(driver => timeElement.Enabled);
                ScrollToElement(timeElement);
                timeElement.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail($"The expected time {hour} is not selectable");
            }
        }

        public void VerifyClimateInformation()
        {
            wait.Until(driver => climateMoreInfo.Enabled);
            ScrollToElement(climateMoreInfo);
        }
    }
}
