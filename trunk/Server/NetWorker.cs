using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace CR.RightClick.Server {
  public enum EventTypeEnum : byte {
    MouseMove,  // bytes 4-7=x, bytes 8-11=y
    MouseDown,  // byte 4=button
    MouseUp,    // byte 4=button
    KeyDown,    // bytes 4-7=keycode
    KeyUp       // bytes 4-7=keycode
  }

  class NetWorker {
    private const UInt32 MOUSEEVENTF_LEFTDOWN = 0x0002;
    private const UInt32 MOUSEEVENTF_LEFTUP = 0x0004;
    private const UInt32 MOUSEEVENTF_RIGHTDOWN = 0x0008;
    private const UInt32 MOUSEEVENTF_RIGHTUP = 0x0010;
    private const UInt32 MOUSEEVENTF_MIDDLEDOWN = 0x0020;
    private const UInt32 MOUSEEVENTF_MIDDLEUP = 0x0040;
    UInt32[] mouseDownItems = {
      MOUSEEVENTF_LEFTDOWN, MOUSEEVENTF_RIGHTDOWN, MOUSEEVENTF_MIDDLEDOWN};
    UInt32[] mouseUpItems = {
      MOUSEEVENTF_LEFTUP, MOUSEEVENTF_RIGHTUP, MOUSEEVENTF_MIDDLEUP};


    [DllImport("user32.dll")]
    private static extern void mouse_event(
      UInt32 dwFlags, // motion and click options
      UInt32 dx, // horizontal position or change
      UInt32 dy, // vertical position or change
      UInt32 dwData, // wheel movement
      IntPtr dwExtraInfo // application-defined information
    );

    const UInt32 KEYEVENTF_EXTENDEDKEY = 0x0001;
    const UInt32 KEYEVENTF_KEYUP = 0x0002;
    const UInt32 KEYEVENTF_UNICODE = 0x0004;
    const UInt32 KEYEVENTF_SCANCODE = 0x0008;
    [DllImport("user32.dll")]
    private static extern void keybd_event(
      byte VirtualKeyCode,
      byte ScanCode,
      UInt32 Flags,
      UInt32 ExtraInfo);


    /// <summary>
    /// Send a mouse up and mouse down event.
    /// </summary>
    /// <param name="button">0-left, 1-right</param>
    public void SendMouseDown(int button) {
      mouse_event(mouseDownItems[button], 0, 0, 0, new System.IntPtr());
      mouse_event(mouseUpItems[button], 0, 0, 0, new System.IntPtr());
    }
    public void SendMouseUp(int button) {
      mouse_event(mouseDownItems[button], 0, 0, 0, new System.IntPtr());
      mouse_event(mouseUpItems[button], 0, 0, 0, new System.IntPtr());
    }

    System.Net.Sockets.UdpClient socket =
     new System.Net.Sockets.UdpClient(
       Properties.Settings.Default.port);

    ServerWindow MainWindow;
    public void Start(ServerWindow MainWindow) {
      this.MainWindow = MainWindow;
      System.Net.IPEndPoint endPoint = new System.Net.IPEndPoint(
        IPAddress.Any, Properties.Settings.Default.port);

      System.Diagnostics.Debug.WriteLine("Thread started");

      while (true) {
        if (socket.Available > 0) {
          byte[] b = socket.Receive(ref endPoint);
          System.Diagnostics.Debug.WriteLine("Data received: " + b[0].ToString());
          switch ((EventTypeEnum)b[0]) {
            case EventTypeEnum.MouseMove:
              int x = BitConverter.ToInt32(b, 4);
              int y = BitConverter.ToInt32(b, 8);
              Cursor.Position = new System.Drawing.Point(x, y);
              break;
            case EventTypeEnum.MouseDown:
              int buttonDown = BitConverter.ToInt32(b, 4);
              SendMouseDown(buttonDown);
              break;
            case EventTypeEnum.MouseUp:
              int buttonUp = BitConverter.ToInt32(b, 4);
              SendMouseUp(buttonUp);
              break;
          }
        }
        System.Threading.Thread.Sleep(0);
      }
    }
  }
}
