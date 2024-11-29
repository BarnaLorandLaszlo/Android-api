using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Maui_api.Services;
using Maui_api.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui_api.ViewModels
{
    internal partial class WeatherInfoPageViewModel : ObservableObject
    {
        private readonly WeatherApiService _weatherApiService;

        public WeatherInfoPageViewModel()
        {
            _weatherApiService = new WeatherApiService();
        }


        [ObservableProperty]
        private string latitude;

        [ObservableProperty]
        private string longitude;

        [ObservableProperty]
        private string weatherIcon;

        [ObservableProperty]
        private string tempeture;

        [ObservableProperty]
        private string weatherDescription;

        [ObservableProperty]
        private string location;

        [ObservableProperty]
        private int humidity;

        [ObservableProperty]
        private string cloudCoverLevel;

        [ObservableProperty]
        private string isDay;

        [RelayCommand]
        private async Task FetchWeatherInformation()
        {
            var weatherApiRespone = await _weatherApiService.GetWeatherInformation(Latitude, Longitude);
            if (weatherApiRespone != null)
            {
                WeatherIcon = weatherApiRespone.current.weather_icons[0];
                Tempeture = $"{weatherApiRespone.current.temperature}°C";
                Location = $"{weatherApiRespone.location.name}, {weatherApiRespone.location.region}, {weatherApiRespone.location.country}";
                WeatherDescription = weatherApiRespone.current.weather_descriptions[0];
                Humidity = weatherApiRespone.current.humidity;
                CloudCoverLevel = $"{weatherApiRespone.current.cloudcover}%";


            }
           
        }
    }
}
