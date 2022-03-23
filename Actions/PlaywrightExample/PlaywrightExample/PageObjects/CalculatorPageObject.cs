using SpecFlow.Actions.Playwright;
using System.Threading.Tasks;
using Microsoft.Playwright;
using PlaywrightExample.PageObjects;

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

        
        


        public async Task EnterFirstNumberAsync(string number)
        {
            //Enter text
            await Page.FillAsync(FirstNumberFieldSelector, number);
        }

        public async Task EnterSecondNumberAsync(string number)
        {
            //Enter text
            await Page.FillAsync(SecondNumberFieldSelector, number);
        }

        public async Task ClickAddAsync()
        {
            //Click the add button
            await Page.ClickAsync(AddButtonSelector);
        }

        public async Task EnsureCalculatorIsOpenAndResetAsync()
        {
            
            //Open the calculator page in the browser if not opened yet
            if (Page.Url != CalculatorUrl)
            {
                await Page.GotoAsync(CalculatorUrl);
            }
            //Otherwise reset the calculator by clicking the reset button
            else
            {
                //Click the rest button
                await Page.ClickAsync(ResetButtonSelector);

                //Wait until the result is empty again
                await WaitForEmptyResultAsync();
            }
        }

        public async Task<string?> WaitForNonEmptyResultAsync()
        {
            // Waits for the ResultLabelSelector value to be !== ""
            await WaitForNonEmptyValue(ResultLabelSelector);

            // Gets the value attribute of the ResultLabelSelector
            return await GetValueAttributeAsync(ResultLabelSelector);
        }

        public async Task WaitForEmptyResultAsync()
        {
            // Waits for the ResultLabelSelector value to be === ""
            await WaitForEmptyValue(ResultLabelSelector);
        }


        public async Task WaitForNonEmptyValue(string selector)
        {
            await Page.WaitForFunctionAsync($"document.querySelector(\"{selector}\").value !== \"\"");
        }

        public async Task WaitForEmptyValue(string selector)
        {
            await Page.WaitForFunctionAsync($"document.querySelector(\"{selector}\").value === \"\"");
        }

        public async Task<string?> GetValueAttributeAsync(string selector, PageInputValueOptions? pageInputValueOptions = null)
        {
            return await Page.InputValueAsync(selector, pageInputValueOptions);
        }

        public CalculatorPageObject(IPage page) : base(page)
        {
        }
    }
}