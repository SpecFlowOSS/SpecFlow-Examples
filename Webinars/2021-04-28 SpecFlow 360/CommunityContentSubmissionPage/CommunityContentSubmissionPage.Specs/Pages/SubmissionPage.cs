using Boa.Constrictor.WebDriver;
using OpenQA.Selenium;
using static Boa.Constrictor.WebDriver.WebLocator;

namespace CommunityContentSubmissionPage.Specs.Pages
{
    public static class SubmissionPage
    {
        public static IWebLocator UrlInputField => L("URL Input field", By.Id("txtUrl"));
        public static IWebLocator UrlLabel => L("URL Label", By.CssSelector("#url label"));
        public static IWebLocator EmailInputField => L("Email Input", By.CssSelector("#email input"));
        public static IWebLocator DescriptionInputField => L("Description input", By.CssSelector("#description input"));
        public static IWebLocator TypeSelect => L("Type select", By.CssSelector("#type select"));
        public static IWebLocator PrivacyPolicy => L("privacy policy checkbox", By.Id("chkPrivacyPolicy"));
        public static IWebLocator SubmitButton => L("submit button", By.ClassName("btn-primary"));
        public static IWebLocator CancelButton => L("cancel button", By.ClassName("btn-secondary"));
        public static IWebLocator TypeLabel => L("Type Label", By.CssSelector("#type label"));
        public static IWebLocator DescriptionLabel => L("Description Label", By.CssSelector("#description label"));
        public static IWebLocator EmailLabel => L("Email Label", By.CssSelector("#email label"));
        public static IWebLocator NameField => L("Name Input", By.CssSelector("#name input"));
    }
}
