using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GCFriendScoreV3_testes
{
    public class Login
    {
        IWebDriver driver;

        public IWebDriver Logar()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            driver.Navigate().GoToUrl("https://gamersclub.com.br/jogador/1536302");

            driver.Manage().Window.Maximize();

            IWebElement btnEntrar = driver.FindElement(By.XPath("//*[@id='gcForm']/div[5]/div[2]/a"));
            btnEntrar.Click();

            Thread.Sleep(5000);
            Thread.Sleep(5000);

            IWebElement loginLabel = driver.FindElement(By.XPath("//*[@id='steamAccountName']"));
            IWebElement passLabel = driver.FindElement(By.XPath("//*[@id='steamPassword']"));
            IWebElement btnLogin = driver.FindElement(By.XPath("//*[@id='imageLogin']"));
            loginLabel.SendKeys("Projetosgt_Testes");
            passLabel.SendKeys("truc0123");
            btnLogin.Click();

            Thread.Sleep(5000);
            Thread.Sleep(5000);
            Thread.Sleep(5000);


            return driver;
        }
    }
}
