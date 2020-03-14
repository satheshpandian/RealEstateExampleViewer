using System.Windows;
using System.Windows.Data;
using RealEstateExampleViewer.Models.Views;
using RealEstateExampleViewer.Repository;
using StructureMap;

namespace RealEstateExampleViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IRealEstateRepository realEstateRepository;
        public MainWindow()
        {
            InitializeComponent();
            var container = new Container(_ =>
            {
                _.Scan(x =>
                {
                    x.TheCallingAssembly();
                    x.WithDefaultConventions();
                });
                _.For<IRealEstateRepository>().Use<RealEstateRepository>();
            });

            realEstateRepository= container.GetInstance<IRealEstateRepository>();


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BuildingsGrid.DataContext = realEstateRepository.GetAllBuildings();
        }

        private void BuildingsGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (e.AddedItems[0].GetType() == typeof(ViewBuilding))
            {
                ViewBuilding building = (ViewBuilding) e.AddedItems[0];
                var leases = realEstateRepository.GetAllSuites(building.BuildingID);
                ListCollectionView collectionView = new ListCollectionView(leases);
                collectionView.GroupDescriptions.Add(new PropertyGroupDescription("SuiteName"));
                SuitesGrid.ItemsSource = collectionView;
            }
            else
            {
                SuitesGrid.Items.Clear();
            }
            
        }
    }
}
