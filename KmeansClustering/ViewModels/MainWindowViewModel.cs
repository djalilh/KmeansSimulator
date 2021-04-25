using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using KmeansClustering.Views;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using static KmeansClustering.Models.Enums;

namespace KmeansClustering
{
    public class MainWindowViewModel: INotifyPropertyChanged
    {
        #region Public Propreties
        public SeriesCollection SeriesCollection { get; set; }
        public string Classification { get; set; } = "Kmeans";

        private int _nbPoints;
        public int NbPoints
        {
            get { return _nbPoints; }
            set { _nbPoints = value; RaisePropertyChanged(nameof(NbPoints)); }
        }

        private int _nbCluster;
        public int NbClusters
        {
            get { return _nbCluster; }
            set { _nbCluster = value; RaisePropertyChanged(nameof(NbClusters)); }
        }


        private string _selectedAlgorithm;
        public string SelectedAlgorithm
        {
            get { return _selectedAlgorithm; }
            set { _selectedAlgorithm = value; RaisePropertyChanged(nameof(SelectedAlgorithm)); }
        }

        private long _executionTime;

        public long ExecutionTime
        {
            get { return _executionTime; }
            set { _executionTime = value; RaisePropertyChanged(nameof(ExecutionTime)); }
        }

        private double _silhouettePercentage = 0 ;
        public double SilhouettePercentage
        {
            get { return _silhouettePercentage; }
            set { _silhouettePercentage = value; RaisePropertyChanged(nameof(SilhouettePercentage)); }
        }

        public DistanceAlgorithm  DistanceAlgorithm { get; set; }

        #endregion

        #region Constructors

        public MainWindowViewModel()
        {
            SeriesCollection = new SeriesCollection();

            SeriesCollection.Add(
                new ScatterSeries()
                {
                    Values = new ChartValues<ScatterPoint>(),
                    MinPointShapeDiameter = MinPointSize,
                    MaxPointShapeDiameter = MaxPointSize,
                    FontSize = 20
                }
            );
            SeriesCollection.Add(
                new ScatterSeries()
                {
                    Values = new ChartValues<ScatterPoint>(),
                    MinPointShapeDiameter = MinPointSize,
                    MaxPointShapeDiameter = MaxPointSize
                }
            );
            SeriesCollection.Add(
                new ScatterSeries()
                {
                    Values = new ChartValues<ScatterPoint>(),
                    MinPointShapeDiameter = MinPointSize,
                    MaxPointShapeDiameter = MaxPointSize
                }
            );
            SeriesCollection.Add(
                new ScatterSeries()
                {
                    Values = new ChartValues<ScatterPoint>(),
                    MinPointShapeDiameter = MinPointSize,
                    MaxPointShapeDiameter = MaxPointSize
                }
            );
            SeriesCollection.Add(
                new ScatterSeries()
                {
                    Values = new ChartValues<ScatterPoint>(),
                    MinPointShapeDiameter = MinPointSize,
                    MaxPointShapeDiameter = MaxPointSize
                }
            );
            SeriesCollection.Add(
                new ScatterSeries()
                {
                    Values = new ChartValues<ScatterPoint>(),
                    MinPointShapeDiameter = MinPointSize,
                    MaxPointShapeDiameter = MaxPointSize
                }
            );
            SeriesCollection.Add(
                new ScatterSeries()
                {
                    Values = new ChartValues<ScatterPoint>(),
                    MinPointShapeDiameter = MinPointSize,
                    MaxPointShapeDiameter = MaxPointSize
                }
            );
            SeriesCollection.Add(
                new ScatterSeries()
                {
                    Values = new ChartValues<ScatterPoint>(),
                    MinPointShapeDiameter = MinPointSize,
                    MaxPointShapeDiameter = MaxPointSize
                }
            );
            SeriesCollection.Add(
                new ScatterSeries()
                {
                    Values = new ChartValues<ScatterPoint>(),
                    MinPointShapeDiameter = MinPointSize,
                    MaxPointShapeDiameter = MaxPointSize
                }
            );
            SeriesCollection.Add(
                new ScatterSeries()
                {
                    Values = new ChartValues<ScatterPoint>(),
                    MinPointShapeDiameter = MinPointSize,
                    MaxPointShapeDiameter = MaxPointSize
                }
            );

        }

        #endregion

        #region Commands

        public ICommand NewCommand
        {
            get
            {
                if(_newCommand == null)
                {
                    _newCommand = new RelayCommand(() => NewCommand_Executed());
                }
                return _newCommand;
            }
        }

        public ICommand SilouetteCommand
        {
            get
            {
                if (_silouetteCommand == null)
                {
                    _silouetteCommand = new RelayCommand(() => SilouetteCommand_Executed());
                }
                return _silouetteCommand;
            }
        }

        #endregion

        #region Private Methods

