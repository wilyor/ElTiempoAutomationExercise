using Allure.Net.Commons;
using ElTiempoAutomation.Drivers;
using ElTiempoAutomation.Support;
using NUnit.Framework;

namespace ElTiempoAutomation.StepDefinitions
{
    [Binding]
    public sealed class Hooks
    {
        public static AllureLifecycle allure = AllureLifecycle.Instance;

        [BeforeTestRun]
        public static void BeforetestRun()
        {
            allure.CleanupResultDirectory();
        }

        [BeforeFeature]
        public static void FirstBeforeScenario()
        {
            Console.WriteLine("Initializing driver");
            ReportManager.InitializeReport();
            WebDriverManager.GetDriver(ConfigManager.GetDefaultBrowser());
        }

        [BeforeScenario]
        public static void BeforeScenario()
        {
            var scenarioName = "ClimateVerification";
            ReportManager.CreateTest(scenarioName);
        }

        [AfterScenario]
        public static void AfterScenario()
        {
            var screenshotPath = TakeScreenShot();
            ReportManager.AddScreenshotToReport(screenshotPath);
            ReportManager.FinalizeReport();
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            Console.WriteLine("Closing reporter");
            ReportManager.FinalizeReport();
            Console.WriteLine("Closing driver");
            WebDriverManager.QuitDriver();
        }

        private static string TakeScreenShot()
        {
            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string screenshotsPath = Path.Combine(projectDirectory, "Screenshots");
            if (!Directory.Exists(screenshotsPath))
            {
                Directory.CreateDirectory(screenshotsPath);
            }
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string filePath = $"{screenshotsPath}\\test_{timestamp}.png";
            WebDriverManager.TakeScreenshot(WebDriverManager.driver, filePath);

            TestContext.AddTestAttachment(filePath);
            AllureApi.AddAttachment("Evidence", "image/png", filePath);
            return filePath;
        }
    }
}