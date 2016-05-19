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

namespace FilteringImage3
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();

    }

    private void btnRun_Click(object sender, EventArgs e)
    {
      Projections data = File.GetProjections();
      int pointsCount = data.PointsCount;
      double[,] fxy = Imaging.reverseProjection(data);
      imgResult.Image = Helpers.GenerateBitmap(fxy);

      //for(int i = 0; i < pointsCount; i++)
      //{
      //  for(int j = 0; j < pointsCount; j++)
      //  {
      //    txbOutput.AppendText(fxy[i, j].ToString());
      //  }
      //}
    }
  }
}