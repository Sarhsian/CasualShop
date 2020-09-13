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

namespace CasualShop.Controllers
{
    public class AdminController : Controller
    {
        private readonly EFDBContext _context;
        DataManager dm;

        public AdminController(EFDBContext context, DataManager _dm)
        {
            dm = _dm;
            _context = context;
        }
       
        public async Task<IActionResult> Index()
        {
            var clothes = _context.Clothes.Include(b => b.Brand).Include(t => t.Tag);
            return View(await clothes.ToListAsync());
        }
       
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clothes = await _context.Clothes.Include(b => b.Brand).Include(t => t.Tag)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clothes == null)
            {
                return NotFound();
            }

            return View(clothes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            //list of commands for sending to view
            SelectList brands = new SelectList(_context.Brands, "Id", "Name");
            ViewBag.Brands = brands;
            SelectList tags = new SelectList(_context.Tags, "Id", "Name");
            ViewBag.Tags = tags;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Clothes clothes)
        {
            await _context.Clothes.AddAsync(clothes);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }        

        public async Task<IActionResult> Edit(int? id)
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
        
        [HttpPost]
        public async Task<IActionResult> Edit(Clothes clothes)
        {
            _context.Entry(clothes).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id)
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
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clothes = await _context.Clothes.FindAsync(id);
            _context.Clothes.Remove(clothes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClothesExists(int id)
        {
            return _context.Clothes.Any(e => e.Id == id);
        }
    }
}
