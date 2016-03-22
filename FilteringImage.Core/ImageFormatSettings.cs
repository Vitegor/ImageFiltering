using System;

namespace FilteringImage.Core
{
  //Структура, в которой хранятся настройки форматов изображений
  public struct ImageFormatSettings
  {
    private const string EXTENSION_FOR_SAVE = ".bmp";
    private const string EXTENSIONS_PATTERN_FOR_OPEN = "BMP files (*.bmp) | *.bmp;";

    /*
      Свойство, возвращающее шаблон для форматов изображения,
      которые доступны при загрузке изображения в программу
    */
    public static string ExtensionsPatternsForOpen
    {
      get { return EXTENSIONS_PATTERN_FOR_OPEN; }
    }

    /*
      Свойство, возвращающее формат, в котором сохраняется изображение
    */
    public static string ExtensionForSave
    {
      get { return EXTENSION_FOR_SAVE; }
    }
  }
}