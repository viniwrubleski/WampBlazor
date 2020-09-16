using System.Collections.Generic;
using System.Threading.Tasks;
using WampSharp.V2.Rpc;

namespace WampBlazor.Shared.Services
{
    public interface IWeatherForecastService
    {
        [WampProcedure("com.weatherforecast.get")]
        Task<IEnumerable<WeatherForecast>> Get();
    }
}