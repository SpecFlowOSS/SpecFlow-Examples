using Boa.Constrictor.Screenplay;
using Boa.Constrictor.WebDriver;
using CommunityContentSubmissionPage.Specs.Pages;
using CommunityContentSubmissionPage.Specs.Steps;
using System;
using System.Collections.Generic;

namespace CommunityContentSubmissionPage.Specs.Interactions
{
    public class FillOutSubmissionForm : ITask
    {
        private readonly IEnumerable<SubmissionEntryFormRowObject> _rows;

        private FillOutSubmissionForm(IEnumerable<SubmissionEntryFormRowObject> rows)
        {
            _rows = rows;
        }

        public void PerformAs(IActor actor)
        {
            foreach (var row in _rows)
            {
                switch (row.Label.ToUpper())
                {
                    case "URL":
                        actor.AttemptsTo(SendKeys.To(SubmissionPage.UrlInputField, row.Value));
                        break;
                    case "TYPE":
                        actor.AttemptsTo(Select.ByText(SubmissionPage.TypeSelect, row.Value));
                        break;
                    case "EMAIL":
                        actor.AttemptsTo(SendKeys.To(SubmissionPage.EmailInputField, row.Value));
                        break;
                    case "DESCRIPTION":
                        actor.AttemptsTo(SendKeys.To(SubmissionPage.DescriptionInputField, row.Value));
                        break;
                    case "NAME":
                        actor.AttemptsTo(SendKeys.To(SubmissionPage.NameField, row.Value));
                        break;
                    case "PRIVACY POLICY":
                        var privacyPolicyIsChecked = actor.AskingFor(SelectedState.Of(SubmissionPage.PrivacyPolicy));
                        var expectedPrivacyPolicyChecked = row.Value.ToUpper() == "TRUE";

                        if (expectedPrivacyPolicyChecked != privacyPolicyIsChecked)
                        {
                            actor.AttemptsTo(Click.On(SubmissionPage.PrivacyPolicy));
                        }

                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public static ITask With(IEnumerable<SubmissionEntryFormRowObject> rows)
        {
            return new FillOutSubmissionForm(rows);
        }
    }
}
