using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Start of a custom linked list implementation, finish at will
namespace Exam2Review
{
  internal class MyLinkedList<T>
  {
    MyNode<T> first;

    MyNode<T> last;

    void AddLast(T value)
    {
      if (first == null && last == null)
      {
        MyNode<T> current =  new MyNode<T>(value);
        last = current;
        first = current;
      }else if (last != null)
      {
        last.previous = last;
        last = new MyNode<T>(value, last.previous); 
      }


    }
    
  }

  internal class MyNode<T>
  {
    public MyNode<T> next;
    public MyNode<T> previous;
    T value;

    public MyNode(T value)
    {
      this.value = value;
      next = null;
      previous = null;
    }
    public MyNode(T value, MyNode<T> previous)
    {
      this.value = value;
      next = null;
      this.previous = previous;
    }


  }
}
