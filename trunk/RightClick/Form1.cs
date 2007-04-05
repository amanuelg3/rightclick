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

    bool capturing = false;

    private const UInt32 MOUSEEVENTF_LEFTDOWN = 0x0002;
    private const UInt32 MOUSEEVENTF_LEFTUP = 0x0004;
    private const UInt32 MOUSEEVENTF_RIGHTDOWN = 0x0008;
    private const UInt32 MOUSEEVENTF_RIGHTUP = 0x0010;
    private const UInt32 MOUSEEVENTF_MIDDLEDOWN = 0x0020;
    private const UInt32 MOUSEEVENTF_MIDDLEUP = 0x0040;

    [DllImport("user32.dll")]
    private static extern void mouse_event(
      UInt32 dwFlags, // motion and click options
      UInt32 dx, // horizontal position or change
      UInt32 dy, // vertical position or change
      UInt32 dwData, // wheel movement
      IntPtr dwExtraInfo // application-defined information
    );

    public static void SendClick() {
      mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, new System.IntPtr());
      mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, new System.IntPtr());
    }

    private void Form1_Load(object sender, EventArgs e) {
      Keys k = (Keys)Properties.Settings.Default.Hotkey;
      hotkey1.RegisterKey(TvShow.Hotkey.ModiferKey.MOD_NONE, k);
      hotkey1.HotKeyPressed += new TvShow.Hotkey.HotKeyPressedEventHandler(hotkey1_HotKeyPressed);

      this.Text = "RightClick: Hotkey-" + k.ToString();
    }

    void hotkey1_HotKeyPressed(Keys Key) {
      SendClick();
      System.Diagnostics.Debug.WriteLine("hotkey1_HotKeyPressed: " + Key.ToString());
    }

    private void timer1_Tick(object sender, EventArgs e) {
      SendClick();
      timer1.Enabled = false;
    }

    private void button1_Click(object sender, EventArgs e) {
      lPrompt.Text = "Press the new hotkey";
      lPrompt.Visible=true;
      textBox1.Focus();
      capturing=true;
    }

    private void textBox1_KeyDown(object sender, KeyEventArgs e) {
      label1.Text = e.KeyCode.ToString();
      if (capturing) {
        Keys k = e.KeyCode; 
        DialogResult r= MessageBox.Show("You pressed " + k.ToString() + "\r\n" +
          "Save and restart RightClick?", "Save", MessageBoxButtons.YesNo);
        if (r == DialogResult.Yes) {
          Properties.Settings.Default.Hotkey = (int)k;
          Properties.Settings.Default.Save();
          Application.Restart();
        }
      }
    }
  }
}