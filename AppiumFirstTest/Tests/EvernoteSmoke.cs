using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using AppiumFirstTest.Pages;

namespace AppiumFirstTest
{
    [TestClass]
   public class EvernoteSmoke
    {
        private AndroidDriver<AndroidElement> driver = null;

        [TestInitialize]
        public void RunEvernote()
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability("device", "Android");
            capabilities.SetCapability(CapabilityType.Platform, "Windows");
            capabilities.SetCapability("deviceName", "SM_P550");
            capabilities.SetCapability("platformName", "Android");
            capabilities.SetCapability("platformVersion", "6.0.1");
            capabilities.SetCapability("appPackage", "com.evernote");
            capabilities.SetCapability("appActivity", "com.evernote.ui.HomeActivity");
           
            driver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities, TimeSpan.FromSeconds(180));
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
            
        }
        //This was first test
        //[TestMethod]
        //public void TestFirst()
        //{
        //    var drv = Driver.StartDriver();

        //    var avatar = drv.FindElementById("avatar_image_view");
        //    avatar.Click();

        //    var pic = drv.FindElementById("profile_pic");

        //    Assert.AreEqual(true, pic.Displayed);
        //    //var two = driver.FindElement(By.Name("2"));
        //    //two.Click();
        //    //var plus = driver.FindElement(By.Name("+"));
        //    //plus.Click();
        //    //var four = driver.FindElement(By.Name("4"));
        //    //four.Click();
        //    //var equalTo = driver.FindElement(By.Name("="));
        //    //equalTo.Click();

        //    //var results = driver.FindElement(By.ClassName("android.widget.EditText"));

        //   // Assert.AreEqual("6", results.Text);
        //}
        [TestMethod]
        public void AddNewTextNodeWithText()
        {
            EvernoteMainPage MP = new EvernoteMainPage(driver);
            EvernoteAddNoteTypeList list = MP.AddTextNote();
            EvernoteNewNotePage newNote = list.SelectTextNote();
     
            newNote.WriteNoteText("test");
            newNote.SaveButtonClick();
            Assert.IsTrue(newNote.EditSkittleButton.Displayed);
        }
        [TestMethod]
        public void AddNewTextNodeAndDeleteIt()
        {
            EvernoteMainPage MP = new EvernoteMainPage(driver);
            EvernoteAddNoteTypeList list = MP.AddTextNote();
            EvernoteNewNotePage newNote = list.SelectTextNote();
            newNote.WriteNoteText("test");
            newNote.SaveButtonClick();
            MP = newNote.DeleteSavedNote();
            Assert.IsTrue(MP.NoteListView.Displayed);
        }

        [TestMethod]
        public void NotesList()
        {
            EvernoteMainPage MP = new EvernoteMainPage(driver);
            MP.ListContains();
        }

        [TestMethod]
        public void NotesListDisplayed()
        {
            EvernoteMainPage MP = new EvernoteMainPage(driver);
            MP.NotesListMainPageContainsElements();
        }


        [TestCleanup]
        public void CloseEvernote()
            {
                driver.CloseApp();
            }
        
    }
}
