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
    Dictionary<WCMatch, string> dict = new Dictionary<WCMatch, string>();
      Random rand = new Random();
    public Form1()
    {
      InitializeComponent();

      PopulateMatches();
      FilterTeamAWinners();
      PopulateDictionary();
      HypotheticalQ();
      //TESTING EQUALITY OVERRIDE
      WCMatch A = new WCMatch("Brazil", "Japan", 0, 0);
      WCMatch B = new WCMatch("Japan", "Brazil", 1, 2);
      A.IsTeamAWinner();
      Console.WriteLine($"A == B: {A.Equals(B)}");
    }

    public void PopulateDictionary()
    {
      dict = matches.ToDictionary(match => match, match => match.Winner() );
      while(dict.Count < 40)
      {
        WCMatch newMatch = new WCMatch(WorldCupData.GetRandomCountry(), WorldCupData.GetRandomCountry(), rand.Next(0,8), rand.Next(0,8));
        if (!dict.ContainsKey(newMatch))
        {
          dict[newMatch] = newMatch.Winner();
        }
      }
      foreach( KeyValuePair<WCMatch, string> kvp in dict)
      {
        Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
      }

      Dictionary<string, int> newDict = new Dictionary<string, int>();

      IEnumerable<WCMatch> keys = dict.Keys;

      // NO logical meaning. but notice how we can chain iEnumerable methods
      foreach(WCMatch match in dict.Keys.Where(key => key.IsTeamAWinner()).Take(10).Distinct().Concat( dict.Keys.Skip(3)).Distinct()  ) 
      {
        string country = dict[match];
      }
      
      foreach (WCMatch match in dict.Keys)
      {
        if (!newDict.ContainsKey(match.Winner()))
        {
          newDict[match.Winner()] = 0;
        }
        newDict[match.Winner()] += match.GoalDiff;
      }

      foreach (KeyValuePair<string, int> kvp in newDict)
      {
        Console.WriteLine($"{kvp.Key} - GD: {kvp.Value}");
      }
      Dictionary<string, int> orderedDict = newDict.OrderBy(kvp => kvp.Value).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
      Console.WriteLine("Ordered dict:");
      foreach (KeyValuePair<string, int> kvp in orderedDict)
      {
        Console.WriteLine($"{kvp.Key} - GD: {kvp.Value}");
      }



    }

    public void FilterTeamAWinners()
    {
      IEnumerable<WCMatch> teamAWinners = matches.Where(match => match.IsTeamAWinner()); 
      foreach(WCMatch match in teamAWinners)
      {
        Console.WriteLine($"{match}");
      }
    }

    public void HypoteticalQ()
    {
      Queue<WCMatch> queue = new Queue<WCMatch>();
      LinkedList<WCMatch> linkedList = new LinkedList<WCMatch>();
      
      while(queue.Count < 10)
      {
        WCMatch newMatch = new WCMatch(WorldCupData.GetRandomCountry(), WorldCupData.GetRandomCountry(), rand.Next(0,8), rand.Next(0,8));
        if (!queue.Contains(newMatch))
          queue.Enqueue(newMatch);
      }

      while(linkedList.Count < 10)
      {
         WCMatch newMatch = new WCMatch(WorldCupData.GetRandomCountry(), WorldCupData.GetRandomCountry(), rand.Next(0,8), rand.Next(0,8));
        if (!linkedList.Contains(newMatch))
          linkedList.AddLast(newMatch);
      }

      foreach(WCMatch match in queue.Concat(linkedList).Where(match => match.scoreA > 3).Skip(2).Distinct())
      {
        
      }

      List<WCMatch> list2 = new List<WCMatch>();

      IEnumerable<WCMatch> concat2 = list2.Concat(queue.Concat(linkedList).Where(match => match.scoreA > 3).Skip(2).Distinct());

      List<WCMatch> list3 = queue.Concat(linkedList).Where(match => match.scoreA > 3).Skip(2).Distinct().ToList();
      Dictionary<string, int> dict2 = queue.Concat(linkedList).Where(match => match.scoreA > 3).Skip(2).Distinct().OrderByDescending(match => match.GoalDiff).ToDictionary(match => match.Winner(), match => match.GoalDiff);
      Dictionary<string, int> dict3 = dict2.OrderBy(kvp => kvp.Value).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
    }

    public void PopulateMatches()
    {
      // Add 20 UNIQUE matches to our list
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
