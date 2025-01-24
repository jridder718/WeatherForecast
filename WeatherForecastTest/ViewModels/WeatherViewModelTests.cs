using System.Collections.ObjectModel;
using Moq;
using WeatherForecast.Models;
using WeatherForecast.Services.Api;
using WeatherForecast.Services.Factory;
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
        var weatherData = WeatherDataFactory.CreateWithDefaults();
        _viewModel.CurrentWeather = weatherData;

        Assert.That(_viewModel.CurrentWeather, Is.EqualTo(weatherData));
    }

    [Test]
    public void Forecast_InitialValue_ShouldBeEmpty() {
        Assert.That(_viewModel.Forecast, Is.Empty);
    }

    [Test]
    public void Forecast_ModifyCollection_ShouldReflectChanges() {
        var weatherData = WeatherDataFactory.CreateWithDefaults();
        _viewModel.Forecast.Add(weatherData);

        Assert.That(_viewModel.Forecast, Is.EqualTo(new ObservableCollection<WeatherData> { weatherData }));
    }

    [Test]
    public void OnPropertyChanged_ShouldRaisePropertyChangedEvent() {
        string? propertyName = null;
        _viewModel.PropertyChanged += (_, args) => propertyName = args.PropertyName;
        _viewModel.CurrentWeather = WeatherDataFactory.CreateWithDefaults();

        Assert.That(propertyName, Is.EqualTo(nameof(_viewModel.CurrentWeather)));
    }
}
