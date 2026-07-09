using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exam2Review
{
  public partial class Form1 : Form
  {
    List<WCMatch> matches = new List<WCMatch>();
    public Form1()
    {
      InitializeComponent();

      PopulateMatches();
      FilterTeamAWinners();
      //TESTING EQUALITY OVERRIDE
      WCMatch A = new WCMatch("Brazil", "Netherlands", 0,0);
      WCMatch B = new WCMatch("Japan","Brazil", 1,2);
      A.IsTeamAWinner();
      Console.WriteLine($"A == B: {A.Equals(B)}");
    }

    public void FilterTeamAWinners()
    {
      IEnumerable<WCMatch> teamAWinners = matches.Where(match => match.IsTeamAWinner()); 
      foreach(WCMatch match in teamAWinners)
      {
        Console.WriteLine($"{match}");
      }
    }

    public void PopulateMatches()
    {
      // Add 20 UNIQUE matches to our list
      Random rand = new Random();
      for(int i = 0; i < 20; i++)
      {
        WCMatch newMatch = new WCMatch(WorldCupData.GetRandomCountry(), WorldCupData.GetRandomCountry(), rand.Next(0,8), rand.Next(0,8));
        if (matches.Contains(newMatch))
        {
          i--;
          continue;
        }
        matches.Add(newMatch);
      }

      matches.ForEach(match => Console.WriteLine($"Unique: {match}"));

      //while(matches.Count < 20)
      //{
      //  WCMatch newMatch = new WCMatch(WorldCupData.GetRandomCountry(), WorldCupData.GetRandomCountry());
      //  if (!matches.Contains(newMatch))
      //    matches.Add(newMatch);
      //}
    }
  }


  public class WorldCupData
  {
    private static readonly Random _random = new Random();

    public static readonly List<string> Countries = new List<string>
    {
        "Canada", "Mexico", "USA", "Argentina", "Brazil", "France", "Germany",
        "Japan", "Morocco", "Senegal", "Spain", "England", "Portugal" 
    };

    public static string GetRandomCountry() => Countries[_random.Next(Countries.Count)];
  }
}
