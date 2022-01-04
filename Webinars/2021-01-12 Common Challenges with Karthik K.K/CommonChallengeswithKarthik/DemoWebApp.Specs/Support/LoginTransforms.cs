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

        [StepArgumentTransformation(@"I have a ?(invalid|valid) username")]
        public UserCredentials TransformTableToUserCredentials(Table table)
        {
            return table.CreateInstance<UserCredentials>();
        }
    }
}
