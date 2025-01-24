using System.Net.Http;
using System.Text.Json;

namespace WeatherForecast.Services.Api;

public class WeatherApiService(HttpClient? httpClient = null) {
    private readonly HttpClient _httpClient = httpClient ?? new HttpClient();
    private const string ApiUrl = "https://www.7timer.info/bin/api.pl?lon={0}&lat={1}&product=civil&output=json";

    public JsonElement GetWeatherData(double longitude, double latitude) {
        var url = string.Format(ApiUrl, longitude, latitude);
        var response = _httpClient.GetAsync(url).Result;
        
        return JsonDocument.Parse(response.Content.ReadAsStringAsync().Result).RootElement;
    }
}
