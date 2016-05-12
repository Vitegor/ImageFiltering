using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace FilteringImage.Core
{
  //Класс, реализующий методы фильтрации
  public static class Filter
  {
    /*
      Фильтр среднего контргармонического.

      Параметры:
        bitmap - битовая карта исходного изображения
        maskGradeIndex - размер маски
        filterGrade - порядок фильтра
    */
    public static Bitmap FilterCounterHarmonic(Bitmap bitmap, byte maskGrade, double filterGrade)
    {
      if(maskGrade >= 2)
      {
        int height = bitmap.Size.Height;
        int width = bitmap.Size.Width;

        double sNumR, sNumG, sNumB;
        double sDenR, sDenG, sDenB;

        byte r, g, b;

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
                if(isMaskPointInImageArea(x, y, height, width, i, j, maskGrade))
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

    /*
      Фильтр срединной точки.

      Параметры:
        bitmap - битовая карта исходного изображения
        maskGrade - размер маски
    */
    public static Bitmap FilterMidpoint(Bitmap bitmap, byte maskGrade)
    {
      if(maskGrade >= 2)
      {
        int height = bitmap.Size.Height;
        int width = bitmap.Size.Width;

        byte r, g, b;

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
                if(isMaskPointInImageArea(x, y, height, width, i, j, maskGrade))
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

    /*
      Идеальный фильтр низких частот.
      
      Параметры:
        bitmap - битовая карта исходного изображения
        cutOffFrequency - частота среза
    */
    public static FilterResult FilterIdealLowPass(Bitmap bitmap, double cutOffFrequency)
    {
      double[,] fxy = Helpers.GetBitmapFunction(bitmap);
      fxy = Helpers.CenteringFunction(fxy);
      FourierResult[] dft = Fourier.DFT2D(fxy);

      int m = fxy.GetLength(1);
      int n = fxy.GetLength(0); 
      int length = m - 1;
      int height = n - 1;
      double d;
      byte h;
      double energyBefore = 0;
      double energyAfter = 0;
      double[,] filterSpectrum = new double[n, m];

      for(int y = 0; y <= height; y++)
      {
        for(int x = 0; x <= length; x++)
        {
          energyBefore += Math.Pow(dft[y].Re[x], 2) + Math.Pow(dft[y].Im[x], 2);
          d = Math.Sqrt(Math.Pow(x - m / 2, 2) + Math.Pow(y - n / 2, 2));
          h = (byte)(d <= cutOffFrequency ? 1 : 0);
          dft[y].Re[x] *= h;
          dft[y].Im[x] *= h;
          energyAfter += Math.Pow(dft[y].Re[x], 2) + Math.Pow(dft[y].Im[x], 2);
          filterSpectrum[y, x] = h;
        }
      }

      fxy = Fourier.IDFT2D(dft);
      fxy = Helpers.CenteringFunction(fxy);

      FilterResult result = new FilterResult();
      result.Bitmap = Helpers.GenerateBitmap(fxy);
      result.Energy = Math.Round(energyAfter / energyBefore * 100, 2);
      result.FilterSpectrum = Helpers.GetProportionalImage(filterSpectrum);

      return result;
    }

    /*
      Гауссов фильтр низких частот.

      Параметры:
        bitmap - битовая карта исходного изображения
        cutOffFrequency - частота среза
    */
    public static FilterResult FilterGaussLowPass(Bitmap bitmap, double cutOffFrequency)
    {
      double[,] fxy = Helpers.GetBitmapFunction(bitmap);
      fxy = Helpers.CenteringFunction(fxy);

      FourierResult[] dft = Fourier.DFT2D(fxy);

      int m = fxy.GetLength(1);
      int n = fxy.GetLength(0);
      int length = m - 1;
      int height = n - 1;
      double d;
      double h;
      double energyBefore = 0;
      double energyAfter = 0;
      double[,] filterSpectrum = new double[n, m];

      for(int y = 0; y <= height; y++)
      {
        for(int x = 0; x <= length; x++)
        {
          energyBefore += Math.Pow(dft[y].Re[x], 2) + Math.Pow(dft[y].Im[x], 2);
          d = Math.Sqrt(Math.Pow(x - m / 2, 2) + Math.Pow(y - n / 2, 2));
          h = Math.Exp((-1 * d*d) / (2 * cutOffFrequency * cutOffFrequency));
          dft[y].Re[x] *= h;
          dft[y].Im[x] *= h;
          energyAfter += Math.Pow(dft[y].Re[x], 2) + Math.Pow(dft[y].Im[x], 2);
          filterSpectrum[y, x] = h;
        }
      }

      fxy = Fourier.IDFT2D(dft);
      fxy = Helpers.CenteringFunction(fxy);

      FilterResult result = new FilterResult();
      result.Bitmap = Helpers.GenerateBitmap(fxy);
      result.Energy = Math.Round(energyAfter / energyBefore * 100, 2);
      result.FilterSpectrum = Helpers.GetProportionalImage(filterSpectrum);

      return result;
    }

    /*
      Метод, определяющий, находится ли пиксель с текущими координатами в области изображения.

      Параметры:
        x - координата пикселя по оси Х на изображении
        y - координата пикселя по оси Y на изображении
        height - высота изображения (пиксели)
        width - ширина изображения (пиксели)
        maskX - координата пикселя по оси Х на маске
        maskY - координата пикселя по оси У на маске
        maskGrade - размерность маски (пиксели)
    */
    private static bool isMaskPointInImageArea(int x, int y, int height, int width, int maskX, int maskY, byte maskGrade)
    {
      return (x + maskX >= 0 && y + maskY >= 0) && (x + maskX <= width - 1 && y + maskY <= height - 1);
    }
  }
}