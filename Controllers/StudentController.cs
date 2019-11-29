using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SampleASPCore.Models;
using SampleASPCore.Services;

namespace SampleASPCore.Controllers
{
    public class StudentController : Controller
    {
        private IStudent _student;
        public StudentController(IStudent student)
        {
            _student = student;
        }

        // GET: Student
        public async Task<ActionResult> Index()
        {
            if (TempData["pesan"] != null)
                ViewBag.Pesan = TempData["pesan"];

            var models = await _student.GetAll();

            ViewBag.LastName = new SelectList(models,"StudentID","LastName");
            return View(models);
        }

        [HttpPost]
        public async Task<IActionResult> Search(string keyword,string selectLast)
        {
            var models = await _student.GetByName(keyword);

            
            return View("Index",models);
        }

        // GET: Student/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var model = await _student.GetById(id.ToString());

            return View(model);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Student student)
        {
            try
            {
                await _student.Create(student);
                TempData["pesan"] = $"Data student {student.FirstMidName} berhasil ditambah";
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Error = $"Error: {ex.Message}";
                return View();
            }
        }

        // GET: Student/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = await _student.GetById(id.ToString());

            return View(model);
        }

        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Student student)
        {
            try
            {
                await _student.Edit(student);
                TempData["pesan"] = $"Data student {student.FirstMidName} berhasil diedit";
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Pesan = $"Pesan Kesalahan: {ex.Message}";
                return View();
            }
        }

        // GET: Student/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var model = await _student.GetById(id.ToString());
            return View(model);
        }

        // POST: Student/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<ActionResult> DeletePost(int id)
        {
            try
            {
                await _student.Delete(id.ToString());
                TempData["pesan"] = $"Data student berhasil didelete";
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Pesan = $"Error: {ex.Message}";
                return View();
            }
        }
    }
}