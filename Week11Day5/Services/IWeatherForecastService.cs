using System.Threading.Tasks;
using Week11Day5.Models;

namespace Week11Day5.Services
{
    public interface IWeatherForecastService
    {
        Task<FullWeatherForecast> GetFullForecastAsync(string city);
        Task<double> GetHumidityAsync(string city);
        Task<string> GetRainForecastAsync(string city);
    }
}