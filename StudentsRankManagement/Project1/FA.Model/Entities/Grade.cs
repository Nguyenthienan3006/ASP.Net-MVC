using System.ComponentModel.DataAnnotations;

namespace FA.Model
{
    public class Grade
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public IList<Student> Students { get; set; }
    }
}
