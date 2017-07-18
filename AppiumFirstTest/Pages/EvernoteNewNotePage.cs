using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.PageObjects;

namespace AppiumFirstTest.Pages
{
    public class EvernoteNewNotePage
    {
       private AndroidDriver<AndroidElement> _driver;
        
        public EvernoteNewNotePage(AndroidDriver<AndroidElement> driver)
        {
            PageFactory.InitElements(driver, this);
            this._driver = driver;
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));
        }
        #region Locators
        /// <summary>
        /// Locators
        /// </summary>
        [FindsBy(How = How.ClassName, Using = "android.view.View")]
        public IWebElement InputField { set; get; }

        [FindsBy(How = How.Id, Using = "com.evernote:id/check_mark")]
        public IWebElement SaveButton { set; get; }

        [FindsBy(How = How.Id, Using = "com.evernote:id/edit_skittle")]
        public IWebElement EditSkittleButton { set; get; }

        [FindsBy(How = How.Id, Using = "com.evernote:id/overflow_icon")]
        public IWebElement ThreeDotButton { set; get; }

        [FindsBy(How = How.Id, Using = "com.evernote:id/delete")]
        public IWebElement DeleteNoteButton { set; get; }

        [FindsBy(How = How.Id, Using = "android:id/button1")]
        public IWebElement ConfirmDeletePopUp { set; get; }
        
        #endregion

        public EvernoteNewNotePage WriteNoteText(string Text)
        {
            InputField.SendKeys(Text);
            return new EvernoteNewNotePage(_driver);
        }

        public EvernoteNewNotePage SaveButtonClick()
        {
            SaveButton.Click();
            return new EvernoteNewNotePage(_driver);
        }
        public EvernoteNewNotePage EditSkittleButtonClick()
        {
            EditSkittleButton.Click();
            return new EvernoteNewNotePage(_driver);
        }

        public EvernoteMainPage DeleteSavedNote()
        {
            ThreeDotButton.Click();
            DeleteNoteButton.Click();
            ConfirmDeletePopUp.Click();

            return new EvernoteMainPage(_driver);
        }
    }
}
