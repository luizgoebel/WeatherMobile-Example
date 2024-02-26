using Newtonsoft.Json;
using WeatherMobile.APP.Model;

namespace WeatherMobile.APP.Services;

public class WeatherService : IServices.IWeatherService
{
    HttpClient _httpClient;
    public WeatherService()
    {
        _httpClient = new HttpClient();
    }
    public async Task<GeoData> RecuperarCoordenadasDoIP()
    {
        try
        {
            string URI = HTTP.URI.RecuperarCoornadasDoIP();
            HttpResponseMessage response = await _httpClient.GetAsync(URI);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            GeoData geoData = JsonConvert.DeserializeObject<GeoData>(responseBody);
            return geoData;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro de Requisição {ex.Message}");
        }
    }
    public async Task<string> RecuperarLocalUsuario(string latitude, string longitude)
    {
        try
        {
            string URI = HTTP.URI.RecuperarLocalUsuario(latitude, longitude);
            HttpResponseMessage response = await _httpClient.GetAsync(URI);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            string localCode = JsonConvert.DeserializeObject<string>(responseBody);
            return localCode;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro de Requisição {ex.Message}");
        }
    }
    public async Task<Weather> RecuperarPrevisaoPorCidade(string localCode)
    {
        try
        {
            string URI = HTTP.URI.RecuperarCoornadasDoIP();
            HttpResponseMessage response = await _httpClient.GetAsync(URI);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            Weather weather = JsonConvert.DeserializeObject<Weather>(responseBody);
            return weather;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro de Requisição {ex.Message}");
        }
    }
}
