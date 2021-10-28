using ConsumeAPIApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ConsumeAPIApplication.Services
{
    public class UserService
    {
        public UserDTO Register(UserDTO userDto)
        {
            UserDTO userDTO = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:36606/api/");
                var postTask = client.PostAsJsonAsync<UserDTO>("User", userDto);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var data = result.Content.ReadFromJsonAsync<UserDTO>();
                    data.Wait();
                    userDTO = data.Result;
                }
            }
            return userDTO;
        }
        public UserDTO Login(UserDTO userDto)
        {
            UserDTO userDTO = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:36606/api/");
                var postTask = client.PostAsJsonAsync<UserDTO>("User/Login", userDto);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var data = result.Content.ReadFromJsonAsync<UserDTO>();
                    data.Wait();
                    userDTO = data.Result;
                }
            }
            return userDTO;
        }
        public string CallWeather(string token)
        {
            //WeatherForecast
            string weatherData = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:36606/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var getTask = client.GetAsync("WeatherForecast");
                getTask.Wait();
                var result = getTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var data = result.Content.ReadAsStringAsync();
                    data.Wait();
                    weatherData = data.Result;
                }
            }
            return weatherData;
        }
    }
}

