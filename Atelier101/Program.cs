namespace Atelier101
{
    internal class program
    {
        static double detteInitiale;
        static double tauxInteretAnnuel;
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("\n                                                                             ");

            Console.WriteLine("Calcul de remboursement de carte de crédit");

            saisirparametres();

            
            

            bool go = true;
            double solde = detteInitiale;
            double tauxinteretmensuel = tauxInteretAnnuel / 12;
            double paiementcumulatif = 0;
            double interetcumulatif = 0;
            int mois = 1;


            while (go)
            {
                double paiementminimal = 0.04 * solde;
                double interetcourantcum = tauxinteretmensuel * solde;
                interetcumulatif += interetcourantcum;

                paiementcumulatif += paiementminimal;
                if(mois % 1 == 0)
                {
                    Console.WriteLine(mois.ToString("N0").PadLeft(6) + " " + solde.ToString("N2").PadLeft(9) + "$ " + paiementminimal.ToString("N2").PadLeft(7) + "$ " + paiementcumulatif.ToString("N2").PadLeft(9) +
                    "$ " + interetcourantcum.ToString("N2").PadLeft(7) + "$ " + interetcumulatif.ToString("N2").PadLeft(9) + "$ ");
                }
                


                solde -= paiementminimal - interetcourantcum;
                mois++;

                if (solde < 1)
                {
                    go = false;
                }
            }
        }
        static void saisirparametres()
        {
            Console.Write("Veuillez entrez votre dette initiale: ");
            string input = Console.ReadLine();
            Console.WriteLine("Vous avez une dette de: " + input + "$ ");

            if(double.TryParse(input, out double resultat))
            {
                detteInitiale = resultat;
            }
            else
            {
                detteInitiale = 0;
            }

            Console.Write("Veuillez entrez votre taux d'interet annuel: ");
            input = Console.ReadLine();
            Console.WriteLine("Vous avez un taux d'intéret de: " + (input) + "% ");

            if( double.TryParse(input, out resultat)) 
            {
                tauxInteretAnnuel = resultat;            
            }
            else
            {
                tauxInteretAnnuel= 0;
            }
        }
    }
}