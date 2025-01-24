namespace WeatherForecast.Views;

public partial class MainWindow {
    public MainWindow() {
        InitializeComponent();
        DataContext = new ViewModels.WeatherViewModel();
    }
}
