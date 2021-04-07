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
        public double Attr1 { get; set; }
        public double Attr2 { get; set; }
        public List<Point> Points { get; set; }
        public int NbPoints { get; set; }
        public double SilhouettePercentage { get; set; }


        public bool Reposition(List<Point> Points)
        {
            if (Points.Count() == 0) return false;
            double A1 = Attr1; double A2 = Attr2;

            Attr1 = Points.Select(p => p.Attr1).Sum() / Points.Count();
            Attr2 = Points.Select(p => p.Attr2).Sum() / Points.Count();


            if (A1 == Attr1 &&
                A2 == Attr2)
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
