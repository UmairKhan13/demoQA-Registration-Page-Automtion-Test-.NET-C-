using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
namespace SeleniumProject
{
 public class selenium
 {
 public static void Main(string[] args)
 {
 new DriverManager().SetUpDriver(new ChromeConfig());
 IWebDriver driver = new ChromeDriver();
 driver.Manage().Window.Maximize();
 driver.Url = "https://demoqa.com/automation-practice-form";
 //first name
 driver.FindElement(By.Id("firstName")).SendKeys("Mujtaba and Umair");
 //last name
 driver.FindElement(By.Id("lastName")).SendKeys("Khan");
 //email
 driver.FindElement(By.Id("userEmail")).SendKeys("kmuhammadumair02@gmail.com");
 //gender
 driver.FindElement(By.XPath("//*[@id='genterWrapper']/div[2]/div[1]/label[1]")).Click();
 //phone number
 driver.FindElement(By.Id("userNumber")).SendKeys("03152800088");
 //DateTime of birth
 driver.FindElement(By.Id("dateOfBirthInput")).Click();
 driver.FindElement(By.Id("dateOfBirthInput")).Clear();
 var month = driver.FindElement(By.ClassName("react-datepicker__month-select"));
 var selectMonth = new SelectElement(month);
 selectMonth.SelectByText("January");
 var year = driver.FindElement(By.ClassName("react-datepicker__year-select"));
 var selectYear = new SelectElement(year);
 selectYear.SelectByValue("2000");
 driver.FindElement(By.CssSelector("div#dateOfBirth > div:nth-of-type(2) > div:nth-of-type(2) > " +
 "div > div > div:nth-of-type(2) > div:nth-of-type(2) > div:nth-of-type(3) > div:nth-of-type(2)")).Click();

 //subject
 IWebElement webl =
driver.FindElement(By.XPath("/html[1]/body[1]/div[2]/div[1]/div[1]/div[2]/div[2]/div[1]/form[1]/div[6]/div[2]/div[1]/di
v[1]/div[1]"));
 Actions builder = new Actions(driver);
 builder.MoveToElement(webl).Click(webl).SendKeys("Co").Build().Perform();
 Thread.Sleep(1000);
 builder.MoveToElement(webl).SendKeys(Keys.Enter).Build().Perform();
 driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(20);
 //hobby
 IJavaScriptExecutor jss = (IJavaScriptExecutor)driver;
 jss.ExecuteScript("arguments[0].scrollIntoView(true);",
driver.FindElement(By.XPath("//*[@id='hobbiesWrapper']/div[2]/div[1]/label[1]")));
 driver.FindElement(By.XPath("//*[@id='hobbiesWrapper']/div[2]/div[1]/label[1]")).Click();
 //image
 driver.FindElement(By.Id("uploadPicture")).SendKeys(@"C:\Users\mumai\Downloads\paymentuseCase.jpg");
 driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(10);
 //address
 driver.FindElement(By.Id("currentAddress")).SendKeys("FAST NUCES,SHAH LATIF,KARACHI");
 //state
 IWebElement state = driver.FindElement(By.XPath("//input[@id='react-select-3-input']"));
 state.SendKeys("Uttar Pradesh");
 state.SendKeys(Keys.ArrowDown);
 state.SendKeys(Keys.Enter);
 //city
 IWebElement city = driver.FindElement(By.XPath("//input[@id='react-select-4-input']"));
 city.SendKeys("Agra");
 city.SendKeys(Keys.ArrowDown);
 city.SendKeys(Keys.Enter);
 //
 driver.Close();
 }
 }
}