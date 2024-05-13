using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Spectre.Console;

class Program
{
    const string apiKey = "45c6b1c77ec6da196fd2a2b805e63a78";
    const string weatherApiUrlTemplate = "http://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}&units=metric";
    const string citiesApiUrl = "https://countriesnow.space/api/v0.1/countries/capital";

    static async Task Main(string[] args)
    {
        List<string> cities = await GetCitiesList();

        var selectOption = AnsiConsole.Prompt(
            new MultiSelectionPrompt<string>()
                .Title("Select [green]cities[/]?")
                .NotRequired()
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more cities)[/]")
                .InstructionsText(
                    "[grey](Press [blue]<space>[/] to toggle a city, " +
                    "[green]<enter>[/] to accept)[/]")
                .AddChoices(cities));

        using (var httpClient = new HttpClient())
        {
            var tasks = new List<Task<WeatherData>>();

            foreach (var city in selectOption)
            {
                var url = string.Format(weatherApiUrlTemplate, city, apiKey);
                tasks.Add(FetchWeather(httpClient, url));
            }

            Task.WaitAll(tasks.ToArray());

            var table = new Table().Centered();
            table.AddColumn("[red]City[/]");
            table.AddColumn("[yellow]Temperature (°C)[/]");
            table.AddColumn("[blue]Description[/]");
            table.AddColumn("[darkorange3]Humidity (%)[/]");
            table.AddColumn("[green]Pressure[/]");

            foreach (var task in tasks)
            {
                var result = task.Result;
                table.AddRow(
                    result.Name,
                    $"{result.Main.Temp}°C",
                    result.Weather[0].Description,
                    $"{result.Main.Humidity}%",
                    $"{result.Main.Pressure} hPa"
                );
            }
            AnsiConsole.Render(table);
        }
    }

    static async Task<WeatherData> FetchWeather(HttpClient httpClient, string url)
    {
        var response = await httpClient.GetAsync(url);
        var content = await response.Content.ReadAsStringAsync();
        var weatherData = JsonSerializer.Deserialize<WeatherData>(content, new JsonSerializerOptions()
        {
            UnmappedMemberHandling = System.Text.Json.Serialization.JsonUnmappedMemberHandling.Skip,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        return weatherData;
    }

    static async Task<List<string>> GetCitiesList()
    {
        using (var httpClient = new HttpClient())
        {
            var response = await httpClient.GetAsync(citiesApiUrl);
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var cityData = JsonSerializer.Deserialize<CityData>(jsonResponse, new JsonSerializerOptions()
            {
                UnmappedMemberHandling = System.Text.Json.Serialization.JsonUnmappedMemberHandling.Skip, 
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            var cities = new List<string>();
            foreach (var cityInfo in cityData.Data)
            {
                cities.Add(cityInfo.Capital);
            }
            return cities;
        }
    }
}

public class WeatherData
{
    public string Name { get; set; }
    public MainInfo Main { get; set; }
    public WeatherDescription[] Weather { get; set; }
}

public class MainInfo
{
    public float Temp { get; set; }
    public int Humidity { get; set; }
    public float Pressure { get; set; }
}

public class WeatherDescription
{
    public string Description { get; set; }
}

public class CityData
{
    public IEnumerable<CityInfo> Data { get; set; }
}

public class CityInfo
{
    public string Capital { get; set; }
}

