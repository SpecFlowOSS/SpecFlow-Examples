using SampleGeneratorPlugin;
using TechTalk.SpecFlow.Generator.Plugins;
using TechTalk.SpecFlow.Generator.UnitTestConverter;
using TechTalk.SpecFlow.Infrastructure;
using TechTalk.SpecFlow.UnitTestProvider;

[assembly:GeneratorPlugin(typeof(GeneratorPlugin.SampleGeneratorPlugin))]

namespace GeneratorPlugin
{
    public class SampleGeneratorPlugin : IGeneratorPlugin
    {
	    public void Initialize(GeneratorPluginEvents generatorPluginEvents, GeneratorPluginParameters generatorPluginParameters,
		    UnitTestProviderConfiguration unitTestProviderConfiguration)
	    {
		    // Register the decorator
		    generatorPluginEvents.RegisterDependencies += RegisterDependencies;
	    }

	    private void RegisterDependencies(object sender, RegisterDependenciesEventArgs eventArgs)
	    {
		    eventArgs.ObjectContainer.RegisterTypeAs<MyMethodTagDecorator, ITestMethodTagDecorator>(MyMethodTagDecorator.TAG_NAME);
	    }
    }
}
