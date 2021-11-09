using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EnergyFrontend.Models;
using Microsoft.Extensions.Configuration;
using EnergyFrontend.Services;

namespace EnergyFrontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IConfiguration configuration;
        private readonly EnergyRecordService energyRecordService;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, EnergyRecordService energyRecordService)
        {
            this.logger = logger;
            this.configuration = configuration;
            this.energyRecordService = energyRecordService;
        }

        public async Task<IActionResult> Index()
        {
            logger.LogInformation(configuration.GetValue<string>("BackendOrigin"));
            // Fetch data from backend
            await energyRecordService.GetEnergyRecordsAsync();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
