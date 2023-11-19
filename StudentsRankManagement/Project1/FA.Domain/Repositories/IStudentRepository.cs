using FA.Model;

namespace FA.Domain
{
    public interface IStudentRepository
    {
        List<Student> getAll();
        Student getStudent(int id);
        int Insert(Student student);
        int Update(Student student);
        int Delete(int id);
    }
}
