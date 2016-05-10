using System;
using System.Collections.Generic;
using System.Drawing;

namespace FilteringImage.Core
{
  public static class Fourier
  {
    #region Прямое преобразование

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

      #region По строкам

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

      #region По столбцам

      FourierResult[] colResult = new FourierResult[m];
      double[] re = new double[n];
      double[] im = new double[n];

      for(int x = 0; x <= length; x++)
      {
        for(int y = 0; y <= height; y++)
        {
          //Набираем значения действительной и мнимой частей по столбцам
          re[y] = rowResult[y].Re[x];
          im[y] = rowResult[y].Im[x];
        }
        colResult[x] = DFT(re, im);
      }

      #endregion

      #region Обратное отражение

      for(int x = 0; x <= length; x++)
      {
        for(int y = 0; y <= height; y++)
        {
          /*
            Значение помещаем в массив результатов по строкам т.к. как он соответствует
            размерам исходной функции
          */
          rowResult[y].Re[x] = colResult[x].Re[y];
          rowResult[y].Im[x] = colResult[x].Im[y];
          rowResult[y].Spectrum[x] = colResult[x].Spectrum[y];
        }
      }

      #endregion

      return rowResult;
    }

    /*
      Одномерное дискретное преобразование Фурье

      Параметры:
      re - действительная часть
      im - мнимая часть
    */
    public static FourierResult DFT(double[] re, double[] im = null)
    {
      int m = re.Length;
      int length = m - 1;
      double _im = 0; //Для определения мнимой части

      FourierResult result = new FourierResult(m);

      for(var u = 0; u <= length; u++)
      {
        for(int x = 0; x <= length; x++)
        {
          _im = im == null ? 0 : im[x];
          result.Re[u] += Re(re[x], _im, u, x, m);
          result.Im[u] += Im(re[x], _im, u, x, m);
        }
        result.Spectrum[u] = Spectrum(result.Re[u], result.Im[u]);
      }

      return result;
    }

    /*
      Вычисление значения действительной части, комплексное.

      Параметры:
        re - действительная часть преобразования
        im - мнимая часть преобразования
        u - индекс частотной области
        x - временной индекс входных отсчетов
        m - количество отсчетов входной последовательности и
            количество частотных отсчетов результата преобразования Фурье
    */
    private static double Re(double re, double im, int u, int x, int m)
    {
      return
        re * Math.Cos((2 * Math.PI * x * u) / m) +
        im * Math.Sin((2 * Math.PI * x * u) / m);
    }

    /*
      Вычисление значения мнимой части, комплексное.

      Параметры:
        re - действительная часть преобразования
        im - мнимая часть преобразования
        u - индекс частотной области
        x - временной индекс входных отсчетов
        m - количество отсчетов входной последовательности и
            количество частотных отсчетов результата преобразования Фурье
    */
    private static double Im(double re, double im, int u, int x, int m)
    {
      return
        im * Math.Cos((2 * Math.PI * x * u) / m) -
        re * Math.Sin((2 * Math.PI * x * u) / m);
    }

    /*
      Вычисление значения спектра.

      Параметры:
        re - значение действительной части прямого дискретного преобразования Фурьре
        im - значение мнимой части прямого дискретного преобразования Фурьре
    */
    private static double Spectrum(double re, double im)
    {
      return Math.Sqrt(Math.Pow(re, 2) + Math.Pow(im, 2));
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

    #endregion

    #region Обратное преобразование

    /*
      Двумерное дискретное обратное преобразование Фурье

      Параметры:
        fourierResult - результат двумерного дискретного прямого преобразования Фурье
    */
    public static double[,] IDFT2D(FourierResult[] fourierResult)
    {
      int m = fourierResult[0].Re.Length; //Количество столбцов
      int n = fourierResult.Length; //Количество строк
      int length = m - 1;
      int height = n - 1;

      #region По строкам

      //Количество результатов по строкам равно количеству строк - n
      InverseFourierResult[] rowResult = new InverseFourierResult[n];

      //Количество значений мнимой и действительной частей равно числу столбцов - m
      double[] re = new double[m];
      double[] im = new double[m];

      for(int y = 0; y <= height; y++)
      {
        for(int x = 0; x <= length; x++)
        {
          re[x] = fourierResult[y].Re[x];
          im[x] = fourierResult[y].Im[x];
        }
        rowResult[y] = IDFT(re, im);
      }

      #endregion

      #region По столбцам

      InverseFourierResult[] colResult = new InverseFourierResult[m];
      re = new double[n];
      im = new double[n];

      //Цикл по столбцам
      for(int x = 0; x <= length; x++)
      {
        //Цикл по строкам
        for(int y = 0; y <= height; y++)
        {
          re[y] = rowResult[y].Re[x];
          im[y] = rowResult[y].Im[x];
        }
        colResult[x] = IDFT(re, im);
      }

      #endregion

      #region Обратное отражение

      double[,] result = new double[n, m];

      for (int y = 0; y <= height; y++)
      {
        for(int x = 0; x <= length; x++)
        {
          result[y, x] = colResult[x].Re[y];
        }
      }

      #endregion

      return result;
    }

    /*
      Одномерное обратное преобразование Фурье

      Параметры:
        re - действительная часть результата прямого преобразования Фурьре
        im - мнимая часть результата прямого преобразования Фурьре
    */
    public static InverseFourierResult IDFT(double[] re, double[] im)
    {
      int m = re.Length;
      int length = m - 1;
      InverseFourierResult result = new InverseFourierResult(m);

      for(int u = 0; u <= length; u++)
      {
        for(int x = 0; x <= length; x++)
        {
          result.Re[u] += InverseRe(re[x], im[x], u, x, m);
          result.Im[u] += InverseIm(re[x], im[x], u, x, m);
        }
      }

      return result;
    }

    /*
      Вычисление значения действительной части обратного преобразования.

      Параметры:
        Re - значение действительной части прямонго преобразования Фурьре
        u - индекс частотной области
        x - временной индекс входных отсчетов
        m - количество отсчетов входной последовательности и
            количество частотных отсчетов результата преобразования Фурье
    */
    private static double InverseRe(double re, double im, int u, int x, int m)
    {
      return 
        re * Math.Cos((2 * Math.PI * u * x) / m) -
        im * Math.Sin((2 * Math.PI * u * x) / m);
    }

    /*
      Вычисление значения мнимой части обратного преобразования.

      Параметры:
        Im - значение мнимой части прямонго преобразования Фурьре
        u - индекс частотной области
        x - временной индекс входных отсчетов
        m - количество отсчетов входной последовательности и
            количество частотных отсчетов результата преобразования Фурье
    */
    private static double InverseIm(double re, double im, int u, int x, int m)
    {
      return 
        im * Math.Cos((2 * Math.PI * u * x) / m) +
        re * Math.Sin((2 * Math.PI * u * x) / m);
    }

    #endregion
  }
}