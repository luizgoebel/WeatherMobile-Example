using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using WeatherMobile.APP.Model;

namespace WeatherMobile.APP.ViewModel;

public partial class WeatherViewModel : ObservableObject
{
    [ObservableProperty]
    public decimal temperatura;
    [ObservableProperty]
    public string condicao;
    [ObservableProperty]
    public string cidade;
    [ObservableProperty]
    public string estado;
    [ObservableProperty]
    public decimal umidade;
    [ObservableProperty]
    public decimal velocidadeVento;
    public ObservableCollection<Weather> weathers { get; set; } = new();
    [ObservableProperty]
    public Weather weatherSelecionado;

    private readonly Services.IServices.IWeatherService _weatherService;
    public WeatherViewModel(Services.IServices.IWeatherService weatherService)
    {
        _weatherService = weatherService;
        weathers = CriarLista();
        weatherSelecionado = weathers.FirstOrDefault();
        DefinirDadosViewModel(weatherSelecionado);
    }

    private ObservableCollection<Weather> CriarLista()
    {
        return
        [
            new ("Florianópolis", "SC", 27.5m, "Ensolarado", 70, 10),
            new ("Joinville", "SC", 25.8m, "Parcialmente Nublado", 65, 8),
            new ("Blumenau", "SC", 26.3m, "Chuvoso", 75, 12),
            new ("São José", "SC", 28.1m, "Nublado", 68, 9),
            new ("Chapecó", "SC", 30.2m, "Chuva Fraca", 80, 11),
            new ("Criciúma", "SC", 28.7m, "Tempo Quente", 72, 10),
            new ("Itajaí", "SC", 25.4m, "Chuva Forte", 78, 13),
            new ("Jaraguá do Sul", "SC", 26.9m, "Nevoeiro", 60, 7),
            new ("Palhoça", "SC", 27.6m, "Trovoadas", 77, 9),
            new ("Lages", "SC", 23.8m, "Granizo", 85, 14),
            new ("Balneário Camboriú", "SC", 29.5m, "Nevando", 75, 8),
            new ("Brusque", "SC", 28.3m, "Geada", 82, 12),
            new ("Tubarão", "SC", 27.2m, "Hailstorm", 73, 11),
            new ("Caçador", "SC", 30.1m, "Tornado", 88, 15),
            new ("Canoinhas", "SC", 24.6m, "Furacão", 79, 10),
            new ("Concórdia", "SC", 25.9m, "Tempestade", 70, 9),
            new ("Imbituba", "SC", 26.8m, "Vendaval", 68, 12),
            new ("Rio do Sul", "SC", 27.3m, "Ciclone", 75, 11),
            new ("São Bento do Sul", "SC", 24.7m, "Rajada de Vento", 79, 10),
            new ("Araranguá", "SC", 28.6m, "Calmaria", 72, 8)
        ];
    }

    public void RecuperarDadosLocalPrevisao(string cidade)
    {
        Weather weather = weathers.FirstOrDefault(x => x.Cidade.Equals(cidade)) ?? throw new Exception("Não foi possível encontrar a cidade solicitada");
        weatherSelecionado = weather;
        DefinirDadosViewModel(weather);
    }
    private void DefinirDadosViewModel(Weather weather)
    {
        this.Cidade = weather.Cidade;
        this.Estado = weather.Estado;
        this.Temperatura = weather.Temperatura;
        this.Condicao = weather.Condicao;
        this.Umidade = weather.Umidade;
        this.VelocidadeVento = weather.VelocidadeVento;
    }
}
