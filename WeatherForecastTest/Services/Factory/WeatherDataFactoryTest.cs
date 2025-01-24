using System.Text.Json;
using WeatherForecast.Models;
using WeatherForecast.Services.Factory;
using WeatherForecastTest.TestUtils;

namespace WeatherForecastTest.Services.Factory;

public class WeatherDataFactoryTest {
    [Test]
    public void Create_ReturnsValidWeatherData() {
        var jsonElement = JsonDocument.Parse(MockDataProvider.GetApiMockDataElement()).RootElement;
        var weatherData = WeatherDataFactory.Create(jsonElement);

        Assert.That(weatherData, Is.InstanceOf<WeatherData>());
        Assert.Multiple(() => {
            Assert.That(weatherData.Hours, Is.EqualTo(1));
            Assert.That(weatherData.Temperature, Is.EqualTo(20));
            Assert.That(weatherData.Weather, Is.EqualTo("clear"));
        });
    }
}
