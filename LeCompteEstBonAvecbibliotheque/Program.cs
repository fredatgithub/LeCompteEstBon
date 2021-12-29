using System;
using LibraryLeCompteEstbon;

namespace LeCompteEstBonAvecbibliotheque
{
  internal class Program
  {
    static void Main()
    {
      Action<string> Display = Console.WriteLine;
      Display("Recherche si le compte est bon en utilisant ma bibliothèque");
      Display(string.Empty);
      Display("Recherche du total 111 avec les nombres 1,2,3,4,5,6");
      Display(string.Empty);
      if (ClassLeCompteEstBon.IsTheCountJust(1, 2, 3, 4, 5, 6, 111))
      {
        Console.ForegroundColor = ConsoleColor.Green;
        Display("Le compte est bon :");
      }
      else
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Display("Le compte n'est pas bon mais la meilleure solution est :");
      }

      Display(string.Empty);
      Display($"{ClassLeCompteEstBon.CalculateIfTheCountIsCorrect(1, 2, 3, 4, 5, 6, 111)}");
      Display(string.Empty);
      Console.ForegroundColor = ConsoleColor.White;
      Display("press any key to exit:");
      Console.ReadKey();
    }
  }
}
