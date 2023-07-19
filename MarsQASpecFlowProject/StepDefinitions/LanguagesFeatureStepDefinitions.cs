using MarsQASpecFlowProject.Pages;
using MarsQASpecFlowProject.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace MarsQASpecFlowProject.StepDefinitions
{


    [Binding]
    public class LanguagesFeatureStepDefinitions : CommonDriver
    {
        private LaunchPage page;
        private LoginPage loginpage;
        private LanguagePage languagePage;
      
        public LanguagesFeatureStepDefinitions()
        {
             page = new LaunchPage();
            loginpage = new LoginPage();
            languagePage = new LanguagePage();
        }

        [Given(@"I open local host succesfully")]
        public void GivenIOpenLocalHostSuccesfully()
        {
            // driver = new ChromeDriver();
            //page.launch(driver);
        }

        [When(@"I click on Sign in link")]
        public void WhenIClickOnSignInLink()
        {
            driver.FindElement(By.XPath("//div[@id='home']/div/div/div/div/a")).Click();
        }

       
        [When(@"I provided Username ""([^""]*)"" in text field")]
        public void WhenIProvidedUsernameInTextField(string uname)
        {
            if (uname != null) {
                loginpage.loginUser(uname);
            }
        }

        [When(@"I provided Password ""([^""]*)"" in text field")]
        public void WhenIProvidedPasswordInTextField(string pwd)
        {
            if (pwd != null)
            {
                loginpage.loginPwd(pwd);
            }
        }


        [When(@"I tick the remember Me\? checkbox")]
        public void WhenITickTheRememberMeCheckbox()
        {
            loginpage.rememberChk();
        }

        [When(@"I click login button")]
        public void WhenIClickLoginButton()
        {
            loginpage.loginbtn();
        }

        [Then(@"I can see inline error message ""([^""]*)""")]
        public void ThenICanSeeInlineErrorMessage(string errormsg)
        {
            String message = driver.FindElement(By.XPath("//div[@class='ui basic red pointing prompt label transition visible']")).Text;
            Assert.AreEqual(errormsg, message);
           
        }

        [Then(@"I can verify the error messages ""([^""]*)"" for username ""([^""]*)""  and password ""([^""]*)"" text fields")]
        public void ThenICanVerifyTheErrorMessagesForUsernameAndPasswordTextFields(string errormsg, string username, string password)
        {
            if (username == "")
            {
                String message = driver.FindElement(By.XPath("//div[@class='ui basic red pointing prompt label transition visible']")).Text;
                Assert.AreEqual(errormsg, message);
            }
            else if (password == "")
            {
                String message = driver.FindElement(By.XPath("//div[contains(text(),'Password must be at least 6 characters')]")).Text;
                Assert.AreEqual(errormsg, message);
            } else
            {
                Console.WriteLine("Username and password are not null");
            }


        }
        
        [Then(@"I logged in successfully")]
        public void ThenILoggedInSuccessfully()
        {
            String logotxt = driver.FindElement(By.XPath("//a[@href='/']")).Text;
            Assert.AreEqual("Mars Logo", logotxt);
        }



        [Given(@"I successfullly logged into the Mars_qa Project")]
        public void GivenISuccessfulllyLoggedIntoTheMars_QaProject()
        {
            GivenIOpenLocalHostSuccesfully();
            WhenIClickOnSignInLink();
            WhenIProvidedUsernameInTextField("bairi.bhavani9@gmail.com");
            WhenIProvidedPasswordInTextField("Achhi02110");
            WhenITickTheRememberMeCheckbox();
            WhenIClickLoginButton();
        }

        [When(@"I click on language tab")]
        public void WhenIClickOnLanguageTab()
        {
            driver.Navigate().Refresh();
            languagePage.selectlanguageTab();
        }

        [When(@"I click on Add new button")]
        public void WhenIClickOnAddNewButton()
        {
            languagePage.addNewBtn();
        }

        [When(@"I enter the add language ""([^""]*)"" in text field")]
        public void WhenIEnterTheAddLanguageInTextField(string lang)
        {
            languagePage.fillTextField(lang);
        }

        [When(@"I select a Choose language level ""([^""]*)"" from drop down list")]
        public void WhenISelectAChooseLanguageLevelFromDropDownList(string dvalue)
        {
            languagePage.selectValue(dvalue);
        }

        [When(@"I click on add button")]
        public void WhenIClickOnAddButton()
        {
            languagePage.languageAddBtn();
        }


        [Then(@"I can see the ""([^""]*)"" added message")]
        public void ThenICanSeeTheAddedMessage(string lang)
        {
            IWebElement addedMsg = driver.FindElement(By.XPath("//div[contains(text(),'has been added to your languages')]"));
            Assert.IsTrue(addedMsg.Text.Contains(lang + " has been added to your languages"));
        }

        [When(@"I want to add duplicate ""([^""]*)"" and ""([^""]*)""")]
        public void WhenIWantToAddDuplicateAnd(string duplicatelang, string duplicatelevel)
        {
            languagePage.addNewBtn();
            languagePage.fillTextField(duplicatelang);
            languagePage.selectValue(duplicatelevel);
            languagePage.languageAddBtn();
        }

        [Then(@"I can verify the error message ""([^""]*)"" for duplicate ""([^""]*)"" and ""([^""]*)""")]
        public void ThenICanVerifyTheErrorMessageForDuplicateAnd(string errormsg, string duplicatelang, string duplicatelevel)
        {
            String message = driver.FindElement(By.XPath("//div[contains(text(),'This language is already exist in your language list.')]")).Text;
            Assert.AreEqual(errormsg, message);
        }

        [When(@"I click on Sign Out button")]
        public void WhenIClickOnSignOutButton()
        {
            driver.FindElement(By.XPath("//button[@class='ui green basic button']")).Click();
        }
        
        [When(@"I want to update ""([^""]*)"" with ""([^""]*)"" and ""([^""]*)"" languge and level")]
        public void WhenIWantToUpdateWithAndLangugeAndLevel(string lang, string langone, string levelone)
        {
            languagePage.updateLanguage(lang, langone, levelone);
        }

        [When(@"I want to update ""([^""]*)"" with invalid/blank ""([^""]*)"" and ""([^""]*)"" languge and level")]
        public void WhenIWantToUpdateWithInvalidBlankAndLangugeAndLevel(string lang, string emptylang, string levelone)
        {
            languagePage.updateLanguage(lang, emptylang, levelone);
        }

        [Then(@"I can verify the error messages ""([^""]*)"" for language ""([^""]*)""  and level ""([^""]*)""")]
        public void ThenICanVerifyTheErrorMessagesForLanguageAndLevel(string errormsg, string langone, string levelone)
        {
            if ((langone == "" )|| (levelone == ""))
            {
                String message = driver.FindElement(By.XPath("//div[contains(text(),'Please enter language and level')]")).Text;
                Assert.AreEqual(errormsg, message);
             }

        }

        [Then(@"The updated ""([^""]*)"" and ""([^""]*)"" message should be displayed")]
        public void ThenTheUpdatedAndMessageShouldBeDisplayed(string langone, string level1)
        {
            IWebElement updatedMsg = driver.FindElement(By.XPath("//div[contains(text(),'has been updated to your languages')]"));
            Assert.IsTrue(updatedMsg.Text.Contains(langone + " has been updated to your languages"));
        }

        [When(@"I want to delete existing ""([^""]*)""")]
        public void WhenIWantToDeleteExisting(string lang)
        {
            languagePage.deleteLanguage(lang);
        }
        
        [Then(@"The deleted ""([^""]*)"" message ""([^""]*)"" should be displayed")]
        public void ThenTheDeletedMessageShouldBeDisplayed(string lang, string errormsg)
        {
            IWebElement deletedMsg = driver.FindElement(By.XPath("//div[contains(text(),'has been deleted from your languages')]"));
            Assert.IsTrue(deletedMsg.Text.Contains(errormsg));
        }

    }
}
