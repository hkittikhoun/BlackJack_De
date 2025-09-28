using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2KittikhounHugo
{
    public class Partie
    {
        private int _nbJoueur;
        public int NbJoueur
        {
            get { return _nbJoueur; }
            set { _nbJoueur = value; }
        }
        private Joueur[] _joueurs;
        public Joueur[] Joueurs 
        {
            get { return _joueurs; }
            set { _joueurs = value; }
        }
        private int _tourEnCours;
        public int TourEnCours
        {
            get { return _tourEnCours; }
            set { _tourEnCours = value; }
        }
        private int _resultatsDes;
        public int ResultatsDes
        {
            get { return _resultatsDes; }
            set { _resultatsDes = value; }
        }
        private int _partieActuelle;
        public int PartieActuelle
        {
            get { return _partieActuelle; }
            set { _partieActuelle = value; }
        }

        private const int VALEUR_MAX = 21;

        // Constructeur par défaut
        public Partie()
        {
            NbJoueur = 0;
            Joueurs = new Joueur[0];
            TourEnCours = 0;
            ResultatsDes = 0;
            PartieActuelle = 0;
        }
        // Consrtructeur
        public Partie(int pNbJoueur, Joueur[] pJoueurs, int pTourEnCours, int pResultatsDes, int pPartieActuelle)
        {
            NbJoueur = pNbJoueur;
            Joueurs = pJoueurs;
            TourEnCours = pTourEnCours;
            ResultatsDes = pResultatsDes;
            PartieActuelle = 0;
        }

        // Méthode pour démarrer un nouveau tour
        public void DemarrerNouveauTour()
        {
            if (TourEnCours >= NbJoueur)
            {
                TourEnCours = 1; // recommence le tour après le dernier joueur
                PartieActuelle++;
            }
            else
            {
                TourEnCours++; // Passe au joueur suivant
            }
        }

        // Vérification des points
        public bool enBasDeLaValeur(int resultatDes)
        {
            bool enBas = true;
            if(resultatDes > VALEUR_MAX)
            {
                enBas = false;
            }
            return enBas;
        }

        // Regarde le gagnant
        public int joueurGagnant(int[] points)
        {
            int gagnant = -1;
            int scoreMax = -1;

            for (int i = 0; i < points.Length; i++)
            {
                if (points[i] > scoreMax)
                {
                    scoreMax = points[i];
                    gagnant = i;
                }
            }

            return gagnant;
        }
    }
}