using MyTestServiceReference;
using System;
using System.ServiceModel;
using System.Threading.Tasks;
using Week11Day5.Models;

namespace Week11Day5.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        public readonly string serviceUrl = "https://localhost:44320/WeatherForecast.asmx";
        public readonly EndpointAddress endpointAddress;
        public readonly BasicHttpBinding basicHttpBinding;

        public WeatherForecastService()
        {
            endpointAddress = new EndpointAddress(serviceUrl);

            basicHttpBinding = new BasicHttpBinding(
                endpointAddress.Uri.Scheme.ToLower() == "http" ?
                    BasicHttpSecurityMode.None :
                    BasicHttpSecurityMode.Transport)
            {
                OpenTimeout = TimeSpan.MaxValue,
                CloseTimeout = TimeSpan.MaxValue,
                ReceiveTimeout = TimeSpan.MaxValue,
                SendTimeout = TimeSpan.MaxValue
            };
        }

        public async Task<double> GetHumidityAsync(string city)
        {
            var wsClient = new WeatherForecastSoapClient(basicHttpBinding, endpointAddress);

            var soapResponse = await wsClient.GetHumidityForCityAsync(city);

            return soapResponse.Body.GetHumidityForCityResult;
        }

        public async Task<string> GetRainForecastAsync(string city)
        {
            var wsClient = new WeatherForecastSoapClient(basicHttpBinding, endpointAddress);

            var response = await wsClient.GetRainForecastForCityAsync(city);

            return response.Body.GetRainForecastForCityResult;
        }

        public async Task<FullWeatherForecast> GetFullForecastAsync(string city)
        {
            var wsClient = new WeatherForecastSoapClient(basicHttpBinding, endpointAddress);

            var soapResponse1 = await wsClient.GetHumidityForCityAsync(city);
            var humidity = soapResponse1.Body.GetHumidityForCityResult;

            var soapResponse2 = await wsClient.GetRainForecastForCityAsync(city);
            var rain = soapResponse2.Body.GetRainForecastForCityResult;

            return new FullWeatherForecast { Humidity = humidity, RainForecast = rain };
        }
    }
}
