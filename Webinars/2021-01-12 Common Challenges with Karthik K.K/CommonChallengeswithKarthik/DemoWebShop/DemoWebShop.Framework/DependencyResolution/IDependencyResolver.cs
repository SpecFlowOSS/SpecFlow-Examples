namespace DemoWebShop.Framework
{
    public interface IDependencyResolver
    {
        void RegisterTypeAs<TType, TInterface>(string? name = null) where TType : class, TInterface;
    }
}