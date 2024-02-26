namespace WeatherMobile.APP.Model;

public class Weather(string cidade, string estado, decimal temperatura, string condicao, decimal umidade, decimal velocidadeVento)
{
    public string Cidade { get; set; } = cidade;
    public string Estado { get; set; } = estado;
    public decimal Temperatura { get; set; } = temperatura;
    public string Condicao { get; set; } = condicao;
    public decimal Umidade { get; set; } = umidade;
    public decimal VelocidadeVento { get; set; } = velocidadeVento;
}
