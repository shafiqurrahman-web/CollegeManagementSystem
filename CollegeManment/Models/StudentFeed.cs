using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeManagement.Models
{
    public class StudentFeed
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FeedId { get; set; }
        
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public int StudentId { get; set; }
        public StudentRegistration StudentRegistration { get; set; }    
    }
}
