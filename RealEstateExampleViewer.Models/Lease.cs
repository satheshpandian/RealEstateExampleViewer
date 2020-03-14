using System;
using System.ComponentModel.DataAnnotations;

namespace RealEstateExampleViewer.Models
{
    public class Lease
    {
        [Required]
        [Key]
        public Int16 LeaseID { get; set; }
        [Required]
        public Int16 BuildingID { get; set; }
        [Required]
        public Int16 SuiteID { get; set; }

        [MaxLength(50)]
        public string TenantName { get; set; }
        
        public DateTime LeaseBegin { get; set; }

        public DateTime LeaseExpiration { get; set; }
      
        public double RentPerMonth { get; set; }
    }
}
