namespace WeatherMobile.APP.HTTP;

public static class URI
{
    private const string _apiKey = "8lGB6AJMfbwrEDocKWWcS4VZ2bpGFl6g";
    public static string RecuperarCoornadasDoIP()
        => "http://www.geoplugin.net/json.gp";
    public static string RecuperarLocalUsuario(string latitude, string longitude)
        => $"http://dataservice.accuweather.com/locations/v1/cities/geoposition/search?apikey={_apiKey}&q={latitude}%2C{longitude}&language=pt-br";
    public static string RecuperarPrevisaoPorCidade(string localCode)
        => $"";
}
