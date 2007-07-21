using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace CR.RightClick.Server {
  public partial class ServerWindow : Form {
    public ServerWindow() {
      InitializeComponent();
    }

    System.Threading.Thread netThread;
    NetWorker worker1 = new NetWorker();

    private void ServerWindow_Load(object sender, EventArgs e) {
      ThreadStart s = new ThreadStart(startNetThread);
      netThread = new Thread(s);
      netThread.Start();
    }

    public void startNetThread() {
      worker1.Start(this);
    }

    private void ServerWindow_FormClosing(object sender, FormClosingEventArgs e) {
      if (netThread != null) netThread.Abort();
    }

  }
}