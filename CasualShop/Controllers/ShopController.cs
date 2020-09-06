using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CasualShop.Models;
using Microsoft.AspNetCore.Authorization;
using CasualShop.DAL.Repository;
using CasualShop.DAL.Entities;
using CasualShop.BLL;

namespace CasualShop.Controllers
{
    [Authorize]
    public class ShopController : Controller
    {
        private readonly ILogger<ShopController> _logger;
        private DataManager _dataManager;
        private ServicesManager _serviceManager;

        public ShopController(ILogger<ShopController> logger, DataManager dataManager)
        {
            _logger = logger;
            _dataManager = dataManager;
            _serviceManager = new ServicesManager(dataManager);
        }

        public IActionResult Index()
        {
            //List<Clothes> _clothes = _dataManager.Clothes.GetAllClothes().ToList();
            var _clothes = _serviceManager.Brands.GetBrandsList();

            return View(_clothes);
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
