//--------------------------------------------------
// Fichier ExploListe.cs
// Auteur: Félix Dubé
// Création: 2024-02-02
//--------------------------------------------------
namespace Atelier2C6_101_2024
{
    internal class ExploListe
    {
        const int NB_ELEMENTS = 10;
        static List<int> _lstEntiers = new List<int>();
        static Random _r = new Random();
        static public void Exec()
        {
            Util.Titrer("Exploration de listes");
            ListeEntiers();

            Util.Pause();


        }

        //--------------------------------------------------
        //
        //--------------------------------------------------

        static void ListeEntiers()
        {
            for (int i = 0; i < NB_ELEMENTS; i++)
            {
                _lstEntiers.Add(_r.Next(-189, 10000));
            }

            Util.SepST("Liste initale");
            AfficherListe();
        }

        //--------------------------------------------------
        //
        //--------------------------------------------------

        static void AfficherListe()
        {
            for (int i = 0; i < _lstEntiers.Count; i++)
            {
                Console.WriteLine(i + ":" + _lstEntiers[i]);
            }
        }
    }
}
