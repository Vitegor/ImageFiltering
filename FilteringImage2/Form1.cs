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
        resultImage.Image = (Image)sourceImage.Image.Clone();
        sourceBitmap = new Bitmap(sourceImage.Image);
        btnSaveImage.Enabled = true;
        btnResetImage.Enabled = true;
        grboxColorChannel.Enabled = true;
        grboxNoise.Enabled = true;
        grboxFiltering.Enabled = true;
        DrowSourceSpectrum(sourceBitmap);
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
      resultImage.Image = sourceImage.Image;
    }

    //Добавление биполярного шума
    private void btnAddNoiseBipolar_Click(object sender, EventArgs e)
    {
      Bitmap bitmap = new Bitmap(resultImage.Image);
      resultImage.Image = Noise.AddBipolarNoise(bitmap, GetCurrentColorChannel());
    }

    //Добавление униполярного соляного шума
    private void btnAddNoiseUnipolarSalt_Click(object sender, EventArgs e)
    {
      Bitmap bitmap = new Bitmap(resultImage.Image);
      resultImage.Image = Noise.AddUnipolarSaltNoise(bitmap, GetCurrentColorChannel());
    }

    //Добавление униполярного перечного шума
    private void btnAddNoiseUnipolarPepper_Click(object sender, EventArgs e)
    {
      Bitmap bitmap = new Bitmap(resultImage.Image);
      resultImage.Image = Noise.AddUnipolarPepperNoise(bitmap, GetCurrentColorChannel());
    }

    //Применение Идеального фильтра низких частот
    private void btnLowPassFilter_Click(object sender, EventArgs e)
    {
      resultImage.Image = Filter.FilterIdealLowPass(new Bitmap(resultImage.Image), GetCurrentCutOffFrequency());
      DrowFilteredImageSpectrum(new Bitmap(resultImage.Image));
    }

    //Применение Гауссова фильтра низких частот
    private void btnGaussLowPassFilter_Click(object sender, EventArgs e)
    {
      resultImage.Image = Filter.FilterGaussLowPass(new Bitmap(resultImage.Image), GetCurrentCutOffFrequency());
      DrowFilteredImageSpectrum(new Bitmap(resultImage.Image));
    }

    //Отрисовка спектра исходного изображения
    private void DrowSourceSpectrum(Bitmap bitmap)
    {
      srcImgSpectrum.Image = Helpers.GetImageSpectrum(bitmap, RGBChannel.Gray);
    }

    //Отрисовка спектра отфильтрованного изображения
    private void DrowFilteredImageSpectrum(Bitmap bitmap)
    {
      resultImgSpectrum.Image = Helpers.GetImageSpectrum(bitmap, RGBChannel.Gray);
    }

    //Получение текущего выбранного цветового канала
    private RGBChannel GetCurrentColorChannel()
    {
      RGBChannel colorChannel = RGBChannel.Red;
      if(rdoGreen.Checked) colorChannel = RGBChannel.Green;
      if(rdoBlue.Checked) colorChannel = RGBChannel.Blue;
      return colorChannel;
    }

    //Получение введенной частоты среза
    private double GetCurrentCutOffFrequency()
    {
      return Convert.ToDouble(txtCutOffFrequency.Text);
    }
  }
}