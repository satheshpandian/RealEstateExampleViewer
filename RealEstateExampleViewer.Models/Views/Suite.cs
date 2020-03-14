using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateExampleViewer.Models.Views
{
    public class ViewSuite
    {
        public Int16 BuildingID { get; set; }

        public Int16 SuiteID { get; set; }

        public string SuiteName { get; set; }
      
        public int SuiteArea { get; set; }

        [NotMapped]
        public List<Lease> Leases { get; set; }
    }
}
