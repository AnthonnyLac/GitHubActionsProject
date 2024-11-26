using GitHubActionsProject.API.Controllers;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubActionsProject.Tests.API.Controllers
{
    public class WeatherForecastControllerTests
    {
        private readonly WeatherForecastController _controller;

        public WeatherForecastControllerTests()
        {
            // Configura o logger substituído pelo NSubstitute
            var logger = Substitute.For<ILogger<WeatherForecastController>>();
            _controller = new WeatherForecastController(logger);
        }

        [Fact]
        public void Get_ShouldReturnNonNullResult()
        {
            // Act
            var result = _controller.Get();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Get_ShouldReturnExactlyFiveForecasts()
        {
            // Act
            var result = _controller.Get();

            // Assert
            var forecasts = result.ToArray();
            Assert.Equal(5, forecasts.Length);
        }

        [Fact]
        public void Get_ForecastDates_ShouldBeInTheFuture()
        {
            // Act
            var result = _controller.Get();

            // Assert
            foreach (var forecast in result)
            {
                Assert.True(forecast.Date.ToDateTime(TimeOnly.MinValue) > DateTime.Now);
            }
        }

        [Fact]
        public void Get_ForecastSummaries_ShouldBelongToPredefinedList()
        {
            // Act
            var result = _controller.Get();

            // Assert
            foreach (var forecast in result)
            {
                Assert.Contains(forecast.Summary, WeatherForecastController.Summaries);
            }
        }

        [Fact]
        public void Get_ForecastTemperatures_ShouldBeWithinValidRange()
        {
            // Act
            var result = _controller.Get();

            // Assert
            foreach (var forecast in result)
            {
                Assert.InRange(forecast.TemperatureC, -20, 55);
            }
        }
    }
}
