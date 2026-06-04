using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparisonDemo
{
  internal class CNum
  {
    public int Data { get; set; }
    public CNum(int n)
    {
      Data = n;
    }

    //Static preferred way to implement custom comparison methos
    public static int AscendingComparison(CNum num1, CNum num2)
    {

      return num1.Data.CompareTo(num2.Data);
    }

    public override bool Equals(object obj)
    {
      if (!(obj is CNum other)) return false;
      return Data.Equals(other.Data);
    }

    public override int GetHashCode()
    {
      return 1; 
    }
    
  }
}
