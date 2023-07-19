using MarsQASpecFlowProject.Pages;
using MarsQASpecFlowProject.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace MarsQASpecFlowProject.StepDefinitions
{
    [Binding]
    public class SkillsFeatureStepDefinitions : CommonDriver
    {
        private SkillPage skillPageObj;
        private LoginPage loginpage;
      
        public SkillsFeatureStepDefinitions()
        {
            skillPageObj = new SkillPage();
            loginpage = new LoginPage();
        }

        [When(@"I click on skill tab")]
        public void WhenIClickOnSkillTab()
        {
            driver.Navigate().Refresh();
            skillPageObj.skillsTab();
        }

        [When(@"I click on skills Add new button")]
        public void WhenIClickOnSkillsAddNewButton()
        {
            skillPageObj.skillAddNewBtn();
        }

        [When(@"I enter the add skill ""([^""]*)"" in text field")]
        public void WhenIEnterTheAddSkillInTextField(string skills)
        {
            skillPageObj.fillSkillTextField(skills);
        }

        [When(@"I select a Choose skill level ""([^""]*)"" from drop down list")]
        public void WhenISelectAChooseSkillLevelFromDropDownList(string skillLevel)
        {
            skillPageObj.selectSkillLevel(skillLevel);
        }

        [When(@"I click on skills add button")]
        public void WhenIClickOnSkillsAddButton()
        {
            skillPageObj.skillAddBtn();
        }

        [Then(@"I can see the skills ""([^""]*)"" added message")]
        public void ThenICanSeeTheSkillsAddedMessage(string skillvalue)
        {
            IWebElement skillAddedMsg = driver.FindElement(By.XPath("//div[contains(text(),'has been added to your skills')]"));
            Assert.IsTrue(skillAddedMsg.Text.Contains(skillvalue + " has been added to your skills"));
        }

        [When(@"I want to add duplicate skills ""([^""]*)"" and ""([^""]*)""")]
        public void WhenIWantToAddDuplicateSkillsAnd(string dupskills, string dupskillLevel)
        {
            WhenIClickOnSkillsAddNewButton();
            WhenIEnterTheAddSkillInTextField(dupskills);
            WhenISelectAChooseSkillLevelFromDropDownList (dupskillLevel);
            WhenIClickOnSkillsAddButton();

        }

        [Then(@"I can verify the  error message ""([^""]*)"" for duplicate ""([^""]*)"" and ""([^""]*)""")]
        public void ThenICanVerifyTheErrorMessageForDuplicateAnd(string errormsg, string dupskills, string dupskillLevel)
        {
            String message = driver.FindElement(By.XPath("//div[contains(text(),'This skill is already exist in your skill list.')]")).Text;
            Assert.AreEqual(errormsg, message);
        }

        [When(@"I want to update ""([^""]*)"" with ""([^""]*)"" and ""([^""]*)"" skill and level")]
        public void WhenIWantToUpdateWithAndSkillAndLevel(string skill, string skillone, string skilllevel)
        {
            skillPageObj.updateSkills(skill, skillone, skilllevel);
        }

        [Then(@"The updated skills ""([^""]*)"" and ""([^""]*)"" message should be displayed")]
        public void ThenTheUpdatedSkillsAndMessageShouldBeDisplayed(string skillone, string skilllevel)
        {
            IWebElement updatedMsg = driver.FindElement(By.XPath("//div[contains(text(),'has been updated to your skills')]"));
            Assert.IsTrue(updatedMsg.Text.Contains(skillone + " has been updated to your skills"));

        }
            [When(@"I want to update ""([^""]*)"" with invalid/blank ""([^""]*)"" and ""([^""]*)"" skill and level")]
            public void WhenIWantToUpdateWithInvalidBlankAndskillAndLevel(string skill, string empty, string levelone)
            {
                skillPageObj.updateSkills(skill, empty, levelone);
            }

        [Then(@"I can verify the error messages ""([^""]*)"" for skill ""([^""]*)"" and level ""([^""]*)""")]
        public void ThenICanVerifyTheErrorMessagesForSkillAndLevel(string errormsg, string skillone, string levelone)
        {
            if((skillone == "") || (levelone == ""))
            {
                String message = driver.FindElement(By.XPath("//div[contains(text(), 'Please enter skill and experience level')]")).Text;
                Assert.AreEqual(errormsg, message);


            }
        }

        [When(@"I want to delete existing skills ""([^""]*)""")]
        public void WhenIWantToDeleteExistingSkills(string skills)
        {
            skillPageObj.deleteSkills(skills);
        }

        [Then(@"The deleted  skills ""([^""]*)"" message ""([^""]*)"" should be displayed")]
        public void ThenTheDeletedSkillsMessageShouldBeDisplayed(string skill, string errormsg)
        {
            IWebElement deletedMsg = driver.FindElement(By.XPath("//div[contains(text(),'has been deleted')]"));
            Assert.IsTrue(deletedMsg.Text.Contains(errormsg));
        }

    }
}
