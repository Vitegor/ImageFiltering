using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FilteringImage.Core;

namespace FilteringImage.Test.Fourier2DBitmap
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      int m = 150;
      int n = 180;

      double[,] fxy = new double[n, m];
      FourierResult[] result = new FourierResult[n];

      Console.WriteLine("========== Исходная функция ==========");
      for(int i = 0; i <= n - 1; i++)
      {
        for(int j = 0; j <= m - 1; j++) fxy[i, j] = 1 * Helpers.Step(i + j);
      }

      result = Fourier.DFT2D(fxy);
      Bitmap bm = new Bitmap(m, n);

      Console.WriteLine("========== Спектр ==========");
      int x, y = 0;
      byte gray = 0;

      foreach(var row in result)
      {
        x = 0;
        foreach(var item in row.Spectrum)
        {
          gray = ColorChannel.ToGray(item, item, item);
          bm.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
          x++;
        }
        y++;
      }

      pictureBox1.Image = bm;
    }
  }
}