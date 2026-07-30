using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inheritance
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
      string word = "Pello World!";
      string planters = "PLANTERS";

      if ( planters.Contains(word.First()) )
      {
        Console.WriteLine("Found in PLANTERS");
      }

      //IComparable icomp = new IComparable();
     // IEnumerable<int> ints = new IEnumerable<int>();
      //Animal animal = new Animal();
      Animal german2 = new GermanShepherd("Max");
      Dog german1 = new GermanShepherd("Peanut");
      Dog lab1 = new Lab("Pinkie");
      Dog heeler1 = new Heeler("Brian");

      List<Dog> dogs = new List<Dog>();
      dogs.Add(lab1);
      dogs.Add(german1);
      dogs.Add(heeler1);

      
      for (int i = 3; i > 0; i--)
      {
        german1.Birthday();
        lab1.Birthday();
      }

      Console.WriteLine($"Lab's nose: {lab1.NoseColor()}");
      Console.WriteLine($"German's nose: {german1.NoseColor()}");


      Console.WriteLine("------------- Age: ");
      foreach (Dog dog in dogs)
      {
        Console.WriteLine($"{dog.GetName()}'s age: {dog.GetAge()}");
        Console.WriteLine(dog.BaseNoseColor());
        Console.WriteLine(dog.GetWeight());
        Console.WriteLine($"{dog.HomePlanet()}");



        //if (dog is GermanShepherd german)
        //{
        //  Console.WriteLine($"{german.GetName()}'s age: {german.GetAge()}");
        //}
        //else if (dog is Lab lab)
        //{
        //  Console.WriteLine($"{lab.GetName()}'s age: {lab.GetAge()}");
        //}
        //else if (dog is Heeler heeler)
        //{
        //  Console.WriteLine($"{heeler.GetName()}'s age: {heeler.GetAge()}");
        //}
        //else if (dog is IComparable comparableDog)
        //{
        //  Console.WriteLine($"Found a Comparable Dog");
        //}
      }

      //Console.WriteLine($"German's age: {german1.GetAge()}");
      //Console.WriteLine($"Lab's age: {lab1.GetAge()}");

      //Console.WriteLine("------------- Age (using new): ");
      //if( german1 is GermanShepherd german)
      //{
      //  Console.WriteLine($"German's age: {german.GetAge()}");
      //}else if( german1 is Lab lab)
      //{
      //  Console.WriteLine($"German's age: {lab.GetAge()}");
      //}

      //if( lab1 is GermanShepherd germanCaptured)
      //{
      //  Console.WriteLine($"Lab's age: {germanCaptured.GetAge()}");
      //}else if( lab1 is Lab lab)
      //{
      //  Console.WriteLine($"Lab's age: {lab.GetAge()}");
      //}



      //if (german1 is GermanShepherd)
      //{
      //  //Console.WriteLine($"My name is {german1.GetName()}");
      //  Console.WriteLine($"My name is {((GermanShepherd)german1).GetName()}");
      //}

      //Console.WriteLine($"I am {german1.GetAge()} years old");
      //Console.WriteLine($"My nose is {german1.NoseColor().ToString()} ");
    }
  }
}
