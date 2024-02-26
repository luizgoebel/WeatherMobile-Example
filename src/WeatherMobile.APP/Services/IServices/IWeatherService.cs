namespace WeatherMobile.APP.Services.IServices;

public interface IWeatherService
{
    Task<Model.Weather> RecuperarPrevisaoPorCidade(string cidade);
}