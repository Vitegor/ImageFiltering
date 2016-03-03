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
    private static double[] harmonicFilterGrade = new double[] { -1, 0, 1 };

    public static Bitmap FilterCounterHarmonic(Bitmap bitmap, byte maskGradeIndex, byte harmonicFilterGradeIndex)
    {
      if(maskGrades.Length >= maskGradeIndex)
      {
        int height = bitmap.Size.Height;
        int width = bitmap.Size.Width;

        double sNumR, sNumG, sNumB;
        double sDenR, sDenG, sDenB;

        byte r, g, b;

        byte maskGrade = maskGrades[maskGradeIndex];
        double filterGrade = harmonicFilterGrade[harmonicFilterGradeIndex];
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
                  r = bitmap.GetPixel(x + i, y + j).R;
                  g = bitmap.GetPixel(x + i, y + j).G;
                  b = bitmap.GetPixel(x + i, y + j).B;

                  sNumR += r != 0 ? Math.Pow(r, filterGrade + 1) : 0;
                  sNumG += g != 0 ? Math.Pow(g, filterGrade + 1) : 0;
                  sNumB += b != 0 ? Math.Pow(b, filterGrade + 1) : 0;

                  sDenR += r != 0 ? Math.Pow(r, filterGrade) : 0;
                  sDenG += g != 0 ? Math.Pow(g, filterGrade) : 0;
                  sDenB += b != 0 ? Math.Pow(b, filterGrade) : 0;
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
      if(maskGrades.Length >= maskGradeIndex)
      {
        int height = bitmap.Size.Height;
        int width = bitmap.Size.Width;

        byte r, g, b;

        byte maskGrade = maskGrades[maskGradeIndex];
        int maskArea = maskGrade - 2;
        int maskAreaMin = maskArea * (-1);

        List<int> sumR = new List<int>();
        List<int> sumG = new List<int>();
        List<int> sumB = new List<int>();

        for(int x = 0; x < width; x++)
        {
          for(int y = 0; y < height; y++)
          {
            sumR.Clear();
            sumG.Clear();
            sumB.Clear();

            for(int i = maskAreaMin; i <= maskArea; i++)
            {
              for(int j = maskAreaMin; j <= maskArea; j++)
              {
                if(isMaskPointInImageArea(x, y, i, j, height, width, maskGrade))
                {
                  sumR.Add(bitmap.GetPixel(x + i, y + j).R);
                  sumG.Add(bitmap.GetPixel(x + i, y + j).G);
                  sumB.Add(bitmap.GetPixel(x + i, y + j).B);
                }
              }
            }
            r = (byte)((sumR.Max() + sumR.Min()) / 2);
            g = (byte)((sumG.Max() + sumG.Min()) / 2);
            b = (byte)((sumB.Max() + sumB.Min()) / 2);

            bitmap.SetPixel(x, y, Color.FromArgb(r, g, b));
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