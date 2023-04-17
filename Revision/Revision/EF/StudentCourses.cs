using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revision.EF
{
    public class StudentCourses
    {
        public int StudentId { get; set; }
        public int StudentNationalId { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
        public StudentCourses()
        {
            Student = new Student();
            Course =  new Course();
        }
    }
}
