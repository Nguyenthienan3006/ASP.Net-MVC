using FA.Domain;
using Microsoft.AspNetCore.Mvc;
using FA.Model;

namespace FA.WebMvc.Controllers
{
    public class GradeController : Controller
    {
        private IGradeRepository _Repository;

        public GradeController(IGradeRepository repository)
        {
            _Repository = repository;
        }
        public IActionResult Index()
        {
            var grade = _Repository.getAll();
            return View(grade);
        }
        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(string gradeName)
        {
            _Repository.insert(new Model.Grade() { Name = gradeName });
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if(id.HasValue)
            {
                _Repository.delete(id.Value);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                var grade = _Repository.getGrade(id.Value);
                return View(grade);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(int? id, Grade grade)
        {
            if(grade.Name != null)
            {
                _Repository.update(grade);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Edit");
            }
        }
    }
}
