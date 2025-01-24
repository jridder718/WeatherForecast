namespace WeatherForecastTest.TestUtils;

public static class MockDataProvider {
    public static string GetApiMockData() {
        return GetMockData("ApiMockData.json");
    }

    public static string GetApiMockDataElement() {
        return GetMockData("ApiMockDataElement.json");
    }

    private static string GetMockData(string fileName) {
        var apiDataPath = Path.Combine(TestContext.CurrentContext.WorkDirectory, "../../../TestUtils/", fileName);
        
        return File.ReadAllText(apiDataPath);
    }
}
