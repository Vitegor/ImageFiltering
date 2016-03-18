using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using FilteringImage.Core;

namespace FilteringImage
{
  public partial class formMain : Form
  {
    //Битовая карта исходной изображения
    private static Bitmap sourceBitmap;
    
    //Размерности масок
    private static byte[] maskGrades = new byte[] { 3, 5, 9 };

    //Порядки фильтра средненго контргармонического
    private static double[] harmonicFilterGrade = new double[] { -1, 0, 1 };

    //Инициализация формы
    public formMain()
    {
      InitializeComponent();
      cboxMaskSize.SelectedIndex = 0;
      cboxCounterHarmonicFilterGrade.SelectedIndex = 1;
    }

    //Загрузка изображения в программу
    private void btnGetImage_Click(object sender, EventArgs e)
    {
      openImage.Filter = ImageFormatSettings.ExtensionsPatternsForOpen;

      if (openImage.ShowDialog() == DialogResult.OK)
      {
        sourceImage.Image = new Bitmap(openImage.FileName);
        resultImage.Image = (Image)sourceImage.Image.Clone();
        sourceBitmap = new Bitmap(sourceImage.Image);
        btnSaveImage.Enabled = true;
        btnResetImage.Enabled = true;
        grboxColorChannel.Enabled = true;
        grboxNoise.Enabled = true;
        grboxFiltering.Enabled = true;
      }
    }

    //Сохранение изображения
    private void btnSaveImage_Click(object sender, EventArgs e)
    {
      if (resultImage.Image != null)
      {
        saveImage.DefaultExt = ImageFormatSettings.ExtensionForSave;
        saveImage.Filter = ImageFormatSettings.ExtensionsPatternsForOpen;

        if (saveImage.ShowDialog() == DialogResult.OK)
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

    //Применение контргармонического фильтра
    private void btnFilterCounterHarmonic_Click(object sender, EventArgs e)
    {
      resultImage.Image = Filter.FilterCounterHarmonic(
        new Bitmap(resultImage.Image),
        maskGrades[(byte)cboxMaskSize.SelectedIndex],
        harmonicFilterGrade[(byte)cboxCounterHarmonicFilterGrade.SelectedIndex]);
    }

    //Применение фильтра стредней точки
    private void btnFilterMidpoint_Click(object sender, EventArgs e)
    {
      resultImage.Image = Filter.FilterMidpoint(
        new Bitmap(resultImage.Image),
         maskGrades[(byte)cboxMaskSize.SelectedIndex]);
    }

    //Получение текущего выбранного цветового канала
    private RGBChannel GetCurrentColorChannel()
    {
      RGBChannel colorChannel = RGBChannel.Red;
      if(rdoGreen.Checked) colorChannel = RGBChannel.Green;
      if(rdoBlue.Checked) colorChannel = RGBChannel.Blue;
      return colorChannel;
    }
  }
}