using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KmeansClustering
{
    public class Point
    {
        public int PointID { get; set; }
        public double Attr1 { get; set; }
        public double Attr2 { get; set; }
        public Cluster Cluster { get; set; }
        public double Silhouette { get; set; }

        public double CalculateDistance(Cluster cluster)
        {
            return Math.Sqrt(
                Math.Pow(cluster.Attr1 - Attr1, 2) +
                Math.Pow(cluster.Attr2 - Attr2, 2)
                );
        }

        public double CalculateDistance(Point point)
        {
            return Math.Sqrt(
                Math.Pow(point.Attr1 - Attr1, 2) +
                Math.Pow(point.Attr2 - Attr2, 2)
                );
        }

        public void SetCluster(List<Cluster> Clusters)
        {
            Clusters.ForEach((cluster) => {
                if (Cluster == null) Cluster = cluster;
                else if (CalculateDistance(cluster) < CalculateDistance(Cluster))
                {
                    Cluster = cluster;
                }
            });
        }

        private double CalculateA(List<Point> Points)
        {
            double sum = 0;
            Points.ForEach((point) => {
                sum += CalculateDistance(point);
            });
            return (double)sum / (double)Points.Count();
        }

        private double CalculateB(List<Point> Points)
        {
            List<double> distanses = new List<double>();
            Points.ForEach((point) => {
                distanses.Add(CalculateDistance(point));
            });
            return distanses.Min();
        }

        public void CalculateSilhouette(List<Point> Points)
        {
            double A = CalculateA(Points.Where(p => p.Cluster.ClusterID == Cluster.ClusterID).ToList());
            double B = CalculateB(Points.Where(p => p.Cluster.ClusterID != Cluster.ClusterID).ToList());

            if (A > B)
            {
                Silhouette = ((double)B / (double)A) - 1;
            }
            else if (A == B)
            {
                Silhouette = 0;
            }
            else if (A < B)
            {
                Silhouette = 1 - ((double)A / (double)B);
            }
        }

    }
}
