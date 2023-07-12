using MarsQASpecFlowProject.Pages;
using MarsQASpecFlowProject.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace MarsQASpecFlowProject.StepDefinitions
{
    [Binding]
    public class SkillsFeatureStepDefinitions 
    {
        Pages.SkillPage skillPageObj = new Pages.SkillPage();
        private new readonly IWebDriver driver;

        public SkillsFeatureStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }



        [When(@"I click on skill tab")]
        public void WhenIClickOnSkillTab()
        {
            driver.Navigate().Refresh();
            Thread.Sleep(2000);
            skillPageObj.skillsTab(driver);
        }

        [When(@"I click on skills Add new button")]
        public void WhenIClickOnSkillsAddNewButton()
        {
            skillPageObj.skillAddNewBtn(driver);
        }

        [When(@"I enter the add skill ""([^""]*)"" in text field")]
        public void WhenIEnterTheAddSkillInTextField(string skills)
        {
            skillPageObj.fillSkillTextField(driver, skills);
        }

        [When(@"I select a Choose skill level ""([^""]*)"" from drop down list")]
        public void WhenISelectAChooseSkillLevelFromDropDownList(string skillLevel)
        {
            skillPageObj.selectSkillLevel(driver, skillLevel);
        }

        [When(@"I click on skills add button")]
        public void WhenIClickOnSkillsAddButton()
        {
            skillPageObj.skillAddBtn(driver);
        }

        [Then(@"I can see the skills ""([^""]*)"" added message")]
        public void ThenICanSeeTheSkillsAddedMessage(string skillvalue)
        {
            Thread.Sleep(300);
            IWebElement skillAddedMsg = driver.FindElement(By.XPath("//div[contains(text(),'has been added to your skills')]"));
            Assert.IsTrue(skillAddedMsg.Text.Contains(skillvalue + " has been added to your skills"));
        }

        [When(@"I want to add duplicate skills ""([^""]*)"" and ""([^""]*)""")]
        public void WhenIWantToAddDuplicateSkillsAnd(string dupskills, string dupskillLevel)
        {
            Thread.Sleep(2000);
            WhenIClickOnSkillsAddNewButton();
            WhenIEnterTheAddSkillInTextField(dupskills);
            WhenISelectAChooseSkillLevelFromDropDownList (dupskillLevel);
            WhenIClickOnSkillsAddButton();

        }

        [Then(@"I can verify the  error message ""([^""]*)"" for duplicate ""([^""]*)"" and ""([^""]*)""")]
        public void ThenICanVerifyTheErrorMessageForDuplicateAnd(string errormsg, string dupskills, string dupskillLevel)
        {
            Thread.Sleep(1000);
            String message = driver.FindElement(By.XPath("//div[contains(text(),'This skill is already exist in your skill list.')]")).Text;
            Assert.AreEqual(errormsg, message);
        }

        [When(@"I want to update ""([^""]*)"" with ""([^""]*)"" and ""([^""]*)"" skill and level")]
        public void WhenIWantToUpdateWithAndSkillAndLevel(string skill, string skillone, string skilllevel)
        {
            Thread.Sleep(2000);
            skillPageObj.updateSkills(driver, skill, skillone, skilllevel);
        }

        [Then(@"The updated skills ""([^""]*)"" and ""([^""]*)"" message should be displayed")]
        public void ThenTheUpdatedSkillsAndMessageShouldBeDisplayed(string skillone, string skilllevel)
        {
            Thread.Sleep(500);
            IWebElement updatedMsg = driver.FindElement(By.XPath("//div[contains(text(),'has been updated to your skills')]"));
            Assert.IsTrue(updatedMsg.Text.Contains(skillone + " has been updated to your skills"));
        
        }

    }
}
