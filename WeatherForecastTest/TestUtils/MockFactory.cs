using System.Net;
using System.Text;
using Moq;
using Moq.Protected;

namespace WeatherForecastTest.TestUtils;

public static class MockFactory {
    public static HttpClient CreateHttpClientMock(string jsonResponseContent) {
        var handlerMock = new Mock<HttpMessageHandler>();
        
        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(jsonResponseContent, Encoding.UTF8, "application/json"),
            });

        return new HttpClient(handlerMock.Object);
    }
}
