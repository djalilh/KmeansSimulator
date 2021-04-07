using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace KmeansClustering
{
    public class SilouetteViewModel
    {
        #region Public Propreties

       // public List<Point> Points { get; set; }
        public List<PointViewModel> NegativePointsModel { get; set; }
        public List<PointViewModel> PositivePointsModel { get; set; }

        #endregion

        #region Constructors

        public SilouetteViewModel(List<Point> points)
        {
           // Points = points;
            PositivePointsModel = new List<PointViewModel>();
            NegativePointsModel = new List<PointViewModel>();
            if (points != null && points.Count() != 0)
            {
                points.Where(p => p.Silhouette >= 0).ToList().ForEach((point) => { PositivePointsModel.Add( new PointViewModel(point)); });
                points.Where(p => p.Silhouette < 0).ToList().ForEach((point) => { NegativePointsModel.Add( new PointViewModel(point)); });
                PositivePointsModel = PositivePointsModel.OrderByDescending(p => p.Width).ToList();
                NegativePointsModel = NegativePointsModel.OrderBy(p => p.Width).ToList();
            }
        }

        #endregion

        #region Commands


        #endregion

        #region Private Methods


        #endregion

        #region Protected Methods
        protected void RaisePropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Private Propreties

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

    }


    public class PointViewModel
    {
        public Point Point { get; set; }
        public string Name
        {
            get
            {
                return "(" + Point.Attr1 + "," + Point.Attr2 + ") " + Point.Silhouette;
            }
        }
        public double Width
        {
            get
            {
                if (Point.Silhouette > 0) return Point.Silhouette * 500;
                else return Point.Silhouette * 500 * -1;
            }
        }
        public PointViewModel(Point point)
        {
            Point = point;
        }
    }
}
