using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WlihaHackEviction.Models;

namespace WlihaHackEviction.Controllers
{
    public class EvictionInfoController : Controller
    {
        private readonly EvictionDatabaseContext _context;

        public EvictionInfoController(EvictionDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/EvictionInfo
        public async Task<IActionResult> Index()
        {
            return View(await _context.DBEvictionInfo.ToListAsync());
        }

        // GET: EvictionInfo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evictionInfo = await _context.DBEvictionInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evictionInfo == null)
            {
                return NotFound();
            }

            return View(evictionInfo);
        }

        // GET: EvictionInfo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EvictionInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateOfEviction,EvictionNotice,Lease,Verified,Notes,TenantId,AddressId,PreparerId")] EvictionInfo evictionInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(evictionInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(evictionInfo);
        }

        // GET: EvictionInfo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evictionInfo = await _context.DBEvictionInfo.FindAsync(id);
            if (evictionInfo == null)
            {
                return NotFound();
            }
            return View(evictionInfo);
        }

        // POST: EvictionInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateOfEviction,EvictionNotice,Lease,Verified,Notes,TenantId,AddressId,PreparerId")] EvictionInfo evictionInfo)
        {
            if (id != evictionInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evictionInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EvictionInfoExists(evictionInfo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(evictionInfo);
        }

        // GET: EvictionInfo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evictionInfo = await _context.DBEvictionInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evictionInfo == null)
            {
                return NotFound();
            }

            return View(evictionInfo);
        }

        // POST: EvictionInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var evictionInfo = await _context.DBEvictionInfo.FindAsync(id);
            _context.DBEvictionInfo.Remove(evictionInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EvictionInfoExists(int id)
        {
            return _context.DBEvictionInfo.Any(e => e.Id == id);
        }
    }
}
