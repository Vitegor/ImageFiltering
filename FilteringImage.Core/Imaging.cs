using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilteringImage.Core
{
  public static class Imaging
  {
    public static double[,] reverseProjection(Projections projections)
    {
      int pointsCount = projections.PointsCount;
      int projectionsCount = projections.ProjectionsCount;

      double[,] xy = new double[pointsCount, pointsCount]; //Массив для хранения сечения
      double[] p = new double[pointsCount * projectionsCount]; //Массив для хранения проекций

      for(int j = 0; j < projectionsCount; j++)
      {
        for(int i = 0;i < pointsCount; i++)
        {
          // Заполняем массив проекций из данных файла
          p[i + j * pointsCount] = projections.Data[i + j * pointsCount];
        }
      }

      double dQ = projections.AngularStep; //угловой шаг
      double Q = dQ * (-1); //начальное значение угла поворота
      double sinGL, cosGL, v, r;

      for (int k = 0; k < projectionsCount; k++)
      {
        Q = Q + dQ;
        sinGL = Math.Sin(Math.PI / 180 * Q);
        cosGL = Math.Cos(Math.PI / 180 * Q);

        for(int i = 0; i < pointsCount; i++)
        {
          for(int j = 0; j < pointsCount; j++)
          {
            v = (i - Math.Floor((double)pointsCount / 2)) * cosGL + (j - Math.Floor((double)pointsCount / 2)) * sinGL;
            r = Math.Round(v) + Math.Floor((double)pointsCount / 2);

            if (r < pointsCount && r > -1)
            {
              xy[i, j] += p[(int)r+k*pointsCount];
            }
          }
        }
     }


      return xy;
    }
  }
}