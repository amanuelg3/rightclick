namespace Xivo
{
  partial class HotList
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
      if (disposing && (components != null))
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
      this.listBox1 = new System.Windows.Forms.ListBox();
      this.panel1 = new System.Windows.Forms.Panel();
      this.bEdit = new System.Windows.Forms.Button();
      this.bRemove = new System.Windows.Forms.Button();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // listBox1
      // 
      this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.listBox1.FormattingEnabled = true;
      this.listBox1.Location = new System.Drawing.Point(0, 0);
      this.listBox1.Name = "listBox1";
      this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
      this.listBox1.Size = new System.Drawing.Size(273, 550);
      this.listBox1.TabIndex = 0;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.bEdit);
      this.panel1.Controls.Add(this.bRemove);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(0, 525);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(273, 26);
      this.panel1.TabIndex = 1;
      // 
      // bEdit
      // 
      this.bEdit.Location = new System.Drawing.Point(81, 0);
      this.bEdit.Name = "bEdit";
      this.bEdit.Size = new System.Drawing.Size(75, 23);
      this.bEdit.TabIndex = 1;
      this.bEdit.Text = "Edit";
      this.bEdit.UseVisualStyleBackColor = true;
      // 
      // bRemove
      // 
      this.bRemove.Location = new System.Drawing.Point(0, 0);
      this.bRemove.Name = "bRemove";
      this.bRemove.Size = new System.Drawing.Size(75, 23);
      this.bRemove.TabIndex = 0;
      this.bRemove.Text = "Remove";
      this.bRemove.UseVisualStyleBackColor = true;
      this.bRemove.Click += new System.EventHandler(this.bRemove_Click);
      // 
      // HotList
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(273, 551);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.listBox1);
      this.Name = "HotList";
      this.Text = "XiVo - Hot List";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HotList_FormClosing);
      this.Load += new System.EventHandler(this.HotList_Load);
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ListBox listBox1;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button bRemove;
    private System.Windows.Forms.Button bEdit;
  }
}