using System;

namespace Le_compte_est_bon_NET48
{
  internal class Program
    {
        static int Niveau = 0;
        static int NumberOfNumbers = 6;     // Nombre de nombres
        struct Operation
        {
            public int Total;
            public int Number1;
            public int Number2;
            public char TheOperation;
            public bool Intermediare;
        }

        static Operation[] Operations = new Operation[10];


        public static void RetenirOpération(int niveau, int number1, char operation, int number2, int total, bool intermediare)
        {
            Operations[niveau].Number1 = number1; Operations[niveau].Number2 = number2; Operations[niveau].Total = total;
            Operations[niveau].TheOperation = operation;
            Operations[niveau].Intermediare = intermediare;
            if (Niveau < niveau)
            {
                Niveau = niveau;
            }
        }

        public static void AfficherRésultat()
        {
            // Afficher d'abord les calculs intermédiaires
            for (int i = 0; i < Niveau; i++)
            {
                if (Operations[i].Intermediare)
                {
                    Console.WriteLine(Operations[i].Number1 + " " + Operations[i].TheOperation + " " + Operations[i].Number2 + " = " + Operations[i].Total);
                }
            }

            for (int i = Niveau; i >= 0; i--)
            {
                if (Operations[i].Intermediare == false)
                {
                    Console.WriteLine(Operations[i].Number1 + " " + Operations[i].TheOperation + " " + Operations[i].Number2 + " = " + Operations[i].Total);
                }
            }
        }

        private static void Main()
        {
            Action<string> display = Console.WriteLine;
            display("Le compte est bon inspiré du fameux jeu télévisé");
            display(string.Empty);
            int[] Nombres = new int[NumberOfNumbers];
            int Total;

            // saisir les N nombres
            string candidateNumbers;
            for (int i = 0; i < NumberOfNumbers; ++i)
            {
                Console.Write("Veuillez entrer le numéro N[" + i + "] ? ");
                candidateNumbers = Console.ReadLine(); Nombres[i] = int.Parse(candidateNumbers);
            }

            // saisie du total
            Console.Write("Quel est le total a atteindre ? ");
            candidateNumbers = Console.ReadLine();
            Total = int.Parse(candidateNumbers);
            display(string.Empty);
            display("Veuillez patienter pendant la recherche d'une solution ....");
            // rechercher LA solution
            bool found = LeCompteEstIlBon(Nombres, Total, 0);
            if (found)
            {
                Console.WriteLine("Le compte est bon !");
                AfficherRésultat();
                display("press any key to exit:");
                Console.ReadKey();
                return;
            }

            // LA solution n'ayant pas été trouvée, rechercher la solution la plus proche
            int incrementation = 0;
            do
            {
                found = LeCompteEstIlBon(Nombres, Total + incrementation, 0);
                if (found == false)
                {
                    found = LeCompteEstIlBon(Nombres, Total - incrementation, 0);
                }

                incrementation++;
            } while (found == false);
            Console.WriteLine("Meilleure solution : ");
            AfficherRésultat();
            Console.Read();
        }

        public static bool EssaiOpération(int total, int number, int[] tableauNombres, int niveau)
        {
            bool found;

            if (total <= 0)
            {
                return false;
            }

            // Peut-on réaliser TOTAL = NB + ? (? désignant une combinaison des nombres restants)
            if (total > number)
            {
                found = LeCompteEstIlBon(tableauNombres, total - number, niveau + 1);
                if (found)
                {
                    RetenirOpération(niveau, number, '+', (total - number), total, false);
                    return true;
                }
            }

            // Peut-on réaliser TOTAL = NB - ?
            if (total < number)
            {
                found = LeCompteEstIlBon(tableauNombres, number - total, niveau + 1);
                if (found)
                {
                    RetenirOpération(niveau, number, '-', (number - total), total, false);
                    return true;
                }
            }

            // Peut-on réaliser TOTAL = ? - NB
            found = LeCompteEstIlBon(tableauNombres, number + total, niveau + 1);
            if (found)
            {
                RetenirOpération(niveau, (total + number), '-', number, total, false);
                return true;
            }

            // Peut-on réaliser TOTAL = NB * ?
            if (total % number == 0)
            {
                found = LeCompteEstIlBon(tableauNombres, total / number, niveau + 1);
                if (found)
                {
                    RetenirOpération(niveau, number, '*', (total / number), total, false);
                    return true;
                }
            }

            // Peut-on réaliser TOTAL = NB / ?
            if (number % total == 0)
            {
                found = LeCompteEstIlBon(tableauNombres, number / total, niveau + 1);
                if (found)
                {
                    RetenirOpération(niveau, number, '/', (number / total), total, false);
                    return true;
                }
            }

            return false;
        }

        public static bool LeCompteEstIlBon(int[] numbers, int total, int niveau)
        {
            bool found;
            int[] tableauRestant;

            if (total <= 0 || numbers.Length == 0)
            {
                return false;
            }


            // trier le tableau des nombres restants par ordre décroissant
            Array.Sort(numbers); 
            Array.Reverse(numbers);

            // Un seul des nombres restants ferait-il l'affaire ?
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == total)
                {
                    return true;
                }
            }

            // s'il ne reste plus que deux nombres ....
            if (numbers.Length == 2)
            {
                return TrouverDansDeux(total, numbers[0], numbers[1], niveau);
            }

