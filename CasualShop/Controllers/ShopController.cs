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
using Microsoft.AspNetCore.Mvc.Rendering;
using CasualShop.BLL.DtoModels;

namespace CasualShop.Controllers
{
    //[Authorize]
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
            //SelectList brands = new SelectList(_serviceManager.Brands.GetBrandsList(), "Id", "Name");
            //ViewBag.Brands = brands;
            //SelectList tags = new SelectList(_serviceManager.Tags.GetTagsList(), "Id", "Name");
            //ViewBag.Tags = tags;

            var _clothes = _serviceManager.Clothes.GetClothesList();
            var model = PagingList.Create(_clothes, 9, page);
            //var _clothes = _serviceManager.Clothes.GetClothesList();

            return View(model);
        }

        [HttpGet]
        public IActionResult Index(int? brand, int? tag, int page = 1)
        {            
                List<BrandDto> brandsList = _serviceManager.Brands.GetBrandsList();
                brandsList.Insert(0, new BrandDto { Name = "All", Id = 0 });
                SelectList brands = new SelectList(brandsList, "Id", "Name");
                ViewBag.Brands = brands;

                List<TagDto> tagsList = _serviceManager.Tags.GetTagsList();
                tagsList.Insert(0, new TagDto { Name = "All", Id = 0 });
                SelectList tags = new SelectList(tagsList, "Id", "Name");
                ViewBag.Tags = tags;
            
            IEnumerable<ClothesDto> clothes = _serviceManager.Clothes.GetClothesList();

            if (brand != null && brand != 0)
            {
                clothes = clothes.Where(c => c.ClothesBrand.Id == brand);
            }
            if (tag != null && tag != 0)
            {
                clothes = clothes.Where(c => c.Tag.Id == tag);
            }
            if (brand != null && brand != 0 && tag != null && tag != 0)
            {
                clothes = clothes.Where(c => c.ClothesBrand.Id == brand && c.Tag.Id == tag);
            }

            var model = PagingList.Create(clothes, 9, page);

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
