using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace RightClick {
  public partial class Form1 : Form {
    public Form1() {
      InitializeComponent();
    }

    int capturing = -1;
    Keys[] keys = new Keys[2];

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

    /// <summary>
    /// Send a mouse up and mouse down event.
    /// </summary>
    /// <param name="button">0-left, 1-right</param>
    public void SendClick(int button) {
      mouse_event(mouseDownItems[button], 0, 0, 0, new System.IntPtr());
      mouse_event(mouseUpItems[button], 0, 0, 0, new System.IntPtr());
    }

    private void Form1_Load(object sender, EventArgs e) {
      try {
        keys[0] = (Keys)Properties.Settings.Default.ClickKey;
        lClick.Text = keys[0].ToString();
        keys[1] = (Keys)Properties.Settings.Default.RightClickKey;
        lRightClick.Text = keys[1].ToString();
        hotkey1.RegisterKey(RightClick.Hotkey.ModiferKey.MOD_NONE, keys[0]);
        hotkey1.RegisterKey(RightClick.Hotkey.ModiferKey.MOD_NONE, keys[1]);
        hotkey1.HotKeyPressed += new RightClick.Hotkey.HotKeyPressedEventHandler(hotkey1_HotKeyPressed);
      }
      catch (Exception ex) {
        MessageBox.Show(ex.Message);
      }
    }

    void hotkey1_HotKeyPressed(Keys Key) {
      for (int i = 0; i < keys.Length; ++i) {
        if (Key == keys[i])
          SendClick(i);
      }
      System.Diagnostics.Debug.WriteLine("hotkey1_HotKeyPressed: " + Key.ToString());
    }

    private void bClick_Click(object sender, EventArgs e) {
      capturing = 0;
      textBox1.Visible = true;
      textBox1.Focus();
    }

    private void bRightClick_Click(object sender, EventArgs e) {
      capturing = 1;
      textBox1.Visible = true;
      textBox1.Focus();
    }

    private void form_KeyDown(object sender, KeyEventArgs e) {
      if (capturing != -1) {
        Keys k = e.KeyCode;
        DialogResult r = MessageBox.Show("You pressed " + k.ToString() + "\r\n" +
          "Save and restart RightClick?", "Save", MessageBoxButtons.YesNo);
        if (r == DialogResult.Yes) {
          keys[capturing] = k;
          Properties.Settings.Default.ClickKey = (int) keys[0];
          Properties.Settings.Default.RightClickKey = (int) keys[1];
          Properties.Settings.Default.Save();
          capturing = -1;
          Application.Restart();
        }
      }
    }

  }
}