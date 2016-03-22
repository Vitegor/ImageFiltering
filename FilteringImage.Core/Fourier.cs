using System;

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
    public static FourierResult[] DFT2D(double[,] srcFxy, int m = defaultM, int n = defaultN)
    {
      int srcFxyLength = srcFxy.Rank;
      int srcFxyHeight = srcFxy.Length;
      int maxU = m - 1;
      int maxV = n - 1;
      double[,] fxy = new double[m, n];

      FourierResult fxv = new FourierResult(m);
      FourierResult[] result = new FourierResult[n];

      for(int x = 0; x <= srcFxyLength - 1; x++)
      {
        for(int y = 0; y <= srcFxyHeight - 1; y++)
        {
          fxy[x, y] = srcFxy[x, y] * Step(x + y);
        }
      }

      for(int u = 0; u <= maxU; u++)
      {
        for(int v = 0; v <= maxV; v++)
        {
          for(int x = 0; x <= maxU; x++)
          {
            for(int y = 0; y <= maxV; y++)
            {
              
            }
          }
        }
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
    public static FourierResult DFT(double[] sourceFx, int m = defaultM)
    {
      int sourceLength = sourceFx.Length;
      /*
        Если количество отсчетов меньше чем количество элементов в исходной массиве, то
        количество отсчетов делаем равным количеству элементов в исходном массиве
      */
      m = m < sourceLength ? sourceLength : m;
      int processingLimit = m - 1;
      double[] fx = new double[m];

      FourierResult result = new FourierResult(m);

      for(int i = 0; i <= sourceLength - 1; i++) fx[i] = sourceFx[i]*Step(i);

      for(var u = 0; u <= processingLimit; u++)
      {
        for(int x = 0; x <= processingLimit; x++)
        {
          result.ReDFT[u] += ReDFT(fx[x], u, x, m);
          result.ImDFT[u] += ImDFT(fx[x], u, x, m);
          result.ReIDFT[u] += ReIDFT(result.ReDFT[u], u, x, m);
          result.ImIDFT[u] += ImIDFT(result.ImIDFT[u], u, x, m);
          result.FourierSpectrum[u] += FourierSpectrum(result.ReDFT[u], result.ImDFT[u]);
          result.PowerSpectrum[u] += PowerSpectrum(result.FourierSpectrum[u]);
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
    private static double ReDFT(double fx, int u, int x, int m)
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
    private static double ImDFT(double fx, int u, int x, int m)
    {
      return fx * Math.Sin((2 * Math.PI * u * x) / m);
    }

    /*
      Вычисление значения действительной части обратного дискретного преобразования Фурье.

      Параметры:
        reDFT - значение действительной части прямонго преобразования Фурьре
        u - индекс частотной области
        x - временной индекс входных отсчетов
        m - количество отсчетов входной последовательности и
            количество частотных отсчетов результата преобразования Фурье
    */
    private static double ReIDFT(double reDFT, int u, int x, int m)
    {
      return reDFT * Math.Cos((2 * Math.PI * u * x) / m);
    }

    /*
      Вычисление значения мнимой части обратного дискретного преобразования Фурье.

      Параметры:
        imDFT - значение мнимой части прямонго преобразования Фурьре
        u - индекс частотной области
        x - временной индекс входных отсчетов
        m - количество отсчетов входной последовательности и
            количество частотных отсчетов результата преобразования Фурье
    */
    private static double ImIDFT(double imDFT, int u, int x, int m)
    {
      return imDFT * Math.Sin((2 * Math.PI * u * x) / m);
    }

    /*
      Вычисление значения спектра преобразования Фурье.

      Параметры:
        reDFT - значение действительной части прямого дискретного преобразования Фурьре
        imDFT - значение мнимой части прямого дискретного преобразования Фурьре
    */
    private static double FourierSpectrum(double reDFT, double imDFT)
    {
      return Math.Sqrt(Math.Pow(reDFT, 2) + Math.Pow(imDFT, 2));
    }

    /*
      Вычисление значения спектра мощности (энергетического спектра).

      Параметры:
        fourierSpectrum - значение спектра преобразования Фурье
    */
    private static double PowerSpectrum(double fourierSpectrum)
    {
      return fourierSpectrum * fourierSpectrum;
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