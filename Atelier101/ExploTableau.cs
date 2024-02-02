//--------------------------------------------------
// Fichier ExploTableau.cs
// Auteur: Félix Dubé
// Création: 2024-02-02
//--------------------------------------------------

namespace Atelier2C6_101_2024
{
    internal class ExploTableau
    {
        const int NB_ELEMENTS = 10;
        static int[] _tabEntiers = new int[NB_ELEMENTS];
        static Humain[] _tabHumains = new Humain[NB_ELEMENTS];

        static string[] _noms = new string[10];
        static Random _r = new Random();
        public static void Exec()
        {
            Util.Titrer("Tableau (array) en C#");

            _noms[0] = "Esteban";
            _noms[1] = "Etienne";
            _noms[2] = "Raphael";
            _noms[3] = "Liliane";
            _noms[4] = "Samuel";
            _noms[5] = "Félix";
            _noms[6] = "Georges";
            _noms[7] = "Charles-Etienne";
            _noms[8] = "Fernando";
            _noms[9] = "Nizar";
            //TabEntiers();
            TabHumains();
            Util.Pause();
        }

        //--------------------------------------------------
        //
        //--------------------------------------------------

        static void TabHumains()
        {
            for (int i = 0; i < NB_ELEMENTS; i++)
            {
                _tabHumains[i] = new Humain(_noms[_r.Next(0, 10)], new DateTime(_r.Next(1964, 2007), _r.Next(1, 13), _r.Next(1, 29)));
            }
            Util.SepST("Tableau humain initial");
            AfficherTabHum();


            Util.SepST("Tableau humain trié par age");
            Array.Sort(_tabHumains, comparerAge);
            AfficherTabHum();

            Util u = new Util();
            u.Sep("inverse");
            Array.Reverse(_tabHumains);
            AfficherTabHum();

            u.Sep("POST Clear");
            Array.Clear(_tabHumains);
            AfficherTabHum();
        }

        //--------------------------------------------------
        //
        //--------------------------------------------------

        static int comparerHumain(Humain humA, Humain humB)
        {
            return humA.GetNom().CompareTo(humB.GetNom());
        }

        //--------------------------------------------------
        //
        //--------------------------------------------------

        static int comparerAge(Humain humA, Humain humB)
        {
            if (humA.GetNaissance().Ticks > humB.GetNaissance().Ticks)
            {
                return -1;
            }
            if (humA.GetNaissance().Ticks < humB.GetNaissance().Ticks)
            {
                return 1;
            }
            return 0;
        }

        //--------------------------------------------------
        //
        //--------------------------------------------------
        static void TabEntiers()
        {
            for (int i = 0; i < _tabEntiers.Length; i++)
            {
                _tabEntiers[i] = _r.Next(0, 1000);
            }
            Util.SepST("tab initial");
            AfficherTab();

            Array.Sort(_tabEntiers);
            Util u = new Util();
            u.Sep("Tab trié");
            AfficherTab();

            Array.Reverse(_tabEntiers);
            u.Sep("Tab inversé");
            AfficherTab();

            double moy = _tabEntiers.Average();
            u.Sep("moyenne: " + moy);

            Array.Clear(_tabEntiers);
            u.Sep("post clear()");
            AfficherTab();


        }

        //--------------------------------------------------
        //
        //--------------------------------------------------

        static void AfficherTab()
        {
            for (int i = 0; i < _tabEntiers.Length; i++)
            {
                Console.WriteLine(i + ":" + _tabEntiers[i]);
            }
        }

        //--------------------------------------------------
        //
        //--------------------------------------------------

        static void AfficherTabHum()
        {
            for (int i = 0; i < _tabHumains.Length; i++)
            {
                if (_tabHumains[i] != null)
                {
                    _tabHumains[i].Afficher();
                }
                else
                {
                    Console.WriteLine("humain nul");
                }
            }
        }



    }
}
