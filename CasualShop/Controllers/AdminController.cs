using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CasualShop.DAL;
using CasualShop.DAL.Entities;
using CasualShop.DAL.Repository;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using CasualShop.Areas.Identity.Data;

namespace CasualShop.Controllers
{    
    public class AdminController : Controller
    {
        private readonly EFDBContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        private UserManager<CasualShopUser> _userManager;
        string adminId;

        public AdminController(EFDBContext context,
            IWebHostEnvironment hostEnvironment,
            UserManager<CasualShopUser> userManager)
        {
            adminId = "6d0e867b-efdf-46c5-a271-41cdc90881b7";
            _userManager = userManager;
            _context = context;
            _hostEnvironment = hostEnvironment;
        }
       
        public IActionResult Permission()
        {
            return Content("You don't have permission");
        }
        public async Task<IActionResult> Index()
        {
            if (_userManager.GetUserId(User) == adminId)
            {
                var clothes = _context.Clothes.Include(b => b.Brand).Include(t => t.Tag).Include(i => i.Image);
                return View(await clothes.ToListAsync());
            }
            else return Permission();
        }
       
        public async Task<IActionResult> Details(int? id)
        {
            if (_userManager.GetUserId(User) == adminId)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var clothes = await _context.Clothes.Include(b => b.Brand).Include(t => t.Tag).Include(i => i.Image)
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (clothes == null)
                {
                    return NotFound();
                }

                return View(clothes);
            }
            else return Permission();
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (_userManager.GetUserId(User) == adminId)
            {
                //list of commands for sending to view
                SelectList brands = new SelectList(_context.Brands, "Id", "Name");
                ViewBag.Brands = brands;
                SelectList tags = new SelectList(_context.Tags, "Id", "Name");
                ViewBag.Tags = tags;

                return View();
            }
            else return Permission();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Clothes clothes)
        {
            if (_userManager.GetUserId(User) == adminId)
            {
                if (ModelState.IsValid)
                {
                    //save image to wwwroot/Image
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(clothes.Image.ImageFile.FileName);
                    string extention = Path.GetExtension(clothes.Image.ImageFile.FileName);
                    clothes.Image.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;
                    string path = Path.Combine(wwwRootPath + "/Image/", fileName);

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await clothes.Image.ImageFile.CopyToAsync(fileStream);
                    }

                    Image img = new Image
                    {
                        ImageName = clothes.Image.ImageName,
                        Title = clothes.Image.Title
                    };

                    await _context.Images.AddAsync(img);
                    await _context.SaveChangesAsync();

                    clothes.Image = null;
                    clothes.ImageId = _context.Images.FirstOrDefault(i => i.ImageName == img.ImageName).Id;

                    await _context.Clothes.AddAsync(clothes);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction("Index");
            }
            else return Permission();
        }        

        public async Task<IActionResult> Edit(int? id)
        {
            if (_userManager.GetUserId(User) == adminId)
            {
                if (id == null)
                {
                    return NotFound();
                }

                Clothes clothes = await _context.Clothes.FindAsync(id);
                if (clothes != null)
                {
                    SelectList brands = new SelectList(_context.Brands, "Id", "Name", clothes.BrandId);
                    ViewBag.Brands = brands;
                    SelectList tags = new SelectList(_context.Tags, "Id", "Name", clothes.TagId);
                    ViewBag.Tags = tags;

                    return View(clothes);
                }
                return RedirectToAction("Index");
            }
            else return Permission();
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit(Clothes clothes)
        {
            if (_userManager.GetUserId(User) == adminId)
            {
                _context.Entry(clothes).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else return Permission();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (_userManager.GetUserId(User) == adminId)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var clothes = await _context.Clothes
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (clothes == null)
                {
                    return NotFound();
                }

                return View(clothes);
            }
            else return Permission();
        }
        
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_userManager.GetUserId(User) == adminId)
            {
                var clothes = await _context.Clothes.FindAsync(id);
                if (clothes.ImageId != null)
                {
                    var image = await _context.Images.FindAsync(clothes.ImageId);
                    //delete image from wwwroot/image
                    var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "image", image.ImageName);
                    if (System.IO.File.Exists(imagePath))
                        System.IO.File.Delete(imagePath);
                    //delete the record
                    _context.Images.Remove(image);
                }
                _context.Clothes.Remove(clothes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else return Permission();
        }
       
        private bool ClothesExists(int id)
        {
            return _context.Clothes.Any(e => e.Id == id);
        }
    }
}
