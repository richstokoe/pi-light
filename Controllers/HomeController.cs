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
        private const int RED = 16;
        private const int GREEN = 26;
        private readonly ILogger<HomeController> _logger;
        private readonly GpioHelper gpio;

        public HomeController(
            ILogger<HomeController> logger,
            GpioHelper gpio)
        {
            _logger = logger;
            this.gpio = gpio;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Red(bool on = true)
        {
            var pinValue = on ? PinValue.High : PinValue.Low;
            gpio.SetPinMode(RED, PinMode.Output);
            gpio.WritePin(RED, pinValue);
            return Content("RED is ON");
        }

        public IActionResult Green(bool on = true)
        {
            var pinValue = on ? PinValue.High : PinValue.Low;
            gpio.SetPinMode(GREEN, PinMode.Output);
            gpio.WritePin(GREEN, pinValue);
            return Content("GREEN is ON");
        }
    }
}
