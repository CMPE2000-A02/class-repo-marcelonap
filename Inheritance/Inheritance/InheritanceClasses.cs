using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using GDIDrawer;

namespace Inheritance
{
  internal abstract class Animal : IComparable
  {
    protected int numTeeth { get; set; }
    protected int age { get; set; }
    protected string name { get; set; }
    
    protected string species { get; set; }

    public Animal(string name, string species)
    {
      Console.WriteLine("Animal constructor");
      this.name = name;
      this.species = species;
      age = 0;
    }

    public abstract string HowDoIMove();

    public virtual string HomePlanet()
    {
      return "Earth";
    }
    #region NVI
    public string GetWeight()
    {
      return "My Weight is: " + CoreGetWeight();
    }

    public abstract double CoreGetWeight();
    #endregion
    public abstract int CompareTo(object o);
    //public int CompareTo(object obj)
    //{
    //  if (!(obj is Animal animal)) throw new ArgumentException("Not an animal");

    //  return animal.age.CompareTo(age);
    //}
    public void Birthday()
    {
      age++;
    }
    public string GetName()
    {
    //int i = base.age * age;
      return name;
    }


    public override bool Equals(object obj)
    {
      if (!(obj is Animal other)) return false;
      
      return other.name == this.name;
    }

    public override int GetHashCode()
    {
      return 1;
    }
  }

  internal class Dog : Animal
  {

    public Dog(string name) : base(name, "canine") 
    {
      Console.WriteLine("Dog constructor");
    }

   // public abstract double CoreGetWeight();
    public override double CoreGetWeight()
    {
      throw new NotImplementedException();
    }

    public override int CompareTo(object o)
    {
      if (!(o is Dog other)) throw new ArgumentException("Not a dog");
      return name.CompareTo(other.name);
    }

    public override string HowDoIMove()
    {
      return "4 paws";
    }

    public void CelebrateBirthday()
    {
      Birthday();
    }
    virtual public int GetAge()
    {
      return age;
    }

    public string BaseNoseColor()
    {
      return $"Nose Color: {NoseColor()}";
    }

    virtual public Color NoseColor()
    {
      return RandColor.GetColor();
    }

    public override bool Equals(object obj)
    {
      if (!(obj is Dog other)) return false;
      return base.Equals(obj) && this.age == other.age;
     // return this.age == other.age;
    }

    public override int GetHashCode()
    {
      return base.GetHashCode();
    }
  }

  internal class Lab : Dog
  {
    public Lab(string name) : base(name) { }
    public override double CoreGetWeight()
    {
      return 30.0;
    }

    public override int CompareTo(object o)
    {
      return base.CompareTo(o);
    }

    public override Color NoseColor()
    {
      return Color.Gold;
    }

    override public int GetAge()
    {
      return 13;
    }
  }

  internal class Heeler : Dog
  {
    public Heeler(string name) : base(name) { }
    public override Color NoseColor()
    {
      return Color.Gray;
    }

    public override double CoreGetWeight()
    {
      return 19.3;
    }

    override public int GetAge()
    {
      return 2;
    }

  }

  internal class GermanShepherd : Dog
  {
    protected int age;
    public GermanShepherd(string name) : base(name)
    {
      Console.WriteLine("German Shepherd constructor");
    }

    public string GetName()
    {
    //int i = base.age * age;
      return name;
    }

    public override double CoreGetWeight()
    {
      return 45.5;
    }

    public override string HomePlanet()
    {
      return "Heaven";
    }

    public override Color NoseColor()
    {
      return Color.Black;
    }

    override public int GetAge()
    {
      return base.GetAge() * 7;
      //return age * 7;
    }
  }
}
