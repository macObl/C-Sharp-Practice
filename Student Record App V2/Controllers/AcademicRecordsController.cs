using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab6.Models.DataAccess;
using Lab6.Models;
using Microsoft.AspNetCore.Http;

namespace Lab6.Controllers
{
    public class AcademicRecordsController : Controller
    {
        private readonly StudentRecordContext _context;

        public AcademicRecordsController(StudentRecordContext context)
        {
            _context = context;
        }

        // GET: AcademicRecords
        public async Task<IActionResult> Index(string sort)
        {
            ViewData["sort"] = sort;

            var StudentRecordContext = _context.AcademicRecord.Include(a => a.CourseCodeNavigation).Include(a => a.Student);
            var sortedRecords = StudentRecordContext.ToArray();
            if (sort == "course")
            {
                sortedRecords = StudentRecordContext.OrderBy(r => r.CourseCodeNavigation.Title).ToArray();
            }
            else if (sort == "student")
            {
                sortedRecords = StudentRecordContext.OrderBy(r => r.Student.Name).ToArray();
            }
            else if (sort == "grade")
            {
                sortedRecords = StudentRecordContext.OrderBy(r => r.Grade).ToArray();
            }
            if (HttpContext.Session.GetString("SortOrder") == null || HttpContext.Session.GetString("SortOrder") == "Descending")
            {
                HttpContext.Session.SetString("SortOrder", "Ascending");
            }
            else
            {
                HttpContext.Session.SetString("SortOrder", "Descending");
                sortedRecords = sortedRecords.Reverse().ToArray();
            }
            return View(sortedRecords);
        }

        // GET: AcademicRecords/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicRecord = await _context.AcademicRecord
                .Include(a => a.CourseCodeNavigation)
                .Include(a => a.Student)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (academicRecord == null)
            {
                return NotFound();
            }

            return View(academicRecord);
        }

        // GET: AcademicRecords/Create
        public IActionResult Create()
        {
            var courses = (from a in _context.Course select new { Code = a.Code, Title = a.Code + " - " + a.Title }).ToList();
            ViewData["CourseCode"] = new SelectList(courses,"Code", "Title");
            
            var students  = (from b in _context.Student select new { Id = b.Id, Name = b.Id + " - " + b.Name }).ToList();
            ViewData["StudentId"] = new SelectList(students, "Id", "Name");
            return View();
        }

        // POST: AcademicRecords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseCode,StudentId,Grade")] AcademicRecord academicRecord)
        {
            if (ModelState.IsValid)
            {
                var exists = (from e in _context.AcademicRecord where string.Compare(e.StudentId, academicRecord.StudentId) == 0 && string.Compare(e.CourseCode, academicRecord.CourseCode) == 0 select e).FirstOrDefault<AcademicRecord>();

                if(exists == null)
                {
                    _context.Add(academicRecord);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("CourseCode", "The student has already had an academic record for this course");
                }
            }
            var courses = (from a in _context.Course select new { Code = a.Code, Title = a.Code + " - " + a.Title }).ToList();
            ViewData["CourseCode"] = new SelectList(courses, "Code", "Title");

            var students = (from b in _context.Student select new { Id = b.Id, Name = b.Id + " - " + b.Name }).ToList();
            ViewData["StudentId"] = new SelectList(students, "Id", "Name");
            return View(academicRecord);
        }

        // GET: AcademicRecords/Edit/5
        public async Task<IActionResult> Edit(string StudentId, string courseCode)
        {
            if (StudentId == null || courseCode == null)
            {
                return NotFound();
            }
            var academicRecord = (from ar in _context.AcademicRecord.Include(a => a.CourseCodeNavigation).Include(a => a.Student)
                                  where ar.CourseCode == courseCode && ar.StudentId == StudentId
                                  select ar).FirstOrDefault<AcademicRecord>();
            if (academicRecord == null)
            {
                return NotFound();
            }
            return View(academicRecord);
        }

        // POST: AcademicRecords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AcademicRecord academicRecord)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(academicRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcademicRecordExists(academicRecord.StudentId))
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
            ViewData["CourseCode"] = new SelectList(_context.Course, "Code", "Code", academicRecord.CourseCode);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id", academicRecord.StudentId);
            return View(academicRecord);
        }

        public async Task<IActionResult> EditAll()
        {
            var records = _context.AcademicRecord.Include(a => a.CourseCodeNavigation).Include(a => a.Student);
            var sortedRecords = records.ToArray();
            string sort = HttpContext.Request.Query["sort"].ToString();
            if (sort == "course")
            {
                sortedRecords = records.OrderBy(r => r.CourseCodeNavigation.Title).ToArray();
            }
            else if (sort == "student")
            {
                sortedRecords = records.OrderBy(r => r.Student.Name).ToArray();
            }
            else
            {
                sortedRecords = records.OrderBy(r => r.Grade).ToArray();
            }
            if (HttpContext.Session.GetString("SortOrder") == null || HttpContext.Session.GetString("SortOrder") == "Descending")
            {
                HttpContext.Session.SetString("SortOrder", "Ascending");
            }
            else
            {
                HttpContext.Session.SetString("SortOrder", "Descending");
                sortedRecords = sortedRecords.Reverse().ToArray();
            }
            return View(sortedRecords);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAll(AcademicRecord[] academicRecords)
        {
            if (ModelState.IsValid)
            {
                foreach (AcademicRecord record in academicRecords)
                {
                    _context.Update(record);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(academicRecords);
        }

        // GET: AcademicRecords/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicRecord = await _context.AcademicRecord
                .Include(a => a.CourseCodeNavigation)
                .Include(a => a.Student)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (academicRecord == null)
            {
                return NotFound();
            }

            return View(academicRecord);
        }

        // POST: AcademicRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var academicRecord = await _context.AcademicRecord.FindAsync(id);
            _context.AcademicRecord.Remove(academicRecord);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcademicRecordExists(string id)
        {
            return _context.AcademicRecord.Any(e => e.StudentId == id);
        }
    }
}
