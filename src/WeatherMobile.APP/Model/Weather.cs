namespace WeatherMobile.APP.Model;

public class Weather
{
    public Weather(string cidade, string estado, string pais, decimal temperatura, decimal maxima, decimal minima, string textoClima, string condicao, decimal umidade, decimal velocidadeVento)
    {
        Cidade = cidade;
        Estado = estado;
        Pais = pais;
        Temperatura = temperatura;
        Maxima = maxima;
        Minima = minima;
        TextoClima = textoClima;
        Condicao = condicao;
        Umidade = umidade;
        VelocidadeVento = velocidadeVento;
    }
    public Weather()
    {

    }

    public string Cidade { get; set; }
    public string Estado { get; set; }
    public string Pais { get; set; }
    public decimal Temperatura { get; set; }
    public decimal Maxima { get; set; }
    public decimal Minima { get; set; }
    public string TextoClima { get; set; }
    public string Condicao { get; set; }
    public decimal Umidade { get; set; }
    public decimal VelocidadeVento { get; set; }
}
