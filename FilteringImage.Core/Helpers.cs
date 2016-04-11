using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FilteringImage.Core
{
  public static class Helpers
  {
    public static double GetProportionalValue(double value, double srcMin, double srcMax, double resMin, double resMax)
    {
      return (resMax - resMin) * ((value - srcMin) / (srcMax - srcMin));
    }

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