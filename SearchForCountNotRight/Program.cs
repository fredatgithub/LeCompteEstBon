using LibraryLeCompteEstbon;
using System;

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
      // string lesNombres = "1,2,3,4,5,6,111";
      int[] source = new int[] { 1, 2, 3,4,5,6,111 };
      bool result = ClassLeCompteEstBon.IsTheCountRight(source[0], source[1], source[2], source[3], source[4], source[5], source[6]);
      for (int i = 101; i < 1000; i++)
      {
        if (!ClassLeCompteEstBon.IsTheCountRight(source[0], source[1], source[2], source[3], source[4], source[5], i))
        {
          Console.ForegroundColor = ConsoleColor.Red;
          Display($"Le compte n'est pas bon pour les nombres suivants : {source[0]}, {source[1]}, {source[2]}, {source[3]}, {source[4]}, {source[5]} pour le total : {i}");
        }
        else
        {
          Console.ForegroundColor = ConsoleColor.Green;
          //Display($"Le compte est bon pour le total : {i}");
        }
      }
      //Parallel.For(101, 999)
      //  {

      //}

      Console.ForegroundColor = ConsoleColor.White;
      Display("Press any key to exit:");
      Console.ReadKey();
    }
  }
}
