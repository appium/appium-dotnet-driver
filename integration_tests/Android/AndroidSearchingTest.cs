﻿using NUnit.Framework;
using System;
using Appium.Integration.Tests.Helpers;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;

namespace Appium.Integration.Tests.Android
{
    [TestFixture()]
    public class AndroidSearchingTest
    {
        private AndroidDriver<AndroidElement> driver;

        [OneTimeSetUp]
        public void BeforeAll()
        {
            AppiumOptions capabilities = Env.ServerIsRemote()
                ? Caps.GetAndroidCaps(Apps.get("androidApiDemos"))
                : Caps.GetAndroidCaps(Apps.get("androidApiDemos"));
            if (Env.ServerIsRemote())
            {
                capabilities.AddAdditionalCapability("username", Env.GetEnvVar("SAUCE_USERNAME"));
                capabilities.AddAdditionalCapability("accessKey", Env.GetEnvVar("SAUCE_ACCESS_KEY"));
                capabilities.AddAdditionalCapability("name", "android - simple");
                capabilities.AddAdditionalCapability("tags", new string[] {"sample"});
            }
            Uri serverUri = Env.ServerIsRemote() ? AppiumServers.RemoteServerUri : AppiumServers.LocalServiceUri;
            driver = new AndroidDriver<AndroidElement>(serverUri, capabilities, Env.InitTimeoutSec);
            driver.Manage().Timeouts().ImplicitWait = Env.ImplicitTimeoutSec;
        }

        [SetUp]
        public void SetUp()
        {
            driver.StartActivity("io.appium.android.apis", ".ApiDemos");
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
        public void FindByAccessibilityIdTest()
        {
            By byAccessibilityId = new ByAccessibilityId("Graphics");
            Assert.AreNotEqual(driver.FindElement(byAccessibilityId).Text, null);
            Assert.GreaterOrEqual(driver.FindElements(byAccessibilityId).Count, 1);
        }

        [Test]
        public void FindByAndroidUIAutomatorTest()
        {
            By byAndroidUIAutomator = new ByAndroidUIAutomator("new UiSelector().clickable(true)");
            Assert.IsNotNull(driver.FindElement(byAndroidUIAutomator).Text);
            Assert.GreaterOrEqual(driver.FindElements(byAndroidUIAutomator).Count, 1);
        }

        [Test]
        public void FindByXPathTest()
        {
            string byXPath = "//android.widget.TextView[contains(@text, 'Animat')]";
            Assert.IsNotNull(driver.FindElementByXPath(byXPath).Text);
            Assert.AreEqual(driver.FindElementsByXPath(byXPath).Count, 1);
        }

        [Test]
        public void FindScrollable()
        {
            driver.FindElementByAccessibilityId("Views").Click();
            AndroidElement radioGroup = driver
                .FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector()"
                                                 + ".resourceId(\"android:id/list\")).scrollIntoView("
                                                 + "new UiSelector().text(\"Radio Group\"));");
            Assert.NotNull(radioGroup.Location);
        }
    }
}