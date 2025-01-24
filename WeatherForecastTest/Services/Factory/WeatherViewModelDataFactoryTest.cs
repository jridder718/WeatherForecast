using System.Text.Json;
using WeatherForecast.Models;
using WeatherForecast.Services.Factory;
using WeatherForecastTest.TestUtils;

namespace WeatherForecastTest.Services.Factory;

public class WeatherViewModelDataFactoryTest {
    [Test]
    public void Create_ReturnsValidWeatherDataViewModel() {
        var jsonElement = JsonDocument.Parse(MockDataProvider.GetApiMockData()).RootElement;
        var weatherViewModelData = WeatherViewModelDataFactory.Create(jsonElement);

        Assert.Multiple(() => {
            Assert.That(weatherViewModelData.CurrentWeather.Hours, Is.EqualTo(1));
            Assert.That(weatherViewModelData.Forecast[0].Hours, Is.EqualTo(2));
        });
    }
}
