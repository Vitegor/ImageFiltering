using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FilteringImage.Core
{
  public static class File
  {
    public static Projection[] GetProjections()
    {
      const string PATH_TO_FILE = @"C:\data.txt";
      const string START_OF_DATA = "data";
      Projection[] result = new Projection[1];

      try
      {
        using(StreamReader sr = new StreamReader(PATH_TO_FILE))
        {
          if (sr.ReadLine() == START_OF_DATA)
          {
            int pointsConunt = Convert.ToInt32(sr.ReadLine());
            int projectionsCount = Convert.ToInt32(sr.ReadLine());
            int angularStep = Convert.ToInt32(sr.ReadLine());
            result = new Projection[projectionsCount]; //Инициализируем результат

            for(int i = 0; i < projectionsCount; i++)
            {
              sr.ReadLine(); //Читаем значение угла
              string stringValues = sr.ReadLine(); //Читаем строку значений
              string[] arrayValues = stringValues.Split(' '); //Получаем массив значений в стоковом формате

              result[i].Angle = i;
              result[i] = new Projection(angularStep * i, pointsConunt);

              for(int j = 0; j < pointsConunt; j++)
              {
                result[i].Data[j] = double.Parse(arrayValues[j]);
              }
            }
          }
        }
      }
      catch(Exception e)
      {
        throw e;
      }

      return result;
    }
  }
}