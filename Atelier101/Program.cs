//--------------------------------------------------
// Fichier Program.cs
// Auteur: Félix Dubé
// Création: 2024-01-31
//--------------------------------------------------

namespace Atelier2C6_101_2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool go = true;
            while (go)
            {
                Util.Titrer("Atelier 2C6 gr 101");
                AfficherMenu();
                ExecuterChoix();
            }
        }

        //--------------------------------------------------
        //
        //--------------------------------------------------

        static void ExecuterChoix()
        {
            char choix = Util.SaisirChar();
            string option = choix.ToString().ToUpper();

            switch(option)
            {
                case ("F"):
                    ExecFinancier();
                    break;
                case ("H"):
                    ExecHumanite();
                    break;
                case ("Q"):
                default:
                    Environment.Exit(0);
                    break;
            }
        }

        //--------------------------------------------------
        //
        //--------------------------------------------------

        static void ExecFinancier()
        {
            Financier fin = new Financier();
            fin.Exec();
        }

        //--------------------------------------------------
        //
        //--------------------------------------------------

        static void ExecHumanite()
        {
            Util.Titrer("Humanité");

            Humain h1 = new Humain("Albert", new DateTime(1889, 1, 1));
            h1.Afficher();

            Humain h2 = new Humain("Béatrice");
            h2.Afficher();

            Humain h3 = new Humain();
            h3.Afficher();


            Util.Pause();
        }

        //--------------------------------------------------
        //
        //--------------------------------------------------

        static void AfficherMenu()
        {
            Console.WriteLine("f- Financier");
            Console.WriteLine("h- Humanité");
            Console.WriteLine("q- Quitter");
            Console.Write("\nvotre choix:");
        }

    }
}
