using System.Text.Json;
using WeatherForecast.Models;

namespace WeatherForecast.Services.Factory;

public static class WeatherDataFactory {
    public static WeatherData Create(JsonElement jsonElement) {
        return new WeatherData {
            Hours = jsonElement.GetProperty("timepoint").GetInt32(),
            Temperature = jsonElement.GetProperty("temp2m").GetInt32(),
            Weather = jsonElement.GetProperty("weather").GetString() ?? string.Empty
        };
    }

    public static WeatherData CreateWithDefaults() {
        return new WeatherData {
            Hours = int.MaxValue,
            Temperature = int.MaxValue,
            Weather = string.Empty
        };
    }
}
