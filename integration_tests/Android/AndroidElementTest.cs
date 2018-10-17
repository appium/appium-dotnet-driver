﻿using Appium.Integration.Tests.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using System;

namespace Appium.Integration.Tests.Android
{
    public class AndroidElementTest
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

        [Test()]
        public void FindByAccessibilityIdTest()
        {
            By byAccessibilityId = new ByAccessibilityId("Graphics");
            Assert.AreNotEqual(driver.FindElementById("android:id/content").FindElement(byAccessibilityId).Text, null);
            Assert.GreaterOrEqual(driver.FindElementById("android:id/content").FindElements(byAccessibilityId).Count,
                1);
        }

        [Test()]
        public void FindByAndroidUIAutomatorTest()
        {
            By byAndroidUIAutomator = new ByAndroidUIAutomator("new UiSelector().clickable(true)");
            Assert.IsNotNull(driver.FindElementById("android:id/content").FindElement(byAndroidUIAutomator).Text);
            Assert.GreaterOrEqual(driver.FindElementById("android:id/content").FindElements(byAndroidUIAutomator).Count,
                1);
        }

        [Test]
        public void ReplaceValueTest()
        {
            string originalValue = "original value";
            string replacedValue = "replaced value";

            driver.StartActivity("io.appium.android.apis", ".view.Controls1");

            AndroidElement editElement =
                driver.FindElementByAndroidUIAutomator("resourceId(\"io.appium.android.apis:id/edit\")");

            editElement.SendKeys(originalValue);

            Assert.AreEqual(originalValue, editElement.Text);

            editElement.ReplaceValue(replacedValue);

            Assert.AreEqual(replacedValue, editElement.Text);
        }

        [Test]
        public void SetImmediateValueTest()
        {
            string value = "new value";

            driver.StartActivity("io.appium.android.apis", ".view.Controls1");

            AndroidElement editElement =
                driver.FindElementByAndroidUIAutomator("resourceId(\"io.appium.android.apis:id/edit\")");

            editElement.SetImmediateValue(value);

            Assert.AreEqual(value, editElement.Text);
        }

        [Test]
        public void ScrollingToSubElement()
        {
            driver.FindElementByAccessibilityId("Views").Click();
            AndroidElement list = driver.FindElement(By.Id("android:id/list"));
            var locator = new ByAndroidUIAutomator("new UiScrollable(new UiSelector()).scrollIntoView("
                                                   + "new UiSelector().text(\"Radio Group\"));");
            AppiumWebElement radioGroup = list.FindElement(locator);
            Assert.NotNull(radioGroup.Location);
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
    }
}