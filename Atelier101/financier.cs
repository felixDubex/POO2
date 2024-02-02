//--------------------------------------------------
// Fichier financier.cs
// Auteur: Félix Dubé
// Création: 2024-01-31
//--------------------------------------------------
namespace Atelier2C6_101_2024
{
    internal class Financier
    {
        static double _detteInitiale;
        static double _capitalInitial;
        static double _tauxInteretAnnuel;
        static double _rythmeComposition;
        static double _dureePlacement;
        static double _tauxRythme;
        static double _capital;
        static int _mois;
        static double _interetCumulatif = 0;
        public void Exec()
        {
            bool go = true;

            while (go)
            {
                Util.Titrer("Le Financier");
                AfficherMenu();
                string option = ExecuterChoix();
                if (option == "Q")
                {
                    break;
                }
                Util.Pause();
            }
        }

        //--------------------------------------------------
        //
        //--------------------------------------------------


        void AfficherMenu()
        {
            Console.WriteLine("D- Dette remboursement");
            Console.WriteLine("P- Placement rendement");
            Console.WriteLine("Q- Quitter");
            Console.Write("\nvotre choix:");
        }

        //--------------------------------------------------
        //
        //--------------------------------------------------

        string ExecuterChoix()
        {
            char choix = Util.SaisirChar();
            string option = choix.ToString().ToUpper();

            switch (option)
            {
                case ("D"):
                    CalculerDette();
                    break;
                case ("P"):
                    CalculerPlacement();
                    break;
                case ("Q"):
                default:
                    break;
            }
            
            
            return option;
        }

        //--------------------------------------------------
        //
        //--------------------------------------------------

        void CalculerPlacement()
        {
            Util.Titrer("Calcul d'un placement");
            SaisirCapital();           
            SaisirTauxAnnuel();
            SaisirRythme();
            SaisirDuree();
            _tauxRythme = _tauxInteretAnnuel / _rythmeComposition;
            bool finPlacement = false;
            while (!finPlacement)
            {
                Console.Write("Voulez-vous avoir les itérations ? oui ou non: ");
                string choixIteration = Console.ReadLine();
                       
                if (choixIteration == "oui" || choixIteration == "Oui" || choixIteration == "y")
                {
                    AfficherIterations();
                    finPlacement = true;
                }

                else if (choixIteration == "non" || choixIteration == "Non" || choixIteration == "n")
                {
                    AfficherFin();
                    finPlacement = true;
                }
            }
           
        }

        //--------------------------------------------------
        //
        //--------------------------------------------------

        void CalculerDette()
        {
            Util.Titrer("Calcul d'une dette");
            SaisirParametres();
            double tauxInteretAnnuel = 0.21;
            double tauxInteretMensuel = tauxInteretAnnuel / 12;
            Console.WriteLine("Dette initiale:" + _detteInitiale + "$\nTaux intérêt annuel:" + tauxInteretAnnuel);     
            int mois = 1;
            double interetCum = 0;
            double paiementCum = 0;
            double solde = _detteInitiale;
            while (solde >1)
            {
                double paiementMin = 0.04 * solde;
                double interetCourant = solde * tauxInteretMensuel;
                paiementCum += paiementMin;
                interetCum += interetCourant;
                if (mois % 1 == 0)
                {
                    Console.WriteLine(_mois.ToString("N0").PadLeft(6) + " "
                               + solde.ToString("N2").PadLeft(9) + " "
                               + paiementMin.ToString("N2").PadLeft(7) + " "
                               + paiementCum.ToString("N2").PadLeft(9) + " "
                               + interetCourant.ToString("N2").PadLeft(7) + " "
                               + interetCum.ToString("N2").PadLeft(9));
                }
                solde -= paiementMin - interetCourant;
                _mois++;    
            }
        }

        //--------------------------------------------------
        //
        //--------------------------------------------------

        void SaisirParametres()
        {  
            _detteInitiale = Util.SaisirUnDouble("\nMontant de la dette");

        }

        //--------------------------------------------------
        //
        //--------------------------------------------------

        void SaisirCapital()
        {
            _capitalInitial = Util.SaisirUnDouble("\n Montant du capital: ");
        }

        //--------------------------------------------------
        //
        //--------------------------------------------------

        static void SaisirTauxAnnuel()
        {
            _tauxInteretAnnuel = Util.SaisirUnDouble("\n Saisir le taux d'intérêt annuel: ");
        }

        //--------------------------------------------------
        //
        //---------------------------------------------------

        static void SaisirRythme()
        {
            MenuRythme();
            char choix = Util.SaisirChar();
            string option = choix.ToString().ToUpper();
            switch (option)
            {
                case ("A"):
                    _rythmeComposition = 1;
                    break;
                case ("M"):
                    _rythmeComposition =  12;
                    break;
                case ("Q"):
                    _rythmeComposition = 365.24;
                    break;
                
            }
        }

        //--------------------------------------------------
        //
        //--------------------------------------------------

        static void SaisirDuree()
        {
            Console.Write("\nVeuillez entrer votre durée de placement(en mois): ");
            string input = Console.ReadLine();
            if (double.TryParse(input, out double resultat))
            {
                if (_rythmeComposition == 1)
                {
                    _dureePlacement = resultat / 12;
                }
                else if (_rythmeComposition == 365.24)
                {
                    _dureePlacement = resultat / 12 * 365.24;
                }
                else
                {
                    _dureePlacement = resultat;
                }
            }
            else
            {
                _dureePlacement = 0;
            }
        }

        //--------------------------------------------------
        //
        //--------------------------------------------------

        static void AfficherIterations()
        {
            _capital = _capitalInitial;
            
            while (_mois <= _dureePlacement)
            {
                if (_mois % 1 == 0)
                {

                    for (_mois = 1; _mois <= _dureePlacement; _mois++)
                    {
                        double interetMensuel = _tauxRythme * _capital  ;
                        _capital += interetMensuel;
                        _interetCumulatif += interetMensuel;

                        Console.WriteLine(_mois.ToString("N0").PadLeft(6) + " " + _capital.ToString("N2").PadLeft(9) + "$ " + interetMensuel.ToString("N2").PadLeft(7) + "$ " + _interetCumulatif.ToString("N2").PadLeft(9) + "$ ");
                    }
                }
            }
        }

        //--------------------------------------------------
        //
        //--------------------------------------------------


        static void AfficherFin()
        {
            _capital = _capitalInitial;
            
            if (_mois % 1 == 0)
            {
                for (_mois = 1; _mois <= _dureePlacement; _mois++)
                {
                    double interetMensuel = _tauxRythme * _capital;
                    _capital += interetMensuel;
                    _interetCumulatif += interetMensuel;

                    if (_mois == _dureePlacement)
                    {
                        Console.WriteLine(_mois.ToString("N0").PadLeft(6) + " " + _capital.ToString("N2").PadLeft(9) + "$ " + interetMensuel.ToString("N2").PadLeft(7) + "$ " + _interetCumulatif.ToString("N2").PadLeft(9) + "$ ");
                    }
                }
            }
        }

        //--------------------------------------------------
        //
        //--------------------------------------------------

        static void MenuRythme()
        {
            Console.WriteLine("Veuillez entrer votre rythme de composition: ");
            Console.WriteLine("A- Annuel");
            Console.WriteLine("M- Mensuel");
            Console.WriteLine("Q- Quotidien");
            Console.Write("\nvotre choix:");
        }

    }
}
