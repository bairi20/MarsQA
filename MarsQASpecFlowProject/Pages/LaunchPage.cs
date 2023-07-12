using MarsQASpecFlowProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsQASpecFlowProject.Pages
{
    internal class LaunchPage : CommonDriver
    {

    public void launch(OpenQA.Selenium.IWebDriver driver)
        {
            //launch turnup portal
            driver.Navigate().GoToUrl("http://localhost:5000/");
            //Initialize();
            driver.Manage().Window.Maximize();
            Thread.Sleep(2000);
        }
    }
}
