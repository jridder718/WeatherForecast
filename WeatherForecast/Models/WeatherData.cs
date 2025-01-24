namespace WeatherForecast.Models;

public class WeatherData {
    public required int Hours { get; init; }
    public required int Temperature { get; init; }
    public required string Weather { get; init; }
}
