using System.Net.Http.Headers;
using WeatherMobile.ServicesClient.Factory.IFactory;

namespace WeatherMobile.ServicesClient.Factory;

public class HttpClientFactory : IHttpClientFactory
{
    public HttpClient CreateHttpClient()
    {
        return new();
    }
}
