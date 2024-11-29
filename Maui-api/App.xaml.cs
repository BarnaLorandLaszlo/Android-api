using Maui_api.Pages;

namespace Maui_api
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new WeatherinfoPage();


        }
    }
}
