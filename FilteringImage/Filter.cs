using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FilteringImage
{
  public static class Filter
  {
    private static byte[] maskGrades = new byte[] { 3, 5, 9 };

    public static Bitmap FilterCounterHarmonic(Bitmap bitmap, byte maskGradeIndex, double filterGrade = 1)
    {
      if(maskGrades.Length >= maskGradeIndex)
      {
        int height = bitmap.Size.Height;
        int width = bitmap.Size.Width;

        double sNumR, sNumG, sNumB;
        double sDenR, sDenG, sDenB;

        byte r, g, b;

        byte maskGrade = maskGrades[maskGradeIndex];
        int maskArea = maskGrade - 2;
        int maskAreaMin = maskArea * (-1);

        //Циклы по всему изображению
        for(int x = 0; x < width; x++)
        {
          for(int y = 0; y < height; y++)
          {
            sNumR = sNumG = sNumB = 0;
            sDenR = sDenG = sDenB = 0;

            //Циклы по маске
            for(int i = maskAreaMin; i <= maskArea; i++)
            {
              for(int j = maskAreaMin; j <= maskArea; j++)
              {
                if(isMaskPointInImageArea(x, y, i, j, height, width, maskGrade))
                {
                  sNumR += Math.Pow(bitmap.GetPixel(x + i, y + j).R, filterGrade + 1);
                  sNumG += Math.Pow(bitmap.GetPixel(x + i, y + j).G, filterGrade + 1);
                  sNumB += Math.Pow(bitmap.GetPixel(x + i, y + j).B, filterGrade + 1);

                  sDenR += Math.Pow(bitmap.GetPixel(x + i, y + j).R, filterGrade);
                  sDenG += Math.Pow(bitmap.GetPixel(x + i, y + j).G, filterGrade);
                  sDenB += Math.Pow(bitmap.GetPixel(x + i, y + j).B, filterGrade);
                }
              }
            }

            r = (byte)Math.Round(sNumR / sDenR);
            g = (byte)Math.Round(sNumG / sDenG);
            b = (byte)Math.Round(sNumB / sDenB);

            bitmap.SetPixel(x, y, Color.FromArgb(r, g, b));
          }
        }
      }

      return bitmap;
    }

    public static Bitmap FilterMidpoint(Bitmap bitmap, byte maskGradeIndex)
    {
      int height = bitmap.Size.Height;
      int width = bitmap.Size.Width;

      for(int x = 0; x < width; x++)
      {
        for(int y = 0; y < height; y++)
        {
          if(maskGrades.Length >= maskGradeIndex)
          {
            byte maskGrade = maskGrades[maskGradeIndex];
            int maskArea = maskGrade - 2;
            int maskAreaMin = maskArea * (-1);
          }
        }
      }

      return bitmap;
    }

    private static bool isMaskPointInImageArea(int x, int y, int maskX, int maskY, int height, int width, byte maskGrade)
    {
      return (x + maskX >= 0 && y + maskY >= 0) && (x + maskX <= width - 1 && y + maskY <= height - 1);
    }
  }
}