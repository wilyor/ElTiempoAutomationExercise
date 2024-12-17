using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElTiempoAutomation.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        protected IWebElement continueButtonPopUp => driver.FindElement(By.XPath("//*[text()='Aceptar y continuar gratis']"));

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        //In case the popUp to subscribe appears
        protected void CloseContinuePopUp()
        {
            try
            {
                wait.Until(driver => continueButtonPopUp.Displayed);
                continueButtonPopUp.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine("continueButtonPopUp did not appear");
            }
        }

        protected void ScrollToElement(IWebElement elementToScrollTo)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView({block:'center'});", elementToScrollTo);
        }
    }
}
