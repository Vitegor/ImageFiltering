using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using FilteringImage.Core;

namespace FilteringImage2
{
  public partial class Form1 : Form
  {
    private static Bitmap sourceBitmap;

    public Form1()
    {
      InitializeComponent();
    }

    //Открытыие изображения
    private void btnGetImage_Click(object sender, EventArgs e)
    {
      openImage.Filter = ImageFormatSettings.ExtensionsPatternsForOpen;

      if(openImage.ShowDialog() == DialogResult.OK)
      {
        sourceImage.Image = new Bitmap(openImage.FileName);
        sourceBitmap = new Bitmap(sourceImage.Image);
        resultImage.Image = Helpers.GetImageInColorScale(new Bitmap(sourceBitmap));
        resultImgSpectrum.Image = null;
        imgSpectrumFilter.Image = null;
        btnSaveImage.Enabled = true;
        btnResetImage.Enabled = true;
        grboxFiltering.Enabled = true;
        DrowSourceSpectrum();
      }
    }

    //Сохранение изображения
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
      imgSpectrumFilter.Image = null;
      lblResultImageEnergy.Text = "null";
    }

    //Применение Идеального фильтра низких частот
    private void btnLowPassFilter_Click(object sender, EventArgs e)
    {
      FilterResult fr = Filter.FilterIdealLowPass(new Bitmap(resultImage.Image), GetCurrentCutOffFrequency());
      resultImage.Image = fr.Bitmap;
      imgSpectrumFilter.Image = fr.FilterSpectrum;
      lblResultImageEnergy.Text = Convert.ToString(fr.Energy);
      DrowFilteredImageSpectrum();
    }

    //Применение Гауссова фильтра низких частот
    private void btnGaussLowPassFilter_Click(object sender, EventArgs e)
    {
      FilterResult fr = Filter.FilterGaussLowPass(new Bitmap(resultImage.Image), GetCurrentCutOffFrequency());
      resultImage.Image = fr.Bitmap;
      imgSpectrumFilter.Image = fr.FilterSpectrum;
      lblResultImageEnergy.Text = Convert.ToString(fr.Energy);
      DrowFilteredImageSpectrum();
    }

    //Отрисовка спектра исходного изображения
    private void DrowSourceSpectrum()
    {
      srcImgSpectrum.Image = Helpers.GetImageSpectrum(new Bitmap(sourceBitmap));
    }

    //Отрисовка спектра отфильтрованного изображения
    private void DrowFilteredImageSpectrum()
    {
      resultImgSpectrum.Image = Helpers.GetImageSpectrum(new Bitmap(resultImage.Image));
    }

    //Получение введенной частоты среза
    private double GetCurrentCutOffFrequency()
    {
      if (!(numCutOffFrequency.Value <= 0))
        return Convert.ToDouble(numCutOffFrequency.Value);

      return 0.001;
    }
  }
}