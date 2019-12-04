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
    public class scoresController : Controller
    {
        private readonly trac_nghiem_onlineEntities _context;

        public scoresController(trac_nghiem_onlineEntities context)
        {
            _context = context;
        }

        // GET: scores
        public async Task<IActionResult> Index()
        {
            var trac_nghiem_onlineEntities = _context.scores.Include(s => s.student).Include(s => s.test);
            return View(await trac_nghiem_onlineEntities.ToListAsync());
        }

        // GET: scores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var score = await _context.scores
                .Include(s => s.student)
                .Include(s => s.test)
                .FirstOrDefaultAsync(m => m.id_score == id);
            if (score == null)
            {
                return NotFound();
            }

            return View(score);
        }

        // GET: scores/Create
        public IActionResult Create()
        {
            ViewData["id_student"] = new SelectList(_context.students, "id_student", "id_student");
            ViewData["test_code"] = new SelectList(_context.tests, "test_code", "test_code");
            return View();
        }

        // POST: scores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_score,score_number,detail,id_student,test_code")] score score)
        {
            if (ModelState.IsValid)
            {
                _context.Add(score);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_student"] = new SelectList(_context.students, "id_student", "id_student", score.id_student);
            ViewData["test_code"] = new SelectList(_context.tests, "test_code", "test_code", score.test_code);
            return View(score);
        }

        // GET: scores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var score = await _context.scores.FindAsync(id);
            if (score == null)
            {
                return NotFound();
            }
            ViewData["id_student"] = new SelectList(_context.students, "id_student", "id_student", score.id_student);
            ViewData["test_code"] = new SelectList(_context.tests, "test_code", "test_code", score.test_code);
            return View(score);
        }

        // POST: scores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_score,score_number,detail,id_student,test_code")] score score)
        {
            if (id != score.id_score)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(score);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!scoreExists(score.id_score))
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
            ViewData["id_student"] = new SelectList(_context.students, "id_student", "id_student", score.id_student);
            ViewData["test_code"] = new SelectList(_context.tests, "test_code", "test_code", score.test_code);
            return View(score);
        }

        // GET: scores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var score = await _context.scores
                .Include(s => s.student)
                .Include(s => s.test)
                .FirstOrDefaultAsync(m => m.id_score == id);
            if (score == null)
            {
                return NotFound();
            }

            return View(score);
        }

        // POST: scores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var score = await _context.scores.FindAsync(id);
            _context.scores.Remove(score);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool scoreExists(int id)
        {
            return _context.scores.Any(e => e.id_score == id);
        }
    }
}
