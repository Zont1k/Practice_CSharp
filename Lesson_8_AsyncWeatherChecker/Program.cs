using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
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
            var tasks = new List<Task<string>>();

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
                var result = await task;
                dynamic weatherData = JsonConvert.DeserializeObject(result);

                table.AddRow(
                    (string)weatherData.name,
                    $"{weatherData.main.temp}°C",
                    (string)weatherData.weather[0].description,
                    $"{weatherData.main.humidity}%",
                    $"{weatherData.main.pressure} hPa"
                );
            }
            AnsiConsole.Render(table);
        }
    }

    static async Task<string> FetchWeather(HttpClient httpClient, string url)
    {
        var response = await httpClient.GetAsync(url);
        return await response.Content.ReadAsStringAsync();
    }

    static async Task<List<string>> GetCitiesList()
    {
        using (var httpClient = new HttpClient())
        {
            var response = await httpClient.GetAsync(citiesApiUrl);
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            dynamic data = JsonConvert.DeserializeObject(jsonResponse);
            var cities = new List<string>();
            foreach (var item in data.data)
            {
                cities.Add((string)item.capital);
            }
            return cities;
        }
    }
}
