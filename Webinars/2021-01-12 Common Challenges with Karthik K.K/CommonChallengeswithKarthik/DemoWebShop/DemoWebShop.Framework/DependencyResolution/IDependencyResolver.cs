namespace DemoWebShop.Framework.DependencyResolution;

public interface IDependencyResolver
{
    void RegisterTypeAs<TType, TInterface>(string? name = null) where TType : class, TInterface;
}