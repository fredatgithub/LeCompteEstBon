using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Le_compte_est_bon_NET48
{
    internal class Program
    {
        static int Niveau = 0;
        static int N = 6;     // Nombre de nombres
        struct OPERATION
        {
            public int Total;
            public int N1, N2;
            public char op;
            public bool interm;
        }

        static OPERATION[] Ops = new OPERATION[10];


        static void RetenirOpération(int Niv, int N1, char op, int N2, int TOTAL, bool interm)
        {
            Ops[Niv].N1 = N1; Ops[Niv].N2 = N2; Ops[Niv].Total = TOTAL;
            Ops[Niv].op = op;
            Ops[Niv].interm = interm;
            if (Niveau < Niv)
            {
                Niveau = Niv;
            }
        }

        static void AfficherRésultat()
        {
            // Afficher d'abord les calculs intermédiaires
            for (int i = 0; i < Niveau; i++)
            {
                if (Ops[i].interm)
                {
                    Console.WriteLine(Ops[i].N1 + " " + Ops[i].op + " " + Ops[i].N2 + " = " + Ops[i].Total);
                }
            }

            for (int i = Niveau; i >= 0; i--)
            {
                if (Ops[i].interm == false)
                {
                    Console.WriteLine(Ops[i].N1 + " " + Ops[i].op + " " + Ops[i].N2 + " = " + Ops[i].Total);
                }
            }
        }

        static void Main()
        {
            Action<string> display = Console.WriteLine;
            display("Le compte est bon inspiré du fameux jeu télévisé");
            display(string.Empty);
            int[] Nombres = new int[N];
            int Total;

            // saisir les N nombres
            string s;
            for (int i = 0; i < N; ++i)
            {
                Console.Write("Veuillez entrer le numéro N[" + i + "] ? ");
                s = Console.ReadLine(); Nombres[i] = int.Parse(s);
            }

            // saisie du total
            Console.Write("Quel est le total a atteindre ? ");
            s = Console.ReadLine();
            Total = int.Parse(s);
            display(string.Empty);
            display("Veuillez patienter pendant la recherche d'une solution ....");
            // rechercher LA solution
            bool trouvé = LeCompteEstIlBon(Nombres, Total, 0);
            if (trouvé)
            {
                Console.WriteLine("Le compte est bon !");
                AfficherRésultat();
                Console.Read();
                return;
            }

            // LA solution n'ayant pas été trouvée, rechercher la solution la plus proche
            int inc = 0;
            do
            {
                trouvé = LeCompteEstIlBon(Nombres, Total + inc, 0);
                if (trouvé == false)
                {
                    trouvé = LeCompteEstIlBon(Nombres, Total - inc, 0);
                }

                inc++;
            } while (trouvé == false);
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
                    int[] tr2 = new int[tableauRestant.Length + 1];
                    for (int k = 0; k < tableauRestant.Length; k++)
                    {
                        tr2[k] = tableauRestant[k];
                    }

                    tr2[tableauRestant.Length] = numbers[i] + numbers[j];
                    Array.Sort(tr2); Array.Reverse(tr2);
                    found = LeCompteEstIlBon(tr2, total, niveau + 1);
                    if (found)
                    {
                        RetenirOpération(niveau, numbers[i], '+', numbers[j], numbers[i] + numbers[j], true);
                        return true;
                    }

                    // essayer la soustraction de ces deux nombres   
                    // ajouter la différence au tableau des nombres restants
                    tr2 = new int[tableauRestant.Length + 1];
                    for (int k = 0; k < tableauRestant.Length; k++)
                    {
                        tr2[k] = tableauRestant[k];
                    }

                    tr2[tableauRestant.Length] = numbers[i] - numbers[j];
                    Array.Sort(tr2); Array.Reverse(tr2);
                    if (numbers[i] != numbers[j])
                    {
                        found = LeCompteEstIlBon(tr2, total, niveau + 1);
                        if (found)
                        {
                            RetenirOpération(niveau, numbers[i], '-', numbers[j], numbers[i] - numbers[j], true);
                            return true;
                        }
                    }

                    // essayer la multiplication de ces deux nombres   
                    // ajouter le produit au tableau des nombres restants
                    tr2 = new int[tableauRestant.Length + 1];
                    for (int k = 0; k < tableauRestant.Length; k++)
                    {
                        tr2[k] = tableauRestant[k];
                    }

                    tr2[tableauRestant.Length] = numbers[i] * numbers[j];
                    Array.Sort(tr2); Array.Reverse(tr2);
                    found = LeCompteEstIlBon(tr2, total, niveau + 1);
                    if (found)
                    {
                        RetenirOpération(niveau, numbers[i], '*', numbers[j], numbers[i] * numbers[j], true);
                        return true;
                    }

                    // essayer la division de ces deux nombres 
                    if (numbers[i] % numbers[j] == 0)
                    {
                        tr2 = new int[tableauRestant.Length + 1];
                        for (int k = 0; k < tableauRestant.Length; k++)
                        {
                            tr2[k] = tableauRestant[k];
                        }

                        tr2[tableauRestant.Length] = numbers[i] / numbers[j];
                        Array.Sort(tr2); Array.Reverse(tr2);
                        found = LeCompteEstIlBon(tr2, total, niveau + 1);
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

        static bool TrouverDansDeux(int TOTAL, int N1, int N2, int Niv)
        {

            if (TOTAL == N1 + N2)
            {
                RetenirOpération(Niv, N1, '+', N2, TOTAL, false);
                return true;
            }

            if (TOTAL == N1 - N2)
            {
                RetenirOpération(Niv, N1, '-', N2, TOTAL, false);
                return true;
            }

            if (TOTAL == N2 - N1)
            {
                RetenirOpération(Niv, N2, '-', N1, TOTAL, false);
                return true;
            }

            if (TOTAL == N1 * N2)
            {
                RetenirOpération(Niv, N1, '*', N2, TOTAL, false);
                return true;
            }

            if (N1 > N2 && N1 % N2 == 0 && TOTAL == N1 / N2)
            {
                RetenirOpération(Niv, N1, '/', N2, TOTAL, false);
                return true;
            }

            if (N2 > N1 && N2 % N1 == 0 && TOTAL == N2 / N1)
            {
                RetenirOpération(Niv, N2, '/', N1, TOTAL, false);
                return true;
            }

            return false;
        }
    }
}
