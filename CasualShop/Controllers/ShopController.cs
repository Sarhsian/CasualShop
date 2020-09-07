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
using CasualShop.BLL;
using ReflectionIT.Mvc.Paging;

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

        public IActionResult Index(int page = 1)
        {
            var _clothes = _serviceManager.Clothes.GetClothesList();
            var model = PagingList.Create(_clothes, 6, page);
            //var _clothes = _serviceManager.Clothes.GetClothesList();

            return View(model);
        }

        public IActionResult ClothesInfo(int id)
        {
            return View(_serviceManager.Clothes.GetClothesModelById(id));
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
