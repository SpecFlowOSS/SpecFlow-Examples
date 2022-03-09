using SpecFlow.Actions.Playwright;
using System.Threading.Tasks;

namespace Example.PageObjects
{
    /// <summary>
    /// Calculator Page Object
    /// </summary>
    public class CalculatorPageObject : BasePage
    {
        // The page URL
        private protected const string CalculatorUrl = "https://specflowoss.github.io/Calculator-Demo/Calculator.html";

        //Finding elements by ID
        private static string FirstNumberFieldSelector => "#first-number";
        private static string SecondNumberFieldSelector => "#second-number";
        private static string AddButtonSelector => "#add-button";
        private static string ResultLabelSelector => "#result";
        private static string ResetButtonSelector => "#reset-button";

        private Interactions _interactions;

        public CalculatorPageObject(BrowserDriver browserDriver) : base(browserDriver)
        {
            _interactions = new Interactions(_page);
        }

        public async Task EnterFirstNumberAsync(string number)
        {
            //Enter text
            await _interactions.SendTextAsync(FirstNumberFieldSelector, number);
        }

        public async Task EnterSecondNumberAsync(string number)
        {
            //Enter text
            await _interactions.SendTextAsync(SecondNumberFieldSelector, number);
        }

        public async Task ClickAddAsync()
        {
            //Click the add button
            await _interactions.ClickAsync(AddButtonSelector);
        }

        public async Task EnsureCalculatorIsOpenAndResetAsync()
        {
            //Open the calculator page in the browser if not opened yet
            if ((await _page).Url != CalculatorUrl)
            {
                await _interactions.GoToUrl(CalculatorUrl);
            }
            //Otherwise reset the calculator by clicking the reset button
            else
            {
                //Click the rest button
                await _interactions.ClickAsync(ResetButtonSelector);

                //Wait until the result is empty again
                await WaitForEmptyResultAsync();
            }
        }

        public async Task<string?> WaitForNonEmptyResultAsync()
        {
            // Waits for the ResultLabelSelector value to be !== ""
            await _interactions.WaitForNonEmptyValue(ResultLabelSelector);

            // Gets the value attribute of the ResultLabelSelector
            return await _interactions.GetValueAttributeAsync(ResultLabelSelector);
        }

        public async Task WaitForEmptyResultAsync()
        {
            // Waits for the ResultLabelSelector value to be === ""
            await _interactions.WaitForEmptyValue(ResultLabelSelector);
        }
    }
}