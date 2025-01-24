using WeatherForecast.Services.Api;
using WeatherForecastTest.TestUtils;

namespace WeatherForecastTest.Services.Api;

[TestFixture]
public class WeatherApiServiceTest {
    [Test]
    public void GetWeatherData_ReturnsValidWeatherData() {
        var weatherService = new WeatherApiService(MockFactory.CreateHttpClientMock(MockDataProvider.GetApiMockData()));
        var result = weatherService.GetWeatherData(0, 0);
        var firstElement = result.GetProperty("dataseries")[0];

        Assert.Multiple(() => {
            Assert.That(firstElement.GetProperty("timepoint").GetInt32(), Is.EqualTo(1));
            Assert.That(firstElement.GetProperty("temp2m").GetInt32(), Is.EqualTo(20));
            Assert.That(firstElement.GetProperty("weather").GetString(), Is.EqualTo("clear"));
        });
    }
}
