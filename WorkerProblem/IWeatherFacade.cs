using WorkerProblem.Entities;

// create an interface
public interface IWeatherFacade
{
    WeatherFacadeResults GetTempInCity(string zipCode);
}