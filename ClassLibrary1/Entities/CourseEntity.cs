using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary1.Entities
{
    [Table("Courses")] 
    public class CourseEntity
    {
        [Key] 
        public int Id { get; set; }

        [Required]
        [MaxLength(100)] 
        public string Title { get; set; }

        [Required]
        public int Credits { get; set; }

        [Required]
        public int InstructorId { get; set; }

        
        public InstructorEntity Instructor { get; set; }


        public ICollection<EnrollmentEntity> Enrollments { get; set; } = new List<EnrollmentEntity>();

        public CourseEntity()
        {
            Enrollments = new HashSet<EnrollmentEntity>();
        }

    }
}
