using System.Collections.Generic;
using RealEstateExampleViewer.Models;
using RealEstateExampleViewer.Models.Views;

namespace RealEstateExampleViewer.Repository
{
    public interface IRealEstateRepository
    {
        List<ViewBuilding> GetAllBuildings();

        List<Lease> GetAllLeases();

        List<ViewSuite> GetAllSuites(int BuildingID);

        List<Suite> GetAllSuites();
    }
}