using System;
using System.Globalization;
using NUnit.Framework;

namespace SpecFlow.Example.Localization
{
    [TestFixture]
    public class ConverterTest
    {
        [Test]
        public void ConvertStringToDouble_Exploration()
        {
            Assert.AreEqual(1050.1, Convert.ToDouble("1,050.1", CultureInfo.GetCultureInfo("en-US")));
            Assert.AreEqual(1050.1, Convert.ToDouble("1.050,1", CultureInfo.GetCultureInfo("de-AT")));
            Assert.AreEqual(1050.1, Convert.ToDouble("1'050.1", CultureInfo.GetCultureInfo("de-CH")));
        }
    }
}
