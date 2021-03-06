﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FilteringImage.Core
{
  public static class ColorChannel
  {
    public static Bitmap HighlightColorChannel(Bitmap srcBitmap, Bitmap bitmap, RGBChannel color)
    {
      int height = srcBitmap.Size.Height;
      int width = srcBitmap.Size.Width;
      byte r = 0;
      byte g = 0;
      byte b = 0;

      for(int x = 0; x < width; x++)
      {
        for(int y = 0; y < height; y++)
        {
          switch(color)
          {
            case RGBChannel.Red:
            {
              r = srcBitmap.GetPixel(x, y).R;
              g = 0;
              b = 0;
              break;
            }
            case RGBChannel.Green:
            {
              r = 0;
              g = srcBitmap.GetPixel(x, y).G;
              b = 0;
              break;
            }
            case RGBChannel.Blue:
            {
              r = 0;
              g = 0;
              b = srcBitmap.GetPixel(x, y).B;
              break;
            }
          }

          bitmap.SetPixel(x, y, Color.FromArgb(r, g, b));
        }
      }

      return bitmap;
    }

    #region Hide Color Channel
    public static Bitmap HideRedChannel(Bitmap bitmap)
    {
      return HideColorChannel(bitmap, RGBChannel.Red);
    }

    public static Bitmap HideGreenChannel(Bitmap bitmap)
    {
      return HideColorChannel(bitmap, RGBChannel.Green);
    }

    public static Bitmap HideBlueChannel(Bitmap bitmap)
    {
      return HideColorChannel(bitmap, RGBChannel.Blue);
    }

    private static Bitmap HideColorChannel(Bitmap bitmap, RGBChannel color)
    {
      int height = bitmap.Size.Height;
      int width = bitmap.Size.Width;
      byte r, g, b;

      for(int x = 0; x < width; x++)
      {
        for(int y = 0; y < height; y++)
        {
          r = bitmap.GetPixel(x, y).R;
          g = bitmap.GetPixel(x, y).G;
          b = bitmap.GetPixel(x, y).B;

          switch(color)
          {
            case RGBChannel.Red: r = 0; break;
            case RGBChannel.Green: g = 0; break;
            case RGBChannel.Blue: b = 0; break;
          }

          bitmap.SetPixel(x, y, Color.FromArgb(r, g, b));
        }
      }

      return bitmap;
    }
    #endregion

    #region Show Color Channel
    public static Bitmap ShowRedChannel(Bitmap srcBitmap, Bitmap bitmap)
    {
      return ShowColorChannel(srcBitmap, bitmap, RGBChannel.Red);
    }

    public static Bitmap ShowGreenChannel(Bitmap srcBitmap, Bitmap bitmap)
    {
      return ShowColorChannel(srcBitmap, bitmap, RGBChannel.Green);
    }

    public static Bitmap ShowBlueChannel(Bitmap srcBitmap, Bitmap bitmap)
    {
      return ShowColorChannel(srcBitmap, bitmap, RGBChannel.Blue);
    }

    private static Bitmap ShowColorChannel(Bitmap srcBitmap, Bitmap bitmap, RGBChannel color)
    {
      int height = srcBitmap.Size.Height;
      int width = srcBitmap.Size.Width;
      byte r, g, b;

      for(int x = 0; x < width; x++)
      {
        for(int y = 0; y < height; y++)
        {
          r = bitmap.GetPixel(x, y).R;
          g = bitmap.GetPixel(x, y).G;
          b = bitmap.GetPixel(x, y).B;

          switch(color)
          {
            case RGBChannel.Red: r = srcBitmap.GetPixel(x, y).R; break;
            case RGBChannel.Green: g = srcBitmap.GetPixel(x, y).G; break;
            case RGBChannel.Blue: b = srcBitmap.GetPixel(x, y).B; break;
          }

          bitmap.SetPixel(x, y, Color.FromArgb(r, g, b));
        }
      }

      return bitmap;
    }
    #endregion

    public static byte ToGray(double red, double green, double blue)
    {
      double MAX_BYTE = 255;
      red = red > MAX_BYTE ? MAX_BYTE : red;
      green = green > MAX_BYTE ? MAX_BYTE : green;
      blue = blue > MAX_BYTE ? MAX_BYTE : blue;

      return (byte)(0.2125 * red + 0.7154 * green + 0.0721 * blue);
    }
  }
}