namespace DemoWebApp.Specs.Pages.LoginPage
{
    public interface ILoginPage : IPage
    {
        void Login(string username, string password);
    }
}