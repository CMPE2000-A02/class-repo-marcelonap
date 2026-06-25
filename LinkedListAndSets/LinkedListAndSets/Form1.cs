using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinkedListAndSets
{
  public partial class Form1 : Form
  {
    LinkedList<string> llStrings = new LinkedList<string>();
    public Form1()
    {
      InitializeComponent();
      llStrings.AddFirst("^'^");
      for(int i = 0; i < 10; i++)
      {
        LinkedListNode<string> newNode = llStrings.AddAfter(llStrings.First, " |");
        if(i == 7)
        {
          llStrings.AddAfter(newNode, "askldjvhkdsajn");
        }
      }
      llStrings.AddLast(" V");

      foreach (string n in llStrings)
      {
        //System.InvalidOperationException: 'Collection was modified after the enumerator was instantiated.'

        //if (n.Contains("a")) // Is it our bad actor string
        //{
        //  llStrings.Remove(n);
        //  continue;
        //}
        Console.WriteLine(n);

      }
       
      LinkedListNode<string> node = llStrings.First;
      while(node != null)
      {
        if (node.Value.Contains("a")) // Is it our bad actor string
        {
          LinkedListNode<string> nextNode = node.Next;
          llStrings.Remove(node);
          node = nextNode;
          continue;
        }
        Console.WriteLine(node.Value);
        node = node.Next;
      }
      HashSet<string> mySet = llStrings.ToHashSet();
      foreach(string s in mySet)
      {
        Console.WriteLine(s);
      }

    }
  }
}
