using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICoreClientAppCS.Models;

namespace WebAPICoreClientAppCS.Controllers
{
    public class CourseIndexerController : Controller
    {
        private CourseIndexer ci = new CourseIndexer();
        private List<MyCourse> courses;
        // GET: CourseIndexerController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CourseIndexerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CourseIndexerController/Create
        public ActionResult Search()
        {
            return View();
        }

        // POST: CourseIndexerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(string txtName)
        {
            try
            {
                courses = ci[txtName];
                ViewData["courses"] = courses;
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseIndexerController/Create
        public ActionResult SearchByRange()
        {
            return View();
        }

        // POST: CourseIndexerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SearchByRange(int txtStartRange, int txtEndRange)
        {
            try
            {
                courses = ci[txtStartRange, txtEndRange];
                ViewData["courses"] = courses;
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseIndexerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CourseIndexerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseIndexerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CourseIndexerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
