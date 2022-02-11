using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Assist;

namespace GherkinOnlineEditor.Specs.StepDefinitions
{
    [Binding]
    public class AutoCompletionSteps
    {
        private readonly FileManager _fileManager;
        private readonly AutoCompletion _autoCompletion;
        private List<string> _automcompletionResult = new List<string>();

        public AutoCompletionSteps(FileManager fileManager, AutoCompletion autoCompletion)
        {
            _fileManager = fileManager;
            _autoCompletion = autoCompletion;
        }

        [Given(@"the existing steps")]
        public void GivenTheExistingSteps(string content)
        {
            _fileManager.AddFeatureFile(content);
        }

        [When(@"typing")]
        public void WhenTyping(string enteredText)
        {
            _automcompletionResult = _autoCompletion.GetAutomcompletionForFile(enteredText).ToList();
        }

        [Then(@"suggestions are presented:")]
        public void ThenSuggestionsArePresented(Table table)
        {
            var expectedSuggestions = table.Rows.Select(r => r["Suggestion"]).ToList();

            _automcompletionResult.Should().BeEquivalentTo(expectedSuggestions);
        }




        [Given(@"these suggestions are presented")]
        public void GivenTheseSuggestionsArePresented(Table table)
        {
            throw new PendingStepException();
        }

        [When(@"I select")]
        public void WhenISelect(Table table)
        {
            throw new PendingStepException();
        }

        [Then(@"the step text after the keyword is replaced with")]
        public void ThenTheStepTextAfterTheKeywordIsReplacedWith(string multilineText)
        {
            throw new PendingStepException();
        }

        record TypingMatchesStepRow(string Typing, string StepText, string Match);

        [Given(@"Typing Matches Step")]
        public void GivenTypingMatchesStep(Table table)
        {
            var rows = table.CreateSet<TypingMatchesStepRow>();

            foreach (var row in rows)
            {
                var automcompletionForFile = _autoCompletion.GetAutomcompletionForFile(row.Typing);

                if (row.Match == "Yes")
                {
                    automcompletionForFile.Should().Contain(row.StepText);
                }
                else
                {
                    automcompletionForFile.Should().NotContain(row.StepText);
                }
            }
        }

        [Given(@"suggestions are:")]
        public void GivenSuggestionsAre(Table table)
        {
            throw new PendingStepException();
        }

        [When(@"displayed on screen")]
        public void WhenDisplayedOnScreen()
        {
            throw new PendingStepException();
        }

        [Then(@"the order is")]
        public void ThenTheOrderIs(Table table)
        {
            throw new PendingStepException();
        }

    }

    
}
