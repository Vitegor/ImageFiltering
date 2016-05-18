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
      Projection[] data = File.GetProjections();

      foreach(Projection proj in data)
      {
        foreach(double value in proj.Data)
          txbOutput.AppendText(String.Format("{0} \n", value));
      }
    }
  }
}