using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using SeleniumExtras.WaitHelpers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore
{
    public class Checkout
    {
        private String searchKeyword;
        private ChromeDriver chromeDriver;


        public void GivenIHaveNavigatedToMyStoreWebsite()
        {
            chromeDriver = new ChromeDriver();
            chromeDriver.Navigate().GoToUrl("http://automationpractice.com/index.php");
        }

        public void GivenIHaveEnteredSearchKeyword(string searchString)
        {
            this.searchKeyword = searchString.ToLower();
            var searchInputBox = chromeDriver.FindElement(By.Id("search_query_top"));
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("search_query_top")));
            searchInputBox.SendKeys(searchKeyword);
        }

        public void WhenIPressTheSearchButton()
        {
            var searchButton = chromeDriver.FindElement(By.Name("submit_search"));
            searchButton.Click();
        }
        public void SelectADressFromList()
        {
            //var labels = chromeDriver.FindElements(By.CssSelector("ul[class*=product_list]"));
            //labels.FirstOrDefault().Click();
            //IWebElement selectElement = chromeDriver.FindElement(By.CssSelector("ul[class*=product_list]"));
            //var selectObject = new SelectElement(selectElement);
            //selectObject.SelectByIndex(1);
            chromeDriver.Navigate().GoToUrl("http://automationpractice.com/index.php?id_product=5&controller=product&search_query=printed+summer+dress&results=3");
        }
        public void ConfigureSelection()
        {
            var quantityInput = chromeDriver.FindElement(By.Id("quantity_wanted"));
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("quantity_wanted")));
            quantityInput.Clear();
            quantityInput.SendKeys("2");
            // select the drop down list
            var education = chromeDriver.FindElement(By.Name("group_1"));
            //create select element object 
            var selectElement = new SelectElement(education);
            selectElement.SelectByText("M");
            var addToCart = chromeDriver.FindElement(By.Name("Submit"));
            addToCart.Click();
            chromeDriver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=order");
        }

        public void ConfirmSelection()
        {

            //IAlert alert = (IAlert)chromeDriver.SwitchTo().ActiveElement();
            //alert.Accept();
            chromeDriver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=order");
        }

    }
}
