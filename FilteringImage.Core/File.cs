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
            double angularStep = double.Parse(sr.ReadLine().Replace('.', ','));
            result = new Projection[projectionsCount]; //Инициализируем результат

            for(int i = 0; i < projectionsCount; i++)
            {
              string temp1 = sr.ReadLine(); //Читаем значение угла

              string stringValues = sr.ReadLine().TrimStart(); //Читаем строку значений, удаляем первый пробел
              string[] arrayValues = stringValues.Split(' '); //Получаем массив значений в стоковом формате

              result[i] = new Projection(angularStep * i, pointsConunt);

              for(int j = 0; j < pointsConunt; j++)
              {
                string temp = arrayValues[j];
                result[i].Data[j] = double.Parse(arrayValues[j].Replace('.', ','), NumberStyles.Any);
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