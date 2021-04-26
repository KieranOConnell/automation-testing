﻿using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.IO;

namespace AutomationTesting.Utilities
{
    public class ExtentManager
    {
        public static ExtentHtmlReporter extentHtmlReporter;
        private static ExtentReports extent;

        private ExtentManager()
        {

        }

        public static ExtentReports GetInstance()
        {
            if (extent == null)
            {
                string filePath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
                filePath = Directory.GetParent(Directory.GetParent(filePath).FullName).FullName;
                string reportPath = filePath + "\\Reports\\";
                string reportName = "Report-" + DateTime.Now.ToString("dd/MM/yyyy").Replace("/", "_") + "-" + DateTime.Now.ToString("HH:mm:ss").Replace(":", "_") + ".html";
                extentHtmlReporter = new ExtentHtmlReporter(reportPath + reportName);
                extent = new ExtentReports();
                extent.AttachReporter(extentHtmlReporter);
                extent.AddSystemInfo("Operating Systems", "Windows 10, Ubuntu, macOS Big Sur");
                extent.AddSystemInfo("Browsers", "Google Chrome, Mozilla Firefox, Microsoft Edge, Safari");

                string extentConfigPath = filePath + "\\Configuration\\extent-config.xml";
                extentHtmlReporter.LoadConfig(extentConfigPath);
            }

            return extent;
        }
    }
}
