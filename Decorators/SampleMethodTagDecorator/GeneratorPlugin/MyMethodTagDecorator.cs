using System.CodeDom;
using TechTalk.SpecFlow.Generator;
using TechTalk.SpecFlow.Generator.UnitTestConverter;

namespace SampleGeneratorPlugin
{
	public class MyMethodTagDecorator : ITestMethodTagDecorator
	{

		public static readonly string TAG_NAME = "myMethodTagDecorator";
		private readonly ITagFilterMatcher _tagFilterMatcher;

		public MyMethodTagDecorator(ITagFilterMatcher tagFilterMatcher)
		{
			_tagFilterMatcher = tagFilterMatcher;
		}

		public bool CanDecorateFrom(string tagName, TestClassGenerationContext generationContext, CodeMemberMethod testMethod)
		{
			return _tagFilterMatcher.Match(TAG_NAME, tagName);
		}

		public void DecorateFrom(string tagName, TestClassGenerationContext generationContext, CodeMemberMethod testMethod)
		{
			var attribute = new CodeAttributeDeclaration(
				"NUnit.Framework.ApartmentAttribute",
				new CodeAttributeArgument(
					new CodeFieldReferenceExpression(
						new CodeTypeReferenceExpression(typeof(System.Threading.ApartmentState)),
						"STA")));

			testMethod.CustomAttributes.Add(attribute);
		}

		public int Priority { get; }
		public bool RemoveProcessedTags { get; }
		public bool ApplyOtherDecoratorsForProcessedTags { get; }
	}
}
