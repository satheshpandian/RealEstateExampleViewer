using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateExampleViewer.Models.Views
{
    //[NotMapped]
    public class ViewBuilding:Models.Building 
    {
        [NotMapped]
        public double Occupancy { get; set; }
    }
}
