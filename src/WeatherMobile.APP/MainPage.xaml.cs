using WeatherMobile.APP.Model;
using WeatherMobile.APP.ViewModel;

namespace WeatherMobile.APP;

public partial class MainPage : ContentPage
{
    private readonly WeatherViewModel _weatherViewModel;

    public MainPage(WeatherViewModel weatherViewModel)
    {
        _weatherViewModel = weatherViewModel;
        InitializeComponent();
        BindingContext = weatherViewModel;
    }

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        Picker picker = (Picker)sender;
        Weather weather = (Weather)picker.SelectedItem;
        _weatherViewModel.RecuperarDadosLocalPrevisao(weather.Cidade);
    }
}
