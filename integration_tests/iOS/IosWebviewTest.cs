﻿using NUnit.Framework;
using System;
using Appium.Integration.Tests.Helpers;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Appium.iOS;

namespace Appium.Integration.Tests.iOS
{
    [TestFixture()]
    public class iOSWebviewTest
    {
        private AppiumDriver<IWebElement> driver;

        [OneTimeSetUp]
        public void BeforeAll()
        {
            AppiumOptions capabilities = Caps.GetIOSCaps(Apps.get("iosWebviewApp"));
            if (Env.ServerIsRemote())
            {
                capabilities.AddAdditionalCapability("username", Env.GetEnvVar("SAUCE_USERNAME"));
                capabilities.AddAdditionalCapability("accessKey", Env.GetEnvVar("SAUCE_ACCESS_KEY"));
                capabilities.AddAdditionalCapability("name", "ios - webview");
                capabilities.AddAdditionalCapability("tags", new string[] {"sample"});
            }
            Uri serverUri = Env.ServerIsRemote() ? AppiumServers.RemoteServerUri : AppiumServers.LocalServiceUri;
            driver = new IOSDriver<IWebElement>(serverUri, capabilities, Env.InitTimeoutSec);
            driver.Manage().Timeouts().ImplicitWait = Env.ImplicitTimeoutSec;
        }

        [OneTimeTearDown]
        public void AfterAll()
        {
            if (driver != null)
            {
                driver.Quit();
            }
            if (!Env.ServerIsRemote())
            {
                AppiumServers.StopLocalService();
            }
        }

        [Test()]
        public void GetPageTestCase()
        {
            driver.FindElementByXPath("//UIATextField[@value='Enter URL']")
                .SendKeys("www.google.com");
            driver.FindElementByClassName("UIAButton").Click();
            driver.FindElementByClassName("UIAWebView").Click(); // dismissing keyboard
            Thread.Sleep(10000);
            driver.Context = "WEBVIEW";
            Thread.Sleep(3000);
            var el = driver.FindElementByClassName("gsfi");
            el.SendKeys("Appium");
            el.SendKeys(Keys.Return);
            Thread.Sleep(1000);
            Assert.IsTrue(driver.Title.Contains("Appium"));
        }
    }
}