        private void NewCommand_Executed()
        {
            _newSimulationView = new NewSimulationView();
            var vm = new NewSimulationViewModel();
            vm.OnStartSimulation += (int clusters, int points, DistanceAlgorithm algo) =>
            {
                _newSimulationView.Close();
                _newSimulationView = null;
                NbPoints = points;
                NbClusters = clusters;
                DistanceAlgorithm = algo;
                if (algo == DistanceAlgorithm.Equlidient) SelectedAlgorithm = "Equlidient";
                if (algo == DistanceAlgorithm.Manhattan) SelectedAlgorithm = "Manhattan";
                Kmeans(clusters, points, algo);
            };
            _newSimulationView.DataContext = vm;
            _newSimulationView.Show();
        }

        private void Kmeans(int clusters, int points, DistanceAlgorithm algorithm)
        {
            Task.Run(async () => {
                
                var watch = System.Diagnostics.Stopwatch.StartNew();
                InitPoints(points);
                InitChartPoints();
                await Task.Delay(TimeSpan.FromSeconds(1));
                InitClusters(clusters);
                SetClusterForEachPoint();
                InitClusterPoints();
                watch.Stop();
                ExecutionTime = watch.ElapsedMilliseconds;
            });
        }

        private void InitPoints(int points)
        {
            Points = new List<Point>();
            
            Random random = new Random();
                
            for (int i = 0 ; i < points; i++)
            {
                Points.Add(new Point() {PointID = i, AttrX = random.Next(1, 100), AttrY = random.Next(1, 100) });
            }
            
        }

        private void InitChartPoints()
        {
            var values = new ChartValues<ScatterPoint>();
            SeriesCollection.ToList().ForEach((serie) => { serie.Values.Clear(); });
            Points.ForEach((point) => {
                values.Add(new ScatterPoint(point.AttrX, point.AttrY, 1));
                SeriesCollection.FirstOrDefault().Values.Add(new ScatterPoint(point.AttrX, point.AttrY));
            });

        }

        private void InitClusters(int NbClusters)
        {
            Random random = new Random();
            Clusters = new List<Cluster>();
            int id = 0;
            for (int i = 0; i < NbClusters; i++)
            {
                int start = Points.FirstOrDefault().PointID;
                int length = start + Points.Count();
                int pointid = random.Next(start, length);
                Point point = Points.FirstOrDefault(p => p.PointID == pointid);
                Clusters.Add(new Cluster()
                {
                    ClusterID = id,
                    AttrX = point.AttrX,
                    AttrY = point.AttrY
                });
                id++;
            }
        }

        private void SetClusterForEachPoint()
        {
            Points.ForEach((point) => {
                point.SetCluster(Clusters, DistanceAlgorithm);
            });

            UpdateChartPoints();
            RepositionClusters();
        }

        private void UpdateChartPoints()
        {
            for (int i = 0; i < Clusters.Count(); i++)
            {
                SeriesCollection.ElementAt(i).Values.Clear();
                var values = new ChartValues<ScatterPoint>();
                Points.Where(p => p.Cluster.ClusterID == i).ToList().ForEach((point) => {
                    values.Add(new ScatterPoint(point.AttrX, point.AttrY, 1));
                });
                SeriesCollection.ElementAt(i).Values.AddRange(values);
            }
        }

        private void RepositionClusters()
        {
            List<bool> States = new List<bool>();
            Clusters.ForEach((cluster) => {
                States.Add(
                    cluster.Reposition(Points.Where(p => p.Cluster.ClusterID == cluster.ClusterID).ToList())
                    );
                
            });
            if (States.Where(s => s == true).Count() != 0)
            {
                SetClusterForEachPoint();
            }
        }

        private void InitClusterPoints()
        {
           

            Clusters.ForEach((cluster) => {
                cluster.Points = Points.Where(p => p.Cluster.ClusterID == cluster.ClusterID).ToList();
                SeriesCollection.ElementAt(cluster.ClusterID).Values.AddRange(new List<ScatterPoint>() { new ScatterPoint(cluster.AttrX, cluster.AttrY, clusterWeight)});
            });

            Clusters.ForEach((cluster) =>
            {
                cluster.NbPoints = cluster.Points.Count();
                cluster.Points.ForEach((point) =>
                {
                    point.CalculateSilhouette(Points, DistanceAlgorithm);
                });
            });
            
            Clusters.ForEach((cluster) =>
            {
                cluster.CalculateSilhouettePercentage();
                SilhouettePercentage = (SilhouettePercentage + cluster.SilhouettePercentage) / 2;
            });
            
        }

        private void SilouetteCommand_Executed()
        {
            _silouetteView = new SilouetteView();
            var vm = new SilouetteViewModel(Points);
            _silouetteView.DataContext = vm;
            _silouetteView.Show();
        }

        #endregion

        #region Protected Methods
        protected void RaisePropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Private Propreties

        private ICommand _newCommand, _silouetteCommand;
        private NewSimulationView _newSimulationView;
        private SilouetteView _silouetteView;
        private List<Point> Points;
        private List<Cluster> Clusters;
        private int MinPointSize = 10;
        private int MaxPointSize = 20;
        private int clusterWeight = 10;
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

    }
}
