using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;

namespace CR.RightClick.Client {
  public partial class ClientWindow : Form {
    UdpClient socket;
    public enum EventTypeEnum : byte {
      MouseMove,  // bytes 4-7=x, bytes 8-11=y
      MouseDown,  // byte 4=button
      MouseUp,    // byte 4=button
      KeyDown,    // byte 1=keycode
      KeyUp,      // byte 1=keycode
      MouseWheel
    }

    public ClientWindow() {
      InitializeComponent();
      socket = new UdpClient(
        Properties.Settings.Default.Server,
        Properties.Settings.Default.port);
      Opacity = .2;
      MouseWheel += new MouseEventHandler(ClientWindow_MouseWheel);
    }

    void ClientWindow_MouseWheel(object sender, MouseEventArgs e) {
      int x = (int) EventTypeEnum.MouseWheel;
      int y = e.Delta;
      Command[0] = (byte)EventTypeEnum.MouseWheel;
      byte[] b1 = BitConverter.GetBytes(x);
      byte[] b2 = BitConverter.GetBytes(y);
      Array.Copy(b1, 0, Command, 4, b1.Length);
      Array.Copy(b2, 0, Command, 8, b2.Length);
      socket.Send(Command, Command.Length);
      System.Threading.Thread.Sleep(30);
    }

    void Expand() {
      Height = Screen.PrimaryScreen.WorkingArea.Height;
      Width = Screen.PrimaryScreen.WorkingArea.Width;
      Cursor.Position = new Point(Width - 10,Cursor.Position.Y);
    }

    void Collapse() {
      Height = Screen.PrimaryScreen.WorkingArea.Height;
      Width = 1;
      Cursor.Position = new Point(5, Cursor.Position.Y);
    }

    private void Form1_MouseEnter(object sender, EventArgs e) {
      Expand();
    }

    private void Form1_MouseLeave(object sender, EventArgs e) {
      Collapse();

      int x = 65535;
      int y = 32768;
      Command[0] = (byte)EventTypeEnum.MouseMove;
      byte[] b1 = BitConverter.GetBytes(x);
      byte[] b2 = BitConverter.GetBytes(y);
      Array.Copy(b1, 0, Command, 4, b1.Length);
      Array.Copy(b2, 0, Command, 8, b2.Length);
      socket.Send(Command, Command.Length);
    }

    private void Form1_Load(object sender, EventArgs e) {
      Location = new Point(0, 0);
      Collapse();
    }

    byte[] Command = new byte[] {
      0,0,0,0,
      0,0,0,0,
      0,0,0,0,
      0,0,0,0};

    //int lastx, lasty;
    private void Form1_MouseMove(object sender, MouseEventArgs e) {
      if (e.Location.X >= ClientRectangle.Width - 1)
        Collapse();
      int x = e.Location.X * 65535 / ClientRectangle.Width;
      int y = e.Location.Y * 65535 / ClientRectangle.Height;
      //int x = e.Location.X-lastx;
      //int y = e.Location.Y-lasty;
      //lastx = e.Location.X;
      //lasty = e.Location.Y;
      Command[0] = (byte)EventTypeEnum.MouseMove;
      byte[] b1 = BitConverter.GetBytes(x);
      byte[] b2 = BitConverter.GetBytes(y);
      Array.Copy(b1, 0, Command, 4, b1.Length);
      Array.Copy(b2, 0, Command, 8, b2.Length);
      socket.Send(Command, Command.Length);
      System.Threading.Thread.Sleep(30);
    }

    private void notifyIcon1_Click(object sender, EventArgs e) {
      contextMenuStrip1.Show(Cursor.Position);
    }

    private void configureToolStripMenuItem_Click(object sender, EventArgs e) {

    }

    private void quitToolStripMenuItem_Click(object sender, EventArgs e) {
      Close();
    }

    private const UInt32 MOUSEEVENTF_LEFTDOWN = 0x0002;
    private const UInt32 MOUSEEVENTF_LEFTUP = 0x0004;
    private const UInt32 MOUSEEVENTF_RIGHTDOWN = 0x0008;
    private const UInt32 MOUSEEVENTF_RIGHTUP = 0x0010;
    private const UInt32 MOUSEEVENTF_MIDDLEDOWN = 0x0020;
    private const UInt32 MOUSEEVENTF_MIDDLEUP = 0x0040;

    private void ClientWindow_MouseDown(object sender, MouseEventArgs e) {
      UInt32 x = 0;
      switch (e.Button) {
        case MouseButtons.Left:
          x = 0;
          break;
        case MouseButtons.Right:
          x = 1;
          break;
        case MouseButtons.Middle:
          x = 2;
          break;
      }
      Command[0] = (byte)EventTypeEnum.MouseDown;
      byte[] b1 = BitConverter.GetBytes(x);
      Array.Copy(b1, 0, Command, 4, b1.Length);
      socket.Send(Command, Command.Length);
    }

    private void ClientWindow_MouseUp(object sender, MouseEventArgs e) {
      UInt32 x = 0;
      switch (e.Button) {
        case MouseButtons.Left:
          x = 0;
          break;
        case MouseButtons.Right:
          x = 1;
          break;
        case MouseButtons.Middle:
          x = 2;
          break;
      }
      Command[0] = (byte)EventTypeEnum.MouseUp;
      byte[] b1 = BitConverter.GetBytes(x);
      Array.Copy(b1, 0, Command, 4, b1.Length);
      socket.Send(Command, Command.Length);
    }

    private void ClientWindow_KeyDown(object sender, KeyEventArgs e) {
      e.SuppressKeyPress = true;
      e.Handled = true;

      Command[0] = (byte)EventTypeEnum.KeyDown;
      Command[1] = (byte)e.KeyCode;
      socket.Send(Command, Command.Length);
      System.Threading.Thread.Sleep(30);
    }

    private void ClientWindow_KeyUp(object sender, KeyEventArgs e) {
      e.SuppressKeyPress = true;
      e.Handled = true;

      Command[0] = (byte)EventTypeEnum.KeyUp;
      Command[1] = (byte)e.KeyCode;
      socket.Send(Command, Command.Length);
      System.Threading.Thread.Sleep(30);
    }

  }
}