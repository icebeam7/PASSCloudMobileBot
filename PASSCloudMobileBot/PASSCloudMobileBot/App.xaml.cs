using Xamarin.Forms;

namespace PASSCloudMobileBot
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Xamarin.Forms.PlatformConfiguration.AndroidSpecific.Application.SetWindowSoftInputModeAdjust(this, Xamarin.Forms.PlatformConfiguration.AndroidSpecific.WindowSoftInputModeAdjust.Resize);
            MainPage = new NavigationPage(new Views.BotWebViewPage());
        }
    }
}