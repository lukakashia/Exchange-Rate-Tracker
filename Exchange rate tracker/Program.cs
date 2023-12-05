using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        while (true)
        {
            await FetchAndDisplayExchangeRates();

            await Task.Delay(TimeSpan.FromMinutes(5));
        }
    }

    public static async Task FetchAndDisplayExchangeRates()
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "https://v6.exchangerate-api.com/v6/74c1bb7f4ebe559ae6f72796/latest/USD";
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Exchange Rate Data:");
                Console.WriteLine(responseContent);
            }
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine("Failed to fetch exchange rates. Error: " + ex.Message);
        }
    }
}