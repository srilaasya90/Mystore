using NUnit.Framework;

namespace MyStore
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
           Checkout checkout = new Checkout();
            checkout.GivenIHaveNavigatedToMyStoreWebsite();
            checkout.GivenIHaveEnteredSearchKeyword("Printed Summer Dress");
            checkout.WhenIPressTheSearchButton();
            checkout.SelectADressFromList();
            checkout.ConfigureSelection();
            checkout.ConfirmSelection();
            //Assert.IsTrue(chromeDriver.Url.ToLower().Contains(searchKeyword));
            //Assert.IsTrue(chromeDriver.Title.ToLower().Contains(searchKeyword));
        }
    }
}