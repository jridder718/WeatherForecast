namespace WeatherForecastTest.TestUtils;

public static class MockDataProvider {
    public static string GetApiMockData() {
        var apiDataPath = Path.Combine(TestContext.CurrentContext.WorkDirectory, "../../../ApiMockData.json");
        
        return File.ReadAllText(apiDataPath);
    }
}
