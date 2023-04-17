using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revision.EF
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Key]
        public int NationalID { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public virtual HashSet<StudentCourses> Courses { get; set; }
        public Student()
        {
            Courses = new HashSet<StudentCourses>();
        }
    }
}
