using System;
using System.Globalization;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SpecFlow.Example.StepArgumentTransformation
{
    [Binding]
    public class AustrianLocalizationTransformer
    {
        [StepArgumentTransformation]
        public double TransformDouble(string expr)
        {
            return Convert.ToDouble(expr, CultureInfo.GetCultureInfo("de-AT"));
        }      
        
        [StepArgumentTransformation]
        public DateTime TransformDate(string expr)
        {
            return Convert.ToDateTime(expr, CultureInfo.GetCultureInfo("de-AT"));
        }
    }
    [Binding]
    public class ConvertSteps
    {
        [Given("I have entered (.*) into the system")]
        public void GivenIHaveEnteredSomethingIntoTheSystem(double number)
        {
            Assert.That(number, Is.EqualTo(1050.1));
        }

        [Given("the date is (.*)")]
        public void TheDateIs(DateTime dateTime)
        {
            Assert.That(dateTime, Is.EqualTo(new DateTime(2010,12,22)));
        }
    }
}
