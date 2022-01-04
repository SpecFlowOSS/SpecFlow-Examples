namespace DemoWebApp.Specs.Pages
{
    public interface IPage
    {
        public string Url { get; }
        void GoTo();
    }
}