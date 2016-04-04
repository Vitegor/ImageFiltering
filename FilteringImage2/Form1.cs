﻿using System;
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
      srcImgSpectrum.Image = Fourier.GetImageSpectrum(new Bitmap(sourceBitmap));
    }

    private void DrowChartSpectrum()
    {
      double[,] fxy = Helpers.GetBitmapFunction(new Bitmap(sourceBitmap));
      int m = sourceBitmap.Width;
      int n = sourceBitmap.Height;
      int center = n / 2;
      fxy = Helpers.CenteringFunction(fxy);
      FourierResult[] fr = Fourier.DFT2D(fxy);

      chart1.Series.Clear();
      Series s = chart1.Series.Add("Спектр");
      chart1.Series[0].ChartType = SeriesChartType.Spline;
      chart1.Series[0].BorderWidth = 3;

      for (int x = 0; x <= m - 1; x++)
      {
        s.Points.AddXY(x, Math.Log10(fr[center].Spectrum[x]));
      }
    }

    //Отрисовка спектра отфильтрованного изображения
    private void DrowFilteredImageSpectrum()
    {
      resultImgSpectrum.Image = Fourier.GetImageSpectrum(new Bitmap(resultImage.Image));
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