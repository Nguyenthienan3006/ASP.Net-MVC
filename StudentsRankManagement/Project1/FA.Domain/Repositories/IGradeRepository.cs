using FA.Model;

namespace FA.Domain
{
    public interface IGradeRepository
    {
        List<Grade> getAll();
        Grade getGrade(int Id);
        int insert(Grade grade);
        int update(Grade grade);
        int delete(int id);
    }
}
