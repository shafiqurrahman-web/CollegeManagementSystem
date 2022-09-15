using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeManagement.Models
{
    public class InstituteAssociates
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AssociateID { get; set; }
        public string AssociateName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int DesignationId { get; set; }
        List<AssociateDesignation>? AssociateDesignations { get; set; }
        public int TypeId { get; set; }
        List<AssociateType>? AssociationsType { get; set; }
    }
}


