using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.PageObjects;

namespace AppiumFirstTest.Pages
{
    public class EvernoteAddNoteTypeList
    {
        #region Initialization
        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="driver"></param>
        private AndroidDriver<AndroidElement> _driver;

        public EvernoteAddNoteTypeList(AndroidDriver<AndroidElement> driver)
        {
            PageFactory.InitElements(driver, this);
            this._driver = driver;
        }
        #endregion

        #region Locators
        /// <summary>
        /// Locators
        /// </summary>
        [FindsBy(How = How.Id, Using = "com.evernote:id/skittle_0")]
        private IWebElement TextNote { set; get; }

        [FindsBy(How = How.Id, Using = "com.evernote:id/skittle_1")]
        private IWebElement HandWriteNote { set; get; }

        [FindsBy(How = How.Id, Using = "com.evernote:id/skittle_2")]
        private IWebElement ReminderNote { set; get; }

        [FindsBy(How = How.Id, Using = "com.evernote:id/skittle_3")]
        private IWebElement AudioNote { set; get; }

        [FindsBy(How = How.Id, Using = "com.evernote:id/skittle_4")]
        private IWebElement AttachmentNote { set; get; }

        [FindsBy(How = How.Id, Using = "com.evernote:id/skittle_5")]
        private IWebElement CameraNote { set; get; }

        #endregion


        public EvernoteNewNotePage SelectTextNote()
        {
            TextNote.Click();
            return new EvernoteNewNotePage(_driver);
        }

        public void SelectHandWriteNote()
        {
            HandWriteNote.Click();
        }

        public void SelectReminder()
        {
            ReminderNote.Click();
        }

        public void SelectAudioNote()
        {
            AudioNote.Click();
        }
        public void SelectAttachment()
        {
            AttachmentNote.Click();
        }
        public void SelectCamera()
        {
            CameraNote.Click();
        }
    }
}
