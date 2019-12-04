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
    public class questionsController : Controller
    {
        private readonly trac_nghiem_onlineEntities _context;

        public questionsController(trac_nghiem_onlineEntities context)
        {
            _context = context;
        }

        // GET: questions
        public async Task<IActionResult> Index()
        {
            var trac_nghiem_onlineEntities = _context.questions.Include(q => q.subject);
            return View(await trac_nghiem_onlineEntities.ToListAsync());
        }

        // GET: questions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.questions
                .Include(q => q.subject)
                .FirstOrDefaultAsync(m => m.id_question == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // GET: questions/Create
        public IActionResult Create()
        {
            ViewData["id_subject"] = new SelectList(_context.subjects, "id_subject", "id_subject");
            return View();
        }

        // POST: questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_question,id_subject,content,answer_a,answer_b,answer_c,answer_d,correct_answer")] question question)
        {
            if (ModelState.IsValid)
            {
                _context.Add(question);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_subject"] = new SelectList(_context.subjects, "id_subject", "id_subject", question.id_subject);
            return View(question);
        }

        // GET: questions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.questions.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            ViewData["id_subject"] = new SelectList(_context.subjects, "id_subject", "id_subject", question.id_subject);
            return View(question);
        }

        // POST: questions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_question,id_subject,content,answer_a,answer_b,answer_c,answer_d,correct_answer")] question question)
        {
            if (id != question.id_question)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(question);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!questionExists(question.id_question))
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
            ViewData["id_subject"] = new SelectList(_context.subjects, "id_subject", "id_subject", question.id_subject);
            return View(question);
        }

        // GET: questions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.questions
                .Include(q => q.subject)
                .FirstOrDefaultAsync(m => m.id_question == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // POST: questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var question = await _context.questions.FindAsync(id);
            _context.questions.Remove(question);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool questionExists(int id)
        {
            return _context.questions.Any(e => e.id_question == id);
        }
    }
}
