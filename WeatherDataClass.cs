using System;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using WeatherApp2;

namespace WeatherApp2
{
    class WeatherDataClass
    {

        public string[] GetCoordinates(string cityName = "Jyvaskyla", string countryCode = "FI")
        {
            var client = new HttpClient();
            var uri = $"http://api.openweathermap.org/geo/1.0/direct?q={cityName},{countryCode}&limit=1&appid=c73b2df4e5e3e4893bfa3747ed374747";
            var endpoint = new Uri(uri);
            var result = client.GetAsync(endpoint).Result;
            var json = result.Content.ReadAsStringAsync().Result;
            var jsonData = json;
            //Console.WriteLine(json);
            var coordinateData = JsonConvert.DeserializeObject<List<PropertiesList>>(jsonData);

            string[] coordArray = new string[2];

            var latDouble = coordinateData[0].lat;
            var lonDouble = coordinateData[0].lon;
            var lat = latDouble.ToString();
            var lon = lonDouble.ToString();

            coordArray[0] = lat;
            coordArray[1] = lon;

            return coordArray;
        }
        public void Present(string[] dataArray)
        {
            /*foreach (var str in dataArray)
            {
                Console.WriteLine(str);
            }
            */
            Console.WriteLine($"The weather for tomorrow {dataArray[0]}: ");
            Console.WriteLine($"The average day temperature will be {dataArray[1]} degrees celsius,\nand quick description on the weather: \nWe'll be getting {dataArray[2]}.");
        }

        public string[] GetData(string lat = "62.242561", string lon = "25.747499")
        {
            var client = new HttpClient();
            var uri = $"https://api.openweathermap.org/data/2.5/onecall?lat={lat}&lon={lon}&exclude=current,minutely,hourly,alerts&appid=c73b2df4e5e3e4893bfa3747ed374747";
            var endpoint = new Uri(uri);

            var result = client.GetAsync(endpoint).Result;
            var json = result.Content.ReadAsStringAsync().Result;
            // Console.WriteLine(json);
            var jsonData = JsonConvert.DeserializeObject<WeatherData>(json);

            var date = DateTimeOffset.FromUnixTimeSeconds(jsonData.daily[1].dt);
            var datetimeString = date.ToString();
            var dateString = datetimeString.Substring(0, 9);

            var temp = (decimal)jsonData.daily[1].temp.day;
            temp -= 273.15m;
            var tempString = temp.ToString();
            // Console.WriteLine(temp);


            var weatherMain = jsonData.daily[1].weather[0].main;
            var weatherDesc = jsonData.daily[1].weather[0].description;
            var weatherString = weatherMain + ", " + weatherDesc;
            // Console.WriteLine(weatherString);


            string[] dataArray = new string[3];

            dataArray[0] = dateString;
            dataArray[1] = tempString;
            dataArray[2] = weatherString;

            return dataArray;
        }
        public string[] Main(string cityName, string countryCode)
        {
            
            //var cityName = cityCountryArray[0];
            //var countryCode = cityCountryArray[1];

            var prog = new WeatherDataClass();
            var coordArray = prog.GetCoordinates(cityName, countryCode);
            var dataArray = prog.GetData(coordArray[0], coordArray[1]);
            // prog.Present(dataArray);
            /*foreach(string str in dataArray)
            {
                Console.WriteLine(str);
            }*/
            return dataArray;

        }
    }
}
