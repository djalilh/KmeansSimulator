using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KmeansClustering.Models.Enums;

namespace KmeansClustering
{
    public class Point
    {
        public int PointID { get; set; }
        public double AttrX { get; set; }
        public double AttrY { get; set; }
        public Cluster Cluster { get; set; }
        public double Silhouette { get; set; }

        public double CalculateDistance(Cluster cluster, DistanceAlgorithm distanceAlgorithm)
        {
            if (distanceAlgorithm == DistanceAlgorithm.Equlidient) return DistanceEqulidient(cluster);
            else if (distanceAlgorithm == DistanceAlgorithm.Manhattan) return DistanceManhattan(cluster);
            return 0;
        }

        private double DistanceEqulidient(Cluster cluster)
        {
            return Math.Sqrt(
                Math.Pow(cluster.AttrX - AttrX, 2) +
                Math.Pow(cluster.AttrY - AttrY, 2)
                );
        }

        private double DistanceManhattan(Cluster cluster)
        {
            return Math.Abs(cluster.AttrX - AttrX) + Math.Abs(cluster.AttrY - AttrY) ;
        }

        public double CalculateDistance(Point point, DistanceAlgorithm distanceAlgorithm)
        {
            if (distanceAlgorithm == DistanceAlgorithm.Equlidient) return DistanceEqulidient(point);
            if (distanceAlgorithm == DistanceAlgorithm.Manhattan) return DistanceManhattan(point);
            return 0;
        }

        private double DistanceEqulidient(Point point)
        {
            return Math.Sqrt(
                Math.Pow(point.AttrX - AttrX, 2) +
                Math.Pow(point.AttrY - AttrY, 2)
                );
        }

        private double DistanceManhattan(Point point)
        {
            return Math.Sqrt(
                Math.Pow(point.AttrX - AttrX, 2) +
                Math.Pow(point.AttrY - AttrY, 2)
                );
        }

        public void SetCluster(List<Cluster> Clusters, DistanceAlgorithm distanceAlgorithm)
        {
            Clusters.ForEach((cluster) => {
                if (Cluster == null) Cluster = cluster;
                else if (CalculateDistance(cluster, distanceAlgorithm) < CalculateDistance(Cluster, distanceAlgorithm))
                {
                    Cluster = cluster;
                }
            });
        }

        private double CalculateA(List<Point> Points, DistanceAlgorithm distanceAlgorithm)
        {
            double sum = 0;
            Points.ForEach((point) => {
                sum += CalculateDistance(point, distanceAlgorithm);
            });
            return (double)sum / (double)Points.Count();
        }

        private double CalculateB(List<Point> Points, DistanceAlgorithm distanceAlgorithm)
        {
            List<double> distanses = new List<double>();
            Points.ForEach((point) => {
                distanses.Add(CalculateDistance(point, distanceAlgorithm));
            });
            return distanses.Min();
        }

        public void CalculateSilhouette(List<Point> Points, DistanceAlgorithm distanceAlgorithm)
        {
            double A = CalculateA(Points.Where(p => p.Cluster.ClusterID == Cluster.ClusterID).ToList(), distanceAlgorithm);
            double B = CalculateB(Points.Where(p => p.Cluster.ClusterID != Cluster.ClusterID).ToList(), distanceAlgorithm);

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
