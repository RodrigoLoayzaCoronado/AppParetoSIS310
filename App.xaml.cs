namespace SIS310
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NHaF1cWWhIfEx0THxbf1xzZFRHallQTndcUiweQnxTdEZiWH1XcXVQR2FYVUxzXA==");
            MainPage = new AppShell();
        }
    }
}