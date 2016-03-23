using System;
using System.Collections.Generic;

namespace FilteringImage.Core
{
  public static class Fourier
  {
    private const int defaultM = 100;
    private const int defaultN = 100;

    /*
      Двумерное дискретное преобразование Фурье

      Параметры:
        srcFxy - исходный массив значений функции
        m - количество отсчетов входной последовательности и
            количество частотных отсчетов результата преобразования Фурье
        n - количество отсчетов входной последовательности и
            количество частотных отсчетов результата преобразования Фурье
    */
    public static FourierResult[] DFT2D(double[][] srcFxy)
    {
      int m = srcFxy[0].Length;
      int n = srcFxy.Length;
      int lenght = m - 1;
      int height = n - 1;
      double[] fx = new double[m];
      double[] fxReIm = new double[n];

      List<double[]> fxy = new List<double[]>();
      FourierResult[] dft = new FourierResult[n];
      FourierResult[] result = new FourierResult[m];

      for(int y = 0; y <= height; y++)
      {
        for(int x = 0; x <= lenght; x++)
        {
          fx[x] = srcFxy[y][x];
        }
        fxy.Add(fx);
      }

      int counter = 0;
      foreach(var item in fxy)
      {
        dft[counter] = DFT(item);
        counter++;
      }

      for(int i = 0; i <= lenght; i++) result[i] = new FourierResult(n);

      for(int x = 0; x <= lenght; x++)
      {
        for(int y = 0; y <= height; y++)
        {
          fxReIm[y] = FxReIm(dft[y].Re[x], dft[y].Im[x]);
        }
        result[x] = DFT(fxReIm);
      }

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
        result.CenteredFx[i] = sourceFx[i] * Step(i);
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
      Значение функции с действительной и мнимой частью

      Параметры:
        re - действительная часть
        im - мнимая часть
    */
    private static double FxReIm(double re, double im)
    {
      return (re * Math.Cos(0) + im * Math.Sin(0)) - (re * Math.Sin(0) - im * Math.Cos(0));
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