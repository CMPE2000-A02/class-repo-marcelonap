using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2Review
{
  internal class WCMatch
  {
    public string CountryA { get; private set; }
    public string CountryB { get; private set; }


    public int scoreA { get; private set; }
    public int scoreB { get; private set; }


    public int GoalDiff
    {
      get { return Math.Abs(scoreA - scoreB); }
    }

    public WCMatch(string A, string B, int scoreA, int scoreB)
    {
      CountryA = A;
      CountryB = B;
      this.scoreA = scoreA;
      this.scoreB = scoreB;
    }

    public override bool Equals(object obj)
    {
      if (!(obj is WCMatch match)) return false;
      bool result = false;
      string comparer = $"{CountryA}{CountryB}";
      result = comparer.Contains(match.CountryA) && comparer.Contains(match.CountryB);
      return result;
    }

    public override int GetHashCode()
    {
      return 1;
    }

    public override string ToString()
    {
      return $"{CountryA} : {scoreA} X {CountryB} : {scoreB}";
    }
  }
}
