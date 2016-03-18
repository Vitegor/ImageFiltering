using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilteringImage.Core
{
  public static class Fourier
  {
    /*
      Прямое дискретное преобразование Фурье

      Параметры:
        sourceFx - исходный массив значений функции
        m - количество отсчетов входной последовательности и
            количество частотных отсчетов результата преобразования Фурье
    */
    public static FourierResult DFT(double[] sourceFx, int m = 100)
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
          result.Re[u] += fx[x] * Math.Cos((2 * Math.PI * u * x) / m);
          result.Im[u] += fx[x] * Math.Sin((2 * Math.PI * u * x) / m);
        }
      }

      return result;
    }

    /*
      Обратное дискретное преобразование Фурье

      Параметры:
        dft - результат прямого преоразовния Фурьре
    */
    public static FourierResult IDFT(FourierResult dft)
    {
      int m = dft.Re.Length;
      int processingLimit = m - 1;
      double[] re = new double[m]; //Действительная часть
      double[] im = new double[m]; //Мнимая часть

      //Структура данных, в которую будут помещены мнимая и действительная части
      FourierResult result = new FourierResult();

      for(var u = 0; u <= processingLimit; u++)
      {
        for(int x = 0; x <= processingLimit; x++)
        {
          result.Re[u] += dft.Re[x] * Math.Cos((2 * Math.PI * u * x) / m);
          result.Im[u] += dft.Im[x] * Math.Sin((2 * Math.PI * u * x) / m);
        }
      }

      return result;
    }

    /*
      Фурье спектр

      Параметры:
        dft - результат прямого преобразования Фурье
    */
    public static double[] FourierSpectrum(double[] fx, int m = 100)
    {
      FourierResult dft = DFT(fx, m);
      int processingLimit = m - 1;
      double[] result = new double[m];

      for(int u = 0; u <= processingLimit; u++)
      {
        result[u] = Math.Sqrt(Math.Pow(dft.Re[u], 2) - Math.Pow(dft.Im[u], 2));
      }

      return result;
    }

    /*
      Центрирование функции.

      Параметры:
        fх - центрируемый массив
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

  //Структура результата для прямого и обратного преобразования Фурье
  public struct FourierResult
  {
    private double[] _re;
    private double[] _im;

    public FourierResult(int m)
    {
      _re = new double[m];
      _im = new double[m];
    }

    public double[] Re { get { return _re; } } //Действительная часть
    public double[] Im { get { return _im; } } //Мнимая часть
  }
}