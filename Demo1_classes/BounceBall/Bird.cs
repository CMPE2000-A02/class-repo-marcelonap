using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BounceBall
{
  class Bird
  {
    #region members
    private int _numOfWings;
    private string _name;
    private int _numOfToes;
    private bool _hasBeak;
    private int _distanceTraveled; // in kM
    private Color _color;
    #endregion

    #region properties

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

    public Bird(int numOfWings, string name, int numOfToes, bool hasBeak, int distanceTraveled, Color color)
    {
      _numOfWings = numOfWings;
      _name = name;
      _numOfToes = numOfToes;
      this.hasBeak = hasBeak;
      _distanceTraveled = distanceTraveled;
      _color = color;
    }

    public Bird(string name, bool hasBeak, Color color) : this(2, name, 3, hasBeak, 10, color)
    {

    }
   
    public void fly(int distance)
    {
      distanceTraveled = distance;
    }

    public string displayDistanceTraveled()
    {
      return $"{name} has traveled {distanceTraveled} km!";
    }

    public override string ToString()
    {
      return $"Hi I am a bird named {this.name} I have {this._numOfWings} wings and my color is {this._color} ";
     // return base.ToString(); "base" still to come
    }
  }
}
