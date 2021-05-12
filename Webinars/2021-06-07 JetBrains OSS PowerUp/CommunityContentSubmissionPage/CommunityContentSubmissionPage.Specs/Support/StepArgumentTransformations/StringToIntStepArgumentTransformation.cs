using System;
using System.Collections.Generic;
using System.Text;
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
