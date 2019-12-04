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
    public class student_test_detailController : Controller
    {
        private readonly trac_nghiem_onlineEntities _context;

        public student_test_detailController(trac_nghiem_onlineEntities context)
        {
            _context = context;
        }

        // GET: student_test_detail
        public async Task<IActionResult> Index()
        {
            var trac_nghiem_onlineEntities = _context.student_test_detail.Include(s => s.question).Include(s => s.student);
            return View(await trac_nghiem_onlineEntities.ToListAsync());
        }

        // GET: student_test_detail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student_test_detail = await _context.student_test_detail
                .Include(s => s.question)
                .Include(s => s.student)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (student_test_detail == null)
            {
                return NotFound();
            }

            return View(student_test_detail);
        }

        // GET: student_test_detail/Create
        public IActionResult Create()
        {
            ViewData["id_question"] = new SelectList(_context.questions, "id_question", "id_question");
            ViewData["id_student"] = new SelectList(_context.students, "id_student", "id_student");
            return View();
        }

        // POST: student_test_detail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,id_student,id_question,answer_a,answer_b,answer_c,answer_d,student_answer,test_code")] student_test_detail student_test_detail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student_test_detail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_question"] = new SelectList(_context.questions, "id_question", "id_question", student_test_detail.id_question);
            ViewData["id_student"] = new SelectList(_context.students, "id_student", "id_student", student_test_detail.id_student);
            return View(student_test_detail);
        }

        // GET: student_test_detail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student_test_detail = await _context.student_test_detail.FindAsync(id);
            if (student_test_detail == null)
            {
                return NotFound();
            }
            ViewData["id_question"] = new SelectList(_context.questions, "id_question", "id_question", student_test_detail.id_question);
            ViewData["id_student"] = new SelectList(_context.students, "id_student", "id_student", student_test_detail.id_student);
            return View(student_test_detail);
        }

        // POST: student_test_detail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,id_student,id_question,answer_a,answer_b,answer_c,answer_d,student_answer,test_code")] student_test_detail student_test_detail)
        {
            if (id != student_test_detail.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student_test_detail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!student_test_detailExists(student_test_detail.ID))
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
            ViewData["id_question"] = new SelectList(_context.questions, "id_question", "id_question", student_test_detail.id_question);
            ViewData["id_student"] = new SelectList(_context.students, "id_student", "id_student", student_test_detail.id_student);
            return View(student_test_detail);
        }

        // GET: student_test_detail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student_test_detail = await _context.student_test_detail
                .Include(s => s.question)
                .Include(s => s.student)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (student_test_detail == null)
            {
                return NotFound();
            }

            return View(student_test_detail);
        }

        // POST: student_test_detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student_test_detail = await _context.student_test_detail.FindAsync(id);
            _context.student_test_detail.Remove(student_test_detail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool student_test_detailExists(int id)
        {
            return _context.student_test_detail.Any(e => e.ID == id);
        }
    }
}
