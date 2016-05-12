using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FilteringImage.Core
{
  public class FilterResult
  {
    public Bitmap Bitmap; //Битовая карта исходного изображения
    public double Energy; //Значение энергии изображения
    public Bitmap FilterSpectrum; //Битовая карта спектра фильтра
  }
}