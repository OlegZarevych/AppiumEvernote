using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;


namespace DriverSetup
{
    
    public static class Driver
    {
        private static AndroidDriver<AndroidElement> _driver = null;
        //        AppiumDriver<AndroidElement> driver;


        public static AndroidDriver<AndroidElement> StartDriver()
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability("device", "Android");
            capabilities.SetCapability(CapabilityType.Platform, "Windows");
            capabilities.SetCapability("deviceName", "f557346f199d1fb5");
            capabilities.SetCapability("platformName", "Android");
            capabilities.SetCapability("platformVersion", "6.0.1");
            capabilities.SetCapability("appPackage", "com.evernote");
            capabilities.SetCapability("appActivity", "com.evernote.ui.HomeActivity");
            capabilities.SetCapability("appWaitActivity", 1000);
           return _driver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities, TimeSpan.FromSeconds(180));
        }
        public static void CloseDriver()
        {
            _driver.Quit();
        }

        static readonly Finalizer finalizer = new Finalizer();
        sealed class Finalizer
        {
            ~Finalizer()
            {
                CloseDriver();
            }
        }
    }
}