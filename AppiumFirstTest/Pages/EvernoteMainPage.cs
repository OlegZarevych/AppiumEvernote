using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.PageObjects;

namespace AppiumFirstTest.Pages
{
    public class EvernoteMainPage
    {
        #region Initialization
        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="driver"></param>
        private AndroidDriver<AndroidElement> _driver;

        public EvernoteMainPage(AndroidDriver<AndroidElement>  driver)
        {
            PageFactory.InitElements(driver, this);
            this._driver = driver;
        }
        #endregion

        #region Locators
        /// <summary>
        /// Locators
        /// </summary>

        [FindsBy(How = How.Id, Using = "com.evernote:id/main_fab_image_view")]
        private IWebElement AddNoteButton { set; get; }

        [FindsBy(How = How.Id, Using = "com.evernote:id/note_list_listview")]
        public IWebElement NoteListView { set; get; }

        [FindsBy(How = How.Id, Using = "com.evernote:id/title")]
        public IList<IWebElement> NoteListHeader { set; get; }

        #endregion

        public EvernoteAddNoteTypeList AddTextNote()
        {
            AddNoteButton.Click();
            return new EvernoteAddNoteTypeList(_driver);
        }

        public EvernoteMainPage NotesListMainPageContainsElements()
        {
            List<AndroidElement> Notes = _driver.FindElements(By.XPath("//android.widget.LinearLayout[@class='android.widget.LinearLayout']//android.widget.LinearLayout[@id='snippet_container']")).ToList();
            for (int i = 0; i < Notes.Count; i++)
            {

            }
            return new EvernoteMainPage(_driver);
        }

        public void ListContains()
        {
            foreach(IWebElement ListElement in NoteListHeader)
            {
               
            }
        
        }
    }
}
