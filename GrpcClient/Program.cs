using System;
using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using WebApplication5.Client;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //var channel = GrpcChannel.ForAddress("https://localhost:5001/");
            var channel = GrpcChannel.ForAddress("https://localhost:44304/", new GrpcChannelOptions()
            {
                HttpHandler = new GrpcWebHandler(new HttpClientHandler()),
            });

            var c =  new WeatherForecasts.WeatherForecastsClient(channel);

            var e = await c.GetWeatherAsync(new WeatherForecast());

            foreach (var it in e.Forecasts)
            {
                Console.WriteLine(it);
            }

        }
    }
}
