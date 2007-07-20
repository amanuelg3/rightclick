using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;

namespace CR.RightClick.Client {
  public partial class Form1 : Form {
    UdpClient socket;
    public enum EventTypeEnum : byte {
      MouseMove,  // bytes 2-5=x, bytes 6-9=y
      MouseDown,  // byte 2=button
      MouseUp,    // byte 2=button
      KeyDown,    // bytes 2-3=keycode
      KeyUp       // bytes 2-3=keycode
    }

    public Form1() {
      InitializeComponent();
      socket = new UdpClient(Properties.Settings.Default.Server,
        Properties.Settings.Default.port);
    }

    void Expand() {
      Height = Screen.PrimaryScreen.WorkingArea.Height;
      Width = Screen.PrimaryScreen.WorkingArea.Width;
    }

    void Collapse() {
      Height = Screen.PrimaryScreen.WorkingArea.Height;
      Width = 1;
    }

    private void Form1_MouseEnter(object sender, EventArgs e) {
      Expand();
    }

    private void Form1_MouseLeave(object sender, EventArgs e) {
      Collapse();
    }

    private void Form1_Load(object sender, EventArgs e) {
      Location = new Point(0, 0);
      Collapse();
    }

    byte[] Command = new byte[16];
    private void Form1_MouseMove(object sender, MouseEventArgs e) {
      if (e.Location.X >= ClientRectangle.Width - 1)
        Collapse();

      int x=e.Location.X;
      int y=e.Location.Y;
      Command[0]= (byte) EventTypeEnum.MouseMove;
      byte[] b1=BitConverter.GetBytes(x);
      byte[] b2=BitConverter.GetBytes(y);
      Array.Copy(b1,Command,b1.Length);
      Array.Copy(b2,Command,b1.Length);
      socket.Send(Command, 16);
    }

    private void notifyIcon1_Click(object sender, EventArgs e) {
      contextMenuStrip1.Show(Cursor.Position);
    }

    private void configureToolStripMenuItem_Click(object sender, EventArgs e) {

    }

    private void quitToolStripMenuItem_Click(object sender, EventArgs e) {
      Close();
    }
  }
}