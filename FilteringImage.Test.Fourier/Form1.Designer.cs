namespace FilteringImage.Test.Fourier
{
  partial class Form1
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if(disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
      System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
      System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
      System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
      System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
      System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
      System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
      System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
      this.chartSource = new System.Windows.Forms.DataVisualization.Charting.Chart();
      this.chartSpectrum = new System.Windows.Forms.DataVisualization.Charting.Chart();
      this.chartRe = new System.Windows.Forms.DataVisualization.Charting.Chart();
      this.chartIm = new System.Windows.Forms.DataVisualization.Charting.Chart();
      ((System.ComponentModel.ISupportInitialize)(this.chartSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.chartSpectrum)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.chartRe)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.chartIm)).BeginInit();
      this.SuspendLayout();
      // 
      // chartSource
      // 
      this.chartSource.BorderlineWidth = 3;
      this.chartSource.BorderSkin.BorderWidth = 3;
      chartArea1.Name = "ChartArea1";
      this.chartSource.ChartAreas.Add(chartArea1);
      legend1.Alignment = System.Drawing.StringAlignment.Center;
      legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
      legend1.Name = "Legend1";
      this.chartSource.Legends.Add(legend1);
      this.chartSource.Location = new System.Drawing.Point(13, 12);
      this.chartSource.Name = "chartSource";
      this.chartSource.Size = new System.Drawing.Size(469, 300);
      this.chartSource.TabIndex = 0;
      this.chartSource.Text = "chart1";
      // 
      // chartSpectrum
      // 
      this.chartSpectrum.BorderlineWidth = 3;
      this.chartSpectrum.BorderSkin.BorderWidth = 3;
      chartArea2.Name = "ChartArea1";
      this.chartSpectrum.ChartAreas.Add(chartArea2);
      legend2.Alignment = System.Drawing.StringAlignment.Center;
      legend2.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Top;
      legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
      legend2.Name = "Legend1";
      this.chartSpectrum.Legends.Add(legend2);
      this.chartSpectrum.Location = new System.Drawing.Point(502, 12);
      this.chartSpectrum.Name = "chartSpectrum";
      this.chartSpectrum.Size = new System.Drawing.Size(464, 300);
      this.chartSpectrum.TabIndex = 1;
      this.chartSpectrum.Text = "chart2";
      // 
      // chartRe
      // 
      this.chartRe.BorderlineWidth = 3;
      this.chartRe.BorderSkin.BorderWidth = 3;
      chartArea3.Name = "ChartArea1";
      this.chartRe.ChartAreas.Add(chartArea3);
      legend3.Alignment = System.Drawing.StringAlignment.Center;
      legend3.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
      legend3.Name = "Legend1";
      this.chartRe.Legends.Add(legend3);
      this.chartRe.Location = new System.Drawing.Point(13, 331);
      this.chartRe.Name = "chartRe";
      this.chartRe.Size = new System.Drawing.Size(469, 300);
      this.chartRe.TabIndex = 2;
      this.chartRe.Text = "chart3";
      // 
      // chartIm
      // 
      this.chartIm.BorderlineWidth = 3;
      this.chartIm.BorderSkin.BorderWidth = 3;
      chartArea4.Name = "ChartArea1";
      this.chartIm.ChartAreas.Add(chartArea4);
      legend4.Alignment = System.Drawing.StringAlignment.Center;
      legend4.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
      legend4.Name = "Legend1";
      this.chartIm.Legends.Add(legend4);
      this.chartIm.Location = new System.Drawing.Point(502, 331);
      this.chartIm.Name = "chartIm";
      this.chartIm.Size = new System.Drawing.Size(464, 300);
      this.chartIm.TabIndex = 3;
      this.chartIm.Text = "chart4";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(982, 642);
      this.Controls.Add(this.chartIm);
      this.Controls.Add(this.chartRe);
      this.Controls.Add(this.chartSpectrum);
      this.Controls.Add(this.chartSource);
      this.Name = "Form1";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      ((System.ComponentModel.ISupportInitialize)(this.chartSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.chartSpectrum)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.chartRe)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.chartIm)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.DataVisualization.Charting.Chart chartSource;
    private System.Windows.Forms.DataVisualization.Charting.Chart chartSpectrum;
    private System.Windows.Forms.DataVisualization.Charting.Chart chartRe;
    private System.Windows.Forms.DataVisualization.Charting.Chart chartIm;
  }
}

