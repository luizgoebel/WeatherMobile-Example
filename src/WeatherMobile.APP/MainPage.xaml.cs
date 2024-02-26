using WeatherMobile.APP.ViewModel;

namespace WeatherMobile.APP;

public partial class MainPage : ContentPage
{
    private readonly WeatherViewModel _weatherViewModel;

    public MainPage(WeatherViewModel weatherViewModel)
    {
        InitializeComponent();
        _weatherViewModel = weatherViewModel;
    }

    private async void GetWeatherButton_Clicked(object sender, EventArgs e)
    {
        string cidade = cidadeEntry.Text.Trim();
        try
        {
            _weatherViewModel.RecuperarPrevisao(cidade);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro de Requisição", ex.Message, "OK");
        }
    }
}
