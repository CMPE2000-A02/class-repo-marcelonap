using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BounceBall
{
  class Bird : IComparable
  {
    #region members
    private int _numOfWings = 2;
    private string _name;
    private int _numOfToes;
    private bool _hasBeak;
    private int _distanceTraveled; // in kM
    private Color _color;
    #endregion

    #region properties

    public int beakLength { get; private set; } //in cm

    public string Nationality{ get; private set; }

    public static bool HaveToPoop { get; set; }

    public static bool CanFly { get; } = true;

    public int distanceTraveled
    {
      get
      {
        return _distanceTraveled * _numOfWings;
      }
      set
      {
        _distanceTraveled += value > 0 ? value : 0;
      }
    }
    public string name
    {
      get
      {
        return _name;
      }
    }

    public bool hasBeak
    {
      get
      {
        // 'value'keyword has no meaning or reference here
        return _hasBeak;
      }
      set
      {
        //'value' keyword is whatever we are assigning our set property via '='
        _hasBeak = value;
      }
    }
    #endregion

    static Bird()
    {
      HaveToPoop = true;  
    }
    
    public Bird(int numOfWings, string name, int numOfToes, bool hasBeak, int distanceTraveled, Color color)
    {
      _numOfWings = numOfWings;
      _name = name;
      _numOfToes = numOfToes;
      this.hasBeak = hasBeak;
      _distanceTraveled = distanceTraveled;
      _color = color;
      beakLength = 12;
      if (Bird.CanFly)
        distanceTraveled = 16;
    }

    public Bird(string name, bool hasBeak, Color color) : this(5, name, 3, hasBeak, 10, color)
    {

    }

    public int CompareTo(object other)
    {
      if (!(other is Bird otherBird)) throw new ArgumentException("Not a bird");

      return otherBird.distanceTraveled.CompareTo(this.distanceTraveled);
    }
   
    public void fly(int distance)
    {
      distanceTraveled = distance;
      CleanupPoop();
    }

    public string displayDistanceTraveled()
    {
      return $"{name} has traveled {distanceTraveled} km!";
    }

    public bool setNationality(string newNationality)
    {
      if(newNationality.Length > 0)
      {
        Nationality = newNationality;
        return true;
      }
      return false;
    }

    public override string ToString()
    {
      return $"Hi I am a bird named {this.name} I have {this._numOfWings} wings and my color is {this._color} \n {name} is from: {Nationality} ";
     // return base.ToString(); "base" still to come
    }

    public override bool Equals(object obj)
    {
      if (!(obj is Bird otherBird)) return false;

      bool result = this.name == otherBird.name && this.Nationality == otherBird.Nationality;

      return result;
    }

    public override int GetHashCode()
    {
      return 1;
    }

    static void CleanupPoop()
    {
      HaveToPoop = false;
    }


  }
}
