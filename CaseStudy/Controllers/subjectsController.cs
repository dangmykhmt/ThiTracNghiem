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
    public class subjectsController : Controller
    {
        private readonly trac_nghiem_onlineEntities _context;

        public subjectsController(trac_nghiem_onlineEntities context)
        {
            _context = context;
        }

        // GET: subjects
        public async Task<IActionResult> Index()
        {
            return View(await _context.subjects.ToListAsync());
        }

        // GET: subjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.subjects
                .FirstOrDefaultAsync(m => m.id_subject == id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // GET: subjects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: subjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_subject,subject_name")] subject subject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subject);
        }

        // GET: subjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.subjects.FindAsync(id);
            if (subject == null)
            {
                return NotFound();
            }
            return View(subject);
        }

        // POST: subjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_subject,subject_name")] subject subject)
        {
            if (id != subject.id_subject)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!subjectExists(subject.id_subject))
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
            return View(subject);
        }

        // GET: subjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.subjects
                .FirstOrDefaultAsync(m => m.id_subject == id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // POST: subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subject = await _context.subjects.FindAsync(id);
            _context.subjects.Remove(subject);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool subjectExists(int id)
        {
            return _context.subjects.Any(e => e.id_subject == id);
        }
    }
}
