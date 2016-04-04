using System;
using System.Collections.Generic;
using System.Drawing;

namespace FilteringImage.Core
{
  public static class Fourier
  {
    public static Bitmap GetImageSpectrum(Bitmap bitmap)
    {
      bitmap = Helpers.GetImageInColorScale(new Bitmap(bitmap));
      double[,] fxy = Helpers.GetBitmapFunction(bitmap);
      fxy = Helpers.CenteringFunction(fxy);
      FourierResult[] fourierResult = DFT2D(fxy);

      int x, y = 0;
      byte gray;
      foreach(var row in fourierResult)
      {
        x = 0;
        foreach(var item in row.Spectrum)
        {
          bitmap.SetPixel(x, y, Color.FromArgb((byte)Math.Log10(item), 0, 0));
          x++;
        }
        y++;
      }

      return bitmap;
    }

    /*
      Двумерное дискретное преобразование Фурье

      Параметры:
        srcFxy - исходный массив значений функции
        m - количество отсчетов входной последовательности и
            количество частотных отсчетов результата преобразования Фурье
        n - количество отсчетов входной последовательности и
            количество частотных отсчетов результата преобразования Фурье
    */
    public static FourierResult[] DFT2D(double[,] fxy)
    {
      int m = fxy.GetLength(1); //Количество столбцов
      int n = fxy.GetLength(0); //Количество строк
      int length = m - 1;
      int height = n - 1;

      #region Преобразование Фурье по строкам

      FourierResult[] rowResult = new FourierResult[n];
      double[] fx = new double[m];

      for(int y = 0; y <= height; y++)
      {
        for(int x = 0; x <= length; x++)
        {
          fx[x] = fxy[y, x]; //Набираем значения функции по строкам
        }
        rowResult[y] = DFT(fx);
      }

      #endregion

      #region Преобразование Фурье по столбцам

      FourierResult[] colResult = new FourierResult[m];
      double[] re = new double[n];
      double[] im = new double[n];

      for(int x = 0; x <= length; x++)
      {
        //Набираем значения действительной и мнимой частей по столбцам
        for(int y = 0; y <= height; y++)
        {
          re[y] = rowResult[y].Re[x];
          im[y] = rowResult[y].Im[x];
        }
        colResult[x] = ComplexDFT(re, im); //Получаем отраженную матрицу значений
      }

      #endregion

      #region Обратное отражение результата преобразования Фурье по столбцам

      for(int x = 0; x <= length; x++)
      {
        for(int y = 0; y <= height; y++)
        {
          /* Значение помещаем в массив результатов по строкам т.к. как он соответствует
          размерам исходной функции */
          rowResult[y].Re[x] = colResult[x].Re[y];
          rowResult[y].Im[x] = colResult[x].Im[y];
          rowResult[y].Spectrum[x] = colResult[x].Spectrum[y];

        }
      }

      #endregion

      return rowResult;
    }

    public static double[,] IDFT2D(FourierResult[] fourierResult)
    {
      int m = fourierResult[0].Re.Length; //Количество столбцов
      int n = fourierResult.Length; //Количество строк
      int length = m - 1;
      int height = n - 1;

      #region Обратное преобразование Фурье по строкам

      InverseFourierResult[] rowResult = new InverseFourierResult[n];
      double[] re = new double[m];
      double[] im = new double[m];

      for(int y = 0; y <= height; y++)
      {
        //Набираем значения по строкам
        for(int x = 0; x <= length; x++)
        {
          re[x] = fourierResult[y].Re[x];
          im[x] = fourierResult[y].Im[x];
        }
        rowResult[y] = IDFT(re, im);
      }

      #endregion

      #region Обратное преобразование Фурье по столбцам

      InverseFourierResult[] colResult = new InverseFourierResult[m];
      re = new double[n];
      im = new double[n];

      for(int x = 0; x <= length; x++)
      {
        //Набираем значения действительной и мнимой частей по столбцам
        for(int y = 0; y <= height; y++)
        {
          re[y] = rowResult[y].Re[x];
          im[y] = rowResult[y].Im[x];
        }
        colResult[x] = IDFT(re, im); //Получаем отраженную матрицу значений
      }

      #endregion

      #region Обратное отражение результата преобразования Фурье по столбцам

      double[,] result = new double[n, m];

      for(int x = 0; x <= length; x++)
      {
        for(int y = 0; y <= height; y++)
        {
          /*
            Помещаем значения действительной части 
            обратного пребобразования Фурье в реузльтирующий массив
          */
          result[y, x] = colResult[x].Re[y];
        }
      }

      #endregion

      return result;
    }

