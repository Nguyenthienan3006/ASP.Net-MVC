using FA.Data;
using FA.Model;

namespace FA.Domain
{   
    public class GradeRepository : IGradeRepository
    {
        private readonly SchoolDbContext _db;

        public GradeRepository()
        {
            _db = new SchoolDbContext();
        }
        public int delete(int id)
        {
            var grade = getGrade(id);
            if(grade != null)
            {
                _db.Grades.Remove(grade);
                return _db.SaveChanges();
            }
            return 0;
        }

        public List<Grade> getAll()
        {
            return _db.Grades.ToList();
        }

        public Grade getGrade(int GradeId)
        {
            return _db.Grades.FirstOrDefault(g => g.Id == GradeId);
        }

        public int insert(Grade grade)
        {
            _db.Grades.Add(grade);
            return _db.SaveChanges();
        }

        public int update(Grade grade)
        {
            _db.Grades.Update(grade);
            return _db.SaveChanges();
        }
    }
}
