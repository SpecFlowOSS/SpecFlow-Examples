using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BlobStorageAttachments.Specs.Drivers;
using OpenQA.Selenium.Support.Extensions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace BlobStorageAttachments.Specs.Hooks
{
    [Binding]
    public sealed class LoggingHooks
    {
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;
        private readonly BrowserDriver _browserDriver;
        private string? _attachmentTemplate;

        public LoggingHooks(ISpecFlowOutputHelper specFlowOutputHelper, BrowserDriver browserDriver)
        {
            _specFlowOutputHelper = specFlowOutputHelper;
            _browserDriver = browserDriver;
            _attachmentTemplate = Environment.GetEnvironmentVariable("ATTACHMENT_TEMPLATE");
        }

        [AfterStep]
        public void AfterStep()
        {
            var screenshot = _browserDriver.Current.TakeScreenshot();
            var imagePath = Path.GetFileNameWithoutExtension(Path.GetTempFileName()) + ".png";
            Directory.CreateDirectory("Screenshots");
            screenshot.SaveAsFile(Path.Combine("Screenshots", imagePath));
            if (!string.IsNullOrEmpty(_attachmentTemplate))
                _specFlowOutputHelper.AddAttachment(string.Format(_attachmentTemplate, imagePath));
        }
    }
}
