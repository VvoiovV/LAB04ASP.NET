using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        static List<StudentViewModel> students = new List<StudentViewModel>();

        [HttpGet]
        public IActionResult Index(string searchString)
        {
            var filteredStudents = string.IsNullOrEmpty(searchString)
                ? students
                : students.Where(s => s.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                                      s.IndexNumber.Contains(searchString)).ToList();

            ViewBag.SearchString = searchString;
            return View(filteredStudents);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentViewModel student)
        {
            if (ModelState.IsValid)
            {
                student.Id = students.Any() ? students.Max(x => x.Id) + 1 : 1;
                students.Add(student);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();

            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(StudentViewModel updatedStudent)
        {
            var student = students.FirstOrDefault(s => s.Id == updatedStudent.Id);
            if (student == null) return NotFound();

            if (ModelState.IsValid)
            {
                student.Name = updatedStudent.Name;
                student.Email = updatedStudent.Email;
                student.IndexNumber = updatedStudent.IndexNumber;
                student.Birth = updatedStudent.Birth;

                return RedirectToAction("Index");
            }

            return View(updatedStudent);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();

            return View(student);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();

            students.Remove(student);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();

            return View(student);
        }
    }
}
