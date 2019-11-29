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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Student/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}