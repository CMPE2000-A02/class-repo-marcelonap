// Project : BounceBall
// Dec 03 2017
// By Simon Walker
//
// ball type - class definition - support class
// ///////////////////////////////////////////////////////////////////////////

// notes on comments and code documentation
// NOTE: The point of a file header is to let the reader know what is in the
//  file, the date, who wrote it, and any version history (out of scope here)
//
// Things to remember when documenting code are simple:
// [1] you are adding value when it comes to maintenance and readability
//     if you have nothing useful to say, don't write a comment
//
// [2] department of redundancy department - comments must not explain syntax but intent and context
//     i++; // increase i by one   <- NO!
//     i++; // move to the next student record
//
// [3] comments must be accurate (in fact, as accurate as the code)
//     stale or inaccurate comments can be lethal
//
// [4] write comments as though they are for someone else to understand you code
//     make no assumptions about what they do or don't know about this project
//
// [5] spelling counts, especially in regards to variable/method names, comments included


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GDIDrawer;

namespace BounceBall
{
  // ///////////////////////////////////////////////////////////////////////
  // ball class - self moving and rendering 'ball', implements equals
  //  for 'overlap' equality behavior.
  // ///////////////////////////////////////////////////////////////////////
  class ball
  {
    // NOTE: the order of items found in a class should be:
    // delegate type definitions
    // delegates
    // events
    // constant/readonly fields
    // static fields - inline or prior    
    // static properties
    // static methods
    // non-static fields/properties - inline or prior     
    // non-static construction/management
    // non-static events
    // non-static helper methods

    // ball radius, a single change here will alter all related behaviours
    public const int ciRadius = 25;

    // one and only drawer, common to all ball objects
    public static CDrawer _drawer = new CDrawer(bContinuousUpdate: false);

    // random object, available to all to centralize random generation
    public static Random _rnd = new Random();

    private PointF _pos; // current centre point position of the ball

    private PointF _dir; // current X/Y direction and speed of the ball

    // current ball color - used in rendering only
    private Color _color = Color.Red;
    // property : Modifier for ball color
    public Color BallColor
    {
      set
      {
        _color = value;
      }
    }

    // NOTE: You may use #region directives to allow rapid expansion/collapse of code regions
    #region Construction and Management

    /// <summary>
    /// Construct ball at start coordinate, ball will take on random direction/speed (-2.5 - 2.5 each axis) 
    /// </summary>
    /// <param name="startPos">start coordinate of ball</param>
    public ball(PointF startPos)
    {
      _pos = startPos;
      _dir = new PointF((float)(_rnd.NextDouble() * 5 - 2.5), (float)(_rnd.NextDouble() * 5 - 2.5));
    }
    public ball( ) : this(new PointF( ciRadius + 5, ciRadius + 5 ))
    {
      _dir = new PointF(0,0);
    }

    /// <summary>
    /// equality is based entirely on ball area overlap, color and direction attributes are not considered
    /// </summary>
    /// <param name="obj">argument to evaluate</param>
    /// <returns>true if overlap occurs</returns>
    public override bool Equals(object obj)
    {
      // if null or not a ball, then not equal
      if (!(obj is ball other))
        return false;

      // check distance between ball center points, if less than two radii, these balls overlap
      return
          Math.Sqrt
          (
              Math.Pow(_pos.X - other._pos.X, 2) +
              Math.Pow(_pos.Y - other._pos.Y, 2)
          )
          < ball.ciRadius * 2;

      // NOTE: complex math expressions may be formatted to provide insight into function,
      //  but clarity can be better expressed by breaking down the expression into multiple steps
      //  remember that the bonus comes from clarity and maintainability, not obfuscation
      // not to mention, the IDE will not clearly support such formatting, so it can be
      //  inconsistent to write, and therefore trouble to read.
      // the above could be written as such, with little or no performance penalty:

      //double dDist = Math.Pow(_pos.X - other._pos.X, 2) + Math.Pow(_pos.Y - other._pos.Y, 2);
      //dDist = Math.Sqrt(dDist);
      //return dDist < ball.ciRadius * 2;
    }

    /// <summary>
    /// No hashing value, supplied to suppress warnings
    /// </summary>
    /// <returns>1 always</returns>
    public override int GetHashCode()
    {
      return 1;
    }
    #endregion

    #region Support Methods

    /// <summary>
    /// Render invoking ball at the current position
    /// </summary>
    public void Render()
    {
      _drawer.AddCenteredEllipse((int)_pos.X, (int)_pos.Y, 2 * ciRadius, 2 * ciRadius, _color);
    }

    /// <summary>
    /// Move invoking ball by adding on each axis direction value
    /// if the ball is found the leave the bounds of the drawer window
    ///  it is moved to the border and the direction on that axis
    ///  is reversed to add a 'bounce' effect.
    /// </summary>
    public void Move()
    {
      // move the ball to it's new position
      _pos.X += _dir.X;
      _pos.Y += _dir.Y;

      // right boundary correction
      if (_pos.X >= _drawer.ScaledWidth - ball.ciRadius)
      {
        _pos.X = _drawer.ScaledWidth - ball.ciRadius;
        _dir.X *= -1;
      }
      // left boundary correction
      if (_pos.X < ball.ciRadius)
      {
        _pos.X = ball.ciRadius;
        _dir.X *= -1;
      }
      // bottom boundary correction
      if (_pos.Y >= _drawer.ScaledHeight - ball.ciRadius)
      {
        _pos.Y = _drawer.ScaledHeight - ball.ciRadius;
        _dir.Y *= -1;
      }
      // top boundary correction
      if (_pos.Y < ball.ciRadius)
      {
        _pos.Y = ball.ciRadius;
        _dir.Y *= -1;
      }
    }
    #endregion
  }
}
