using MessagePack;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeManagement.Models
{
    public class StudentAttendance
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttendanceId { get; set; }
        public int StudentId { get; set; }
        public DateTime AttendanceDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public StudentRegistration StudentRegistration { get; set; }
    }
}
