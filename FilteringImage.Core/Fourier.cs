using System;
using System.Collections.Generic;

namespace FilteringImage.Core
{
  public static class Fourier
  {
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

      FourierResult[] result = new FourierResult[n];

      for(int i = 0; i <= height; i++)
        result[i] = new FourierResult(m);

      double[,] reRow = new double[n, m];
      double[,] imRow = new double[n, m];
      double[,] reCol = new double[n, m];
      double[,] imCol = new double[n, m];

      for(int y = 0; y <= height; y++)
      {
        for(int u = 0; u <= length; u++)
        {
          for(int x = 0; x <= length; x++)
          {
            reRow[y, x] += Re(fxy[y, x], u, x, m);
            imRow[y, x] += Im(fxy[y, x], u, x, m);
            result[y].Re[u] = reRow[y, x];
            result[y].Im[u] = imRow[y, x];
            result[y].Spectrum[u] += Spectrum(result[y].Re[u], result[y].Im[u]);
          }
        }
      }

      #region CODE
      //for(int x = 0; x <= length; x++)
      //{
      //  for(int u = 0; u <= height; u++)
      //  {
      //    for(int y = 0; y <= height; y++)
      //    {
      //      result[y].Re[x] += ReComplex(reRow[y, x], imRow[y, x], y, u, n);
      //      result[y].Im[x] += ImComplex(reRow[y, x], imRow[y, x], y, u, n);
      //      result[y].Spectrum[x] += Spectrum(result[y].Re[x], result[y].Im[x]);
      //    }
      //  }
      //}
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
    public static FourierResult DFT(double[] sourceFx)
    {
      int m = sourceFx.Length;
      int length = m - 1;

      FourierResult result = new FourierResult(m);

      for(int i = 0; i <= length; i++)
      {
        result.Fx[i] = sourceFx[i];
        result.CenteredFx[i] = sourceFx[i];
      }

      for(var u = 0; u <= length; u++)
      {
        for(int x = 0; x <= length; x++)
        {
          result.Re[u] += Re(result.CenteredFx[x], u, x, m);
          result.Im[u] += Im(result.CenteredFx[x], u, x, m);
          result.ReIDFT[u] += ReIDFT(result.Re[u], u, x, m);
          result.ImIDFT[u] += ImIDFT(result.ImIDFT[u], u, x, m);
          result.Spectrum[u] += Spectrum(result.Re[u], result.Im[u]);
        }
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

    private static double ReComplex(double re, double im, int y, int u, int n)
    {
      return ((re * Math.Cos(2 * Math.PI * y * u)) / (n)) + ((im * Math.Sin(2 * Math.PI * y * u)) / (n));
    }

    private static double ImComplex(double re, double im, int y, int u, int n)
    {
      return ((im * Math.Cos(2 * Math.PI * y * u)) / (n)) - ((re * Math.Sin(2 * Math.PI * y * u)) / (n));
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
    private static double ReIDFT(double Re, int u, int x, int m)
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
    private static double ImIDFT(double Im, int u, int x, int m)
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

    /*
      Возведение -1 в степень

      Параметры:
        n - степень
    */
    public static int Step(int n) { return 1 - 2 * (!isEven(n) ? 1 : 0); }

    /*
      Проверка числа на четность.

      Параметры:
        х - число, проверяемое на четность
    */
    private static bool isEven(double x)
    {
      return x % 2 == 0;
    }
  }
}