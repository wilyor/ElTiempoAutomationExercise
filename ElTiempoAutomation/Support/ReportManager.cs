using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;

namespace ElTiempoAutomation.Support
{
    public class ReportManager
    {
        private static ExtentReports _extent;
        public static ExtentTest _test;

        public static void InitializeReport()
        {
            string reportPath = AppDomain.CurrentDomain.BaseDirectory + "\\Reports\\TestReport.html";
            var sparkReporter = new ExtentSparkReporter(reportPath);

            // report options
            sparkReporter.Config.DocumentTitle = "Report";
            sparkReporter.Config.ReportName = "Automated Test Report";

            _extent = new ExtentReports();
            _extent.AttachReporter(sparkReporter);
        }

        public static ExtentTest CreateTest(string testName)
        {
            _test = _extent.CreateTest(testName);
            return _test;
        }

        public static void AddScreenshotToReport(string screenshotPath)
        {
            _test.AddScreenCaptureFromPath(screenshotPath);
        }

        public static void FinalizeReport()
        {
            _extent.Flush();
        }
    }
}
