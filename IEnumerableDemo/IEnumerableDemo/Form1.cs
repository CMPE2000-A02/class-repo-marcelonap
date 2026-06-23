using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IEnumerableDemo
{
  public partial class Form1 : Form
  {
    List<int> ints = new List<int>();
    public Form1()
    {
      
      InitializeComponent();
      for(int i = 0; i< 100; i++)
      {
        ints.Add(i);
      }
      IEnumerable<int> iEints = ints;
    //  IEnumerable<int> iEints2 = new IEnumerable<int>(); - Cannot instantiate interfaces 
      iEints.Where(i => i % 2 == 0);

      List<int> even = ints.Where(i => i % 2 == 0).ToList(); // Casting to a concrete type
      IEnumerable<int> even2 = ints.Where(i => i % 2 == 0); // Storing it to an IEnumerable
      foreach (int item in even2.OrderByDescending(i => i))
      {
        Console.WriteLine($"item in iEnumerable<int>{item}");
      }
    }
  }
}
