using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeManagement.Models
{
    public class AssociateDesignation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]        
        public int DesignationId { get; set; }
        public string DesignationName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
