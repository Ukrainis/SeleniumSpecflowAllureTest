using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UnitTestProject1.PageObjects
{
    public class ShopMainPage
    {
        public ShopMainPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "homepage-slider")]
        [CacheLookup]
        public IWebElement MainPageSlider { get; set; }

        [FindsBy(How = How.ClassName, Using = "login")]
        [CacheLookup]
        public IWebElement SignInLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[class='button ajax_add_to_cart_button btn btn-default']")]
        public IList<IWebElement> AddToCartBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[class='button lnk_view btn btn-default']")]
        public IList<IWebElement> GoodMoreBtn { get; set; }
    }
}