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
    internal static double[,] GetBitmapFunction(Bitmap bitmap, RGBChannel colorChannel)
    {
      int m = bitmap.Width;
      int n = bitmap.Height;
      int length = m - 1;
      int height = n - 1;
      byte gray;

      double[,] fxy = new double[n, m];

      for(int y = 0; y < height; y++)
      {
        for(int x = 0; x < length; x++)
        {
          gray = ColorChannel.ToGray(
              bitmap.GetPixel(x, y).R,
              bitmap.GetPixel(x, y).G,
              bitmap.GetPixel(x, y).B);

          fxy[y, x] = gray * Step(x + y);
        }
      }

      return fxy;
    }

    internal static Bitmap GetImageInColorScale(Bitmap bitmap, RGBChannel colorChannel)
    {
      int length = bitmap.Width - 1;
      int height = bitmap.Height - 1;
      byte gray;

      for(int y = 0; y < height; y++)
      {
        for(int x = 0; x < length; x++)
        {
          gray = ColorChannel.ToGray(
              bitmap.GetPixel(x, y).R,
              bitmap.GetPixel(x, y).G,
              bitmap.GetPixel(x, y).B);

          bitmap.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
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