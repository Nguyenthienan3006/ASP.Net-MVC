using FA.Domain;
using FA.Model;
using Microsoft.AspNetCore.Mvc;

namespace FA.WebMvc.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _repository;
        private readonly IGradeRepository _gradeRepository;

        public StudentController(IStudentRepository repository, IGradeRepository gradeRepository)
        {
            _repository = repository;
            _gradeRepository = gradeRepository;
        }
        public IActionResult Index()
        {
            var student = _repository.getAll();
            return View(student);
        }

        public IActionResult Create()
        {
            var grade = _gradeRepository.getAll();
            return View(grade);
        }
        [HttpPost]
        public IActionResult Create(string Name, string Email, int GradeId)
        {
            _repository.Insert(new Model.Student() { Name = Name, Email = Email, 
                DateOfJoin = DateTime.Now, GradeId = GradeId
            });
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                _repository.Delete(id.Value);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                var student = _repository.getStudent(id.Value);
                return View(student);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(int? id, Student student)
        {
            if (student.Name != null)
            {
                _repository.Update(student);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Edit");
            }
        }
    }
}
