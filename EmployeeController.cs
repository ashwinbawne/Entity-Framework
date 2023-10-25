using Crud_using_entity_framework.Models;
using Microsoft.AspNetCore.Mvc;

namespace Crud_using_entity_framework.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDAL ed = new EmployeeDAL();

        [HttpGet]
        public IActionResult Index()
        {
            var data = ed.Employees.ToList();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(Employee e)
        {
            if (ModelState.IsValid == true)
            {
                ed.Employees.Add(e);
                int a = ed.SaveChanges();

                if (a > 0)
                {
                    TempData["Message"] = "Data Saved Successfully";
                    return RedirectToAction("Index");
                }

                else
                {
                    ViewBag.CreateMessage = ("<script>alert('Data not Saved..')</script>");
                }

            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var row = ed.Employees.Where(Model => Model.Id == id).FirstOrDefault();

            return View(row);


        }

        [HttpPost]

        public IActionResult Edit(Employee e)
        {
            ed.Entry(e).State = System.Data.Entity.EntityState.Modified;
            int a = ed.SaveChanges();

            if (a > 0)
            {

                return RedirectToAction("Index");
            }

            else
            {
                ViewBag.UpdateMessage = ("<script> alert('Do not saved')</script>");
            }


            return View();
        }

        [HttpGet]

        public IActionResult Delete(int id)
        {
            var row = ed.Employees.Where(Model => Model.Id == id).FirstOrDefault();
            return View(row);
        }

        [HttpPost]

        public IActionResult Delete(Employee e)
        {
            ed.Entry(e).State = System.Data.Entity.EntityState.Deleted;
            int a = ed.SaveChanges();

            if (a > 0)
            {

                ViewBag.DeleteMessage = ("<script> alert('Data deleted')</script>");
                ModelState.Clear();
            }

            else
            {
                ViewBag.DeleteMessage = ("<script> alert('Do not deleted')</script>");
            }

            return View();
        }

        [HttpGet]

        public IActionResult Details(int id)
        {
            var row = ed.Employees.Where(Model => Model.Id == id).FirstOrDefault();
            return View(row);





        }

        [HttpPost]

        public IActionResult Details(Employee e)
        {
            ed.Entry(e).State = System.Data.Entity.EntityState.Added;
            int a = ed.SaveChanges();
            if (a > 0)
            {

                ViewBag.DeleteMessage = ("<script> alert('Data details')</script>");
                ModelState.Clear();
            }

            else
            {
                ViewBag.DeleteMessage = ("<script> alert('Do not deleted')</script>");
            }

            return View();
        }







    }

}

