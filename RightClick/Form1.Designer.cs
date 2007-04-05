namespace RightClick {
  partial class Form1 {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.bRightClick = new System.Windows.Forms.Button();
      this.hotkey1 = new RightClick.Hotkey();
      this.bClick = new System.Windows.Forms.Button();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.lRightClick = new System.Windows.Forms.Label();
      this.lClick = new System.Windows.Forms.Label();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // bRightClick
      // 
      this.bRightClick.Location = new System.Drawing.Point(6, 48);
      this.bRightClick.Name = "bRightClick";
      this.bRightClick.Size = new System.Drawing.Size(86, 23);
      this.bRightClick.TabIndex = 0;
      this.bRightClick.Text = "Right-Click";
      this.bRightClick.UseVisualStyleBackColor = true;
      this.bRightClick.Click += new System.EventHandler(this.bRightClick_Click);
      // 
      // hotkey1
      // 
      this.hotkey1.Location = new System.Drawing.Point(0, 0);
      this.hotkey1.Name = "hotkey1";
      this.hotkey1.Size = new System.Drawing.Size(75, 23);
      this.hotkey1.TabIndex = 1;
      this.hotkey1.Text = "hotkey1";
      // 
      // bClick
      // 
      this.bClick.Location = new System.Drawing.Point(6, 19);
      this.bClick.Name = "bClick";
      this.bClick.Size = new System.Drawing.Size(86, 23);
      this.bClick.TabIndex = 4;
      this.bClick.Text = "Click";
      this.bClick.UseVisualStyleBackColor = true;
      this.bClick.Click += new System.EventHandler(this.bClick_Click);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.textBox1);
      this.groupBox1.Controls.Add(this.lRightClick);
      this.groupBox1.Controls.Add(this.lClick);
      this.groupBox1.Controls.Add(this.bClick);
      this.groupBox1.Controls.Add(this.bRightClick);
      this.groupBox1.Location = new System.Drawing.Point(0, 0);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(262, 81);
      this.groupBox1.TabIndex = 5;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Key Assignment";
      // 
      // lRightClick
      // 
      this.lRightClick.AutoSize = true;
      this.lRightClick.Location = new System.Drawing.Point(98, 53);
      this.lRightClick.Name = "lRightClick";
      this.lRightClick.Size = new System.Drawing.Size(35, 13);
      this.lRightClick.TabIndex = 6;
      this.lRightClick.Text = "label1";
      // 
      // lClick
      // 
      this.lClick.AutoSize = true;
      this.lClick.Location = new System.Drawing.Point(98, 24);
      this.lClick.Name = "lClick";
      this.lClick.Size = new System.Drawing.Size(35, 13);
      this.lClick.TabIndex = 6;
      this.lClick.Text = "label1";
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(139, 21);
      this.textBox1.Multiline = true;
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(100, 45);
      this.textBox1.TabIndex = 6;
      this.textBox1.Text = "Press the new key to use...";
      this.textBox1.Visible = false;
      this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.form_KeyDown);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(265, 84);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.hotkey1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.KeyPreview = true;
      this.Name = "Form1";
      this.Text = "RightClick";
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.form_KeyDown);
      this.Load += new System.EventHandler(this.Form1_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button bRightClick;
    private RightClick.Hotkey hotkey1;
    private System.Windows.Forms.Button bClick;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label lRightClick;
    private System.Windows.Forms.Label lClick;
    private System.Windows.Forms.TextBox textBox1;
  }
}

