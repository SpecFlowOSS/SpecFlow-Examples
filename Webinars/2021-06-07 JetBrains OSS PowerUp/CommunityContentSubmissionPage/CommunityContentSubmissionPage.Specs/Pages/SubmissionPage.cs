using Boa.Constrictor.WebDriver;
using OpenQA.Selenium;
using static Boa.Constrictor.WebDriver.WebLocator;

namespace CommunityContentSubmissionPage.Specs.Pages
{
    public static class SubmissionPage
    {
        public static IWebLocator UrlInputField => L("URL Input field", By.Id("txtUrl"));
        public static IWebLocator UrlLabel => L("URL Label", By.CssSelector("#url label"));
        
        public static IWebLocator UrlError => L("URL Error", By.CssSelector("#url span"));
        public static IWebLocator EmailInputField => L("Email Input", By.CssSelector("#email input"));
        public static IWebLocator EmailLabel => L("Email Label", By.CssSelector("#email label"));
        
        public static IWebLocator EmailSpan => L("Email Label", By.CssSelector("#email span"));
        public static IWebLocator PrivacyPolicy => L("privacy policy checkbox", By.Id("chkPrivacyPolicy"));
        public static IWebLocator PrivacyPolicyLabel => L("privacy policy checkbox", By.CssSelector("#chkPrivacyPolicy label"));
        
        public static IWebLocator PrivacyPolicyError => L("privacy policy checkbox", By.CssSelector("#privacypolicy span"));
        public static IWebLocator TypeSelect => L("Type select", By.CssSelector("#type select"));
        public static IWebLocator TypeLabel => L("Type Label", By.CssSelector("#type label"));
        
        public static IWebLocator TypeError => L("Type Label", By.CssSelector("#type span"));
        public static IWebLocator DescriptionInputField => L("Description input", By.CssSelector("#description input"));
        public static IWebLocator DescriptionLabel => L("Description Label", By.CssSelector("#description label"));
        
        public static IWebLocator DescriptionError => L("Description Label", By.CssSelector("#description span"));
        public static IWebLocator NameField => L("Name Input", By.CssSelector("#name input"));
        public static IWebLocator NameLabel => L("Name Label", By.CssSelector("#name label"));
        
        public static IWebLocator NameError => L("Name Label", By.CssSelector("#name span"));
        public static IWebLocator SubmitButton => L("submit button", By.ClassName("btn-primary"));
        public static IWebLocator CancelButton => L("cancel button", By.ClassName("btn-secondary"));
    }
}

