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
                    if (keyword != null)
                    {
                        if (step.ScenarioBlock != keyword)
                        {
                            continue;
                        }
                    }

                    if (step.Text.ContainsAll(stepText))
                    {
                        yield return step.Text;
                    }
                }
            }
        }


        private (ScenarioBlock? keyword, string[] steps) GetKeywordAndStep(string enteredText)
        {
            var split = enteredText.Split(new string[] { " " }, StringSplitOptions.None);

            if (Enum.TryParse<ScenarioBlock>(split[0], out var block))
            {
                return (block, split[1..]);
            }

            return (null, split);
        }
    }


    public static class StringExtensions
    {
        public static bool ContainsAll(this string text, string[] parts)
        {
            foreach (var part in parts)
            {
                if (!text.Contains(part))
                {
                    return false;
                }
            }

            return true;
        }
    }
}