using System;

namespace FilteringImage.Core
{
  public static class Fourier
  {
    private const int defaultM = 100;

    /*
      Прямое дискретное преобразование Фурье

      Параметры:
        sourceFx - исходный массив значений функции
        m - количество отсчетов входной последовательности и
            количество частотных отсчетов результата преобразования Фурье
    */
    public static FourierResult DiscreteFourierTransform(double[] sourceFx, int m = defaultM)
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
      Центрирование функции.

      Параметры:
        fх - массив значений функции
    */
    private static double[] Centering(double[] fx)
    {
      int length = fx.Length - 1;
      double[] result = new double[fx.Length];

      for(var i = 0; i <= length; i++)
        result[i] *= (byte)(1 - 2 * (!isEven(i) ? 1 : 0));

      return result;
    }

    /*
      Возведение -1 в степень

      Параметры:
        n - степень
    */
    private static double Step(int n) { return (byte)(1 - 2 * (!isEven(n) ? 1 : 0)); }

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