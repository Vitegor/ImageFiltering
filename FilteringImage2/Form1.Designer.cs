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
      System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
      this.resultImage = new System.Windows.Forms.PictureBox();
      this.sourceImage = new System.Windows.Forms.PictureBox();
      this.btnResetImage = new System.Windows.Forms.Button();
      this.btnSaveImage = new System.Windows.Forms.Button();
      this.btnGetImage = new System.Windows.Forms.Button();
      this.saveImage = new System.Windows.Forms.SaveFileDialog();
      this.openImage = new System.Windows.Forms.OpenFileDialog();
      this.grboxNoise = new System.Windows.Forms.GroupBox();
      this.panel5 = new System.Windows.Forms.Panel();
      this.panel4 = new System.Windows.Forms.Panel();
      this.panel2 = new System.Windows.Forms.Panel();
      this.panel1 = new System.Windows.Forms.Panel();
      this.panel3 = new System.Windows.Forms.Panel();
      this.btnAddNoiseUnipolarPepper = new System.Windows.Forms.Button();
      this.btnAddNoiseBipolar = new System.Windows.Forms.Button();
      this.btnAddNoiseUnipolarSalt = new System.Windows.Forms.Button();
      this.chartResultSpectrum = new System.Windows.Forms.DataVisualization.Charting.Chart();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.srcImgSpectrum = new System.Windows.Forms.PictureBox();
      this.grboxColorChannel = new System.Windows.Forms.GroupBox();
      this.rdoBlue = new System.Windows.Forms.RadioButton();
      this.rdoGreen = new System.Windows.Forms.RadioButton();
      this.rdoRed = new System.Windows.Forms.RadioButton();
      ((System.ComponentModel.ISupportInitialize)(this.resultImage)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.sourceImage)).BeginInit();
      this.grboxNoise.SuspendLayout();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.chartResultSpectrum)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.srcImgSpectrum)).BeginInit();
      this.grboxColorChannel.SuspendLayout();
      this.SuspendLayout();
      // 
      // resultImage
      // 
      this.resultImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.resultImage.Location = new System.Drawing.Point(16, 326);
      this.resultImage.Name = "resultImage";
      this.resultImage.Size = new System.Drawing.Size(450, 290);
      this.resultImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.resultImage.TabIndex = 8;
      this.resultImage.TabStop = false;
      // 
      // sourceImage
      // 
      this.sourceImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.sourceImage.Location = new System.Drawing.Point(16, 29);
      this.sourceImage.Name = "sourceImage";
      this.sourceImage.Size = new System.Drawing.Size(450, 275);
      this.sourceImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.sourceImage.TabIndex = 7;
      this.sourceImage.TabStop = false;
      // 
      // btnResetImage
      // 
      this.btnResetImage.Enabled = false;
      this.btnResetImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnResetImage.Location = new System.Drawing.Point(1001, 60);
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
      this.btnSaveImage.Location = new System.Drawing.Point(1072, 12);
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
      this.btnGetImage.Location = new System.Drawing.Point(952, 12);
      this.btnGetImage.Name = "btnGetImage";
      this.btnGetImage.Size = new System.Drawing.Size(100, 30);
      this.btnGetImage.TabIndex = 12;
      this.btnGetImage.Text = "Get Image";
      this.btnGetImage.UseVisualStyleBackColor = true;
      this.btnGetImage.Click += new System.EventHandler(this.btnGetImage_Click);
      // 
      // grboxNoise
      // 
      this.grboxNoise.Controls.Add(this.panel5);
      this.grboxNoise.Controls.Add(this.panel4);
      this.grboxNoise.Controls.Add(this.panel2);
      this.grboxNoise.Controls.Add(this.panel1);
      this.grboxNoise.Controls.Add(this.btnAddNoiseUnipolarPepper);
      this.grboxNoise.Controls.Add(this.btnAddNoiseBipolar);
      this.grboxNoise.Controls.Add(this.btnAddNoiseUnipolarSalt);
      this.grboxNoise.Enabled = false;
      this.grboxNoise.Location = new System.Drawing.Point(952, 203);
      this.grboxNoise.Name = "grboxNoise";
      this.grboxNoise.Size = new System.Drawing.Size(218, 158);
      this.grboxNoise.TabIndex = 16;
      this.grboxNoise.TabStop = false;
      this.grboxNoise.Text = "Add Noise";
      // 
      // panel5
      // 
      this.panel5.BackColor = System.Drawing.Color.Black;
      this.panel5.Location = new System.Drawing.Point(171, 38);
      this.panel5.Name = "panel5";
      this.panel5.Size = new System.Drawing.Size(15, 15);
      this.panel5.TabIndex = 14;
      // 
      // panel4
      // 
      this.panel4.BackColor = System.Drawing.Color.White;
      this.panel4.Location = new System.Drawing.Point(156, 38);
      this.panel4.Name = "panel4";
      this.panel4.Size = new System.Drawing.Size(15, 15);
      this.panel4.TabIndex = 14;
      // 
      // panel2
      // 
      this.panel2.BackColor = System.Drawing.Color.Black;
      this.panel2.Location = new System.Drawing.Point(171, 110);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(15, 15);
      this.panel2.TabIndex = 13;
      // 
      // panel1
      // 
      this.panel1.BackColor = System.Drawing.Color.White;
      this.panel1.Controls.Add(this.panel3);
      this.panel1.Location = new System.Drawing.Point(171, 74);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(15, 15);
      this.panel1.TabIndex = 12;
      // 
      // panel3
      // 
      this.panel3.BackColor = System.Drawing.Color.White;
      this.panel3.Location = new System.Drawing.Point(0, 0);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(15, 15);
      this.panel3.TabIndex = 13;
      // 
      // btnAddNoiseUnipolarPepper
      // 
      this.btnAddNoiseUnipolarPepper.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnAddNoiseUnipolarPepper.Location = new System.Drawing.Point(23, 102);
      this.btnAddNoiseUnipolarPepper.Name = "btnAddNoiseUnipolarPepper";
      this.btnAddNoiseUnipolarPepper.Size = new System.Drawing.Size(173, 30);
      this.btnAddNoiseUnipolarPepper.TabIndex = 12;
      this.btnAddNoiseUnipolarPepper.Text = "Unipolar Pepper";
      this.btnAddNoiseUnipolarPepper.UseVisualStyleBackColor = true;
      this.btnAddNoiseUnipolarPepper.Click += new System.EventHandler(this.btnAddNoiseUnipolarPepper_Click);
      // 
      // btnAddNoiseBipolar
      // 
      this.btnAddNoiseBipolar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnAddNoiseBipolar.Location = new System.Drawing.Point(23, 30);
      this.btnAddNoiseBipolar.Name = "btnAddNoiseBipolar";
      this.btnAddNoiseBipolar.Size = new System.Drawing.Size(173, 30);
      this.btnAddNoiseBipolar.TabIndex = 6;
      this.btnAddNoiseBipolar.Text = "Bipolar";
      this.btnAddNoiseBipolar.UseVisualStyleBackColor = true;
      this.btnAddNoiseBipolar.Click += new System.EventHandler(this.btnAddNoiseBipolar_Click);
      // 
      // btnAddNoiseUnipolarSalt
      // 
      this.btnAddNoiseUnipolarSalt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnAddNoiseUnipolarSalt.ForeColor = System.Drawing.Color.Black;
      this.btnAddNoiseUnipolarSalt.Location = new System.Drawing.Point(23, 66);
      this.btnAddNoiseUnipolarSalt.Name = "btnAddNoiseUnipolarSalt";
      this.btnAddNoiseUnipolarSalt.Size = new System.Drawing.Size(173, 30);
      this.btnAddNoiseUnipolarSalt.TabIndex = 5;
      this.btnAddNoiseUnipolarSalt.Text = "Unipolar Salt";
      this.btnAddNoiseUnipolarSalt.UseVisualStyleBackColor = true;
      this.btnAddNoiseUnipolarSalt.Click += new System.EventHandler(this.btnAddNoiseUnipolarSalt_Click);
      // 
      // chartResultSpectrum
      // 
      chartArea1.Name = "ChartArea1";
      this.chartResultSpectrum.ChartAreas.Add(chartArea1);
      legend1.Name = "Legend1";
      this.chartResultSpectrum.Legends.Add(legend1);
      this.chartResultSpectrum.Location = new System.Drawing.Point(484, 326);
      this.chartResultSpectrum.Name = "chartResultSpectrum";
      this.chartResultSpectrum.Size = new System.Drawing.Size(450, 290);
      this.chartResultSpectrum.TabIndex = 18;
      this.chartResultSpectrum.Text = "chart2";
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
      this.label3.Location = new System.Drawing.Point(13, 310);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(69, 13);
      this.label3.TabIndex = 20;
      this.label3.Text = "Result Image";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label1.Location = new System.Drawing.Point(481, 14);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(89, 13);
      this.label1.TabIndex = 21;
      this.label1.Text = "Source Spectrum";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label4.Location = new System.Drawing.Point(481, 311);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(85, 13);
      this.label4.TabIndex = 22;
      this.label4.Text = "Result Spectrum";
      // 
      // srcImgSpectrum
      // 
      this.srcImgSpectrum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.srcImgSpectrum.Location = new System.Drawing.Point(484, 29);
      this.srcImgSpectrum.Name = "srcImgSpectrum";
      this.srcImgSpectrum.Size = new System.Drawing.Size(450, 275);
      this.srcImgSpectrum.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.srcImgSpectrum.TabIndex = 23;
      this.srcImgSpectrum.TabStop = false;
      // 
      // grboxColorChannel
      // 
      this.grboxColorChannel.Controls.Add(this.rdoBlue);
      this.grboxColorChannel.Controls.Add(this.rdoGreen);
      this.grboxColorChannel.Controls.Add(this.rdoRed);
      this.grboxColorChannel.Enabled = false;
      this.grboxColorChannel.Location = new System.Drawing.Point(953, 114);
      this.grboxColorChannel.Name = "grboxColorChannel";
      this.grboxColorChannel.Size = new System.Drawing.Size(219, 67);
      this.grboxColorChannel.TabIndex = 24;
      this.grboxColorChannel.TabStop = false;
      this.grboxColorChannel.Text = "Select Color Channel";
      // 
      // rdoBlue
      // 
      this.rdoBlue.AutoSize = true;
      this.rdoBlue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.rdoBlue.ForeColor = System.Drawing.Color.DodgerBlue;
      this.rdoBlue.Location = new System.Drawing.Point(156, 31);
      this.rdoBlue.Name = "rdoBlue";
      this.rdoBlue.Size = new System.Drawing.Size(53, 20);
      this.rdoBlue.TabIndex = 13;
      this.rdoBlue.TabStop = true;
      this.rdoBlue.Text = "Blue";
      this.rdoBlue.UseVisualStyleBackColor = true;
      // 
      // rdoGreen
      // 
      this.rdoGreen.AutoSize = true;
      this.rdoGreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.rdoGreen.ForeColor = System.Drawing.Color.Green;
      this.rdoGreen.Location = new System.Drawing.Point(83, 31);
      this.rdoGreen.Name = "rdoGreen";
      this.rdoGreen.Size = new System.Drawing.Size(63, 20);
      this.rdoGreen.TabIndex = 12;
      this.rdoGreen.TabStop = true;
      this.rdoGreen.Text = "Green";
      this.rdoGreen.UseVisualStyleBackColor = true;
      // 
      // rdoRed
      // 
      this.rdoRed.AutoSize = true;
      this.rdoRed.Checked = true;
      this.rdoRed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.rdoRed.ForeColor = System.Drawing.Color.Red;
      this.rdoRed.Location = new System.Drawing.Point(14, 31);
      this.rdoRed.Name = "rdoRed";
      this.rdoRed.Size = new System.Drawing.Size(52, 20);
      this.rdoRed.TabIndex = 0;
      this.rdoRed.TabStop = true;
      this.rdoRed.Text = "Red";
      this.rdoRed.UseVisualStyleBackColor = true;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1184, 634);
      this.Controls.Add(this.grboxColorChannel);
      this.Controls.Add(this.srcImgSpectrum);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.chartResultSpectrum);
      this.Controls.Add(this.grboxNoise);
      this.Controls.Add(this.btnResetImage);
      this.Controls.Add(this.btnSaveImage);
      this.Controls.Add(this.btnGetImage);
      this.Controls.Add(this.resultImage);
      this.Controls.Add(this.sourceImage);
      this.Name = "Form1";
      this.Text = "Filtering Image 2";
      ((System.ComponentModel.ISupportInitialize)(this.resultImage)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.sourceImage)).EndInit();
      this.grboxNoise.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.chartResultSpectrum)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.srcImgSpectrum)).EndInit();
      this.grboxColorChannel.ResumeLayout(false);
      this.grboxColorChannel.PerformLayout();
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
    private System.Windows.Forms.GroupBox grboxNoise;
    private System.Windows.Forms.Panel panel5;
    private System.Windows.Forms.Panel panel4;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.Button btnAddNoiseUnipolarPepper;
    private System.Windows.Forms.Button btnAddNoiseBipolar;
    private System.Windows.Forms.Button btnAddNoiseUnipolarSalt;
    private System.Windows.Forms.DataVisualization.Charting.Chart chartResultSpectrum;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.PictureBox srcImgSpectrum;
    private System.Windows.Forms.GroupBox grboxColorChannel;
    private System.Windows.Forms.RadioButton rdoBlue;
    private System.Windows.Forms.RadioButton rdoGreen;
    private System.Windows.Forms.RadioButton rdoRed;
  }
}

