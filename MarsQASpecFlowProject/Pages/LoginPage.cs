using MarsQASpecFlowProject.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsQASpecFlowProject.Pages
{
    public class LoginPage : CommonDriver
    {

        public void loginUser(IWebDriver driver, String uname)
        {
            try

            {
                //Identify username textbox and enter valid username            
                driver.FindElement(By.XPath("//input[@name='email']")).SendKeys(uname);
                
            }

            catch (Exception ex)

            {
                Assert.Fail("TurnUp portal page didn't load", ex);
            }

         }

        public void loginPwd(IWebDriver driver, String pwd)
        {
            try

            {
                
                //Identify password textbox and enter valid password
                driver.FindElement(By.XPath("//input[@name='password']")).SendKeys(pwd);

            }

            catch (Exception ex)

            {
                Assert.Fail("TurnUp portal page didn't load", ex);
            }

        }


        public void rememberChk(IWebDriver driver)
        {
            driver.FindElement(By.XPath("//input[@type='checkbox']")).Click();
        }
        
        public void loginbtn(IWebDriver driver)
        {

            try

            {
                //Click login button
                driver.FindElement(By.XPath("//div[@class='field']/button")).Click();
                Thread.Sleep(1000);

            }

            catch (Exception ex)

            {
                Assert.Fail("TurnUp portal page didn't load", ex);
            }



        }

    }


    
}
