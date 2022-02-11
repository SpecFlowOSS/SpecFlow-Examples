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

        [When(@"I select")]
        public void WhenISelect(Table table)
        {
            
        }

        [Then(@"the step text after the keyword is replaced with")]
        public void ThenTheStepTextAfterTheKeywordIsReplacedWith(string multilineText)
        {
            
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

        [Given(@"these suggestions are presented")]
        [Given(@"suggestions are:")]
        public void GivenSuggestionsAre(Table table)
        {
            foreach (var row in table.Rows)
            {
                _autoCompletion.AddSuggestion(row["Suggestion"]);
            }
        }

        [When(@"displayed on screen")]
        public void WhenDisplayedOnScreen()
        {
            _automcompletionResult = _autoCompletion.GetAutomcompletionForFile(string.Empty).ToList();
        }

        [Then(@"the order is")]
        public void ThenTheOrderIs(Table table)
        {
            var expectedSuggestions = table.Rows.Select(r => r["Suggestion"]).ToList();

            _automcompletionResult.Should().Equal(expectedSuggestions);
        }

    }

    
}
