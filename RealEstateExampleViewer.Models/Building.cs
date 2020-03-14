using System;
using System.ComponentModel.DataAnnotations;

namespace RealEstateExampleViewer.Models
{
    public class Building
    {
        [Key]
        public Int16 BuildingID { get; set; }

        [MaxLength(50)]
        public string Address { get; set; }

        [MaxLength(50)]
        public string City { get; set; }

        [MaxLength(2)]
        public string  State { get; set; }

        [MaxLength(10)]
        public string ZipOrPostalCode { get; set; }

        public int BuildingArea { get; set; }
    }
}
