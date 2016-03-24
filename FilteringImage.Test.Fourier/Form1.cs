using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core = FilteringImage.Core;
using System.Windows.Forms.DataVisualization.Charting;

namespace FilteringImage.Test.Fourier
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      SeriesChartType CHART_TYPE = SeriesChartType.Spline;
      int LINE_WIDTH = 3;
      int m = 15;
      int length = m - 1;
      double[] fx = new double[m];

      Series sourceSeries = chartSource.Series.Add("Исходный сигнал");
      Series spectrumSeries = chartSpectrum.Series.Add("Спектр преобразования Фурье");
      Series reSeries = chartRe.Series.Add("Действительная часть");
      Series imSeries = chartIm.Series.Add("Мнимая часть");

      for(int i = 0; i <= length; i++) fx[i] = 1;
      for(int i = 0; i <= length; i++) sourceSeries.Points.AddXY(i, fx[i]);
      for(int i = 0; i <= length; i++) fx[i] = fx[i] * Core.Fourier.Step(i);

      Core.FourierResult fourierResult = Core.Fourier.DFT(fx);

      chartSource.Series[0].ChartType = CHART_TYPE;
      chartSpectrum.Series[0].ChartType = CHART_TYPE;
      chartRe.Series[0].ChartType = CHART_TYPE;
      chartIm.Series[0].ChartType = CHART_TYPE;

      chartSource.Series[0].BorderWidth = LINE_WIDTH;
      chartSpectrum.Series[0].BorderWidth = LINE_WIDTH;
      chartRe.Series[0].BorderWidth = LINE_WIDTH;
      chartIm.Series[0].BorderWidth = LINE_WIDTH;

      for(int i = 0; i <= length; i++)
      {
        spectrumSeries.Points.AddXY(i, fourierResult.Spectrum[i]);
        reSeries.Points.AddXY(i, fourierResult.Re[i]);
        imSeries.Points.AddXY(i, fourierResult.Im[i]);
      }
    }
  }
}