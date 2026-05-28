using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PredicatesDemo2
{
  public partial class  Form1 : Form
  {
    List<NumBall> numBalls = new List<NumBall>();
    Queue<NumBall> qNumBalls = new Queue<NumBall>();
    Stack<NumBall> sNumBalls = new Stack<NumBall>();
    public Form1()
    {
      InitializeComponent();

      Console.WriteLine($"@Form1(): populating my list - current list: {numBalls.Count()}");
      PopulateList();
      actionButton.Click += ActionButton_Click;
    }

    private void ActionButton_Click(object sender, EventArgs e)
    {
      Console.WriteLine($"Balls in list({numBalls.Count()}): {numBalls}");
      Console.WriteLine($"Balls in list({numBalls.Count(NumBall.checkColorRed)}): {numBalls}");
      Console.WriteLine($"Balls in list({numBalls.Count(delegate(NumBall ball) { return ball.color.Equals(Color.Blue); } )}): {numBalls}");
      Console.WriteLine($"Balls in list({numBalls.Count(ball => ball.color.Equals(Color.Green))}): {numBalls}");
      Console.WriteLine($"Balls in list({numBalls.Count(ball => ball.Num >= 77 && ball.Num <= 89)}): {numBalls}");


      NumBall target = numBalls.Find(ball => ball.Num >= 77);
      if (target != null)
      {
        Console.WriteLine(target);
      }

      int lastIndex = numBalls.IndexOf(numBalls.FindLast(ball => ball.color.Equals(Color.Red)));
      if (lastIndex == -1) return;

      Console.WriteLine($"Index of Q peek { qNumBalls.ToList().IndexOf(qNumBalls.Peek()) }");
      Console.WriteLine($"Index of S peek { sNumBalls.ToList().IndexOf(sNumBalls.Peek()) }");

      Console.WriteLine($"Index of S peek { sNumBalls.Peek().Num }");
      Console.WriteLine($"Index of Q peek { qNumBalls.Peek().Num }");
      
      Console.WriteLine(numBalls[lastIndex] + $" Index: {lastIndex}");


    }

    public void PopulateList()
    {
      Console.WriteLine($"@PopulateList(): populating my list - current list: {numBalls.Count()}");
      for (int i = 0; i < 500; i++)
      {
        numBalls.Add(new NumBall());
        qNumBalls.Enqueue(new NumBall(i));
        sNumBalls.Push(new NumBall(i));
      }
      //sNumBalls.Pop();
      //sNumBalls.Peek();
      //qNumBalls.Peek();
      //qNumBalls.Dequeue();
      
      for (int i = 0; i < 7; i++)
      {
        numBalls.Add(new NumBall(Color.Green));
      }



    }
  }

  }
