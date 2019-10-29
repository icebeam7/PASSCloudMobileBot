using PASSCloudMobileBot.Helpers;
using PASSCloudMobileBot.Services;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PASSCloudMobileBot.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BotWebViewPage : ContentPage
    {
        public BotWebViewPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var tokenExists = Application.Current.Properties.ContainsKey(Constants.TokenName);
            string token;

            if (!tokenExists)
            {
                token = await BotService.GetToken();
                Application.Current.Properties[Constants.TokenName] = token;
            }
            else
                token = Application.Current.Properties[Constants.TokenName].ToString();

            string botWebViewUrl = "https://webchat.botframework.com/embed/AdventureWorksBotGAB19Munich?s=" + token;
            BotWebView.Source = botWebViewUrl;
        }
    }
}