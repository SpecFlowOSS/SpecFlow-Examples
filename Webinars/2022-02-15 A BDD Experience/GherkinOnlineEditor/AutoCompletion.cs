using System.Globalization;
using Gherkin.Ast;
using TechTalk.SpecFlow.Parser;

namespace GherkinOnlineEditor
{
    public class AutoCompletion
    {
        private readonly FileManager _fileManager;
        private readonly SpecFlowGherkinParser _specFlowGherkinParser;

        public AutoCompletion(FileManager fileManager)
        {
            _fileManager = fileManager;
            _specFlowGherkinParser = new SpecFlowGherkinParser(CultureInfo.GetCultureInfo("en"));
        }

        public IEnumerable<string> GetAutomcompletionForFile(string enteredText)
        {
            var (keyword, stepText) = GetKeywordAndStep(enteredText);


            foreach (var fileContent in _fileManager.FileContent)
            {
                var specFlowDocument = _specFlowGherkinParser.Parse(new StringReader(fileContent), new SpecFlowDocumentLocation(""));

                var steps = specFlowDocument.SpecFlowFeature.ScenarioDefinitions.SelectMany(sd => sd.Steps).Cast<SpecFlowStep>().ToList();

                foreach (var step in steps)
                {
                    if (step.ScenarioBlock != keyword)
                    {
                        continue;
                    }
                    
                    if (step.Text.Contains(stepText))
                    {
                        yield return step.Text;
                    }
                }
            }
        }


        private (ScenarioBlock keyword, string step) GetKeywordAndStep(string enteredText)
        {
            var split = enteredText.Split(new string[]{" "},StringSplitOptions.None);

            return (Enum.Parse<ScenarioBlock>(split[0].Trim()), string.Join(' ', split[1..]));
        }
    }
}