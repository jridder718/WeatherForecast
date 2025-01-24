using System.Text.Json;

namespace WeatherForecast.Services.Api;

public interface IWeatherApiService {
    JsonElement GetWeatherData(double longitude, double latitude);
}
