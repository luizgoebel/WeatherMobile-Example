using WeatherMobile.APP.Model;
using Newtonsoft.Json;

namespace WeatherMobile.APP;

public partial class MainPage : ContentPage
{
    private readonly HttpClient _httpClient;

    public MainPage()
    {
        InitializeComponent();
        _httpClient = new HttpClient();
    }

    private async void GetWeatherButton_Clicked(object sender, EventArgs e)
    {
        string cidade = cidadeEntry.Text.Trim();
        Weather weather = await RecuperarPrevisaoPorCidade(cidade);

        if (weather != null)
        {
            temperaturaLabel.Text = "Temperatura: " + weather.Temperatura + "°C";
            condicaoLabel.Text = "Condição: " + weather.Condicao;
            umidadeLabel.Text = "Umidade: " + weather.Umidade;
            velocidadeVentoLabel.Text = "Velocidade do Vento: " + weather.VelocidadeVento + " km/h";
        }
        else
        {
            await DisplayAlert("Erro", "Não foi possível obter os dados meteorológicos para esta cidade.", "OK");
        }
    }

    private async Task<Weather> RecuperarPrevisaoPorCidade(string cidade)
    {
        string responseBody = await HttpServiceRequest(cidade);
        return JsonConvert.DeserializeObject<Weather>(responseBody);
    }

    private async Task<string> HttpServiceRequest(string cidade)
    {
        string responseBody = string.Empty;
        if (!string.IsNullOrWhiteSpace(cidade))
        {
            try
            {

                HttpResponseMessage response = await _httpClient.GetAsync(URI(cidade));
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();

                return responseBody;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro de Requisição", ex.Message, "OK");
            }
        }
        else
        {
            await DisplayAlert("Erro", "Por favor, insira o nome da cidade.", "OK");
        }

        return responseBody;
    }

    private static string URI(string cidade)
    {
        return $"https://sua-api.com/previsao/{cidade}";
    }

    private void RecuperarCoordenadasDoIP()
    {
        var latitudePadrao = -22.740385;
        var longitudePadrao = -43.024463;
        var data = new
        {
            geoplugin_latitude = -22.740385,
            geoplugin_longitude = -43.024463
        };
        string uri = "http://www.geoplugin.net/json.gp";

        //se url retorno latidade e longitude não forem vazios entra no if
        if (data.geoplugin_latitude == 0 && data.geoplugin_longitude == 0)
        {
            RecuperarLocalUsuario(latitudePadrao, longitudePadrao);
        }
        else
        {
            RecuperarLocalUsuario(data.geoplugin_latitude, data.geoplugin_longitude);
        }
    }

    private void RecuperarLocalUsuario(double latitude, double longitude)
    {

    }
}
