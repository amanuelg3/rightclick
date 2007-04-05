using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Xivo
{
  public partial class HotList : Form
  {
    public HotList()
    {
      InitializeComponent();
    }

    private void HotList_Load(object sender, EventArgs e)
    {

    }

    public void Add(String item)
    {
      listBox1.Items.Add(item);
    }

    public void Remove(String item)
    {
      listBox1.Items.Remove(item);
    }

    public bool Match(String item)
    {
      if (item != null && listBox1.Items.Contains(item))
        return true;
      else
        return false;
    }

    public void Save(string filename)
    {
      System.IO.TextWriter outf = new System.IO.StreamWriter(filename, false);
      foreach (string s in listBox1.Items)
      {
        outf.WriteLine(s);
      }
      outf.Close();
    }

    public void LoadList( string filename)
    {
      if (System.IO.File.Exists(filename))
      {
        System.IO.TextReader inf = new System.IO.StreamReader(filename);
        string s = inf.ReadLine();
        while (s != null)
        {
          listBox1.Items.Add(s);
          s = inf.ReadLine();
        }
        inf.Close();
      }
    }

    private void bRemove_Click(object sender, EventArgs e)
    {
      for (int i = listBox1.SelectedIndices.Count - 1; i >= 0; --i)
        listBox1.Items.RemoveAt(listBox1.SelectedIndices[i]);
    }

    private void HotList_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (e.CloseReason == CloseReason.UserClosing)
      {
        e.Cancel = true;
        Hide();
      }
    }

  }
}