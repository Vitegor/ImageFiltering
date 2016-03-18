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

    private void btnResetImage_Click(object sender, EventArgs e)
    {
      resultImage.Image = sourceImage.Image;
      chboxChannelRed.Checked = true;
      chboxChannelGreen.Checked = true;
      chboxChannelBlue.Checked = true;
    }

    private void btnAddNoiseBipolar_Click(object sender, EventArgs e)
    {
      //Bitmap bitmap = new Bitmap(resultImage.Image);
      //resultImage.Image = Noise.AddBipolarNoise(bitmap);
    }

    private void btnAddNoiseUnipolarSalt_Click(object sender, EventArgs e)
    {
      //Bitmap bitmap = new Bitmap(resultImage.Image);
      //resultImage.Image = Noise.AddUnipolarSaltNoise(bitmap);
    }

    private void btnAddNoiseUnipolarPepper_Click(object sender, EventArgs e)
    {
      //Bitmap bitmap = new Bitmap(resultImage.Image);
      //resultImage.Image = Noise.AddUnipolarPepperNoise(bitmap);
    }
  }
}