    /*
Одномерное дискретное преобразование Фурье

Параметры:
sourceFx - исходный массив значений функции
m - количество отсчетов входной последовательности и
    количество частотных отсчетов результата преобразования Фурье
*/
    public static FourierResult DFT(double[] fx)
    {
      int m = fx.Length;
      int length = m - 1;

      FourierResult result = new FourierResult(m);

      for(var u = 0; u <= length; u++)
      {
        for(int x = 0; x <= length; x++)
        {
          result.Re[u] += Re(fx[x], u, x, m);
          result.Im[u] += Im(fx[x], u, x, m);
        }
        result.Spectrum[u] = Spectrum(result.Re[u], result.Im[u]);
      }

      return result;
    }

    private static InverseFourierResult IDFT(double[] re, double[] im)
    {
      int m = re.Length;
      int length = m - 1;
      InverseFourierResult result = new InverseFourierResult(m);

      for(int u = 0; u <= length; u++)
      {
        for(int x = 0; x <= length; x++)
        {
          result.Re[u] += InverseRe(re[x], u, x, m);
          result.Im[u] += InverseIm(im[x], u, x, m);
        }
      }

      return result;
    }

    private static FourierResult ComplexDFT(double[] re, double[] im)
    {
      int m = re.Length;
      int length = m - 1;
      FourierResult result = new FourierResult(m);

      for(int u = 0; u <= length; u++)
      {
        for(int x = 0; x <= length; x++)
        {
          result.Re[u] += ComplexRe(re[x], im[x], u, x, m);
          result.Im[u] += ComplexIm(re[x], im[x], u, x, m);
        }
        result.Spectrum[u] = Spectrum(result.Re[u], result.Im[u]);
      }

      return result;
    }

    /*
      Вычисление значения действительной части прямного дискретного преобразования Фурье.
      
      Параметры:
        fx - значение функции
        u - индекс частотной области
        x - временной индекс входных отсчетов
        m - количество отсчетов входной последовательности и
            количество частотных отсчетов результата преобразования Фурье
    */
    private static double Re(double fx, int u, int x, int m)
    {
      return fx * Math.Cos((2 * Math.PI * u * x) / m);
    }

    /*
      Вычисление значения мнимой части прямного дискретного преобразования Фурье.

      Параметры:
        fx - значение функции
        u - индекс частотной области
        x - временной индекс входных отсчетов
        m - количество отсчетов входной последовательности и
            количество частотных отсчетов результата преобразования Фурье

    */
    private static double Im(double fx, int u, int x, int m)
    {
      return fx * Math.Sin((2 * Math.PI * u * x) / m);
    }

    private static double ComplexRe(double re, double im, int u, int x, int m)
    {
      return
        re * Math.Cos((2 * Math.PI * x * u) / m) +
        im * Math.Sin((2 * Math.PI * x * u) / m);
    }

    private static double ComplexIm(double re, double im, int u, int x, int m)
    {
      return
        im * Math.Cos((2 * Math.PI * x * u) / m) -
        re * Math.Sin((2 * Math.PI * x * u) / m);
    }

    /*
      Вычисление значения действительной части обратного дискретного преобразования Фурье.

      Параметры:
        Re - значение действительной части прямонго преобразования Фурьре
        u - индекс частотной области
        x - временной индекс входных отсчетов
        m - количество отсчетов входной последовательности и
            количество частотных отсчетов результата преобразования Фурье
    */
    private static double InverseRe(double Re, int u, int x, int m)
    {
      return Re * Math.Cos((2 * Math.PI * u * x) / m);
    }

    /*
      Вычисление значения мнимой части обратного дискретного преобразования Фурье.

      Параметры:
        Im - значение мнимой части прямонго преобразования Фурьре
        u - индекс частотной области
        x - временной индекс входных отсчетов
        m - количество отсчетов входной последовательности и
            количество частотных отсчетов результата преобразования Фурье
    */
    private static double InverseIm(double Im, int u, int x, int m)
    {
      return Im * Math.Sin((2 * Math.PI * u * x) / m);
    }

    /*
      Вычисление значения спектра преобразования Фурье.

      Параметры:
        Re - значение действительной части прямого дискретного преобразования Фурьре
        Im - значение мнимой части прямого дискретного преобразования Фурьре
    */
    private static double Spectrum(double Re, double Im)
    {
      return Math.Sqrt(Math.Pow(Re, 2) + Math.Pow(Im, 2));
    }

    /*
      Вычисление значения спектра мощности (энергетического спектра).

      Параметры:
        spectrum - значение спектра преобразования Фурье
    */
    private static double PowerSpectrum(double spectrum)
    {
      return spectrum * spectrum;
    }
  }
}