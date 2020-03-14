using System;
using System.ComponentModel.DataAnnotations;

namespace RealEstateExampleViewer.Models
{
    public class Suite
    {
        [Required]
        [Key]
        public Int16 SuiteID { get; set; }
        [Required]
        public Int16 BuildingID { get; set; }
       

        [MaxLength(50)]
        public string SuiteName { get; set; }
      
        public int SuiteArea { get; set; }
    }
}
