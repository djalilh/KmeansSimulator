using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KmeansClustering
{
    public class Cluster
    {
        public int ClusterID { get; set; }
        public double AttrX { get; set; }
        public double AttrY { get; set; }
        public List<Point> Points { get; set; }
        public int NbPoints { get; set; }
        public double SilhouettePercentage { get; set; }


        public bool Reposition(List<Point> Points)
        {
            if (Points.Count() == 0) return false;
            double A1 = AttrX; double A2 = AttrY;

            AttrX = Points.Select(p => p.AttrX).Sum() / Points.Count();
            AttrY = Points.Select(p => p.AttrY).Sum() / Points.Count();


            if (A1 == AttrX &&
                A2 == AttrY)
            {
                return false;
            }

            return true;
        }

        public void CalculateSilhouettePercentage()
        {
            int count = 0;
            Points.ForEach((point) => {
                if (point.Silhouette >= 0)
                {
                    count++;
                }
            });

            SilhouettePercentage = (count * 100) / Points.Count();
        }
    }
}
