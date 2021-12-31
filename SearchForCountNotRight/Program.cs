using LibraryLeCompteEstbon;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SearchForCountNotRight
{
  internal class Program
  {
    static void Main()
    {
      Action<string> Display = Console.WriteLine;
      Display("Searching for a count not right");
      Display(string.Empty);
      Display("Please wait while searching ...");
      Stopwatch chrono = new Stopwatch();
      //chrono.Start();
      int[] source = new int[] { 1, 2, 3,4,5,6,111 };
      //for (int i = 101; i < 1000; i++)
      //{
      //  if (!ClassLeCompteEstBon.IsTheCountRight(source[0], source[1], source[2], source[3], source[4], source[5], i))
      //  {
      //    Console.ForegroundColor = ConsoleColor.Red;
      //    Display($"Le compte n'est pas bon pour les nombres suivants : {source[0]}, {source[1]}, {source[2]}, {source[3]}, {source[4]}, {source[5]} pour le total : {i}");
      //  }
      //  else
      //  {
      //    Console.ForegroundColor = ConsoleColor.Green;
      //    //Display($"Le compte est bon pour le total : {i}");
      //  }
      //}

      //chrono.Stop();
      //Display($"Le temps en parallel est de : {chrono.ElapsedMilliseconds}"); //  119258 milliseconds = 1 minute and 59 seconds 

      // now in parallel
      chrono = new Stopwatch();
      chrono.Start();
      Parallel.For(101, 999, i =>
        {
          if (!ClassLeCompteEstBon.IsTheCountRight(source[0], source[1], source[2], source[3], source[4], source[5], i))
          {
            Console.ForegroundColor = ConsoleColor.Red;
            Display($"Le compte n'est pas bon pour les nombres suivants : {source[0]}, {source[1]}, {source[2]}, {source[3]}, {source[4]}, {source[5]} pour le total : {i}");
          }
        });
      
      chrono.Stop();
      Console.ForegroundColor= ConsoleColor.Green;
      Display($"Le temps en parallel est de : {chrono.ElapsedMilliseconds} millisecondes soit {chrono.ElapsedMilliseconds/1000} secondes"); //  19 014 milliseconds = 19 seconds

      Console.ForegroundColor = ConsoleColor.White;
      Display("Press any key to exit:");
      Console.ReadKey();
    }
  }
}
