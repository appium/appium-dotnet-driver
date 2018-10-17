﻿using NUnit.Framework;
using System;
using Appium.Integration.Tests.Helpers;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Appium.Interfaces;
using System.Threading;

namespace Appium.Integration.Tests.Android
{
    [TestFixture()]
    public class AndroidTouchActionTest
    {
        private AndroidDriver<AppiumWebElement> driver;

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
                capabilities.AddAdditionalCapability("name", "android - complex");
                capabilities.AddAdditionalCapability("tags", new string[] {"sample"});
            }
            Uri serverUri = Env.ServerIsRemote() ? AppiumServers.RemoteServerUri : AppiumServers.LocalServiceUri;
            driver = new AndroidDriver<AppiumWebElement>(serverUri, capabilities, Env.InitTimeoutSec);
            driver.Manage().Timeouts().ImplicitWait = Env.ImplicitTimeoutSec;
            driver.CloseApp();
        }

        [SetUp]
        public void SetUp()
        {
            if (driver != null)
            {
                driver.LaunchApp();
            }
        }

        [TearDown]
        public void TearDowwn()
        {
            if (driver != null)
            {
                driver.CloseApp();
            }
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
        public void SimpleTouchActionTestCase()
        {
            IList<AppiumWebElement> els = driver.FindElementsByClassName("android.widget.TextView");

            int number1 = els.Count;

            TouchAction tap = new TouchAction(driver);
            tap.Tap(els[4], 10, 5, 2).Perform();

            els = driver.FindElementsByClassName("android.widget.TextView");

            Assert.AreNotEqual(number1, els.Count);
        }

        [Test()]
        public void ComplexTouchActionTestCase()
        {
            IList<AppiumWebElement> els = driver.FindElementsByClassName("android.widget.TextView");
            var loc1 = els[7].Location;
            AppiumWebElement target = els[1];
            var loc2 = target.Location;           
            TouchAction touchAction = new TouchAction(driver);
            touchAction.Press(loc1.X, loc1.Y).Wait(800)
                .MoveTo(loc2.X, loc2.Y).Release().Perform();
            Assert.AreNotEqual(loc2.Y, target.Location.Y);
        }

        [Test()]
        public void SingleMultiActionTestCase()
        {
            IList<AppiumWebElement> els = driver.FindElementsByClassName("android.widget.TextView");
            var loc1 = els[7].Location;
            AppiumWebElement target = els[1];
            var loc2 = target.Location;

            TouchAction swipe = new TouchAction(driver);

            swipe.Press(loc1.X, loc1.Y).Wait(1000)
                .MoveTo(loc2.X, loc2.Y).Release();

            MultiAction multiAction = new MultiAction(driver);
            multiAction.Add(swipe).Perform();
            Assert.AreNotEqual(loc2.Y, target.Location.Y);
        }

        [Test()]
        public void SequentalMultiActionTestCase()
        {
            string originalActivity = driver.CurrentActivity;
            IList<AppiumWebElement> els = driver.FindElementsByClassName("android.widget.TextView");
            MultiAction multiTouch = new MultiAction(driver);

            TouchAction tap1 = new TouchAction(driver);
            tap1.Press(els[5]).Wait(1500).Release();

            multiTouch.Add(tap1).Add(tap1).Perform();

            Thread.Sleep(2500);
            els = driver.FindElementsByClassName("android.widget.TextView");

            TouchAction tap2 = new TouchAction(driver);
            tap2.Press(els[1]).Wait(1500).Release();

            MultiAction multiTouch2 = new MultiAction(driver);
            multiTouch2.Add(tap2).Add(tap2).Perform();

            Thread.Sleep(2500);
            Assert.AreNotEqual(originalActivity, driver.CurrentActivity);
        }
    }
}