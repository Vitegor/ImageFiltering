using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using FilteringImage.Core;
using System.Windows.Forms.DataVisualization.Charting;

namespace FilteringImage2
{
  public partial class Form1 : Form
  {
    private static Bitmap sourceBitmap;

    public Form1()
    {
      InitializeComponent();
    }

    private void btnGetImage_Click(object sender, EventArgs e)
    {
      openImage.Filter = ImageFormatSettings.ExtensionsPatternsForOpen;

      if(openImage.ShowDialog() == DialogResult.OK)
      {
        sourceImage.Image = new Bitmap(openImage.FileName);
        sourceBitmap = new Bitmap(sourceImage.Image);
        resultImage.Image = Helpers.GetImageInColorScale(new Bitmap(sourceBitmap));
        resultImgSpectrum.Image = null;
        btnSaveImage.Enabled = true;
        btnResetImage.Enabled = true;
        grboxFiltering.Enabled = true;
        DrowSourceSpectrum();
        DrowChartSpectrum();
      }
    }

    private void btnSaveImage_Click(object sender, EventArgs e)
    {
      if(resultImage.Image != null)
      {
        saveImage.DefaultExt = ImageFormatSettings.ExtensionForSave;
        saveImage.Filter = ImageFormatSettings.ExtensionsPatternsForOpen;

        if(saveImage.ShowDialog() == DialogResult.OK)
        {
          resultImage.Image.Save(saveImage.FileName, ImageFormat.Bmp);
        }
      }
    }

    //Сброс обрабатываемого изображения в исходное состояние
    private void btnResetImage_Click(object sender, EventArgs e)
    {
      resultImage.Image = Helpers.GetImageInColorScale(new Bitmap(sourceBitmap));
      resultImgSpectrum.Image = null;
    }

    //Применение Идеального фильтра низких частот
    private void btnLowPassFilter_Click(object sender, EventArgs e)
    {
      resultImage.Image = Filter.FilterIdealLowPass(new Bitmap(resultImage.Image), GetCurrentCutOffFrequency());
      DrowFilteredImageSpectrum();
    }

    //Применение Гауссова фильтра низких частот
    private void btnGaussLowPassFilter_Click(object sender, EventArgs e)
    {
      resultImage.Image = Filter.FilterGaussLowPass(new Bitmap(resultImage.Image), GetCurrentCutOffFrequency());
      DrowFilteredImageSpectrum();
    }

    //Отрисовка спектра исходного изображения
    private void DrowSourceSpectrum()
    {
      srcImgSpectrum.Image = Helpers.GetImageSpectrum(new Bitmap(sourceBitmap));
    }

    private void DrowChartSpectrum()
    {
      int length = sourceBitmap.Width;
      int height = sourceBitmap.Height;
      double[,] fxy = Helpers.GetBitmapFunction(new Bitmap(sourceBitmap));
      fxy = Helpers.CenteringFunction(fxy);
      FourierResult[] fr = Fourier.DFT2D(fxy);

      #region Инициализация графика

      chart1.Series.Clear();
      Series s = chart1.Series.Add("Спектр");
      chart1.Series[0].ChartType = SeriesChartType.Spline;
      chart1.Series[0].BorderWidth = 3;

      #endregion

      #region Нахождение минимального и максимального значений, логарифмирование

      int MIN_COLOR = 0;
      int MAX_COLOR = 255;
      double min = 0;
      double max = 0;
      double tempValue;
      for(int i = 0; i < height; i++)
      {
        for(int j = 0; j < length; j++)
        {
          tempValue = fr[i].Spectrum[j];
          tempValue = tempValue > 0 ? Math.Log10(tempValue) : 0;
          if(tempValue < min) min = tempValue;
          if(tempValue > max) max = tempValue;
          fr[i].Spectrum[j] = tempValue;
        }
      }

      #endregion

      #region Вывод графика спектра

      int center = height / 2;
      for (int i = 0; i <= length - 1; i++)
      {
        s.Points.AddXY(i, (byte)Helpers.GetProportionalValue(fr[center].Spectrum[i], min, max, MIN_COLOR, MAX_COLOR));
      }

      #endregion
    }

    //Отрисовка спектра отфильтрованного изображения
    private void DrowFilteredImageSpectrum()
    {
      resultImgSpectrum.Image = Helpers.GetImageSpectrum(new Bitmap(resultImage.Image));
    }

    //Получение введенной частоты среза
    private double GetCurrentCutOffFrequency()
    {
      return Convert.ToDouble(numCutOffFrequency.Value);
    }

    private void grboxFiltering_Enter(object sender, EventArgs e)
    {

    }
  }
}