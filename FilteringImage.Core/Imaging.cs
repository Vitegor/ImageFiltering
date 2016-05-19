using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilteringImage.Core
{
  public static class Imaging
  {
    public static double[,] reverseProjection(Projection[] projections)
    {
      int projectionsCount = projections.Count();
      int pointsCount = projections[0].Data.Count();
      double dQ = projections[1].Angle - projections[0].Angle; //угловой шаг
      double Q = dQ * (-1); //начальное значение угла поворота
      double sin;
      double cos;
      double v;
      double r;

      for (int k = 0; k < projectionsCount; k++)
      {
        Q = Q + dQ;
        sin = Math.Sin(Math.PI / 180 * Q);
        cos = Math.Cos(Math.PI / 180 * Q);

        for(int i = 0; i < pointsCount; i++)
        {
          for(int j = 0; j < pointsCount; j++)
          {
            v = (i - Math.Floor((double)pointsCount / 2)) * cos + (j - Math.Floor((double)pointsCount / 2)) * sin;
            r = Math.Round(v) + Math.Floor((double)pointsCount / 2);
          }
        }
     }

      double[,] result = new double[pointsCount, pointsCount];

      return result;
    }
  }
}