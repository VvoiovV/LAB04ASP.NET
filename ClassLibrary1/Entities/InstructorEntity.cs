using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Entities
{
    [Table("instructor")] 
    public class InstructorEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)] 
        [Required] 
        public string Name { get; set; }

        [MaxLength(50)] 
        [Required] 
        public string AcademicTitle { get; set; }

        public ICollection<CourseEntity> Courses { get; set; }

    }
}
