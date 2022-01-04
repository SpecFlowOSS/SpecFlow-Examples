using TechTalk.SpecFlow.Assist;

namespace DemoWebApp.Specs.Support
{
    [Binding]
    internal class LoginTransforms
    {
        [StepArgumentTransformation(@"?(Username|Password) validation")]
        public IEnumerable<DomainTerm> TransformTableToDomainTerm(Table table) 
        {
            return table.CreateSet<DomainTerm>();
        }
    }
}
