﻿using System;
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
      
    }

    private void button1_Click(object sender, EventArgs e)
    {
      SeriesChartType CHART_TYPE = SeriesChartType.Spline;
      int LINE_WIDTH = 3;
      int M = 100;
      double[] fx = new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
      Core.FourierResult fourierResult = Core.Fourier.DiscreteFourierTransform(fx);

      Series sourceSeries= chartSource.Series.Add("Исходный сигнал");
      Series spectrumSeries = chartSpectrum.Series.Add("Спектр преобразования Фурье");
      Series reSeries = chartRe.Series.Add("Действительная часть");
      Series imSeries = chartIm.Series.Add("Мнимая часть");

      chartSource.Series[0].ChartType = CHART_TYPE;
      chartSpectrum.Series[0].ChartType = CHART_TYPE;
      chartRe.Series[0].ChartType = CHART_TYPE;
      chartIm.Series[0].ChartType = CHART_TYPE;

      chartSource.Series[0].BorderWidth = LINE_WIDTH;
      chartSpectrum.Series[0].BorderWidth = LINE_WIDTH;
      chartRe.Series[0].BorderWidth = LINE_WIDTH;
      chartIm.Series[0].BorderWidth = LINE_WIDTH;

      for(byte i = 0; i <= fx.Length - 1; i++)
      {
        sourceSeries.Points.AddXY(i, fx[i]);
      }

      for(byte i = 0; i <= M - 1; i++)
      {
        spectrumSeries.Points.AddXY(i, fourierResult.FourierSpectrum[i]);
        reSeries.Points.AddXY(i, fourierResult.ReDFT[i]);
        imSeries.Points.AddXY(i, fourierResult.ImDFT[i]);
      }
    }
  }
}