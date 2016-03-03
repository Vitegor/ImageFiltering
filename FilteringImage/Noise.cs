using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FilteringImage
{
  public static class Noise
  {
    private static Random randomPixels = new Random();
    private const double PIXELS_PERCENTAGE = 0.1;

    public static Bitmap AddBipolarNoise(Bitmap bitmap)
    {
      int height = bitmap.Size.Height;
      int width = bitmap.Size.Width;
      Color color;
      Random randomColor = new Random();

      for (int x = 0; x < width; x++)
      {
        for(int y = 0; y < height; y++)
        {
          if (randomPixels.NextDouble() < PIXELS_PERCENTAGE)
          {
            color = randomColor.NextDouble() > 0.5 ? Color.Black : Color.White;
            bitmap.SetPixel(x, y, color);
          }
        }
      }

      return bitmap;
    }

    public static Bitmap AddUnipolarSaltNoise(Bitmap bitmap)
    {
      return AddUnipolarNoise(bitmap, Color.White);
    }

    public static Bitmap AddUnipolarPepperNoise(Bitmap bitmap)
    {
      return AddUnipolarNoise(bitmap, Color.Black);
    }

    private static Bitmap AddUnipolarNoise(Bitmap bitmap, Color colorForNoise)
    {
      int height = bitmap.Size.Height;
      int width = bitmap.Size.Width;

      for (int x = 0; x < width; x++)
      {
        for (int y = 0; y < height; y++)
        {
          if (randomPixels.NextDouble() < PIXELS_PERCENTAGE)
          {
            if (colorForNoise == Color.Black || colorForNoise == Color.White)
              bitmap.SetPixel(x, y, colorForNoise);
          }
        }
      }

      return bitmap;
    }
  }
}