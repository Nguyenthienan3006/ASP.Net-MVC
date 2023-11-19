using FA.Data;
using FA.Model;

namespace FA.Domain
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolDbContext _db;

        public StudentRepository()
        {
            _db = new SchoolDbContext();
        }
        public int Delete(int Id)
        {
            var student = getStudent(Id);
            if (student != null)
            {
                _db.Students.Remove(student);
                return _db.SaveChanges();
            }
            return 0;
        }

        public List<Student> getAll()
        {
            return _db.Students.ToList();
        }

        public Student getStudent(int StudentId)
        {
            return _db.Students.FirstOrDefault(s => s.Id == StudentId);
        }

        public int Insert(Student student)
        {
            _db.Students.Add(student);
            return _db.SaveChanges();
        }

        public int Update(Student student)
        {
            _db.Students.Update(student);
            return _db.SaveChanges();
        }
    }
}
