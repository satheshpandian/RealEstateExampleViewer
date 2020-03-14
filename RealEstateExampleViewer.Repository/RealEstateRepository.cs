using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RealEstateExampleViewer.Models;
using RealEstateExampleViewer.Models.Views;

namespace RealEstateExampleViewer.Repository
{
    public class RealEstateRepository : IRealEstateRepository
    {
        readonly DataContext _context;
        private readonly IMapper mapper;
        public RealEstateRepository(DataContext context)
        {
            _context = context;
        }
        public List<ViewBuilding> GetAllBuildings()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Building, ViewBuilding>();
            });
            IMapper mapper = config.CreateMapper();

                var buildings= _context.Buildings.AsQueryable();
               return CalculateOccupancy(mapper.ProjectTo<ViewBuilding>(buildings).ToList());
        }

        public List<ViewBuilding> CalculateOccupancy(List<ViewBuilding> buildings)
        {
            var leases = GetAllLeases();
            var suites = GetAllSuites();
            foreach (var building in buildings)
            {
                double totalOccupiedArea =suites.Where(x =>
                        leases.Any(y => y.BuildingID == building.BuildingID && x.BuildingID == y.BuildingID))
                    .Sum(z => z.SuiteArea);
                totalOccupiedArea = Math.Abs(totalOccupiedArea) <= 0 ? 1 : totalOccupiedArea;
               building.Occupancy= building.BuildingArea/ totalOccupiedArea;
            }
            return buildings;
        }

        public List<Lease> GetAllLeases()
        {
            return _context.Leases.ToList();
        }

        public List<Suite> GetAllSuites()
        {
            return _context.Suites.ToList();
        }

        public List<ViewSuite> GetAllSuites(int buildingId)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Suite, ViewSuite>();
            });

            IMapper mapper = config.CreateMapper();
            var suites= _context.Suites.Where(x=>x.BuildingID==buildingId).ToList();
           var viewSuites= mapper.ProjectTo<ViewSuite>(suites.AsQueryable()).ToList();
            foreach (var suite in viewSuites)
            {
                suite.Leases = GetAllLeases().Where(x => x.BuildingID == suite.BuildingID && x.SuiteID ==suite.SuiteID).ToList();
            }
               
            return viewSuites;
        }
    }
}