            // prendre l'un des nombres restants et essayer une combinaison à partir de ce nombre
            for (int i = 0; i < numbers.Length; i++)
            {
                // Préparer le tableau tr des nombres restants
                tableauRestant = new int[numbers.Length - 1];
                for (int j = 0, k = 0; j < numbers.Length; j++)
                {
                    if (i != j)
                    {
                        tableauRestant[k] = numbers[j]; k++;
                    }
                }

                found = EssaiOpération(total, numbers[i], tableauRestant, niveau);
                if (found)
                {
                    return true;
                }
            }

            // essayer ensuite une opération à partir de deux nombres

            if (numbers.Length < 3)
            {
                Console.WriteLine("Ici avec un tableau de moins de 3 éléments !!");
                return false;
            }

            for (int i = 0; i < numbers.Length; i++)                      // choix du premier nombre
            {
                // prendre un deuxième nombre parmi les restants
                for (int j = i + 1; j < numbers.Length; j++)                   // choix du deuxième nombre
                {
                    tableauRestant = new int[numbers.Length - 2];
                    int n = 0;
                    for (int k = 0; k < numbers.Length; k++)
                    {
                        if (k != i && k != j)
                        {
                            tableauRestant[n] = numbers[k]; n++;
                        }
                    }

                    // essayer l'addition de ces deux nombres  
                    // ajouter la somme au tableau des nombres restants
                    int[] tableauRestant2 = new int[tableauRestant.Length + 1];
                    for (int k = 0; k < tableauRestant.Length; k++)
                    {
                        tableauRestant2[k] = tableauRestant[k];
                    }

                    tableauRestant2[tableauRestant.Length] = numbers[i] + numbers[j];
                    Array.Sort(tableauRestant2); 
                    Array.Reverse(tableauRestant2);
                    found = LeCompteEstIlBon(tableauRestant2, total, niveau + 1);
                    if (found)
                    {
                        RetenirOpération(niveau, numbers[i], '+', numbers[j], numbers[i] + numbers[j], true);
                        return true;
                    }

                    // essayer la soustraction de ces deux nombres   
                    // ajouter la différence au tableau des nombres restants
                    tableauRestant2 = new int[tableauRestant.Length + 1];
                    for (int k = 0; k < tableauRestant.Length; k++)
                    {
                        tableauRestant2[k] = tableauRestant[k];
                    }

                    tableauRestant2[tableauRestant.Length] = numbers[i] - numbers[j];
                    Array.Sort(tableauRestant2); 
                    Array.Reverse(tableauRestant2);
                    if (numbers[i] != numbers[j])
                    {
                        found = LeCompteEstIlBon(tableauRestant2, total, niveau + 1);
                        if (found)
                        {
                            RetenirOpération(niveau, numbers[i], '-', numbers[j], numbers[i] - numbers[j], true);
                            return true;
                        }
                    }

                    // essayer la multiplication de ces deux nombres   
                    // ajouter le produit au tableau des nombres restants
                    tableauRestant2 = new int[tableauRestant.Length + 1];
                    for (int k = 0; k < tableauRestant.Length; k++)
                    {
                        tableauRestant2[k] = tableauRestant[k];
                    }

                    tableauRestant2[tableauRestant.Length] = numbers[i] * numbers[j];
                    Array.Sort(tableauRestant2); 
                    Array.Reverse(tableauRestant2);
                    found = LeCompteEstIlBon(tableauRestant2, total, niveau + 1);
                    if (found)
                    {
                        RetenirOpération(niveau, numbers[i], '*', numbers[j], numbers[i] * numbers[j], true);
                        return true;
                    }

                    // essayer la division de ces deux nombres 
                    if (numbers[i] % numbers[j] == 0)
                    {
                        tableauRestant2 = new int[tableauRestant.Length + 1];
                        for (int k = 0; k < tableauRestant.Length; k++)
                        {
                            tableauRestant2[k] = tableauRestant[k];
                        }

                        tableauRestant2[tableauRestant.Length] = numbers[i] / numbers[j];
                        Array.Sort(tableauRestant2); 
                        Array.Reverse(tableauRestant2);
                        found = LeCompteEstIlBon(tableauRestant2, total, niveau + 1);
                        if (found)
                        {
                            RetenirOpération(niveau, numbers[i], '/', numbers[j], numbers[i] / numbers[j], true);
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public static bool TrouverDansDeux(int total, int number1, int number2, int niveau)
        {

            if (total == number1 + number2)
            {
                RetenirOpération(niveau, number1, '+', number2, total, false);
                return true;
            }

            if (total == number1 - number2)
            {
                RetenirOpération(niveau, number1, '-', number2, total, false);
                return true;
            }

            if (total == number2 - number1)
            {
                RetenirOpération(niveau, number2, '-', number1, total, false);
                return true;
            }

            if (total == number1 * number2)
            {
                RetenirOpération(niveau, number1, '*', number2, total, false);
                return true;
            }

            if (number1 > number2 && number1 % number2 == 0 && total == number1 / number2)
            {
                RetenirOpération(niveau, number1, '/', number2, total, false);
                return true;
            }

            if (number2 > number1 && number2 % number1 == 0 && total == number2 / number1)
            {
                RetenirOpération(niveau, number2, '/', number1, total, false);
                return true;
            }

            return false;
        }
    }
}
