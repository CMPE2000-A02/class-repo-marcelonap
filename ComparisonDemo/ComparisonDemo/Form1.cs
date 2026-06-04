using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComparisonDemo
{
  public partial class Form1 : Form
  {
    List<CNum> nums = new List<CNum>();
    const int maxDiscards = 500;
    public Form1()
    {
      InitializeComponent();
      PopulateListOfNums();
      PrintAndSort();
    }

    public void PopulateListOfNums()
    {
      Random rand = new Random();
      int discards = 0;
      for(int i = 0; i < 15; i++)
      {
        CNum current = new CNum(rand.Next(20));
        if (nums.Contains(current))
        {
          if (discards++ > maxDiscards)
          {
            Console.WriteLine("Max discards reached");
            break;
          }
          //try again/ Skip this iteration
          i--;
          continue;  
        }
        nums.Add(current); 
      }
    }

    public void PrintAndSort()
    {
      Console.WriteLine("Before sorting");
      foreach (CNum num in nums)
      {
        Console.WriteLine($"CNum: {num.Data}");
      }
      // Descending sort with Lambda
      nums.Sort((num1, num2) => -1 * num1.Data.CompareTo(num2.Data));
      Console.WriteLine("After sorting descending");
      foreach (CNum num in nums)
      {
        Console.WriteLine($"CNum: {num.Data}");
      }
      nums.Sort(CNum.AscendingComparison);
      Console.WriteLine("After sorting ascending");
      foreach (CNum num in nums)
      {
        Console.WriteLine($"CNum: {num.Data}");
      }

    }

    // Comparison satisfied by any method matching the signature
    internal int AscendingComparisonLoose(CNum num1, CNum num2)
    {

      return num1.Data.CompareTo(num2.Data);
    }



    
  }
}
