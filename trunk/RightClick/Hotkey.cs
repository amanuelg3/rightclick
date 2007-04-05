namespace RightClick
{
    using Microsoft.VisualBasic;
    //using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public class Hotkey : Control
    {
      public delegate void HotKeyPressedEventHandler(Keys Key);
      public event HotKeyPressedEventHandler HotKeyPressed;

        [DebuggerNonUserCode]
        static Hotkey()
        {
            Hotkey.__ENCList = new ArrayList();
        }

        public Hotkey()
        {
            Hotkey.__ENCList.Add(new WeakReference(this));
            this.KeyList = new ArrayList();
        }

        public Hotkey(ModiferKey Modifier, Keys Key)
        {
            Hotkey.__ENCList.Add(new WeakReference(this));
            this.KeyList = new ArrayList();
            this.RegisterKey(Modifier, Key);
        }

        [DllImport("kernel32", EntryPoint="GlobalAddAtomA", CharSet=CharSet.Ansi, SetLastError=true, ExactSpelling=true)]
        private static extern short GlobalAddAtom([MarshalAs(UnmanagedType.VBByRefStr)] ref string lpString);
        [DllImport("kernel32", CharSet=CharSet.Ansi, SetLastError=true, ExactSpelling=true)]
        private static extern short GlobalDeleteAtom(short nAtom);
        [DllImport("user32", CharSet=CharSet.Ansi, SetLastError=true, ExactSpelling=true)]
        private static extern int RegisterHotKey(IntPtr hwnd, int id, int fsModifiers, Keys vk);
        public void RegisterKey(ModiferKey Modifier, Keys Key)
        {
            KeyItem item1 = new KeyItem();
            int num2 = this.GetHashCode();
            string text1 = "GlobalHotKey " + num2.ToString() + this.KeyList.Count.ToString();
            item1.hotkeyID = Hotkey.GlobalAddAtom(ref text1);
            item1.Key = Key;
            item1.Modifier = Modifier;
            this.KeyList.Add(item1);
            int num1 = Hotkey.RegisterHotKey(this.Handle, item1.hotkeyID, (int) Modifier, Key);
            if (num1 == 0)
            {
                System.Windows.Forms.MessageBox.Show (
                  "Can't register " + Key.ToString(),  
                  "Registering Hotkey",
                  System.Windows.Forms.MessageBoxButtons.OK);
            }
            this.CreateControl();
        }

        public void UnRegister()
        {
            IEnumerator enumerator1=null;
            try
            {
                enumerator1 = this.KeyList.GetEnumerator();
                while (enumerator1.MoveNext())
                {
                    KeyItem item1 = (KeyItem) enumerator1.Current;
                    Hotkey.UnregisterHotKey(this.Handle, item1.hotkeyID);
                    Hotkey.GlobalDeleteAtom(item1.hotkeyID);
                }
            }
            finally
            {
                if (enumerator1 is IDisposable)
                {
                    (enumerator1 as IDisposable).Dispose();
                }
            }
        }

        [DllImport("user32", CharSet=CharSet.Ansi, SetLastError=true, ExactSpelling=true)]
        private static extern int UnregisterHotKey(IntPtr hwnd, int id);
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0x312)
            {
                int num1 = (m.LParam.ToInt32() & -65536) >> 0x10;
                //Debug.WriteLine("lparam " + m.LParam.ToString() + " wParam " + m.WParam.ToString());
                HotKeyPressedEventHandler handler1 = this.HotKeyPressed;
                if (handler1 != null)
                {
                    handler1((Keys) num1);
                }
            }
        }


        private static ArrayList __ENCList;
        private ArrayList KeyList;
        private const int WM_HOTKEY = 0x312;

        public class KeyItem
        {
            public short hotkeyID;
            public Keys Key;
            public Hotkey.ModiferKey Modifier;
        }

        public enum ModiferKey
        {
            MOD_ALT = 1,
            MOD_CONTROL = 2,
            MOD_NONE = 0,
            MOD_SHIFT = 4,
            MOD_WIN = 8
        }
    }
}

