using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CaseStudy.Model;
using CaseStudy.Models;

namespace CaseStudy.Controllers
{
    public class quests_of_testController : Controller
    {
        private readonly trac_nghiem_onlineEntities _context;

        public quests_of_testController(trac_nghiem_onlineEntities context)
        {
            _context = context;
        }

        // GET: quests_of_test
        public async Task<IActionResult> Index()
        {
            var trac_nghiem_onlineEntities = _context.quests_of_test.Include(q => q.question).Include(q => q.test);
            return View(await trac_nghiem_onlineEntities.ToListAsync());
        }

        // GET: quests_of_test/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quests_of_test = await _context.quests_of_test
                .Include(q => q.question)
                .Include(q => q.test)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (quests_of_test == null)
            {
                return NotFound();
            }

            return View(quests_of_test);
        }

        // GET: quests_of_test/Create
        public IActionResult Create()
        {
            ViewData["id_question"] = new SelectList(_context.questions, "id_question", "id_question");
            ViewData["test_code"] = new SelectList(_context.tests, "test_code", "test_code");
            return View();
        }

        // POST: quests_of_test/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,test_code,id_question")] quests_of_test quests_of_test)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quests_of_test);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_question"] = new SelectList(_context.questions, "id_question", "id_question", quests_of_test.id_question);
            ViewData["test_code"] = new SelectList(_context.tests, "test_code", "test_code", quests_of_test.test_code);
            return View(quests_of_test);
        }

        // GET: quests_of_test/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quests_of_test = await _context.quests_of_test.FindAsync(id);
            if (quests_of_test == null)
            {
                return NotFound();
            }
            ViewData["id_question"] = new SelectList(_context.questions, "id_question", "id_question", quests_of_test.id_question);
            ViewData["test_code"] = new SelectList(_context.tests, "test_code", "test_code", quests_of_test.test_code);
            return View(quests_of_test);
        }

        // POST: quests_of_test/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,test_code,id_question")] quests_of_test quests_of_test)
        {
            if (id != quests_of_test.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quests_of_test);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!quests_of_testExists(quests_of_test.ID))
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
            ViewData["id_question"] = new SelectList(_context.questions, "id_question", "id_question", quests_of_test.id_question);
            ViewData["test_code"] = new SelectList(_context.tests, "test_code", "test_code", quests_of_test.test_code);
            return View(quests_of_test);
        }

        // GET: quests_of_test/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quests_of_test = await _context.quests_of_test
                .Include(q => q.question)
                .Include(q => q.test)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (quests_of_test == null)
            {
                return NotFound();
            }

            return View(quests_of_test);
        }

        // POST: quests_of_test/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var quests_of_test = await _context.quests_of_test.FindAsync(id);
            _context.quests_of_test.Remove(quests_of_test);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool quests_of_testExists(int id)
        {
            return _context.quests_of_test.Any(e => e.ID == id);
        }
    }
}
