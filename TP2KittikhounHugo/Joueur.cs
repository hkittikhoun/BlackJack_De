using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2KittikhounHugo
{
    public class Joueur
    {
        private int _noJoueur;
        public int NoJoueur
        {
            get { return _noJoueur; }
            set { _noJoueur = value; }
        }
        private string _nom;
        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }
        private string? _avatar;
        public string Avatar
        {
            get { return _avatar; }
            set { _avatar = value; }
        }
        private int _nbJetons;
        public int NbJetons
        {
            get { return _nbJetons; }
            set { _nbJetons = value; }
        }
        private int _pointage;
        public int Pointage
        {
            get { return _pointage; }
            set { _pointage = value; }
        }
        private int _tour;
        public int Tour
        {
            get { return _tour; }
            set { _tour = value; }
        }
        private int _nbPartie;
        public int NbPartie
        {
            get { return _nbPartie; }
            set { _nbPartie = value; }
        }

        // Constructeur par défaut
        public Joueur()
        {
            _noJoueur = 0;
            _nom = string.Empty;
            _avatar = string.Empty;
            _nbJetons = 0;
            _pointage = 0;
            _tour = 0;
            _nbPartie = 0;
        }

        // Constructeur
        public Joueur(int pNoJoueur, string pNom, string pAvatar, int pNbJetons, int pPointage, int pTour, int pNbPartie)
        {
            _noJoueur = pNoJoueur;
            _nom = pNom;
            _avatar = pAvatar;
            _nbJetons = pNbJetons;
            _pointage = pPointage;
            _tour = pTour;
            _nbPartie = pNbPartie;
        }

        public override string ToString()
        {
            return _nom + " | " + _avatar + " | " + _nbJetons + " jetons.";
        }
    }
}
