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
    public static Bitmap GetImageSpectrum(Bitmap bitmap, RGBChannel colorChannel)
    {
      bitmap = GetImageInColorScale(bitmap, colorChannel);
      double[,] fxy = GetBitmapFunction(bitmap, colorChannel);

      FourierResult[] fourierResult = Fourier.DFT2D(fxy);

      int x, y = 0;
      byte gray;

      foreach(var row in fourierResult)
      {
        x = 0;
        foreach(var item in row.Spectrum)
        {
          gray = ColorChannel.ToGray(item, item, item);
          bitmap.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
          x++;
        }
        y++;
      }

      return bitmap;
    }

    private static double[,] GetBitmapFunction(Bitmap bitmap, RGBChannel colorChannel)
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

          fxy[y, x] = gray * Fourier.Step(x + y);
        }
      }

      return fxy;
    }

    private static Bitmap GetImageInColorScale(Bitmap bitmap, RGBChannel colorChannel)
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
  }
}