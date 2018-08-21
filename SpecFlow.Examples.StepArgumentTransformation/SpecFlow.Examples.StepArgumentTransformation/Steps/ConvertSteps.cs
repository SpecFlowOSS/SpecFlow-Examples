using System;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace SpecFlow.Example.StepArgumentTransformation.Steps
{
    [Binding]
    public class ConvertSteps
    {
        [Given("I have entered (.*) into the system")]
        public void GivenIHaveEnteredSomethingIntoTheSystem(double number)
        {
            number.Should().Be(1050.1);
        }

        [Given("the date is (.*)")]
        public void TheDateIs(DateTime dateTime)
        {
            dateTime.Should().Be(new DateTime(2010, 12, 22));
        }
    }
}
