namespace ViewModelEnhancer.Services
{
    public interface IForecastService
    {
        void AddHourlyForecastToModel(LocationWithHourlyForecasts model);
    }
}