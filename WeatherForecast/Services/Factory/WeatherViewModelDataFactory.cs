using System.Collections.ObjectModel;
using System.Text.Json;
using WeatherForecast.Models;

namespace WeatherForecast.Services.Factory;

public static class WeatherViewModelDataFactory {
    public static WeatherViewModelData Create(JsonElement data) {
        var weatherDataElements = data.GetProperty("dataseries");
        var forecast = new ObservableCollection<WeatherData>();
        
        foreach (var element in weatherDataElements.EnumerateArray().Skip(1)) {
            forecast.Add(WeatherDataFactory.Create(element));
        }

        return new WeatherViewModelData {
            CurrentWeather = WeatherDataFactory.Create(weatherDataElements[0]),
            Forecast = forecast
        };
    }
}
