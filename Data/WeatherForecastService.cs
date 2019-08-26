using BlazorAppDB.Data.Weather;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Data
{
    public class WeatherForecastService
    {
        public Task<List<WeatherForecast>> GetForecastAsync(string strCurrentUser)
        {
            List<WeatherForecast> colWeatherForcasts = new List<WeatherForecast>();
            // Get Weather Forecasts  
            using (var context = new WeatherContext())
            {
                colWeatherForcasts = (from weatherForecast in context.WeatherForecast
                                          // only get entries for the current logged in user
                                      where weatherForecast.UserName == strCurrentUser
                                      select weatherForecast).ToList();
            }
            return Task.FromResult(colWeatherForcasts);
        }

        public Task<WeatherForecast>
            CreateForecastAsync(WeatherForecast objWeatherForecast)
        {
            using (var context = new WeatherContext())
            {
                context.WeatherForecast.Add(objWeatherForecast);
                context.SaveChanges();
            }
            return Task.FromResult(objWeatherForecast);
        }

        public Task<bool>
            UpdateForecastAsync(WeatherForecast objWeatherForecast)
        {
            using (var context = new WeatherContext())
            {
                var ExistingWeatherForecast =
                    context.WeatherForecast
                    .Where(x => x.Id == objWeatherForecast.Id)
                    .FirstOrDefault();
                if (ExistingWeatherForecast != null)
                {
                    ExistingWeatherForecast.Date =
                        objWeatherForecast.Date;
                    ExistingWeatherForecast.Summary =
                        objWeatherForecast.Summary;
                    ExistingWeatherForecast.TemperatureC =
                        objWeatherForecast.TemperatureC;
                    ExistingWeatherForecast.TemperatureF =
                        objWeatherForecast.TemperatureF;
                    context.SaveChanges();
                }
                else
                {
                    return Task.FromResult(false);
                }
            }
            return Task.FromResult(true);
        }
    }
}
