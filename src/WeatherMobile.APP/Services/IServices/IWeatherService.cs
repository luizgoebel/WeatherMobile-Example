namespace WeatherMobile.APP.Services.IServices;

public interface IWeatherService
{
    Task<Model.GeoData> RecuperarCoordenadasDoIP();
    Task<string> RecuperarLocalUsuario(string latitude, string longitude);
    Task<Model.Weather> RecuperarPrevisaoPorCidade(string localCode);
}