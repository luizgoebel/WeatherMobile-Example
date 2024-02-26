using Microsoft.Toolkit.Mvvm.ComponentModel;
using WeatherMobile.APP.Model;

namespace WeatherMobile.APP.ViewModel;

public partial class WeatherViewModel : ObservableObject
{
    public decimal Temperatura;
    public string Condicao;
    public decimal Umidade;
    public decimal VelocidadeVento;

    private readonly Services.IServices.IWeatherService _weatherService;
    public WeatherViewModel(Services.IServices.IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }
    private void DefinirDadosViewModel(Weather weather)
    {
        this.Temperatura = weather.Temperatura;
        this.Condicao = weather.Condicao;
        this.Umidade = weather.Umidade;
        this.VelocidadeVento = weather.VelocidadeVento;
    }
    public async void RecuperarPrevisao(string cidade)
    {
        try
        {
            if (string.IsNullOrEmpty(cidade)) throw new Exception("insira o nome da cidade.");

            Weather weather = await RecuperarPrevisaoPorCidade(cidade) ?? throw new Exception("Não foi possível obter os dados meteorológicos para esta cidade.");
            DefinirDadosViewModel(weather);
        }
        catch (Exception)
        {
            throw;
        }
    }
    private async Task<GeoData> RecuperarCoordenadasDoIP()
    => await _weatherService.RecuperarCoordenadasDoIP();
    private async Task<string> RecuperarLocalUsuario(GeoData geoData)
    => await _weatherService.RecuperarLocalUsuario(geoData.geoplugin_latitude, geoData.geoplugin_longitude);
    private async Task<Weather> RecuperarPrevisaoPorCidade(string localCode)
    => await _weatherService.RecuperarPrevisaoPorCidade(localCode);
}
