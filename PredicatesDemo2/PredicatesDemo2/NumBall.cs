using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;

namespace PredicatesDemo2
{
  internal class NumBall
  {
    #region Members/Fields
    public static Random random;
    public int Num { get; private set; }
    public Color color { get; private set; }
    #endregion


    static NumBall()
    {
      random = new Random();
    }

    public NumBall() : this(RandColor.GetKnownColor(), random.Next(0, 101))
    {
      Console.WriteLine("@NumBall(): Default constructor assigning random values");
    }

    public NumBall(int num)
    {
      Num = num;
    }

    public NumBall(Color inColor, int num) : this(num)
    {
      color = inColor;
    }

    public NumBall(Color inColor)
    {
      color = inColor;
      Num = random.Next();
    }

   public static bool checkColorRed(NumBall ball)
    {
      return ball.color.Equals(Color.Red);
    }


    public override string ToString()
    {
      return $"Target: {this.color } - Num: {this.Num}";
    }


  }
}