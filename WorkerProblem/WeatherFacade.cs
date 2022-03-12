﻿using WorkerProblem.Entities;
using WorkerProblem.Services;

namespace WorkerProblem
{
    // implement interface, use services as fields
    public class WeatherFacade : IWeatherFacade
    {
        private readonly ConverterService _converterService;
        private readonly GeoLookupService _geoLookUpService;
        private readonly WeatherService _weatherService;

        public WeatherFacade() :
            this(new ConverterService(), new GeoLookupService(), new WeatherService())
        {

        }

        public WeatherFacade(ConverterService converterService,
                                GeoLookupService geoLookUpService,
                                WeatherService weatherService)
        {
            _converterService = converterService;
            _geoLookUpService = geoLookUpService;
            _weatherService = weatherService;
        }

        public WeatherFacadeResults GetTempInCity(string zipCode)
        {
            City city = _geoLookUpService.GetCityForZipCode(zipCode);
            State state = _geoLookUpService.GetStateForZipCode(zipCode);
            int tempF = _weatherService.GetTempFahrenheit(city, state);
            int tempC = _converterService.ConvertFahrenheitToCelcious(tempF);

            // construct result
            var results = new WeatherFacadeResults
            {
                City = city,
                State = state,
                Fahrenheit = tempF,
                Celsius = tempC
            };

            return results;
        }
    }
}
