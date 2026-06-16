using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ComparisonDemo
{
  internal class CNum : IComparable
  {
    public int Data { get; set; }
    public float Ratio { get; set; }
    public string Name { get; set; }

    public double Product
    {
      get
      {
        return Data * Ratio;
      }
    }

    //public bool OffsetData
    //{
    //  set
    //  {
    //    if (value)
    //    {
    //      Data += 32;
    //    }
    //  }
    //}
    public CNum(int n, string name) : this()
    {
      Console.WriteLine("Running int + string constructor");
      Data = n;
      Name = name;
    }

    public CNum(float fDecimal) : this(10, "T")
    {
      Console.WriteLine("Running float constructors");
      Ratio = fDecimal;
    }

    public CNum()
    {
      Console.WriteLine("Running default constructors");
      Random rand = new Random();
      Ratio = (float)rand.NextDouble();
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
      return $"Data: {Data} Name: {Name} Product: {Product}";
    }
  }
}
