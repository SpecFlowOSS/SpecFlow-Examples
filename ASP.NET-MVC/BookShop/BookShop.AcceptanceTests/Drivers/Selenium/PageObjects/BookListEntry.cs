using OpenQA.Selenium;

namespace BookShop.AcceptanceTests.Drivers.Selenium.PageObjects
{
    class BookListEntry
    {
        private readonly IWebElement _row;

        public BookListEntry(IWebElement row)
        {
            _row = row;
        }

        public string Title
        {
            get
            {
                var rowText = _row.Text;
                

                var webElement = _row.FindElement(By.ClassName("title"));
                var linkElement = webElement.FindElement(By.TagName("a"));
                return linkElement.Text;
            }
        }

        public string Author => _row.FindElement(By.ClassName("#author")).Text;

        public string Price => _row.FindElement(By.ClassName("#price")).Text;

        public IWebElement AddToCartButton => _row.FindElement(By.LinkText("Add to cart"));
        public IWebElement RemoveFromCartButton => _row.FindElement(By.LinkText("X"));

        public IWebElement QuantityField => _row.FindElement(By.Name("Quantity"));

        public IWebElement UpdateButton => _row.FindElement(By.ClassName("btn"));

        public int Quantity
        {
            get => int.Parse(QuantityField.GetAttribute("value"));
            set
            {
                QuantityField.Clear();
                QuantityField.SendKeys(value.ToString());
                UpdateButton.Click();
            }
        }



        public void RemoveFromCart()
        {
            RemoveFromCartButton.Click();
        }

        public void AddToCart()
        {
            AddToCartButton.Click();

        }
    }
}
