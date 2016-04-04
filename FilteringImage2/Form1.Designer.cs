namespace FilteringImage2
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
      this.resultImage = new System.Windows.Forms.PictureBox();
      this.sourceImage = new System.Windows.Forms.PictureBox();
      this.btnResetImage = new System.Windows.Forms.Button();
      this.btnSaveImage = new System.Windows.Forms.Button();
      this.btnGetImage = new System.Windows.Forms.Button();
      this.saveImage = new System.Windows.Forms.SaveFileDialog();
      this.openImage = new System.Windows.Forms.OpenFileDialog();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.srcImgSpectrum = new System.Windows.Forms.PictureBox();
      this.resultImgSpectrum = new System.Windows.Forms.PictureBox();
      this.btnLowPassFilter = new System.Windows.Forms.Button();
      this.grboxFiltering = new System.Windows.Forms.GroupBox();
      this.numCutOffFrequency = new System.Windows.Forms.NumericUpDown();
      this.lblResultImageEnergy = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.btnGaussLowPassFilter = new System.Windows.Forms.Button();
      this.imgSpectrumFilter = new System.Windows.Forms.PictureBox();
      this.label5 = new System.Windows.Forms.Label();
      this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
      ((System.ComponentModel.ISupportInitialize)(this.resultImage)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.sourceImage)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.srcImgSpectrum)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.resultImgSpectrum)).BeginInit();
      this.grboxFiltering.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numCutOffFrequency)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.imgSpectrumFilter)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
      this.SuspendLayout();
      // 
      // resultImage
      // 
      this.resultImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.resultImage.Location = new System.Drawing.Point(16, 277);
      this.resultImage.Name = "resultImage";
      this.resultImage.Size = new System.Drawing.Size(340, 210);
      this.resultImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.resultImage.TabIndex = 8;
      this.resultImage.TabStop = false;
      // 
      // sourceImage
      // 
      this.sourceImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.sourceImage.Location = new System.Drawing.Point(16, 29);
      this.sourceImage.Name = "sourceImage";
      this.sourceImage.Size = new System.Drawing.Size(340, 210);
      this.sourceImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.sourceImage.TabIndex = 7;
      this.sourceImage.TabStop = false;
      // 
      // btnResetImage
      // 
      this.btnResetImage.Enabled = false;
      this.btnResetImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnResetImage.Location = new System.Drawing.Point(972, 29);
      this.btnResetImage.Name = "btnResetImage";
      this.btnResetImage.Size = new System.Drawing.Size(123, 30);
      this.btnResetImage.TabIndex = 15;
      this.btnResetImage.Text = "Reset Image";
      this.btnResetImage.UseVisualStyleBackColor = true;
      this.btnResetImage.Click += new System.EventHandler(this.btnResetImage_Click);
      // 
      // btnSaveImage
      // 
      this.btnSaveImage.Enabled = false;
      this.btnSaveImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnSaveImage.Location = new System.Drawing.Point(866, 28);
      this.btnSaveImage.Name = "btnSaveImage";
      this.btnSaveImage.Size = new System.Drawing.Size(100, 30);
      this.btnSaveImage.TabIndex = 13;
      this.btnSaveImage.Text = "Save Image";
      this.btnSaveImage.UseVisualStyleBackColor = true;
      this.btnSaveImage.Click += new System.EventHandler(this.btnSaveImage_Click);
      // 
      // btnGetImage
      // 
      this.btnGetImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnGetImage.Location = new System.Drawing.Point(760, 28);
      this.btnGetImage.Name = "btnGetImage";
      this.btnGetImage.Size = new System.Drawing.Size(100, 30);
      this.btnGetImage.TabIndex = 12;
      this.btnGetImage.Text = "Get Image";
      this.btnGetImage.UseVisualStyleBackColor = true;
      this.btnGetImage.Click += new System.EventHandler(this.btnGetImage_Click);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label2.Location = new System.Drawing.Point(12, 13);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(73, 13);
      this.label2.TabIndex = 19;
      this.label2.Text = "Source Image";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label3.Location = new System.Drawing.Point(13, 261);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(69, 13);
      this.label3.TabIndex = 20;
      this.label3.Text = "Result Image";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label1.Location = new System.Drawing.Point(392, 13);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(89, 13);
      this.label1.TabIndex = 21;
      this.label1.Text = "Source Spectrum";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label4.Location = new System.Drawing.Point(392, 261);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(85, 13);
      this.label4.TabIndex = 22;
      this.label4.Text = "Result Spectrum";
      // 
      // srcImgSpectrum
      // 
      this.srcImgSpectrum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.srcImgSpectrum.Location = new System.Drawing.Point(395, 29);
      this.srcImgSpectrum.Name = "srcImgSpectrum";
      this.srcImgSpectrum.Size = new System.Drawing.Size(340, 210);
      this.srcImgSpectrum.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.srcImgSpectrum.TabIndex = 23;
      this.srcImgSpectrum.TabStop = false;
      // 
      // resultImgSpectrum
      // 
      this.resultImgSpectrum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.resultImgSpectrum.Location = new System.Drawing.Point(395, 277);
      this.resultImgSpectrum.Name = "resultImgSpectrum";
      this.resultImgSpectrum.Size = new System.Drawing.Size(340, 210);
      this.resultImgSpectrum.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.resultImgSpectrum.TabIndex = 25;
      this.resultImgSpectrum.TabStop = false;
      // 
      // btnLowPassFilter
      // 
      this.btnLowPassFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnLowPassFilter.Location = new System.Drawing.Point(16, 68);
      this.btnLowPassFilter.Name = "btnLowPassFilter";
      this.btnLowPassFilter.Size = new System.Drawing.Size(174, 30);
      this.btnLowPassFilter.TabIndex = 26;
      this.btnLowPassFilter.Text = "Low Pass Filter";
      this.btnLowPassFilter.UseVisualStyleBackColor = true;
      this.btnLowPassFilter.Click += new System.EventHandler(this.btnLowPassFilter_Click);
      // 
      // grboxFiltering
      // 
      this.grboxFiltering.Controls.Add(this.numCutOffFrequency);
      this.grboxFiltering.Controls.Add(this.lblResultImageEnergy);
      this.grboxFiltering.Controls.Add(this.label7);
      this.grboxFiltering.Controls.Add(this.label6);
      this.grboxFiltering.Controls.Add(this.btnGaussLowPassFilter);
      this.grboxFiltering.Controls.Add(this.btnLowPassFilter);
      this.grboxFiltering.Enabled = false;
      this.grboxFiltering.Location = new System.Drawing.Point(760, 77);
      this.grboxFiltering.Name = "grboxFiltering";
      this.grboxFiltering.Size = new System.Drawing.Size(335, 161);
      this.grboxFiltering.TabIndex = 27;
      this.grboxFiltering.TabStop = false;
      this.grboxFiltering.Text = "Filtering";
      this.grboxFiltering.Enter += new System.EventHandler(this.grboxFiltering_Enter);
      // 
      // numCutOffFrequency
      // 
      this.numCutOffFrequency.Location = new System.Drawing.Point(123, 32);
      this.numCutOffFrequency.Name = "numCutOffFrequency";
      this.numCutOffFrequency.Size = new System.Drawing.Size(120, 20);
      this.numCutOffFrequency.TabIndex = 34;
      // 
      // lblResultImageEnergy
      // 
      this.lblResultImageEnergy.AutoSize = true;
      this.lblResultImageEnergy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblResultImageEnergy.Location = new System.Drawing.Point(246, 98);
      this.lblResultImageEnergy.Name = "lblResultImageEnergy";
      this.lblResultImageEnergy.Size = new System.Drawing.Size(37, 20);
      this.lblResultImageEnergy.TabIndex = 33;
      this.lblResultImageEnergy.Text = "null";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label7.Location = new System.Drawing.Point(209, 68);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(108, 13);
      this.label7.TabIndex = 32;
      this.label7.Text = "Result Image Energy:";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label6.Location = new System.Drawing.Point(22, 32);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(94, 13);
      this.label6.TabIndex = 30;
      this.label6.Text = "Cut-off Frequency:";
      // 
      // btnGaussLowPassFilter
      // 
      this.btnGaussLowPassFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnGaussLowPassFilter.Location = new System.Drawing.Point(16, 113);
      this.btnGaussLowPassFilter.Name = "btnGaussLowPassFilter";
      this.btnGaussLowPassFilter.Size = new System.Drawing.Size(174, 30);
      this.btnGaussLowPassFilter.TabIndex = 27;
      this.btnGaussLowPassFilter.Text = "Gauss Low Pass Filter";
      this.btnGaussLowPassFilter.UseVisualStyleBackColor = true;
      this.btnGaussLowPassFilter.Click += new System.EventHandler(this.btnGaussLowPassFilter_Click);
      // 
      // imgSpectrumFilter
      // 
      this.imgSpectrumFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.imgSpectrumFilter.Location = new System.Drawing.Point(758, 277);
      this.imgSpectrumFilter.Name = "imgSpectrumFilter";
      this.imgSpectrumFilter.Size = new System.Drawing.Size(340, 210);
      this.imgSpectrumFilter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.imgSpectrumFilter.TabIndex = 28;
      this.imgSpectrumFilter.TabStop = false;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label5.Location = new System.Drawing.Point(757, 261);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(77, 13);
      this.label5.TabIndex = 29;
      this.label5.Text = "Filter Spectrum";
      // 
      // chart1
      // 
      chartArea1.Name = "ChartArea1";
      this.chart1.ChartAreas.Add(chartArea1);
      this.chart1.Location = new System.Drawing.Point(758, 277);
      this.chart1.Name = "chart1";
      this.chart1.Size = new System.Drawing.Size(340, 210);
      this.chart1.TabIndex = 30;
      this.chart1.Text = "chart1";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1117, 505);
      this.Controls.Add(this.chart1);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.imgSpectrumFilter);
      this.Controls.Add(this.grboxFiltering);
      this.Controls.Add(this.resultImgSpectrum);
      this.Controls.Add(this.srcImgSpectrum);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.btnResetImage);
      this.Controls.Add(this.btnSaveImage);
      this.Controls.Add(this.btnGetImage);
      this.Controls.Add(this.resultImage);
      this.Controls.Add(this.sourceImage);
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Filtering Image 2";
      ((System.ComponentModel.ISupportInitialize)(this.resultImage)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.sourceImage)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.srcImgSpectrum)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.resultImgSpectrum)).EndInit();
      this.grboxFiltering.ResumeLayout(false);
      this.grboxFiltering.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numCutOffFrequency)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.imgSpectrumFilter)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox resultImage;
    private System.Windows.Forms.PictureBox sourceImage;
    private System.Windows.Forms.Button btnResetImage;
    private System.Windows.Forms.Button btnSaveImage;
    private System.Windows.Forms.Button btnGetImage;
    private System.Windows.Forms.SaveFileDialog saveImage;
    private System.Windows.Forms.OpenFileDialog openImage;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.PictureBox srcImgSpectrum;
    private System.Windows.Forms.PictureBox resultImgSpectrum;
    private System.Windows.Forms.Button btnLowPassFilter;
    private System.Windows.Forms.GroupBox grboxFiltering;
    private System.Windows.Forms.Button btnGaussLowPassFilter;
    private System.Windows.Forms.PictureBox imgSpectrumFilter;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label lblResultImageEnergy;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.NumericUpDown numCutOffFrequency;
    private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
  }
}

