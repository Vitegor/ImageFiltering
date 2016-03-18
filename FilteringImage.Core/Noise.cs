using System;
using System.Drawing;

namespace FilteringImage.Core
{
  //Класс, реализующий добавление шумов
  public static class Noise
  {
    //Количество пикселей, подлежащих зашумлению (1 - 100%)
    private const double PIXELS_PERCENTAGE = 0.1;

    //Значение минимальной интенсивности цветового канала
    private const byte MIN_COLOR_INTENSITY = 0;

    //Значение максимальной интенсивности цветового канала
    private const byte MAX_COLOR_INTENSITY = 255;

    private static Random randomPixels = new Random();

    /*
      Биполярный шум.

      Параметры:
        bitmap - исоходная битовая карта изображения
        colorChannel - цветовой канал, по которому производится зашумление
    */
    public static Bitmap AddBipolarNoise(Bitmap bitmap, RGBChannel colorChannel)
    {
      int height = bitmap.Size.Height;
      int width = bitmap.Size.Width;
      byte r = 0;
      byte g = 0;
      byte b = 0;
      byte colorIntensity = 0;
      Random randomColor = new Random();

      for(int x = 0; x < width; x++)
      {
        for(int y = 0; y < height; y++)
        {

          if(randomPixels.NextDouble() < PIXELS_PERCENTAGE)
          {
            r = bitmap.GetPixel(x, y).R;
            g = bitmap.GetPixel(x, y).G;
            b = bitmap.GetPixel(x, y).B;

            colorIntensity
              = randomColor.NextDouble() > 0.5
              ? MAX_COLOR_INTENSITY
              : MIN_COLOR_INTENSITY;

            switch(colorChannel)
            {
              case RGBChannel.Red: r = colorIntensity; break;
              case RGBChannel.Green: g = colorIntensity; break;
              case RGBChannel.Blue: b = colorIntensity; break;
            }

            bitmap.SetPixel(x, y, Color.FromArgb(r, g, b));
          }
        }
      }

      return bitmap;
    }

    /*
      Униполярный соляной шум.

      Параметры:
        bitmap - исоходная битовая карта изображения
        colorChannel - цветовой канал, по которому производится зашумление
    */
    public static Bitmap AddUnipolarSaltNoise(Bitmap bitmap, RGBChannel colorChannel)
    {
      return AddUnipolarNoise(bitmap, colorChannel, Color.White);
    }

    /*
      Униполярный перечный шум.

      Параметры:
        bitmap - исоходная битовая карта изображения
        colorChannel - цветовой канал, по которому производится зашумление
    */
    public static Bitmap AddUnipolarPepperNoise(Bitmap bitmap, RGBChannel colorChannel)
    {
      return AddUnipolarNoise(bitmap, colorChannel, Color.Black);
    }

    /*
      Общий метод для реализации униполярного шума.

      Параметры:
        bitmap - исоходная битовая карта изображения
        colorChannel - цветовой канал, по которому производится зашумление
        colorForNoise - цвет, определяющий тип униполярного шума (черный - перечный, белый - соляной)
    */
    private static Bitmap AddUnipolarNoise(Bitmap bitmap, RGBChannel colorChannel, Color colorForNoise)
    {
      if(colorForNoise == Color.Black || colorForNoise == Color.White)
      {
        int height = bitmap.Size.Height;
        int width = bitmap.Size.Width;
        byte r = 0;
        byte g = 0;
        byte b = 0;

        for(int x = 0; x < width; x++)
        {
          for(int y = 0; y < height; y++)
          {
            if(randomPixels.NextDouble() < PIXELS_PERCENTAGE)
            {
              r = bitmap.GetPixel(x, y).R;
              g = bitmap.GetPixel(x, y).G;
              b = bitmap.GetPixel(x, y).B;

              switch(colorChannel)
              {
                case RGBChannel.Red:
                r = colorForNoise == Color.Black ? MAX_COLOR_INTENSITY : MIN_COLOR_INTENSITY;
                break;

                case RGBChannel.Green:
                g = colorForNoise == Color.Black ? MAX_COLOR_INTENSITY : MIN_COLOR_INTENSITY;
                break;

                case RGBChannel.Blue:
                b = colorForNoise == Color.Black ? MAX_COLOR_INTENSITY : MIN_COLOR_INTENSITY;
                break;
              }

              bitmap.SetPixel(x, y, Color.FromArgb(r, g, b));
            }
          }
        }
      }

      return bitmap;
    }
  }
}