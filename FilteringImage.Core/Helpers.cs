using System;
using System.Drawing;

namespace FilteringImage.Core
{
  //Класс вспомогательных методов
  public static class Helpers
  {
    /*
      Получение спектра изображения.

      Параметры:
        bitmap - битовая карта исходного изображения
    */
    public static Bitmap GetImageSpectrum(Bitmap bitmap)
    {
      const int MIN_COLOR = 0;
      const int MAX_COLOR = 255;
      int length = bitmap.Width;
      int height = bitmap.Height;

      bitmap = GetImageInColorScale(new Bitmap(bitmap));
      double[,] fxy = GetBitmapFunction(bitmap);
      fxy = CenteringFunction(fxy);
      FourierResult[] fourierResult = Fourier.DFT2D(fxy);

      #region Логарифмирование, нахождение минимального и максимального значений

      double min = 0;
      double max = 0;
      double tempValue;
      for(int i = 0; i < height; i++)
      {
        for(int j = 0; j < length; j++)
        {
          tempValue = fourierResult[i].Spectrum[j];
          tempValue = tempValue > 0 ? Math.Log10(tempValue) : 0;
          if(tempValue < min) min = tempValue;
          if(tempValue > max) max = tempValue;
          fourierResult[i].Spectrum[j] = tempValue;
        }
      }

      #endregion

      int x, y = 0;
      byte tempColor = 0;
      foreach(var row in fourierResult)
      {
        x = 0;
        foreach(var item in row.Spectrum)
        {
          tempColor = (byte)GetProportionalValue(item, min, max, MIN_COLOR, MAX_COLOR);
          bitmap.SetPixel(x, y, Color.FromArgb(tempColor, 0, 0));
          x++;
        }
        y++;
      }

      return bitmap;
    }

    /*
      Получение изображения из значений функции с пропорцинальным приведением значений к градациям цвета.

      Параметры:
        fxy - исходная функция
    */
    public static Bitmap GetProportionalImage(double[,] fxy)
    {
      const int MIN_COLOR = 0;
      const int MAX_COLOR = 255;
      int length = fxy.GetLength(1) - 1;
      int height = fxy.GetLength(0) - 1;
      double min = 0;
      double max = 0;

      for(int y = 0; y < height; y++)
      {
        for(int x = 0; x < length; x++)
        {
          if(fxy[y, x] < min) min = fxy[y, x];
          if(fxy[y, x] > max) max = fxy[y, x];
        }
      }

      byte tempColor = 0;
      Bitmap bitmap = new Bitmap(fxy.GetLength(1), fxy.GetLength(0));

      for(int y = 0; y < height; y++)
      {
        for(int x = 0; x < length; x++)
        {
          tempColor = (byte)GetProportionalValue(fxy[y, x], min, max, MIN_COLOR, MAX_COLOR);
          bitmap.SetPixel(x, y, Color.FromArgb(tempColor, 0, 0));
        }
      }

      return bitmap;
    }

    /*
      Получение пропорционального значения .

      Параметры:
        value - исходное значение
        srcMin - минимальное значение исходного множества
        srcMax - максимальное значение исходного множества
        resMin - минимальное значение целевого множества
        resMax - максимальное значение целевого множества
    */
    public static double GetProportionalValue(double value, double srcMin, double srcMax, double resMin, double resMax)
    {
      return (resMax - resMin) * ((value - srcMin) / (srcMax - srcMin));
    }

    /*
      Получение массива значений из битовой карты изображения.

      Параметры:
        bitmap - битовая карта исходного изображения
    */
    public static double[,] GetBitmapFunction(Bitmap bitmap)
    {
      int m = bitmap.Width;
      int n = bitmap.Height;
      int length = m - 1;
      int height = n - 1;

      double[,] fxy = new double[n, m];

      for(int y = 0; y < height; y++)
      {
        for(int x = 0; x < length; x++)
        {
          fxy[y, x] = bitmap.GetPixel(x, y).R;
        }
      }

      return fxy;
    }

    /*
      Получение изображения в градациях одного цвета (красного).

      Параметры:
        bitmap - битовая карта исходного изображения
    */
    public static Bitmap GetImageInColorScale(Bitmap bitmap)
    {
      int length = bitmap.Width - 1;
      int height = bitmap.Height - 1;
      byte red;

      for(int y = 0; y < height; y++)
      {
        for(int x = 0; x < length; x++)
        {
          red = bitmap.GetPixel(x, y).R;
          bitmap.SetPixel(x, y, Color.FromArgb(red, 0, 0));
        }
      }

      return bitmap;
    }

    /*
      Центрирование функции.

      Параметры:
        fxy -  исходные значения
    */
    public static double[,] CenteringFunction(double[,] fxy)
    {
      int length = fxy.GetLength(1) - 1;
      int height = fxy.GetLength(0) - 1;

      for(int y = 0; y <= height; y++)
      {
        for(int x = 0; x <= length; x++)
        {
          fxy[y, x] = fxy[y, x] * Step(x + y);
        }
      }

      return fxy;
    }

    /*
      Получение битовой карты из массива значений.

      Параметры:
        fxy - исходные значения
    */
    public static Bitmap GenerateBitmap(double[,] fxy)
    {
      int length = fxy.GetLength(1) - 1;
      int height = fxy.GetLength(0) - 1;

      Bitmap bitmap = new Bitmap(fxy.GetLength(1), fxy.GetLength(0));

      for(int y = 0; y <= height; y++)
      {
        for(int x = 0; x <= length; x++)
        {
          bitmap.SetPixel(x, y, Color.FromArgb((byte)fxy[y, x], 0, 0));
        }
      }

      return bitmap;
    }

    /*
      Возведение -1 в степень

      Параметры:
        n - степень
    */
    public static int Step(int n) { return 1 - 2 * (!IsEven(n) ? 1 : 0); }

    /*
      Проверка числа на четность.

      Параметры:
        х - число, проверяемое на четность
    */
    public static bool IsEven(double x)
    {
      return x % 2 == 0;
    }
  }
}