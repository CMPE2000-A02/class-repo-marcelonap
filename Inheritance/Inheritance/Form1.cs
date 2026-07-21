using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inheritance
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
      string word = "Hello World!";

      Dog german1 = new GermanShepherd("Peanut");

     // GermanShepherd german1 = new GermanShepherd("peanut");
      if( german1 is GermanShepherd)
      { 
        Console.WriteLine($"My name is {((GermanShepherd)german1).GetName()}");
      }
      for(int i = 3; i > 0; i--)
      {
        german1.Birthday();
      }
      Console.WriteLine($"I am {german1.GetAge()} years old");
      Console.WriteLine($"My nose is {german1.NoseColor().ToString()} ");
    }
  }
}
