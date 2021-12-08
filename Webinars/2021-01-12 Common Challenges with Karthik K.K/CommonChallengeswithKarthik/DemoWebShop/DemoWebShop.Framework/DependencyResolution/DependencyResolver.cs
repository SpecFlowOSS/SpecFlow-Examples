using BoDi;

namespace DemoWebShop.Framework.DependencyResolution
{
    public class DependencyResolver : IDependencyResolver
    {
        private readonly IObjectContainer objectContainer;

        public DependencyResolver(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        public void RegisterTypeAs<TType, TInterface>(string? name = null) where TType : class, TInterface
        {
            objectContainer.RegisterTypeAs<TType, TInterface>(name);
        }
    }
}