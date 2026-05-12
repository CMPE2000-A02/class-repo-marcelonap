// Project : BounceBall
// Dec 03 2017
// By Simon Walker
//
// ball type - class definition - support class
// Print Format : Landscape
// ///////////////////////////////////////////////////////////////////////////

// See ball class for more details on style

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using static System.Diagnostics.Trace; // Pull Trace static helpers local, ie. WriteLine()

namespace BounceBall
{
  public partial class MainForm : Form
  {
    delegate void _delVoidVoid();

    // active balls in play (NOTE: All fields are commented)
    private List<ball> _balls = new List<ball>();

    Bird bird = new Bird(name: "Joanne", hasBeak: true, color: Color.Blue);
    Bird bird1 = new Bird(name: "Rex", hasBeak: true, color: Color.Blue);

    private int _nWidth = 0; // width in pixels for CDrawer
    // thread run flag, no marshalling required, only set in main thread
    private bool _running = false;

    #region Construction and Management

    public MainForm()
    {
      InitializeComponent();
      UI_Tim_Main.Tick += UI_Tim_Main_Tick; // bind timer callback
      UI_TextBox_1.TextChanged += UI_TextBox_1_TextChanged;

      // Event Subscriptions here
      _btnEngage.Click += EngageFireNow;
      _btnThread.Click += _btnThread_Click;
      UI_BirdButton.Click += UI_BirdButton_Click;
      // start with a single ball, centered in the drawer
      //  this should cue the user that clicking or something might add more...

      // _balls.Add(new ball(new PointF(400, 300))); NO ! hardcoded values, center can be resolved
      PointF center = new PointF(ball._drawer.ScaledWidth / 2, ball._drawer.ScaledHeight / 2);
      ball firstBall = new ball(center);
      _balls.Add(firstBall);
      if (bird.setNationality("Brazil"))
        WriteLine($"Nationality succesfully set: {bird1.Nationality} ");
    }

    private void UI_BirdButton_Click(object sender, EventArgs e)
    {
      WriteLine(bird);
      bird.fly(distance: -5);
      WriteLine(bird.displayDistanceTraveled());
      if (!bird.setNationality(""))
        WriteLine("Nationality failed to be set");

      if (bird.hasBeak)
      {
        WriteLine($"{bird.name} has a beak!!");
      }
      else
      {
        bird.hasBeak = true;
      }
    }

    private void UI_TextBox_1_TextChanged(object sender, EventArgs e)
    {
      TextBox target = sender as TextBox;
      WriteLine($"Text has changed: {target.Text}");
    }

    #endregion

    #region Event Handlers
    private void _btnThread_Click(object sender, EventArgs e)
    {
      System.Threading.Thread thread = new System.Threading.Thread(PopBalls);
      thread.IsBackground = true;
      _running = true; // tell thread to keep it up..
      thread.Start(UI_TextBox_1.Text);
    }
    // ///////////////////////////////////////////////////////////////////
    // Main animation timer 
    // Balls are added, moved, and rendered in this event        
    // ///////////////////////////////////////////////////////////////////
    private void UI_Tim_Main_Tick(object sender, EventArgs e)
    {
      // if there is a new left-click, add a new ball at the click position
      if (ball._drawer.GetLastMouseLeftClick(out Point pt))
        lock (_balls)
          _balls.Add(new ball(new PointF(pt.X, pt.Y)));

      // start of scene presentation 
      ball._drawer.Clear();
      // Cheapest possible Key object for Locks.
      //Object exampleKey = new object();
      // move and render each ball in the scene 
      lock (_balls)
      {
        foreach (ball b in _balls)
        {
          b.Move();
          b.Render();
        }
      }

      // check each ball against every other ball to look for overlap (using equals)
      //  if balls are found to overlap, change color to green to mark as such
      lock (_balls)
      {
        for (int iOut = 0; iOut < _balls.Count; iOut++)
        {
          for (int iIn = 0; iIn < _balls.Count; iIn++)
          {
            // ensure ball is not itself, and check for overlap
            if (iOut != iIn && _balls[iOut].Equals(_balls[iIn]))
            {
              // ball are different and overlapping, change to green
              _balls[iOut].BallColor = Color.Green;
              _balls[iIn].BallColor = Color.Green;
            }
          }
        }
      }

      // end of scene presentation
      ball._drawer.Render();

      // Extraneous Delegate/Invoke example from review material
      //_delVoidVoid doThing = DoNothing;
      //doThing.Invoke(); // invoke DoNothing() in current context...
      //Invoke(doThing); // This will "request" that the main thread do this call
      //Invoke(new _delVoidVoid(DoNothing));
    }
    /// <summary>
    /// Sample Event callback using Enviroment for OpenFileDialog initialization
    /// </summary>
    /// <param name="sender">Engage button</param>
    /// <param name="e">args</param>
    private void EngageFireNow(object sender, EventArgs e)
    {
      OpenFileDialog ofd = null;
      ofd = new OpenFileDialog();
      ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
      // 
      ofd.Filter = "puzzles|*.txt|All|*.*";
      if (ofd.ShowDialog() != DialogResult.OK) return;
      WriteLine($"User chose : {ofd.FileName}"); // Output to Console..
    }
    private void DoNothing()
    {
      List<int> _lst = new List<int>(); // or = null; // to see ?? in action
      _lst = _lst ?? new List<int>();

      //string middlename = ( emp?.MidName ?? "N/A" ) ?? "oops"; // ?? used as default filler
    }
    /// <summary>
    /// Thread method used to remove balls from the list if the list exceeds param value
    /// </summary>
    private void PopBalls(object numBalls)
    {
      int maxBalls = int.MaxValue; // biggest value allowed as default
      // initialize, extract our max balls allowed count
      int captureBalls = 0;
      if (numBalls is int)
        maxBalls = (int)numBalls;
      if (int.TryParse(numBalls as String, out captureBalls))
        maxBalls = captureBalls;
       if (maxBalls < 1)
        maxBalls = int.MaxValue;
      // main forever loop, continue while allowed
      while (_running)
      {
        System.Threading.Thread.Sleep(2000);
        lock (_balls)
        {
          while (_balls.Count > maxBalls) // if() ? really ? check requirements...
            _balls.RemoveAt(_balls.Count - 1); // remove last, is that a problem ???
        }
      }
    }
    #endregion

    private void UI_ApplyButton_Click(object sender, EventArgs e)
    {

    }
  }
}
