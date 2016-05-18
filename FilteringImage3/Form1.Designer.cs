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
      this.txbOutput = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.imgResult)).BeginInit();
      this.SuspendLayout();
      // 
      // imgResult
      // 
      this.imgResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.imgResult.Location = new System.Drawing.Point(12, 12);
      this.imgResult.Name = "imgResult";
      this.imgResult.Size = new System.Drawing.Size(437, 345);
      this.imgResult.TabIndex = 0;
      this.imgResult.TabStop = false;
      // 
      // btnRun
      // 
      this.btnRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnRun.Location = new System.Drawing.Point(560, 12);
      this.btnRun.Name = "btnRun";
      this.btnRun.Size = new System.Drawing.Size(142, 33);
      this.btnRun.TabIndex = 1;
      this.btnRun.Text = "RUN";
      this.btnRun.UseVisualStyleBackColor = true;
      this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
      // 
      // txbOutput
      // 
      this.txbOutput.Location = new System.Drawing.Point(466, 78);
      this.txbOutput.Multiline = true;
      this.txbOutput.Name = "txbOutput";
      this.txbOutput.Size = new System.Drawing.Size(318, 279);
      this.txbOutput.TabIndex = 2;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(463, 62);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(42, 13);
      this.label1.TabIndex = 3;
      this.label1.Text = "Output:";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(803, 372);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.txbOutput);
      this.Controls.Add(this.btnRun);
      this.Controls.Add(this.imgResult);
      this.Name = "Form1";
      this.Text = "Filtering Image 3";
      ((System.ComponentModel.ISupportInitialize)(this.imgResult)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox imgResult;
    private System.Windows.Forms.Button btnRun;
    private System.Windows.Forms.TextBox txbOutput;
    private System.Windows.Forms.Label label1;
  }
}

