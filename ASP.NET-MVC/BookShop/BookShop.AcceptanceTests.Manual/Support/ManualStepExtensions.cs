using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BookShop.AcceptanceTests.Manual.Support
{
    [Binding]
    public static class ManualStepBindings
    {
        private const string manualStepMatch = @".*\(manual\)";

        [Given(manualStepMatch)]
        [When(manualStepMatch)]
        [Then(manualStepMatch)]
        public static void ManualStep()
        {
            ScenarioContext.Current.ManualStepWinForm();
        }

        private const string manualStepWithTextMatch = @".*\(manual with text\)";

        [Given(manualStepWithTextMatch)]
        [When(manualStepWithTextMatch)]
        [Then(manualStepWithTextMatch)]
        public static void ManualStepWithText(string multilineText)
        {
            ScenarioContext.Current.ManualStepWinForm();
        }

        private const string manualStepWithTableMatch = @".*\(manual with table\)";

        [Given(manualStepWithTableMatch)]
        [When(manualStepWithTableMatch)]
        [Then(manualStepWithTableMatch)]
        public static void ManualStepWithText(Table table)
        {
            ScenarioContext.Current.ManualStepWinForm();
        }
    }

    public static class ManualStepExtensions
    {
        const string DISABLE_POPUP_KEY = "DisableSpecFlowPopup";

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        class ForegroundWindow : IWin32Window
        {
            static public ForegroundWindow Get()
            {
                var handle = GetForegroundWindow();
                if (handle == IntPtr.Zero)
                    return null;
                return new ForegroundWindow(handle);
            }

            private ForegroundWindow(IntPtr handle)
            {
                Handle = handle;
            }

            public IntPtr Handle { get; set; }
        }

        public static void ManualStepWinForm(this ScenarioContext scenarioContext)
        {
            string disablePopup = Environment.GetEnvironmentVariable(DISABLE_POPUP_KEY);
            if (disablePopup != null && disablePopup.Equals("true", StringComparison.InvariantCultureIgnoreCase))
                Assert.Inconclusive("Manual steps are disabled on this machine");

            StringBuilder messageBoxText = new StringBuilder();
            messageBoxText.Append("Scenario: ");
            messageBoxText.AppendLine(scenarioContext.ScenarioInfo.Title);
            messageBoxText.AppendLine();

            // Because the previously appended lines
            int headerLineCount = messageBoxText.ToString().Count(c => c == '\n');

            int line = GetCurrentPositionText(messageBoxText) + headerLineCount;
            var form = new ManualStepForm
                           {
                               ManualStepText = messageBoxText.ToString(),
                               CurrentLine = line
                           };

            form.ShowDialog();

            var result = form.DialogResult;

            switch (result)
            {
                case DialogResult.Yes:
                    return;
                case DialogResult.No:
                    Assert.Fail("Manual step failed");
                    break;
                default:
                    Assert.Inconclusive("Manual step cancelled");
                    break;
            }
        }

        public static void ManualStep(this ScenarioContext scenarioContext)
        {
            string disablePopup = Environment.GetEnvironmentVariable(DISABLE_POPUP_KEY);
            if (disablePopup != null && disablePopup.Equals("true", StringComparison.InvariantCultureIgnoreCase))
                Assert.Inconclusive("Manual steps are disabled on this machine");

            StringBuilder messageBoxText = new StringBuilder();
            messageBoxText.Append("Scenario: ");
            messageBoxText.AppendLine(scenarioContext.ScenarioInfo.Title);
            messageBoxText.AppendLine();
            
            GetCurrentPositionText(messageBoxText);

            messageBoxText.AppendLine();
            messageBoxText.AppendLine("Was the manual step successfuly executed?");

            var result = MessageBox.Show(ForegroundWindow.Get(), messageBoxText.ToString(), "Manual scenario step", 
                                         MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, 
                                         MessageBoxDefaultButton.Button2);

            switch (result)
            {
                case DialogResult.Yes:
                    return;
                case DialogResult.No:
                    Assert.Fail("Manual step failed");
                    break;
                default:
                    Assert.Inconclusive("Manual step cancelled");
                    break;
            }
        }

        private static int GetCurrentPositionText(StringBuilder messageBoxText)
        {
            int currentPositionText = 0;
            try
            {
                var frames = new StackTrace(true).GetFrames();
                if (frames != null)
                {
                    var featureFileFrame = frames.FirstOrDefault(f =>
                                                                 f.GetFileName() != null &&
                                                                 f.GetFileName().EndsWith(".feature"));

                    if (featureFileFrame != null)
                    {
                        var lines = File.ReadAllLines(featureFileFrame.GetFileName());
                        const int frameSize = 20;
                        int currentLine = featureFileFrame.GetFileLineNumber() - 1;
                        int minLine = Math.Max(0, currentLine - frameSize);
                        int maxLine = Math.Min(lines.Length - 1, currentLine + frameSize);

                        for (int lineNo = currentLine - 1; lineNo >= minLine; lineNo--)
                        {
                            if (lines[lineNo].TrimStart().StartsWith("Scenario:"))
                            {
                                minLine = lineNo + 1;
                                break;
                            }
                        }

                        for (int lineNo = currentLine + 1; lineNo <= maxLine; lineNo++)
                        {
                            if (lines[lineNo].TrimStart().StartsWith("Scenario:"))
                            {
                                maxLine = lineNo - 1;
                                break;
                            }
                        }

                        for (int lineNo = minLine; lineNo <= maxLine; lineNo++)
                        {
                            messageBoxText.Append(lineNo == currentLine ? "->  " : "    ");
                            messageBoxText.AppendLine(lines[lineNo]);
                            if (lineNo == currentLine)
                                currentPositionText = lineNo - minLine;
                        }
                        
                        return currentPositionText;
                    }
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex, "GetCurrentPositionText");
            }

            messageBoxText.AppendLine("(Unable to detect current step)");

            return currentPositionText;
        }
    }
}