namespace FilteringImage
{
  partial class formMain
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
      this.btnGetImage = new System.Windows.Forms.Button();
      this.btnSaveImage = new System.Windows.Forms.Button();
      this.sourceImage = new System.Windows.Forms.PictureBox();
      this.openImage = new System.Windows.Forms.OpenFileDialog();
      this.saveImage = new System.Windows.Forms.SaveFileDialog();
      this.grboxColorChannel = new System.Windows.Forms.GroupBox();
      this.chboxChannelBlue = new System.Windows.Forms.CheckBox();
      this.chboxChannelGreen = new System.Windows.Forms.CheckBox();
      this.chboxChannelRed = new System.Windows.Forms.CheckBox();
      this.grboxNoise = new System.Windows.Forms.GroupBox();
      this.panel2 = new System.Windows.Forms.Panel();
      this.panel1 = new System.Windows.Forms.Panel();
      this.btnAddNoiseUnipolarPepper = new System.Windows.Forms.Button();
      this.btnAddNoiseBipolar = new System.Windows.Forms.Button();
      this.btnAddNoiseUnipolarSalt = new System.Windows.Forms.Button();
      this.grboxFiltering = new System.Windows.Forms.GroupBox();
      this.label4 = new System.Windows.Forms.Label();
      this.cboxMaskSize = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.btnFilterMidpoint = new System.Windows.Forms.Button();
      this.btnFilterCounterHarmonic = new System.Windows.Forms.Button();
      this.resultImage = new System.Windows.Forms.PictureBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.btnResetImage = new System.Windows.Forms.Button();
      this.panel3 = new System.Windows.Forms.Panel();
      this.panel4 = new System.Windows.Forms.Panel();
      this.panel5 = new System.Windows.Forms.Panel();
      this.cboxCounterHarmonicFilterGrade = new System.Windows.Forms.ComboBox();
      ((System.ComponentModel.ISupportInitialize)(this.sourceImage)).BeginInit();
      this.grboxColorChannel.SuspendLayout();
      this.grboxNoise.SuspendLayout();
      this.panel1.SuspendLayout();
      this.grboxFiltering.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.resultImage)).BeginInit();
      this.SuspendLayout();
      // 
      // btnGetImage
      // 
      this.btnGetImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnGetImage.Location = new System.Drawing.Point(553, 27);
      this.btnGetImage.Name = "btnGetImage";
      this.btnGetImage.Size = new System.Drawing.Size(100, 30);
      this.btnGetImage.TabIndex = 0;
      this.btnGetImage.Text = "Get Image";
      this.btnGetImage.UseVisualStyleBackColor = true;
      this.btnGetImage.Click += new System.EventHandler(this.btnGetImage_Click);
      // 
      // btnSaveImage
      // 
      this.btnSaveImage.Enabled = false;
      this.btnSaveImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnSaveImage.Location = new System.Drawing.Point(673, 27);
      this.btnSaveImage.Name = "btnSaveImage";
      this.btnSaveImage.Size = new System.Drawing.Size(100, 30);
      this.btnSaveImage.TabIndex = 1;
      this.btnSaveImage.Text = "Save Image";
      this.btnSaveImage.UseVisualStyleBackColor = true;
      this.btnSaveImage.Click += new System.EventHandler(this.btnSaveImage_Click);
      // 
      // sourceImage
      // 
      this.sourceImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.sourceImage.Location = new System.Drawing.Point(13, 27);
      this.sourceImage.Name = "sourceImage";
      this.sourceImage.Size = new System.Drawing.Size(525, 275);
      this.sourceImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.sourceImage.TabIndex = 2;
      this.sourceImage.TabStop = false;
      // 
      // grboxColorChannel
      // 
      this.grboxColorChannel.Controls.Add(this.chboxChannelBlue);
      this.grboxColorChannel.Controls.Add(this.chboxChannelGreen);
      this.grboxColorChannel.Controls.Add(this.chboxChannelRed);
      this.grboxColorChannel.Enabled = false;
      this.grboxColorChannel.Location = new System.Drawing.Point(554, 134);
      this.grboxColorChannel.Name = "grboxColorChannel";
      this.grboxColorChannel.Size = new System.Drawing.Size(219, 67);
      this.grboxColorChannel.TabIndex = 3;
      this.grboxColorChannel.TabStop = false;
      this.grboxColorChannel.Text = "Select Color Channel";
      // 
      // chboxChannelBlue
      // 
      this.chboxChannelBlue.AutoSize = true;
      this.chboxChannelBlue.CausesValidation = false;
      this.chboxChannelBlue.Checked = true;
      this.chboxChannelBlue.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chboxChannelBlue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.chboxChannelBlue.ForeColor = System.Drawing.Color.Blue;
      this.chboxChannelBlue.Location = new System.Drawing.Point(149, 29);
      this.chboxChannelBlue.Name = "chboxChannelBlue";
      this.chboxChannelBlue.Size = new System.Drawing.Size(54, 20);
      this.chboxChannelBlue.TabIndex = 13;
      this.chboxChannelBlue.Text = "Blue";
      this.chboxChannelBlue.UseVisualStyleBackColor = true;
      this.chboxChannelBlue.CheckedChanged += new System.EventHandler(this.chboxChannelBlue_CheckedChanged);
      // 
      // chboxChannelGreen
      // 
      this.chboxChannelGreen.AutoSize = true;
      this.chboxChannelGreen.CausesValidation = false;
      this.chboxChannelGreen.Checked = true;
      this.chboxChannelGreen.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chboxChannelGreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.chboxChannelGreen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
      this.chboxChannelGreen.Location = new System.Drawing.Point(82, 29);
      this.chboxChannelGreen.Name = "chboxChannelGreen";
      this.chboxChannelGreen.Size = new System.Drawing.Size(64, 20);
      this.chboxChannelGreen.TabIndex = 12;
      this.chboxChannelGreen.Text = "Green";
      this.chboxChannelGreen.UseVisualStyleBackColor = true;
      this.chboxChannelGreen.CheckedChanged += new System.EventHandler(this.chboxChannelGreen_CheckedChanged);
      // 
      // chboxChannelRed
      // 
      this.chboxChannelRed.AutoSize = true;
      this.chboxChannelRed.CausesValidation = false;
      this.chboxChannelRed.Checked = true;
      this.chboxChannelRed.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chboxChannelRed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.chboxChannelRed.ForeColor = System.Drawing.Color.Red;
      this.chboxChannelRed.Location = new System.Drawing.Point(19, 29);
      this.chboxChannelRed.Name = "chboxChannelRed";
      this.chboxChannelRed.Size = new System.Drawing.Size(53, 20);
      this.chboxChannelRed.TabIndex = 11;
      this.chboxChannelRed.Text = "Red";
      this.chboxChannelRed.UseVisualStyleBackColor = true;
      this.chboxChannelRed.CheckedChanged += new System.EventHandler(this.chboxChannelRed_CheckedChanged);
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
      this.grboxNoise.Location = new System.Drawing.Point(554, 215);
      this.grboxNoise.Name = "grboxNoise";
      this.grboxNoise.Size = new System.Drawing.Size(218, 158);
      this.grboxNoise.TabIndex = 4;
      this.grboxNoise.TabStop = false;
      this.grboxNoise.Text = "Add Noise";
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
      // grboxFiltering
      // 
      this.grboxFiltering.Controls.Add(this.cboxCounterHarmonicFilterGrade);
      this.grboxFiltering.Controls.Add(this.label4);
      this.grboxFiltering.Controls.Add(this.cboxMaskSize);
      this.grboxFiltering.Controls.Add(this.label1);
      this.grboxFiltering.Controls.Add(this.btnFilterMidpoint);
      this.grboxFiltering.Controls.Add(this.btnFilterCounterHarmonic);
      this.grboxFiltering.Enabled = false;
      this.grboxFiltering.Location = new System.Drawing.Point(553, 389);
      this.grboxFiltering.Name = "grboxFiltering";
      this.grboxFiltering.Size = new System.Drawing.Size(219, 225);
      this.grboxFiltering.TabIndex = 5;
      this.grboxFiltering.TabStop = false;
      this.grboxFiltering.Text = "Filtering";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label4.Location = new System.Drawing.Point(21, 84);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(79, 16);
      this.label4.TabIndex = 11;
      this.label4.Text = "Filter grade:";
      // 
      // cboxMaskSize
      // 
      this.cboxMaskSize.FormattingEnabled = true;
      this.cboxMaskSize.Items.AddRange(new object[] {
            "3 x 3",
            "5 x 5",
            "9 x 9"});
      this.cboxMaskSize.Location = new System.Drawing.Point(106, 34);
      this.cboxMaskSize.Name = "cboxMaskSize";
      this.cboxMaskSize.Size = new System.Drawing.Size(91, 21);
      this.cboxMaskSize.TabIndex = 9;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label1.Location = new System.Drawing.Point(20, 34);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(71, 16);
      this.label1.TabIndex = 8;
      this.label1.Text = "Mask size:";
      // 
      // btnFilterMidpoint
      // 
      this.btnFilterMidpoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnFilterMidpoint.Location = new System.Drawing.Point(24, 166);
      this.btnFilterMidpoint.Name = "btnFilterMidpoint";
      this.btnFilterMidpoint.Size = new System.Drawing.Size(173, 40);
      this.btnFilterMidpoint.TabIndex = 7;
      this.btnFilterMidpoint.Text = "Midpoint";
      this.btnFilterMidpoint.UseVisualStyleBackColor = true;
      this.btnFilterMidpoint.Click += new System.EventHandler(this.btnFilterMidpoint_Click);
      // 
      // btnFilterCounterHarmonic
      // 
      this.btnFilterCounterHarmonic.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnFilterCounterHarmonic.Location = new System.Drawing.Point(24, 111);
      this.btnFilterCounterHarmonic.Name = "btnFilterCounterHarmonic";
      this.btnFilterCounterHarmonic.Size = new System.Drawing.Size(173, 40);
      this.btnFilterCounterHarmonic.TabIndex = 6;
      this.btnFilterCounterHarmonic.Text = "Counter Harmonic";
      this.btnFilterCounterHarmonic.UseVisualStyleBackColor = true;
      this.btnFilterCounterHarmonic.Click += new System.EventHandler(this.btnFilterCounterHarmonic_Click);
      // 
      // resultImage
      // 
      this.resultImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.resultImage.Location = new System.Drawing.Point(13, 324);
      this.resultImage.Name = "resultImage";
      this.resultImage.Size = new System.Drawing.Size(525, 290);
      this.resultImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.resultImage.TabIndex = 6;
      this.resultImage.TabStop = false;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label2.Location = new System.Drawing.Point(12, 11);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(73, 13);
      this.label2.TabIndex = 9;
      this.label2.Text = "Source Image";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label3.Location = new System.Drawing.Point(12, 308);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(69, 13);
      this.label3.TabIndex = 10;
      this.label3.Text = "Result Image";
      // 
      // btnResetImage
      // 
      this.btnResetImage.Enabled = false;
      this.btnResetImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnResetImage.Location = new System.Drawing.Point(613, 75);
      this.btnResetImage.Name = "btnResetImage";
      this.btnResetImage.Size = new System.Drawing.Size(100, 30);
      this.btnResetImage.TabIndex = 11;
      this.btnResetImage.Text = "Reset Image";
      this.btnResetImage.UseVisualStyleBackColor = true;
      this.btnResetImage.Click += new System.EventHandler(this.btnResetImage_Click);
      // 
      // panel3
      // 
      this.panel3.BackColor = System.Drawing.Color.White;
      this.panel3.Location = new System.Drawing.Point(0, 0);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(15, 15);
      this.panel3.TabIndex = 13;
      // 
      // panel4
      // 
      this.panel4.BackColor = System.Drawing.Color.White;
      this.panel4.Location = new System.Drawing.Point(156, 38);
      this.panel4.Name = "panel4";
      this.panel4.Size = new System.Drawing.Size(15, 15);
      this.panel4.TabIndex = 14;
      // 
      // panel5
      // 
      this.panel5.BackColor = System.Drawing.Color.Black;
      this.panel5.Location = new System.Drawing.Point(171, 38);
      this.panel5.Name = "panel5";
      this.panel5.Size = new System.Drawing.Size(15, 15);
      this.panel5.TabIndex = 14;
      // 
      // cboxCounterHarmonicFilterGrade
      // 
      this.cboxCounterHarmonicFilterGrade.FormattingEnabled = true;
      this.cboxCounterHarmonicFilterGrade.Items.AddRange(new object[] {
            "-1",
            "0",
            "1"});
      this.cboxCounterHarmonicFilterGrade.Location = new System.Drawing.Point(106, 83);
      this.cboxCounterHarmonicFilterGrade.Name = "cboxCounterHarmonicFilterGrade";
      this.cboxCounterHarmonicFilterGrade.Size = new System.Drawing.Size(91, 21);
      this.cboxCounterHarmonicFilterGrade.TabIndex = 12;
      // 
      // formMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(790, 626);
      this.Controls.Add(this.btnResetImage);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.resultImage);
      this.Controls.Add(this.grboxFiltering);
      this.Controls.Add(this.grboxNoise);
      this.Controls.Add(this.grboxColorChannel);
      this.Controls.Add(this.sourceImage);
      this.Controls.Add(this.btnSaveImage);
      this.Controls.Add(this.btnGetImage);
      this.Name = "formMain";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Filtering Image";
      ((System.ComponentModel.ISupportInitialize)(this.sourceImage)).EndInit();
      this.grboxColorChannel.ResumeLayout(false);
      this.grboxColorChannel.PerformLayout();
      this.grboxNoise.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.grboxFiltering.ResumeLayout(false);
      this.grboxFiltering.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.resultImage)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnGetImage;
    private System.Windows.Forms.Button btnSaveImage;
    private System.Windows.Forms.PictureBox sourceImage;
    private System.Windows.Forms.OpenFileDialog openImage;
    private System.Windows.Forms.SaveFileDialog saveImage;
    private System.Windows.Forms.GroupBox grboxColorChannel;
    private System.Windows.Forms.GroupBox grboxNoise;
    private System.Windows.Forms.Button btnAddNoiseBipolar;
    private System.Windows.Forms.Button btnAddNoiseUnipolarSalt;
    private System.Windows.Forms.GroupBox grboxFiltering;
    private System.Windows.Forms.Button btnFilterCounterHarmonic;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btnFilterMidpoint;
    private System.Windows.Forms.ComboBox cboxMaskSize;
    private System.Windows.Forms.PictureBox resultImage;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.CheckBox chboxChannelRed;
    private System.Windows.Forms.CheckBox chboxChannelBlue;
    private System.Windows.Forms.CheckBox chboxChannelGreen;
    private System.Windows.Forms.Button btnResetImage;
    private System.Windows.Forms.Button btnAddNoiseUnipolarPepper;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Panel panel5;
    private System.Windows.Forms.Panel panel4;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.ComboBox cboxCounterHarmonicFilterGrade;
  }
}

