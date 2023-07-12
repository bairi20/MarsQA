using MarsQASpecFlowProject.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using System.Reflection.Emit;

namespace MarsQASpecFlowProject.Pages
{
    public class LanguagePage : CommonDriver
    {

        public void selectlanguageTab(IWebDriver driver)
        {
          
            driver.FindElement(By.XPath("//div[@class='ui top attached tabular menu']//a[@data-tab='first']")).Click();
            
        }       
        
        public void addNewBtn(IWebDriver driver)
        {

            Thread.Sleep(1000);
            // xpath of html table
           var elemTable = driver.FindElement(By.XPath("//table[@class='ui fixed table']"));

            // Fetch all Row of the table
            List<IWebElement> lstTrElem = new List<IWebElement>(elemTable.FindElements(By.TagName("tr")));
            Console.WriteLine("Length of the table rows +++  " + lstTrElem.Count);

            Thread.Sleep(500);

            if (lstTrElem.Count == 5 )
            {
                for (int i = lstTrElem.Count; i >= 1; i--)
                {                   
                    driver.FindElement(By.XPath("/ html[1] / body[1] / div[1] / div[1] / section[2] / div[1] / div[1] / div[1] / div[3] / form[1] / div[2] / div[1] / div[2] / div[1] / table[1] / tbody[1] / tr[1] / td[3] / span[2] / i[1]")).Click();
                    driver.Navigate().Refresh();
                    Thread.Sleep(3000);
                   // Console.WriteLine("Record deleted " + i);
                }
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//div[@class='ui bottom attached tab segment active tooltip-target']//div[@class='ui teal button '][normalize-space()='Add New']")).Click();
             }
            else
            {
                driver.FindElement(By.XPath("//div[@class='ui bottom attached tab segment active tooltip-target']//div[@class='ui teal button '][normalize-space()='Add New']")).Click();
                Thread.Sleep(1000); 
            }
 }

        public void fillTextField(IWebDriver driver, String lang)
        {           
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//input[@name='name']")).SendKeys(lang);

        }
        /*public void fillTextFieldUpdate(IWebDriver driver, String langone)
        {
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//input[@name='name']")).SendKeys(langone);

        }*/

        public void selectValue(IWebDriver driver, String dvalue)
        {
            Thread.Sleep(1000);
            IWebElement languageLevel = driver.FindElement(By.Name("level"));
            SelectElement SelectLevel = new SelectElement(languageLevel);
            SelectLevel.SelectByValue(dvalue);

        }

        public void languageAddBtn(IWebDriver driver)
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

    public void languageUpdateBtn(IWebDriver driver)
        {
            try
            {
                driver.FindElement(By.XPath("//input[@value='Update']")).Click();
                Thread.Sleep(1000);
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public void updateLanguage(IWebDriver driver, String lang, String langone, String levelone)
        {
            Thread.Sleep(2000);
            // Find all rows in the table
            IReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr"));
           
            foreach (var row in rows)
            {
                // Get the text of the first column (language column) in the row
                IWebElement languageElement = row.FindElement(By.XPath("./td[1]"));
                string languageText = languageElement.Text;
                Thread.Sleep(2000);
                // Check if the language matches the provided text
                if (languageText.Equals(lang))
                {
                    // Find and click the edit icon in the row
                    row.FindElement(By.XPath("./td[3]/span[1]/i")).Click();
                    Thread.Sleep(1000);
                    driver.FindElement(By.XPath("//input[@name='name']")).Clear();
                    fillTextField(driver, langone);
                    selectValue(driver, levelone);
                    Thread.Sleep(3000);
                    languageUpdateBtn(driver);
                }
            }
        }


        public void deleteLanguage(IWebDriver driver, String lang)
        {
            Thread.Sleep(2000);
            // Find all rows in the table
            IReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr"));
            
            foreach (var row in rows)
            {
                // Get the text of the first column (language column) in the row
                IWebElement languageElement = row.FindElement(By.XPath("./td[1]"));
                string languageText = languageElement.Text;
                Thread.Sleep(2000);
                // Check if the language matches the provided text
                if (languageText.Equals(lang))
                {
                    // Find and click the edit icon in the row
                    row.FindElement(By.XPath("./td[3]/span[2]/i")).Click();
                    
                }
            }
        }
    }

    
}
