namespace WeatherApp2
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
    public class jklWeather
    {
        public string date { get; set; }
        public string temp { get; set; }

        public string desc { get; set; }
    }
}
