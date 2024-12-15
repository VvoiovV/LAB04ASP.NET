using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Entities
{
    public enum Grade
    {
        A, B, C, D, F
    }

    [Table("enrollment")]
    public class EnrollmentEntity
    {
        [Key]
        public int Id { get; set; }

        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }

    }
}
