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
      this.components = new System.ComponentModel.Container();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.button1 = new System.Windows.Forms.Button();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.hotkey1 = new TvShow.Hotkey();
      this.lPrompt = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // timer1
      // 
      this.timer1.Interval = 5000;
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(12, 29);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(150, 23);
      this.button1.TabIndex = 0;
      this.button1.Text = "Assign hotkey";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(12, 163);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(223, 20);
      this.textBox1.TabIndex = 2;
      this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 186);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(35, 13);
      this.label1.TabIndex = 3;
      this.label1.Text = "label1";
      // 
      // hotkey1
      // 
      this.hotkey1.Location = new System.Drawing.Point(0, 0);
      this.hotkey1.Name = "hotkey1";
      this.hotkey1.Size = new System.Drawing.Size(75, 23);
      this.hotkey1.TabIndex = 1;
      this.hotkey1.Text = "hotkey1";
      // 
      // lPrompt
      // 
      this.lPrompt.AutoSize = true;
      this.lPrompt.Location = new System.Drawing.Point(12, 55);
      this.lPrompt.Name = "lPrompt";
      this.lPrompt.Size = new System.Drawing.Size(176, 13);
      this.lPrompt.TabIndex = 4;
      this.lPrompt.Text = "Press the key to assign to right-click";
      this.lPrompt.Visible = false;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(284, 264);
      this.Controls.Add(this.lPrompt);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.textBox1);
      this.Controls.Add(this.hotkey1);
      this.Controls.Add(this.button1);
      this.Name = "Form1";
      this.Text = "RightClick";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.Button button1;
    private TvShow.Hotkey hotkey1;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label lPrompt;
  }
}

