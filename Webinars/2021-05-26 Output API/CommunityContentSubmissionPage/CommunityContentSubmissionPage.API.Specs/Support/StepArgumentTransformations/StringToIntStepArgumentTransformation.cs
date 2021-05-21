using TechTalk.SpecFlow;

namespace CommunityContentSubmissionPage.API.Specs.Support.StepArgumentTransformations
{
    [Binding]
    public class StringToIntStepArgumentTransformation
    {
        [StepArgumentTransformation("one")]
        public int TransformOneTo1()
        {
            return 1;
        }
    }
}
