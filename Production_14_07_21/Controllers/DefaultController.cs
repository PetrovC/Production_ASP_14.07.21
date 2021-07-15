using Microsoft.AspNetCore.Mvc;
using Production_14_07_21.Models;
using Technobel_Student.DAL.Models.Entities;
using Technobel_Student.DAL.Models.Services;

namespace Production_14_07_21.Controllers
{
    public class DefaultController : Controller
    {
        private readonly StudentService MyStudentService;
        public DefaultController(StudentService myStudentService)
        {
            MyStudentService = myStudentService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddStudent(Student s)
        {
            MyStudentService.Add(s);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteStudentById(int id)
        {
            MyStudentService.Delete(id);
            return RedirectToAction("GetThemAll");
        }
        public IActionResult UpDateStudent(Student s)
        {
            if (ModelState.IsValid)
            {
                MyStudentService.UpDateStudent(s);

            }
            else
            {
                TempData["error"] = "Une erreur est survenue";
            }
            return RedirectToAction("GetThemAll");
        }
        public IActionResult GetThemAll()
        {
            ListAndNewStudent model = new ListAndNewStudent();
            model.Students = MyStudentService.GetThemAll();
            return View(model);
        }
    }
}
