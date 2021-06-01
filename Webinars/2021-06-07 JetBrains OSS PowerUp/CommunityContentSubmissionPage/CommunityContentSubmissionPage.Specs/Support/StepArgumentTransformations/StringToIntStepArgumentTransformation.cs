using TechTalk.SpecFlow;

namespace CommunityContentSubmissionPage.Specs.Support.StepArgumentTransformations
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