using System;
using System.Linq;
namespace Program
{
  class Program
  {
    static void Main(string[] args)
    {
      bool addAnotherPossibiltiy = true;
      string[] possibilities = { };
      int[] hammingDistance = { };
      Console.Write("Enter Input String : ");
      string? input = Console.ReadLine();
      do
      {
        Console.Write("Enter Possibilty : ");
        string? tempPossibility = Console.ReadLine();
        if (tempPossibility != "" && tempPossibility != null)
        {
          possibilities = possibilities.Concat(new string[] { tempPossibility }).ToArray();
          Console.Write("Do You Want To Enter Another Possibilty (ex: true or false)? : ");
          addAnotherPossibiltiy = Convert.ToBoolean(Console.ReadLine());
        }
      } while (addAnotherPossibiltiy);
      for (int i = 0; i < possibilities.Length; i++)
      {
        if (input != null)
        {
          int distance = calculateHammingDistance(input.ToLower(), possibilities[i].ToLower());
          hammingDistance = hammingDistance.Concat(new int[] { distance }).ToArray();
        }
      }
      int[] sortedIndexArray = hammingDistance.Select((r, i) => new { Value = r, Index = i })
                            .OrderBy(t => t.Value)
                            .Select(p => p.Index)
                            .ToArray();
      for (int i = 0; i < sortedIndexArray.Length; i++)
      {
        Console.WriteLine($"{i + 1}) Match {possibilities[sortedIndexArray[i]]}");
      }
    }
    static int calculateHammingDistance(string input, string possibility)
    {
      int distance = 0;
      for (int i = 0; i < Math.Min(input.Length, possibility.Length); i++)
      {
        if (input[i] != possibility[i])
        {
          distance++;
        }
      }
      int max = Math.Max(input.Length, possibility.Length);
      int min = Math.Min(input.Length, possibility.Length);
      return distance + (max - min);
    }
  }
}