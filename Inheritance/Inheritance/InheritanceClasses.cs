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
  //internal class InheritanceClasses
  //{
  //}
  internal class Animal
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

    public void Birthday()
    {
      age++;
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

    public void CelebrateBirthday()
    {
      Birthday();
    }
    public int GetAge()
    {
      return age;
    }

    virtual public System.Drawing.Color NoseColor()
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

  internal class GermanShepherd : Dog
  {
    protected int age;
    public GermanShepherd(string name) : base(name)
    {
      Console.WriteLine("German Shepherd constructor");
    }

    public string GetName()
    {
    //  int i = base.age * age;
      return name;
    }

    public override Color NoseColor()
    {
      return Color.Black;
    }

    new public int GetAge()
    {
      return base.GetAge() * 7;
      //return age * 7;
    }
  }
}
