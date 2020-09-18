using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CasualShop.BLL;
using CasualShop.BLL.DtoModels;
using CasualShop.DAL.Repository;
using CasualShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace CasualShop.Controllers
{
    public class BasketController : Controller
    {
        private DataManager _dataManager;
        private ServicesManager _servicesManager;

        public BasketController(DataManager dataManager)
        {
            _dataManager = dataManager;
            _servicesManager = new ServicesManager(dataManager);
        }
        public IActionResult Index()
        {
            var model = _servicesManager.Baskets.GetBasketsList();
            return View(model);
        }
            
        public IActionResult Delete(int basketId)
        {
            _servicesManager.Baskets.DeleteBasketById(basketId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddToBasket(string userId, int clothesId)
        {
            BasketEditDto _editModel = _servicesManager.Baskets.CreateBasketEditDto();

            _editModel.CurrentUser = userId;
            _editModel.ClothesId = clothesId;
            _editModel.Count = 1;
            _editModel.isProcessed = false;
            _servicesManager.Baskets.SaveBasketEditDtoToDb(_editModel);

            return RedirectToAction("Index");
        }        

        [HttpPost]
        public IActionResult Index(string basketCurrentUserId, string firstName, string lastName, string phoneNum, string email)
        {
            var _basketModel = _servicesManager.Baskets.GetBasketsList().Where(b => b.CurrentUser == basketCurrentUserId && b.isProcessed == false);
           
                EmailService emailService = new EmailService();

                string emailText = "<div>Firstname: " + firstName + "</div><div>Lastname: " + lastName + "</div><div>Phone: " + phoneNum +
                    "</div><div>Email: " + email + "</div><div>";
                int totalPrice = 0;
                foreach (var item in _basketModel)
                {
                    if (item.CurrentUser == basketCurrentUserId && item.isProcessed == false)
                    {
                        var clothesModel = _servicesManager.Clothes.GetClothesModelById(item.ClothesId);
                        emailText = emailText + "<div>Clothes name: " + clothesModel.Name + " Price:" + clothesModel.Price + "$</div>";
                        totalPrice += clothesModel.Price;
                        item.isProcessed = true;
                    }
                    _servicesManager.Baskets.UpdateBasketsDtoToDb(item);
                }
                emailText += "<div style=\"font-weight:bold\">Total price: " + totalPrice.ToString() + "</div></div>";
                emailService.SendEmail(email, "CasualShop Order",
                    emailText);
                return RedirectToAction("Index", "Shop");            
        }
    }
}