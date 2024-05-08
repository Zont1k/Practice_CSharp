using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Spectre.Console;

class Program
{
    const string apiKey = "45c6b1c77ec6da196fd2a2b805e63a78";

    static async Task Main(string[] args)
    {
        string[] cities =
        {
            "Kyiv", "Odessa", "London", "Paris", "Berlin", "Madrid", "Rome", "Moscow", "Athens", "Vienna",
            "Amsterdam", "Brussels", "Stockholm", "Budapest", "Warsaw", "Prague", "Oslo", "Dublin", "Copenhagen",
            "Helsinki", "Lisbon", "Zurich", "New York", "Los Angeles", "Chicago", "Toronto", "Mexico City",
            "Sao Paulo", "Buenos Aires", "Lima", "Rio de Janeiro", "Santiago", "Tokyo", "Shanghai", "Beijing",
            "Seoul", "Hong Kong", "Bangkok", "Singapore", "Mumbai", "Jakarta", "Istanbul", "Dubai", "Tel Aviv",
            "Kuala Lumpur", "Manila", "Taipei"
        };

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
            var table = new Table().Centered();
            table.AddColumn("[red]City[/]");
            table.AddColumn("[yellow]Temperature (°C)[/]");
            table.AddColumn("[blue]Description[/]");
            table.AddColumn("[darkorange3]Humidity (%)[/]");
            table.AddColumn("[green]Pressure[/]");

            foreach (var city in selectOption)
            {
                var url = $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";
                var result = await FetchWeather(httpClient, url);
                dynamic weatherData = JsonConvert.DeserializeObject(result);

                table.AddRow(
                    city,
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
}