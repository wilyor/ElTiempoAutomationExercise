using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

namespace ElTiempoAutomation.Drivers
{
    public class WebDriverManager
    {
        public static IWebDriver driver;

        public static IWebDriver GetDriver(string browser)
        {
            if (driver == null)
            {
                driver = CreateDriver(browser);
            }
            return driver;
        }

        private static IWebDriver CreateDriver(string browser)
        {
            switch (browser)
            {
                case "chrome":
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("--start-maximized");
                    return new ChromeDriver(chromeOptions);

                case "firefox":
                    var firefoxOptions = new FirefoxOptions();
                    firefoxOptions.AddArgument("--start-maximized");
                    return new FirefoxDriver(firefoxOptions);

                case "edge":
                    var edgeOptions = new EdgeOptions();
                    edgeOptions.AddArgument("--start-maximized");
                    return new EdgeDriver(edgeOptions);

                default:
                    throw new ArgumentException($"Browser '{browser}' not supported.");
            }
        }

        public static void QuitDriver()
        {
            if (driver != null)
            {
                driver.Quit();
                driver = null;
            }
        }

        public static void TakeScreenshot(IWebDriver driver, string filePath)
        {
            try
            {
                ITakesScreenshot screenshotDriver = (ITakesScreenshot)driver;
                Screenshot screenshot = screenshotDriver.GetScreenshot();
                screenshot.SaveAsFile(filePath);

                Console.WriteLine($"ScreenShot saved in: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error taking screenshot: {ex.Message}");
            }
        }
    }
}
