using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeManagement.Models
{
    public class StudentMarks
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MarksId { get; set; }
        public int SubjectId { get; set; }
        public int StudentId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        [NotMapped]
        public List<StudentMarks>? LstStudentMarks { get; set; }

        public StudentRegistration StudentRegistration { get; set; }
        public StudentSubjects StudentSubjects { get; set; }


    }
}
