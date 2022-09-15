using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeManagement.Models
{
    public enum Gender
    {
        male,
        female,
    }
    public class StudentRegistration
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }
        public int StudentRegistrationId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string ContactAddress { get; set; }
        public string MobileNo { get; set; }
        public Gender Gender { get; set; }
        public string LandPhone { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public List<StudentFeed> StudentFeeds { get; set; }

    }
}
