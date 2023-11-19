using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FA.Model
{
    public class Student
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Email { get; set; }
        public DateTime DateOfJoin { get; set; }
        [ForeignKey("grade")]
        public int GradeId { get; set; }
        public Grade grade { get; set; }
    }
}
