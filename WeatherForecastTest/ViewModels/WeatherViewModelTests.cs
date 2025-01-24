using Moq;
using WeatherForecast.Models;
using WeatherForecast.Services.Api;
using WeatherForecast.ViewModels;

namespace WeatherForecastTest.ViewModels;

[TestFixture]
public class WeatherViewModelTests {
    private WeatherViewModel _viewModel;

    [SetUp]
    public void Setup() {
        var mockWeatherApiService = new Mock<IWeatherApiService>();
        _viewModel = new WeatherViewModel(mockWeatherApiService.Object);
    }

    [Test]
    public void SetCurrentWeather_ShouldUpdateWeatherData() {
        var weatherData = new WeatherData { Temperature = 20, Weather = "clear", Hours = 1 };
        _viewModel.CurrentWeather = weatherData;

        Assert.That(_viewModel.CurrentWeather, Is.EqualTo(weatherData));
    }

    [Test]
    public void Forecast_InitialValue_ShouldBeEmpty() {
        Assert.That(_viewModel.Forecast, Is.Empty);
    }

    [Test]
    public void Forecast_ModifyCollection_ShouldReflectChanges() {
        var weatherData = new WeatherData { Temperature = 20, Weather = "clear", Hours = 1 };
        _viewModel.Forecast.Add(weatherData);

        Assert.That(_viewModel.Forecast, Is.EqualTo(new List<WeatherData> { weatherData }));
    }

    [Test]
    public void OnPropertyChanged_ShouldRaisePropertyChangedEvent() {
        string? propertyName = null;
        _viewModel.PropertyChanged += (_, args) => propertyName = args.PropertyName;
        _viewModel.CurrentWeather = new WeatherData { Temperature = 20, Weather = "clear", Hours = 1 };

        Assert.That(propertyName, Is.EqualTo(nameof(_viewModel.CurrentWeather)));
    }
}
