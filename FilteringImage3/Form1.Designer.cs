namespace FilteringImage3
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
      this.imgResult = new System.Windows.Forms.PictureBox();
      this.btnRun = new System.Windows.Forms.Button();
      this.btnApplyFilter = new System.Windows.Forms.Button();
      this.btnSaveImage = new System.Windows.Forms.Button();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.numCutOffFrequency = new System.Windows.Forms.NumericUpDown();
      this.label6 = new System.Windows.Forms.Label();
      this.saveImage = new System.Windows.Forms.SaveFileDialog();
      ((System.ComponentModel.ISupportInitialize)(this.imgResult)).BeginInit();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numCutOffFrequency)).BeginInit();
      this.SuspendLayout();
      // 
      // imgResult
      // 
      this.imgResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.imgResult.Location = new System.Drawing.Point(12, 12);
      this.imgResult.Name = "imgResult";
      this.imgResult.Size = new System.Drawing.Size(433, 345);
      this.imgResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.imgResult.TabIndex = 0;
      this.imgResult.TabStop = false;
      // 
      // btnRun
      // 
      this.btnRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnRun.Location = new System.Drawing.Point(464, 12);
      this.btnRun.Name = "btnRun";
      this.btnRun.Size = new System.Drawing.Size(183, 57);
      this.btnRun.TabIndex = 1;
      this.btnRun.Text = "Get Data";
      this.btnRun.UseVisualStyleBackColor = true;
      this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
      // 
      // btnApplyFilter
      // 
      this.btnApplyFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnApplyFilter.Location = new System.Drawing.Point(18, 80);
      this.btnApplyFilter.Name = "btnApplyFilter";
      this.btnApplyFilter.Size = new System.Drawing.Size(149, 44);
      this.btnApplyFilter.TabIndex = 4;
      this.btnApplyFilter.Text = "Gauss Low Pass Filter";
      this.btnApplyFilter.UseVisualStyleBackColor = true;
      this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
      // 
      // btnSaveImage
      // 
      this.btnSaveImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnSaveImage.Location = new System.Drawing.Point(464, 300);
      this.btnSaveImage.Name = "btnSaveImage";
      this.btnSaveImage.Size = new System.Drawing.Size(183, 57);
      this.btnSaveImage.TabIndex = 5;
      this.btnSaveImage.Text = "Save Image";
      this.btnSaveImage.UseVisualStyleBackColor = true;
      this.btnSaveImage.Click += new System.EventHandler(this.btnSaveImage_Click);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.numCutOffFrequency);
      this.groupBox1.Controls.Add(this.btnApplyFilter);
      this.groupBox1.Controls.Add(this.label6);
      this.groupBox1.Location = new System.Drawing.Point(464, 101);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(183, 142);
      this.groupBox1.TabIndex = 6;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Filtering";
      // 
      // numCutOffFrequency
      // 
      this.numCutOffFrequency.Location = new System.Drawing.Point(18, 44);
      this.numCutOffFrequency.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
      this.numCutOffFrequency.Name = "numCutOffFrequency";
      this.numCutOffFrequency.Size = new System.Drawing.Size(149, 20);
      this.numCutOffFrequency.TabIndex = 36;
      this.numCutOffFrequency.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label6.Location = new System.Drawing.Point(16, 28);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(94, 13);
      this.label6.TabIndex = 35;
      this.label6.Text = "Cut-off Frequency:";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(664, 372);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.btnSaveImage);
      this.Controls.Add(this.btnRun);
      this.Controls.Add(this.imgResult);
      this.Name = "Form1";
      this.Text = "Filtering Image 3";
      ((System.ComponentModel.ISupportInitialize)(this.imgResult)).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numCutOffFrequency)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.PictureBox imgResult;
    private System.Windows.Forms.Button btnRun;
    private System.Windows.Forms.Button btnApplyFilter;
    private System.Windows.Forms.Button btnSaveImage;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.NumericUpDown numCutOffFrequency;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.SaveFileDialog saveImage;
  }
}

