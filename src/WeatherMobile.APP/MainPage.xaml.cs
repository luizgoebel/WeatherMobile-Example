using WeatherMobile.APP.Model;
using Newtonsoft.Json;

namespace WeatherMobile.APP
{
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

            Weather weatherData = await Teste(cidade);

            Weather weather = new("Blumenau", "Santa Catarina", "Brasil", 25, 28, 22, "Alerta Laranja de chuvas", "Trovoadas", 82, 8);

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

        private async Task<Weather> Teste(string cidade)
        {
            Weather weather = new();


            if (!string.IsNullOrWhiteSpace(cidade))
            {
                try
                {
                    string responseBody = await HttpServiceRequest(cidade);

                    // Faça o parse do responseBody conforme necessário e atualize sua UI
                    weather = JsonConvert.DeserializeObject<Weather>(responseBody);
                    return weather;
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

            return weather;
        }

        private async Task<string> HttpServiceRequest(string cidade)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"https://sua-api.com/previsao/{cidade}");
            response.EnsureSuccessStatusCode(); // Lança uma exceção se o código de status não for bem-sucedido
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }
    }

}
