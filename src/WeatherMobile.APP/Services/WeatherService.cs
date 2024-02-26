using Newtonsoft.Json;
using WeatherMobile.APP.Model;

namespace WeatherMobile.APP.Services;

public class WeatherService : IServices.IWeatherService
{
    private readonly HttpClient _httpClient;
    public WeatherService()
    {
        _httpClient = new HttpClient();
    }

    public Task<Weather> RecuperarPrevisaoPorCidade(string cidade)
    {
        throw new NotImplementedException();
    }
}
