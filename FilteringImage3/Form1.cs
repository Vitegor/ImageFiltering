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

namespace FilteringImage3
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();

    }

    //Получение данных из файла
    private void btnRun_Click(object sender, EventArgs e)
    {
      Projections data = File.GetProjections();
      int pointsCount = data.PointsCount;
      double[,] fxy = Imaging.reverseProjection(data);
      imgResult.Image = Helpers.GetProportionalImage(fxy);
    }

    //Применение фильтра
    private void btnApplyFilter_Click(object sender, EventArgs e)
    {
      FilterResult fr = Filter.FilterGaussLowPass(new Bitmap(imgResult.Image), GetCurrentCutOffFrequency());
      imgResult.Image = fr.Bitmap;
    }

    //Сохранение изображения
    private void btnSaveImage_Click(object sender, EventArgs e)
    {
      if(imgResult.Image != null)
      {
        saveImage.DefaultExt = ImageFormatSettings.ExtensionForSave;
        saveImage.Filter = ImageFormatSettings.ExtensionsPatternsForOpen;

        if(saveImage.ShowDialog() == DialogResult.OK)
        {
          imgResult.Image.Save(saveImage.FileName, ImageFormat.Bmp);
        }
      }
    }

    //Получение введенной частоты среза
    private double GetCurrentCutOffFrequency()
    {
      if(!(numCutOffFrequency.Value <= 0))
        return Convert.ToDouble(numCutOffFrequency.Value);

      return 0.001;
    }
  }
}