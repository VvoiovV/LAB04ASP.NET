using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Entities
{
    public class CourseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public int InstructorId { get; set; }

        public ICollection<EnrollmentEntity> Enrollments { get; set; }

        [ForeignKey("Instructor")]
        
        public InstructorEntity Instructor { get; set; }

    }
}
