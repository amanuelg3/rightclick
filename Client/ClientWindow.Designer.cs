namespace CR.RightClick.Client {
  partial class ClientWindow {
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientWindow));
      this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.configureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
      this.label1 = new System.Windows.Forms.Label();
      this.contextMenuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configureToolStripMenuItem,
            this.quitToolStripMenuItem});
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new System.Drawing.Size(133, 48);
      // 
      // configureToolStripMenuItem
      // 
      this.configureToolStripMenuItem.Name = "configureToolStripMenuItem";
      this.configureToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
      this.configureToolStripMenuItem.Text = "Configure";
      this.configureToolStripMenuItem.Click += new System.EventHandler(this.configureToolStripMenuItem_Click);
      // 
      // quitToolStripMenuItem
      // 
      this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
      this.quitToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
      this.quitToolStripMenuItem.Text = "Quit";
      this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
      // 
      // notifyIcon1
      // 
      this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
      this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
      this.notifyIcon1.Text = "RightClick Client";
      this.notifyIcon1.Visible = true;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(0, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(151, 20);
      this.label1.TabIndex = 1;
      this.label1.Text = "Mouse -> Remote";
      // 
      // ClientWindow
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.WhiteSmoke;
      this.ClientSize = new System.Drawing.Size(374, 265);
      this.Controls.Add(this.label1);
      this.Cursor = System.Windows.Forms.Cursors.Cross;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "ClientWindow";
      this.Opacity = 0.2;
      this.ShowInTaskbar = false;
      this.Text = "Form1";
      this.TopMost = true;
      this.MouseEnter += new System.EventHandler(this.Form1_MouseEnter);
      this.MouseLeave += new System.EventHandler(this.Form1_MouseLeave);
      this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
      this.Load += new System.EventHandler(this.Form1_Load);
      this.contextMenuStrip1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    private System.Windows.Forms.NotifyIcon notifyIcon1;
    private System.Windows.Forms.ToolStripMenuItem configureToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
    private System.Windows.Forms.Label label1;
  }
}

