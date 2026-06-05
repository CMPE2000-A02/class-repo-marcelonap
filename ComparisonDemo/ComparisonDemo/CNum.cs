using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparisonDemo
{
  internal class CNum : IComparable
  {
    public int Data { get; set; }
    public string Name { get; set; }
    public CNum(int n, string name)
    {
      Data = n;
      Name = name;
    }

    //Static preferred way to implement custom comparison methos
    public static int AscendingComparison(CNum num1, CNum num2)
    {

      return num1.Data.CompareTo(num2.Data);
    }

    // Example of two tier sorting (Data within Name)
    public int CompareTo(object obj)
    {
      if (!(obj is CNum other)) throw new ArgumentException("Attempting to compare something other than a CNum");

      int result = 0;
      result = Name.CompareTo(other.Name);
      if(result == 0)
      {
        result = -1 * Data.CompareTo(other.Data);
        Console.WriteLine("Comparing by Data, name  was the same");
      }
      return result;
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

    public override string ToString()
    {
      return $"Data: {Data} Name: {Name}";
    }
  }
}
