using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ElTiempoAutomation.Pages
{
    public class HomePage : BasePage
    {
        //Selectors
        private IWebElement searchInput => driver.FindElement(By.Id("term"));
        private IWebElement searchContainer => driver.FindElement(By.ClassName("search-container-list"));

        public HomePage(IWebDriver driver) : base(driver) {}

        public void NavigateToPage()
        {
            driver.Navigate().GoToUrl(ConfigManager.GetUrl());
            CloseContinuePopUp();
        }

        public void SearchCity(string cityName)
        {
            wait.Until(driver => searchInput.Displayed);
            searchInput.Clear();
            searchInput.SendKeys(cityName);
        }

        public ZonePage SelectZone(string zoneName)
        {
            wait.Until(driver => searchContainer.Displayed);
            searchContainer.FindElement(By.XPath($"//*[contains(text(), '{zoneName}')]")).Click();
            return new ZonePage(driver);
        }        
    }
}
