using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtensionsDemo
{
  public partial class Form1 : Form
  {

    List<int> ints = new List<int>();
    public Form1()
    {
      InitializeComponent();
      for (int i = 1; i <= 10; ++i)
      {
        ints.Add(i);
      }
      int product = ints.Product();
      Console.WriteLine($"Product is: {product}");
    }
  }
}
