namespace Atelier101
{
    internal class program
    {
        static int codeParam;
        static double detteInitiale;
        static double tauxInteretAnnuel;
        static double capitalInitial;
        static double rythmeComposition;
        static double dureePlacement;
        static void Main(string[] args)
        {
            int mois = 1;
            bool go = true;
            double solde;
            double interetcumulatif = 0;
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("\n                                                                             ");


                Console.WriteLine("Veuillez sélectionner entre l'option 'Remboursement de prêt' ou 'Rendement de prêt': ");
                Console.WriteLine("\n R - Remboursement de prêt\n P - Rendement d'un prêt\n");

                Console.Write("Option sélectionnée: ");
                string choix = Console.ReadLine();
            
                if (choix == "R" || choix == "r")
                {
                    codeParam = 0;
                    Console.Clear();
                    Console.WriteLine("Calcul de remboursement de carte de crédit");

                    SaisirParametres(codeParam);





                    solde = detteInitiale;
                    double tauxinteretmensuel = tauxInteretAnnuel / 12;
                    double paiementcumulatif = 0;




                    while (go)
                    {
                        double paiementminimal = 0.04 * solde;
                        double interetcourantcum = tauxinteretmensuel * solde;
                        interetcumulatif += interetcourantcum;

                        paiementcumulatif += paiementminimal;
                        if (mois % 1 == 0)
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
                    exit = true;
                }

                else if (choix == "P" || choix == "p")
                {
                    codeParam = 1;
                    Console.Clear();
                    Console.WriteLine("Calcul de rendement d'un placement");

                    SaisirParametres(codeParam);

                    solde = capitalInitial;
                    double tauxRythme = tauxInteretAnnuel / rythmeComposition;
                    double interetMensuel = 0;
                    double interetcumulatifcum = 0;
                    bool fin = false;
                    while (!fin)
                    {
                        Console.Write("Voulez-vous avoir les itérations mensuelles? oui ou non: ");
                        string choixIteration = Console.ReadLine();

                        if (choixIteration == "oui" || choixIteration == "Oui" || choixIteration == "y")
                        {
                            while (mois <= dureePlacement)
                            {
                                if (mois % 1 == 0)
                                {

                                    for (mois = 1; mois <= dureePlacement; mois++)
                                    {
                                        interetMensuel = tauxRythme * solde;
                                        solde += interetMensuel;
                                        interetcumulatifcum += interetMensuel;

                                        Console.WriteLine(mois.ToString("N0").PadLeft(6) + " " + solde.ToString("N2").PadLeft(9) + "$ " + interetMensuel.ToString("N2").PadLeft(7) + "$ " + interetcumulatifcum.ToString("N2").PadLeft(9) +
                                    "$ ");
                                    }
                                }

                            }
                            fin = true;
                        }
                        else if (choixIteration == "non" || choixIteration == "Non" || choixIteration == "n")
                        {
                            if (mois % 1 == 0)
                            {
                                for (mois = 1; mois <= dureePlacement; mois++)
                                {
                                    interetMensuel = tauxRythme * solde;
                                    solde += interetMensuel;
                                    interetcumulatifcum += interetMensuel;

                                    if (mois == dureePlacement)
                                    {
                                        Console.WriteLine(mois.ToString("N0").PadLeft(6) + " " + solde.ToString("N2").PadLeft(9) + "$ " + interetMensuel.ToString("N2").PadLeft(7) + "$ " + interetcumulatifcum.ToString("N2").PadLeft(9) +
                                                                    "$ ");
                                    }
                                }
                            }
                            fin = true;
                        }
                        else
                        {
                            Console.WriteLine("Oups!");

                        }
                    }
                    exit = true;
                }
                else
                {
                    Console.WriteLine("Oups!");
                }
            }
            
        }
        static void SaisirParametres(int code)
        {
            double resultat;
            string input;
            if (code == 0)
            {
                Console.Write("Veuillez entrer votre dette initiale: ");
                input = Console.ReadLine();
                Console.WriteLine("Vous avez une dette de: " + input + "$ ");

                if (double.TryParse(input, out resultat))
                {
                    detteInitiale = resultat;
                }
                else
                {
                    detteInitiale = 0;
                }
                SaisirTauxAnnuel();
            }    
            else
            {
                Console.Write("Veuillez entrer votre capital de Départ: ");
                input = Console.ReadLine();
                Console.WriteLine("Vous avez un capital de: " + input + "$ ");
                if (double.TryParse(input, out resultat))
                {
                    capitalInitial = resultat;
                }
                else
                {
                    capitalInitial = 0;
                }
                SaisirTauxAnnuel();
                Console.Write("Veuillez entrer votre rythme de composition: ");
                input = Console.ReadLine();
                if (double.TryParse(input, out resultat))
                {
                    rythmeComposition = resultat;
                }
                else
                {
                    rythmeComposition = 0;
                }
                Console.Write("Veuillez entrer votre durée de placement: ");
                input = Console.ReadLine();
                if (double.TryParse(input, out resultat))
                {
                    dureePlacement = resultat;
                }
                else
                {
                    dureePlacement = 0;
                }
            }

            

        }

        static void SaisirTauxAnnuel()
        {
            Console.Write("Veuillez entrez votre taux d'interet annuel: ");
            string input = Console.ReadLine();
            Console.WriteLine("Vous avez un taux d'intéret de: " + (input) + "% ");

            if (double.TryParse(input, out double resultat))
            {
                tauxInteretAnnuel = resultat;
            }
            else
            {
                tauxInteretAnnuel = 0;
            }
        }

        
    }
}