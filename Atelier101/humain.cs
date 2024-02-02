//--------------------------------------------------
// Fichier humain.cs
// Auteur: Félix Dubé
// Création: 2024-01-31
//--------------------------------------------------
namespace Atelier2C6_101_2024
{
    internal class Humain
    {
        private string _nom;
        DateTime _naissance;
        DateTime _deces;

        public Humain(string n)
        {
            _nom = n;
            _naissance = DateTime.Now;
            _deces = new DateTime(0);
        }

        //--------------------------------------------------
        //
        //--------------------------------------------------

        public Humain()
        {
            _nom = "Incognito";
            _naissance = new DateTime(1,1,1);
            _deces = new DateTime(0);
        }

        //--------------------------------------------------
        //
        //--------------------------------------------------

        public Humain(string n, DateTime nais)
        {
            _nom = n;
            _naissance = nais;
            _deces = new DateTime(0);
        }

        //--------------------------------------------------
        //
        //--------------------------------------------------

        public Humain(string n, DateTime nais, DateTime deces)
        {
            _nom = n;
            _naissance = nais;
            _deces = deces;
        }

        //--------------------------------------------------
        //
        //--------------------------------------------------


        public void Mourir()
        {
            _deces = DateTime.Now;

        }

        //--------------------------------------------------
        //
        //--------------------------------------------------

        public void Mourir(DateTime dateDeces)
        {
            if (dateDeces < DateTime.Now)
            {
                _deces = dateDeces;
            }
            else
            {
                Console.WriteLine("Cette personne est encore vivante!");
            }
        }

        //--------------------------------------------------
        //
        //--------------------------------------------------

        public void Afficher()
        {
            if(EstVivant())
            {
                Console.WriteLine(_nom + " né le " + _naissance.ToShortDateString() + " agé de " + Age() + " ans");
            }
            else
            {
                Console.WriteLine(_nom + ", né le " + _naissance.ToShortDateString() + ", décédé(e) à l'âge de " + Age() + " ans le " + _deces.ToShortDateString());
                int nbAnneesDeces = DateTime.Now.Year - _deces.Year;
                Console.WriteLine("Cela fait " + nbAnneesDeces + " ans que cette personne est décédée.");
            }
            
        }

        //--------------------------------------------------
        //
        //--------------------------------------------------

        private int Age()
        {
            if(EstVivant())
            {
                double delta = DateTime.Now.Ticks - _naissance.Ticks;

                int deltaAn = (int)(delta / 10000000 / (60 * 60 * 24 * 365.24));
                return deltaAn;
            }
            else
            {
                double dateDeces  = (_deces.Ticks - _naissance.Ticks);
                int deltaAn = (int)(dateDeces / 10000000 / (60 * 60 * 24 * 365.24));
                return deltaAn;

            }
            
            //Console.WriteLine("Nb années depuis JC: " + _naissance.Ticks / 10000000 / (60 * 60 * 24 * 365.24));           
        }

        //--------------------------------------------------
        //
        //--------------------------------------------------

        public bool EstVivant()
        {
            if(_deces.Ticks < 1000)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //--------------------------------------------------
        //
        //--------------------------------------------------

        public string GetNom()
        {
            return _nom;
        }

        //--------------------------------------------------
        //
        //--------------------------------------------------

        public DateTime GetNaissance()
        {
            return _naissance;
        }
    }
}
