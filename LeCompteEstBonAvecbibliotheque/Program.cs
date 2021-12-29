using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeCompteEstBonAvecbibliotheque
{
  internal class Program
  {
    static void Main()
    {
      Action<string> Display = Console.WriteLine;
      Display("recherche si le compte est bon en utilisant ma bibliothèque");

      Display("press any key to exit:");
      Console.ReadKey();
    }
  }
}
