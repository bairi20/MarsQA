using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsQASpecFlowProject.Utilities;

namespace MarsQASpecFlowProject.Pages
{
    public class SkillPage : CommonDriver
    {

        public void skillsTab(IWebDriver driver)
        {
            try
            {
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//a[normalize-space()='Skills']")).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void skillAddNewBtn(IWebDriver driver)
        {
                Thread.Sleep(1000);  
                driver.FindElement(By.XPath("//div[@class='ui teal button']")).Click();
        }

        public void fillSkillTextField(IWebDriver driver, String skillvalue)
        {
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//input[@name='name']")).SendKeys(skillvalue);

        }

        public void selectSkillLevel(IWebDriver driver, String skillLevel)
        {
            try
            {
                Thread.Sleep(1000);
                IWebElement skilldropdown = driver.FindElement(By.Name("level"));
                SelectElement SelectSkillLevel = new SelectElement(skilldropdown);
                SelectSkillLevel.SelectByValue(skillLevel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void skillAddBtn(IWebDriver driver)
        {
            try
            {
                driver.FindElement(By.XPath("//input[@value='Add']")).Click();
                Thread.Sleep(1000);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void skillUpdateBtn(IWebDriver driver)
        {
           // Thread.Sleep(2000);
           // driver.FindElement(By.XPath("//div[@class='ui teal button']")).Click();
            driver.FindElement(By.XPath("//input[@value='Update']")).Click();
        }

        public void updateSkills(IWebDriver driver, String skill, String skillone, String skilllevel)
        {
            Thread.Sleep(2000);
            // Find all rows in the table
            IReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr"));
          
            foreach (var row in rows)
            {
                // Get the text of the first column (skill column) in the row
                IWebElement skillElement = row.FindElement(By.XPath("./td[1]"));

                string skillText = skillElement.Text;
                Thread.Sleep(2000);
                // Check if the skill matches the provided text
                if (skillText.Equals(skill))
                {
                    // Find and click the edit icon in the row
                    row.FindElement(By.XPath("./td[3]/span[1]/i")).Click();
                    Thread.Sleep(1000);
                    driver.FindElement(By.XPath("//input[@name='name']")).Clear();
                    fillSkillTextField(driver, skillone);
                    selectSkillLevel(driver, skilllevel);
                    Thread.Sleep(3000);
                    skillUpdateBtn(driver);
                }
            }
        }

        public void deleteSkills(IWebDriver driver, String skill)
        {
            Thread.Sleep(2000);
            // Find all rows in the table
            IReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr"));

            foreach (var row in rows)
            {
                // Get the text of the first column (skill column) in the row
                IWebElement skillElement = row.FindElement(By.XPath("./td[1]"));

                string skillText = skillElement.Text;
                Thread.Sleep(2000);
                // Check if the skill matches the provided text
                if (skillText.Equals(skill))
                {
                    // Find and click the edit icon in the row
                    row.FindElement(By.XPath("./td[3]/span[2]/i")).Click();
                 }
            }
        }
    }
}
