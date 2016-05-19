using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace FilteringImage.Core
{
  public static class File
  {
    public static Projections GetProjections()
    {
      const string PATH_TO_FILE = @"C:\data.txt";
      const string START_OF_DATA = "data";
      Projections result = new Projections();

      try
      {
        using(StreamReader sr = new StreamReader(PATH_TO_FILE))
        {
          if (sr.ReadLine() == START_OF_DATA)
          {
            
            int pointsCount = Convert.ToInt32(sr.ReadLine());
            int projectionsCount = Convert.ToInt32(sr.ReadLine());
            double angularStep = double.Parse(sr.ReadLine().Replace('.', ','));
            result = new Projections(pointsCount, projectionsCount, angularStep, pointsCount * projectionsCount);

            for(int i = 0; i < projectionsCount; i++)
            {
              sr.ReadLine(); //Пропускаем значение угла
              string stringValues = sr.ReadLine().TrimStart(); //Читаем строку значений, удаляем первый пробел
              string[] arrayValues = stringValues.Split(' '); //Получаем массив значений в стоковом формате

              for(int j = 0; j < pointsCount; j++)
              {
                result.Data[j+i* pointsCount] = double.Parse(arrayValues[j].Replace('.', ','), NumberStyles.Any);
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