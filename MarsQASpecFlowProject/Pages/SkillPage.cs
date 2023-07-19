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
        public void skillsTab()
        {
            try
            {
               driver.FindElement(By.XPath("//a[normalize-space()='Skills']")).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void skillAddNewBtn()
        {
            driver.FindElement(By.XPath("//div[@class='ui teal button']")).Click();
        }

        public void fillSkillTextField(String skillvalue)
        {
            driver.FindElement(By.XPath("//input[@name='name']")).SendKeys(skillvalue);

        }

        public void selectSkillLevel(String skillLevel)
        {
            try
            {
                IWebElement skilldropdown = driver.FindElement(By.Name("level"));
                SelectElement SelectSkillLevel = new SelectElement(skilldropdown);
                SelectSkillLevel.SelectByValue(skillLevel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void skillAddBtn()
        {
            try
            {
                driver.FindElement(By.XPath("//input[@value='Add']")).Click();
                          }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void skillUpdateBtn()
        {
           
            driver.FindElement(By.XPath("//input[@value='Update']")).Click();
        }

        public void updateSkills(String skill, String skillone, String skilllevel)
        {
            // Find all rows in the table
            IReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr"));
          
            foreach (var row in rows)
            {
                // Get the text of the first column (skill column) in the row
                IWebElement skillElement = row.FindElement(By.XPath("./td[1]"));

                string skillText = skillElement.Text;
                // Check if the skill matches the provided text
                if (skillText.Equals(skill))
                {
                    // Find and click the edit icon in the row
                    row.FindElement(By.XPath("./td[3]/span[1]/i")).Click();
                    driver.FindElement(By.XPath("//input[@name='name']")).Clear();
                    fillSkillTextField(skillone);
                    selectSkillLevel(skilllevel);
                    skillUpdateBtn();
                }
            }
        }

        public void deleteSkills(String skill)
        {
            // Find all rows in the table
            IReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr"));

            foreach (var row in rows)
            {
                // Get the text of the first column (skill column) in the row
                IWebElement skillElement = row.FindElement(By.XPath("./td[1]"));

                string skillText = skillElement.Text;
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
