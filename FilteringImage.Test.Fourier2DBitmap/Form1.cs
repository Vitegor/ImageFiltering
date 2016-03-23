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
      int m = 90;
      int n = 150;

      double[][] a = new double[n][];
      FourierResult[] result = new FourierResult[n];

      Console.WriteLine("========== Исходная функция ==========");
      for(int i = 0; i <= n - 1; i++)
      {
        a[i] = new double[m];
        for(int j = 0; j <= m - 1; j++)
        {
          a[i][j] = 1;
        }
      }

      result = Fourier.DFT2D(a);
      Bitmap bm = new Bitmap(m, n);

      int y = 0;
      double temp;
      byte gray = 0;

      Console.WriteLine("========== Спектр ==========");

      for(int x = 0; x <= m - 1; x++)
      {
        y = 0;
        FourierResult res = result[x];
        foreach(var item in res.Spectrum)
        {
          temp = item > 255 ? 255 : item;
          gray = (byte)(0.2125 * temp + 0.7154 * temp + 0.0721 * temp);
          bm.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
          y++;
        }
      }

      pictureBox1.Image = bm;
    }
  }
}
