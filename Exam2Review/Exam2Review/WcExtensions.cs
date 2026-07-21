using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exam2Review
{
  internal static class WcExtensions
  {
    public static bool EnqueueIfNew(this Queue<WCMatch> queue, WCMatch newMatch) 
    {
      if (queue.Contains(newMatch))
        return false;

      queue.Enqueue(newMatch);
      return true;

    }

    public static bool IsTeamAWinner(this WCMatch match)
    {
           return match.scoreA > match.scoreB;
    }

    public static string Winner(this WCMatch match)
    {
      string result = "";
      result = match.IsTeamAWinner() ? match.CountryA : match.CountryB;
      return result;
    }
  }
}
