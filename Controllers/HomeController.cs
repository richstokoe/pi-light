using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RS.PiLight.Models;

namespace RS.PiLight.Controllers
{
    public class HomeController : Controller
    {
        private const int RED = 26;
        private const int GREEN = 16;
        private readonly ILogger<HomeController> _logger;
        private readonly GpioHelper gpio;

        public HomeController(
            ILogger<HomeController> logger,
            GpioHelper gpio)
        {
            _logger = logger;
            this.gpio = gpio;

            EnsurePinsOpen();
        }

        private void EnsurePinsOpen()
        {
            try
            {
                this.gpio.SetPinMode(RED, PinMode.Output);
                this.gpio.SetPinMode(GREEN, PinMode.Output);
            }
            catch (InvalidOperationException)
            {
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Red(bool on = true)
        {
            var pinValue = on ? PinValue.High : PinValue.Low;
            gpio.WritePin(RED, pinValue);
            return Content($"RED: {pinValue}");
        }

        public IActionResult Green(bool on = true)
        {
            var pinValue = on ? PinValue.High : PinValue.Low;
            gpio.WritePin(GREEN, pinValue);
            return Content($"GREEN: {pinValue}");
        }
    }
}
