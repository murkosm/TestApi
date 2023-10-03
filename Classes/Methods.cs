using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApi.DB;

namespace TestApi.Classes
{

    public class Methods
    {
        public const string BaseAuthUrl = "https://localhost:7213/Auth/";
        public const string BaseWeatherUrl = "https://localhost:7213/Weather/";
        public const string AuthRegister = "CreateAccount";
        public const string AuthToken = "GetToken";
        public const string WeatherCities = "GetCities";
        public const string WeatherTemperature = "GetWeatherByCity";

        private static readonly ApplicationContext _db = new ApplicationContext();

        public static string register(User user)
        {
            var client = new RestClient(BaseAuthUrl);
            var request = new RestRequest(AuthRegister);
            request.AddJsonBody(user);
            var response = client.ExecutePost(request);
            return response.Content;

        }

        public static string GetToken(string login, string password)
        {

            var client = new RestClient(BaseAuthUrl);
            var request = new RestRequest($"{AuthToken}?login{login}&password={password}");
            var response = client.Execute(request);
            string token = response.Content.Replace("\"", "");
            _db.Tokens.RemoveRange(_db.Tokens);
            Token _token = new Token()
            {
                token = token
            };
            _db.Tokens.Add(_token);
            _db.SaveChanges();
            return response.Content;
        }

        public static List<City> GetCities(string token)
        {
            
            var client = new RestClient(BaseWeatherUrl);
            var request = new RestRequest($"{WeatherCities}?token={token}");
            
            var response = client.Execute(request);
           
            return JsonConvert.DeserializeObject<List<City>>(response.Content);
            

        }

        public static List<Temperature> GetWeathers(string token)
        {
            var client = new RestClient(BaseWeatherUrl);
            var request = new RestRequest($"{WeatherTemperature}?token={token}");
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<List<Temperature>>(response.Content);
        }

        public static Token Get()
        {
            return _db.Tokens.FirstOrDefault();
        }
    }
}
