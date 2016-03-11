using System;

namespace FilteringImage.Core
{
  public static class GetSaveImage
  {
    private const string DEFAULT_EXTENSION_IMAGE = ".bmp";
    private const string PATTERN_EXTENSION_IMAGE = "BMP files (*.bmp) | *.bmp;";

    public static string ExtensionPatternImage
    {
      get
      {
        return PATTERN_EXTENSION_IMAGE;
      }
    }

    public static string DefaultExtensionImage
    {
      get
      {
        return DEFAULT_EXTENSION_IMAGE;
      }
    }
  }
}