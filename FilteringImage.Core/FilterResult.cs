using System.Drawing;

namespace FilteringImage.Core
{
  public class FilterResult
  {
    public Bitmap Bitmap; //Битовая карта отфильтрованного изображения
    public double Energy; //Значение энергии изображения
    public Bitmap FilterSpectrum; //Битовая карта спектра фильтра
  }
}