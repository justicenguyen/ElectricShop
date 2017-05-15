using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ElectricShop.Models;
using System.Data;

namespace ElectricShop.Controllers
{
    public class KhuyenMaiController : Controller
    {
        private readonly ElectricShopContext _context;

        public KhuyenMaiController(ElectricShopContext context)
        {
            _context = context;    
        }

        public async Task<IActionResult> CTKhuyenMai(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khuyenMai = await _context.KhuyenMai.SingleOrDefaultAsync(m => m.ID == id);
            if (khuyenMai == null)
            {
                return NotFound();
            }
            return View(khuyenMai);
        }

      

        // GET: KhuyenMai
        public async Task<IActionResult> Index()
        {
            return View(await _context.KhuyenMai.ToListAsync());
        }




        // GET: KhuyenMai/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khuyenMai = await _context.KhuyenMai
                .SingleOrDefaultAsync(m => m.ID == id);
            if (khuyenMai == null)
            {
                return NotFound();
            }

            return View(khuyenMai);
        }

        // GET: KhuyenMai/Create
        public IActionResult Create()
        {
            return View();
        }
       
        // POST: KhuyenMai/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TieuDeKhuyenMai,HinhAnh,NoiDung")] KhuyenMai khuyenMai)
        {
            if (ModelState.IsValid)
            {
                _context.Add(khuyenMai);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(khuyenMai);
        }

        // GET: KhuyenMai/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khuyenMai = await _context.KhuyenMai.SingleOrDefaultAsync(m => m.ID == id);
            if (khuyenMai == null)
            {
                return NotFound();
            }
            return View(khuyenMai);
        }

        // POST: KhuyenMai/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TieuDeKhuyenMai,HinhAnh,NoiDung")] KhuyenMai khuyenMai)
        {
            if (id != khuyenMai.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(khuyenMai);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhuyenMaiExists(khuyenMai.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(khuyenMai);
        }

        // GET: KhuyenMai/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khuyenMai = await _context.KhuyenMai
                .SingleOrDefaultAsync(m => m.ID == id);
            if (khuyenMai == null)
            {
                return NotFound();
            }

            return View(khuyenMai);
        }

        // POST: KhuyenMai/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var khuyenMai = await _context.KhuyenMai.SingleOrDefaultAsync(m => m.ID == id);
            _context.KhuyenMai.Remove(khuyenMai);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool KhuyenMaiExists(int id)
        {
            return _context.KhuyenMai.Any(e => e.ID == id);
        }
    }
}
