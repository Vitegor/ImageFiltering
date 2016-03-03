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

namespace FilteringImage
{
  public partial class formMain : Form
  {
    private static Bitmap sourceBitmap;

    public formMain()
    {
      InitializeComponent();
      cboxMaskSize.SelectedIndex = 0;
      cboxCounterHarmonicFilterGrade.SelectedIndex = 1;
    }

    private void btnGetImage_Click(object sender, EventArgs e)
    {
      openImage.Filter = "BMP files (*.bmp) | *.bmp;";

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

    private void btnSaveImage_Click(object sender, EventArgs e)
    {
      if (resultImage.Image != null)
      {
        saveImage.DefaultExt = ".bmp";
        saveImage.Filter = "BMP images (*.bmp) | *.bmp;";

        if (saveImage.ShowDialog() == DialogResult.OK)
        {
          resultImage.Image.Save(saveImage.FileName, ImageFormat.Bmp);
        }
      }
    }

    private void btnResetImage_Click(object sender, EventArgs e)
    {
      resultImage.Image = sourceImage.Image;
    }

    private void chboxChannelRed_CheckedChanged(object sender, EventArgs e)
    {
      Bitmap resultBitmap = new Bitmap(resultImage.Image);

      if (chboxChannelRed.Checked == false)
        resultImage.Image = ColorChannel.HideRedChannel(resultBitmap);
      else
        resultImage.Image = ColorChannel.ShowRedChannel(sourceBitmap, resultBitmap);
    }

    private void chboxChannelGreen_CheckedChanged(object sender, EventArgs e)
    {
      Bitmap resultBitmap = new Bitmap(resultImage.Image);

      if (chboxChannelGreen.Checked == false)
        resultImage.Image = ColorChannel.HideGreenChannel(resultBitmap);
      else
        resultImage.Image = ColorChannel.ShowGreenChannel(sourceBitmap, resultBitmap);
    }

    private void chboxChannelBlue_CheckedChanged(object sender, EventArgs e)
    {
      Bitmap resultBitmap = new Bitmap(resultImage.Image);

      if (chboxChannelBlue.Checked == false)
        resultImage.Image = ColorChannel.HideBlueChannel(resultBitmap);
      else
        resultImage.Image = ColorChannel.ShowBlueChannel(sourceBitmap, resultBitmap);
    }

    private void btnAddNoiseBipolar_Click(object sender, EventArgs e)
    {
      Bitmap bitmap = new Bitmap(resultImage.Image);
      resultImage.Image = Noise.AddBipolarNoise(bitmap);
    }

    private void btnAddNoiseUnipolarSalt_Click(object sender, EventArgs e)
    {
      Bitmap bitmap = new Bitmap(resultImage.Image);
      resultImage.Image = Noise.AddUnipolarSaltNoise(bitmap);
    }

    private void btnAddNoiseUnipolarPepper_Click(object sender, EventArgs e)
    {
      Bitmap bitmap = new Bitmap(resultImage.Image);
      resultImage.Image = Noise.AddUnipolarPepperNoise(bitmap);
    }

    private void btnFilterCounterHarmonic_Click(object sender, EventArgs e)
    {
      resultImage.Image = Filter.FilterCounterHarmonic(
        new Bitmap(resultImage.Image),
        (byte)cboxMaskSize.SelectedIndex,
        (byte)cboxCounterHarmonicFilterGrade.SelectedIndex);
    }

    private void btnFilterMidpoint_Click(object sender, EventArgs e)
    {
      resultImage.Image = Filter.FilterMidpoint(
        new Bitmap(resultImage.Image),
        (byte)cboxMaskSize.SelectedIndex);
    }
  }
}