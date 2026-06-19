using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionsDemo
{
  internal static class Extensions
  {
    public static int Product(this List<int> list)
    {
      Console.WriteLine($"list count is {list.Count()}");
      if (list.isEmpty()) return 0;
      int product = list.First();
      foreach( int i in list.Skip(1))
      {
        product *= i;
      }
      return product;
    }

    public static bool isEmpty(this List<int> list)
    {
      return list.Count() == 0;
    }
    
  }
}
