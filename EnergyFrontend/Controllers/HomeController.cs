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
using Microsoft.AspNetCore.Http;
using EnergyFrontend.Interfaces;

namespace EnergyFrontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IConfiguration configuration;
        private readonly IEnergyRecordService energyRecordService;
        private readonly IAuthService authService;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, IEnergyRecordService energyRecordService, IAuthService authService)
        {
            this.logger = logger;
            this.configuration = configuration;
            this.energyRecordService = energyRecordService;
            this.authService = authService;
        }

        public async Task<IActionResult> Index()
        {
            var token = await authService.LoginAsync(new Credentials() { UserName = "test1", Password = "pw1234" });
            HttpContext.Session.SetString("token", token);
            // Fetch data from backend
            var energyRecords = await energyRecordService.GetEnergyRecordsAsync(token);
            return View(energyRecords);
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
