using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP2KittikhounHugo
{
    public partial class FenetreJeu : Form
    {
        Random aleatoire;
        Thread desT, deT1, deT2, deT3;
        private Partie partieEnCours;

        // Dé et cagnotte
        private int de1, de2, de3, de4, de5, de6;
        private int cagnote = 0;

        public FenetreJeu(Form_Acceuil pFormulaire)
        {
            InitializeComponent();
            Joueur[] joueurs = pFormulaire.GetJoueursSelectionnes();
            partieEnCours = new Partie(joueurs.Length, joueurs, 1, 0, 1);
            // attribuer le paramètre form1 à la variable locale
            this.fenetreJeu = pFormulaire;
        }

        // variable locale du formulaire principal (form1)
        private Form_Acceuil fenetreJeu;

        private void retourÈToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // fermer la fenêtre - important utilisation de close
            this.Close();
        }

        private void FenetreJeu_Load(object sender, EventArgs e)
        {
            aleatoire = new Random();

            // Mise à jour des groupBox avec les noms des joueurs
            if (partieEnCours.NbJoueur == 1)
            {
                groupBox_Joueur1.Text = partieEnCours.Joueurs[0].Nom;
                textBox_JetonsJoueur1.Text = partieEnCours.Joueurs[0].NbJetons.ToString();
                partieEnCours.Joueurs[0].Tour = 1;
                groupBox_Joueur2.Text = null;
                groupBox_Joueur3.Text = null;
                groupBox_Joueur4.Text = null;
            }
            else
            if (partieEnCours.NbJoueur == 2)
            {
                groupBox_Joueur1.Text = partieEnCours.Joueurs[0].Nom;
                textBox_JetonsJoueur1.Text = partieEnCours.Joueurs[0].NbJetons.ToString();
                partieEnCours.Joueurs[0].Tour = 1;

                groupBox_Joueur2.Text = partieEnCours.Joueurs[1].Nom;
                textBox_JetonsJoueur2.Text = partieEnCours.Joueurs[1].NbJetons.ToString();
                partieEnCours.Joueurs[1].Tour = 2;

                groupBox_Joueur3.Text = null;
                groupBox_Joueur4.Text = null;
            }
            else
            if (partieEnCours.NbJoueur == 3)
            {
                groupBox_Joueur1.Text = partieEnCours.Joueurs[0].Nom;
                textBox_JetonsJoueur1.Text = partieEnCours.Joueurs[0].NbJetons.ToString();
                partieEnCours.Joueurs[0].Tour = 1;

                groupBox_Joueur2.Text = partieEnCours.Joueurs[1].Nom;
                textBox_JetonsJoueur2.Text = partieEnCours.Joueurs[1].NbJetons.ToString();
                partieEnCours.Joueurs[1].Tour = 2;

                groupBox_Joueur3.Text = partieEnCours.Joueurs[2].Nom;
                textBox_JetonsJoueur3.Text = partieEnCours.Joueurs[2].NbJetons.ToString();
                partieEnCours.Joueurs[2].Tour = 3;

                groupBox_Joueur4.Text = null;
            }
            else
            if (partieEnCours.NbJoueur == 4)
            {
                groupBox_Joueur1.Text = partieEnCours.Joueurs[0].Nom;
                textBox_JetonsJoueur1.Text = partieEnCours.Joueurs[0].NbJetons.ToString();
                partieEnCours.Joueurs[0].Tour = 1;

                groupBox_Joueur2.Text = partieEnCours.Joueurs[1].Nom;
                textBox_JetonsJoueur2.Text = partieEnCours.Joueurs[1].NbJetons.ToString();
                partieEnCours.Joueurs[1].Tour = 2;

                groupBox_Joueur3.Text = partieEnCours.Joueurs[2].Nom;
                textBox_JetonsJoueur3.Text = partieEnCours.Joueurs[2].NbJetons.ToString();
                partieEnCours.Joueurs[2].Tour = 3;

                groupBox_Joueur4.Text = partieEnCours.Joueurs[3].Nom;
                textBox_JetonsJoueur4.Text = partieEnCours.Joueurs[3].NbJetons.ToString();
                partieEnCours.Joueurs[3].Tour = 4;
            }
            else
            {
                // Affichage d'un message d'erreur si le nombre de joueurs n'est pas valide
                MessageBox.Show("Le nombre de joueurs n'est pas valide. Veuillez retourner au menu principal.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Retourner à la fenêtre principale (Form_Acceuil)
                this.Close();
            }

            // Commencer le premier Tour donc celui du premier Joueur
            numericUpDown_Tour.Value = partieEnCours.TourEnCours;

        }

        private void button_Lancer_Click(object sender, EventArgs e)
        {
            string chemin = Directory.GetParent(path: Environment.CurrentDirectory).Parent.Parent.FullName;
            string cheminResources = Path.Combine(chemin, "Resources");

            desT = new Thread(t =>
            {
                try
                {
                    while (desT.IsAlive)
                    {


                        de1 = aleatoire.Next(1, 7);
                        de2 = aleatoire.Next(1, 7);
                        de3 = aleatoire.Next(1, 7);

                        pictureBox_De1.Image = Image.FromFile(Path.Combine(cheminResources, "Blanc_" + de1 + ".png"));
                        pictureBox_De2.Image = Image.FromFile(Path.Combine(cheminResources, "Blanc_" + de2 + ".png"));
                        pictureBox_De3.Image = Image.FromFile(Path.Combine(cheminResources, "Blanc_" + de3 + ".png"));

                        // délai
                        Thread.Sleep(250);
                    }
                }
                catch (Exception ex)
                {
                    // Vous pouvez gérer l'exception ici si nécessaire
                    Console.WriteLine("Une erreur s'est produite lors du chargement des images : " + ex.Message);
                }
            })
            { IsBackground = true };

            // Démarrer Trhead
            desT.Start();
            button_Arreter.Enabled = true;
            button_Lancer.Enabled = false;
            button_Rejouer1D.Enabled = false;
            button_Rejouer2D.Enabled = false;
            button_Rejouer3D.Enabled = false;
        }

        private void button_Arreter_Click(object sender, EventArgs e)
        {
            string chemin = Directory.GetParent(path: Environment.CurrentDirectory).Parent.Parent.FullName;
            string cheminResources = Path.Combine(chemin, "Resources");

            if (desT != null && desT.IsAlive)
            {

                // Mettre à jour le flag pour arrêter le thread
                desT.Interrupt();
                desT = null;
                partieEnCours.ResultatsDes = de1 + de2 + de3;

                if (partieEnCours.TourEnCours == partieEnCours.Joueurs[0].Tour)
                {
                    //Afficher le pointage
                    partieEnCours.Joueurs[0].Pointage = partieEnCours.ResultatsDes;
                    textBox_PointageJoueur1.Text = partieEnCours.ResultatsDes.ToString();

                    // Afficher la valeur des dés
                    pictureBox_Joueur1D1.Image = Image.FromFile(Path.Combine(cheminResources, partieEnCours.Joueurs[0].Avatar + "_" + de1 + ".png"));
                    pictureBox_Joueur1D2.Image = Image.FromFile(Path.Combine(cheminResources, partieEnCours.Joueurs[0].Avatar + "_" + de2 + ".png"));
                    pictureBox_Joueur1D3.Image = Image.FromFile(Path.Combine(cheminResources, partieEnCours.Joueurs[0].Avatar + "_" + de3 + ".png"));

                }
                else if (partieEnCours.TourEnCours == partieEnCours.Joueurs[1].Tour)
                {
                    //Afficher le pointage
                    partieEnCours.Joueurs[1].Pointage = partieEnCours.ResultatsDes;
                    textBox_PointageJoueur2.Text = partieEnCours.ResultatsDes.ToString();

                    // Afficher la valeur des dés
                    pictureBox_Joueur2D1.Image = Image.FromFile(Path.Combine(cheminResources, partieEnCours.Joueurs[1].Avatar + "_" + de1 + ".png"));
                    pictureBox_Joueur2D2.Image = Image.FromFile(Path.Combine(cheminResources, partieEnCours.Joueurs[1].Avatar + "_" + de2 + ".png"));
                    pictureBox_Joueur2D3.Image = Image.FromFile(Path.Combine(cheminResources, partieEnCours.Joueurs[1].Avatar + "_" + de3 + ".png"));
                }
                else if (partieEnCours.TourEnCours == partieEnCours.Joueurs[2].Tour)
                {
                    //Afficher le pointage
                    partieEnCours.Joueurs[2].Pointage = partieEnCours.ResultatsDes;
                    textBox_PointageJoueur3.Text = partieEnCours.ResultatsDes.ToString();

                    // Afficher la valeur des dés
                    pictureBox_Joueur3D1.Image = Image.FromFile(Path.Combine(cheminResources, partieEnCours.Joueurs[2].Avatar + "_" + de1 + ".png"));
                    pictureBox_Joueur3D2.Image = Image.FromFile(Path.Combine(cheminResources, partieEnCours.Joueurs[2].Avatar + "_" + de2 + ".png"));
                    pictureBox_Joueur3D3.Image = Image.FromFile(Path.Combine(cheminResources, partieEnCours.Joueurs[2].Avatar + "_" + de3 + ".png"));
                }
                else if (partieEnCours.TourEnCours == partieEnCours.Joueurs[3].Tour)
                {
                    //Afficher le pointage
                    partieEnCours.Joueurs[3].Pointage = partieEnCours.ResultatsDes;
                    textBox_PointageJoueur4.Text = partieEnCours.ResultatsDes.ToString();


                    // Afficher la valeur des dés
                    pictureBox_Joueur4D1.Image = Image.FromFile(Path.Combine(cheminResources, partieEnCours.Joueurs[3].Avatar + "_" + de1 + ".png"));
                    pictureBox_Joueur4D2.Image = Image.FromFile(Path.Combine(cheminResources, partieEnCours.Joueurs[3].Avatar + "_" + de2 + ".png"));
                    pictureBox_Joueur4D3.Image = Image.FromFile(Path.Combine(cheminResources, partieEnCours.Joueurs[3].Avatar + "_" + de3 + ".png"));
                }

                button_Rejouer1D.Enabled = true;
                button_Rejouer2D.Enabled = true;
                button_Rejouer3D.Enabled = true;

            }
            if (deT1 != null && deT1.IsAlive)
            {
                // Mettre à jour le flag pour arrêter le thread
                deT1.Interrupt();
                partieEnCours.ResultatsDes = de1 + de2 + de3 + de4;
                deT1 = null;

                if (partieEnCours.TourEnCours == partieEnCours.Joueurs[0].Tour)
                {
                    //Afficher le pointage
                    partieEnCours.Joueurs[0].Pointage = partieEnCours.ResultatsDes;
                    textBox_PointageJoueur1.Text = partieEnCours.ResultatsDes.ToString();

                    // Regarde si la valeur est trop haute
                    if (!partieEnCours.enBasDeLaValeur(partieEnCours.ResultatsDes))
                    {
                        partieEnCours.Joueurs[0].NbJetons--;
                        cagnote++;
                    }

                    // Afficher la valeur des dés
                    pictureBox_Joueur1D4.Image = Image.FromFile(Path.Combine(cheminResources, partieEnCours.Joueurs[0].Avatar + "_" + de4 + ".png"));
                }
                else if (partieEnCours.TourEnCours == partieEnCours.Joueurs[1].Tour)
                {
                    //Afficher le pointage
                    partieEnCours.Joueurs[1].Pointage = partieEnCours.ResultatsDes;
                    textBox_PointageJoueur2.Text = partieEnCours.ResultatsDes.ToString();

                    // Regarde si la valeur est trop haute
                    if (!partieEnCours.enBasDeLaValeur(partieEnCours.ResultatsDes))
                    {
                        partieEnCours.Joueurs[1].NbJetons--;
                        cagnote++;
                    }

                    // Afficher la valeur des dés
                    pictureBox_Joueur2D1.Image = Image.FromFile(Path.Combine(cheminResources, partieEnCours.Joueurs[1].Avatar + "_" + de4 + ".png"));
                }
                else if (partieEnCours.TourEnCours == partieEnCours.Joueurs[2].Tour)
                {
                    //Afficher le pointage
                    partieEnCours.Joueurs[2].Pointage = partieEnCours.ResultatsDes;
                    textBox_PointageJoueur3.Text = partieEnCours.ResultatsDes.ToString();

                    // Regarde si la valeur est trop haute
                    if (!partieEnCours.enBasDeLaValeur(partieEnCours.ResultatsDes))
                    {
                        partieEnCours.Joueurs[2].NbJetons--;
                        cagnote++;
                    }
                    // Afficher la valeur des dés
                    pictureBox_Joueur3D4.Image = Image.FromFile(Path.Combine(cheminResources, partieEnCours.Joueurs[2].Avatar + "_" + de4 + ".png"));
                }
                else if (partieEnCours.TourEnCours == partieEnCours.Joueurs[3].Tour)
                {
                    //Afficher le pointage
                    partieEnCours.Joueurs[3].Pointage = partieEnCours.ResultatsDes;
                    textBox_PointageJoueur4.Text = partieEnCours.ResultatsDes.ToString();

                    // Regarde si la valeur est trop haute
                    if (!partieEnCours.enBasDeLaValeur(partieEnCours.ResultatsDes))
                    {
                        partieEnCours.Joueurs[3].NbJetons--;
                        cagnote++;
                    }

                    // Afficher la valeur des dés
                    pictureBox_Joueur4D4.Image = Image.FromFile(Path.Combine(cheminResources, partieEnCours.Joueurs[3].Avatar + "_" + de4 + ".png"));

                    // Passe au prochaine tour
                }

                // Gestion des tours et partie
                if (partieEnCours.NbJoueur == partieEnCours.TourEnCours)
                {
                    gererLeGagnant();
                }
                else
                {
                    partieEnCours.DemarrerNouveauTour();
                    numericUpDown_Tour.Value = partieEnCours.TourEnCours;
                    button_Lancer.Enabled = true;
                }
            }
            if (deT2 != null && deT2.IsAlive)
            {
                // Mettre à jour le flag pour arrêter le thread
                deT2.Interrupt();
                deT2 = null;
                partieEnCours.ResultatsDes = de1 + de2 + de3 + de4 + de5;

                if (partieEnCours.TourEnCours == partieEnCours.Joueurs[0].Tour)
                {
                    //Afficher le pointage
                    partieEnCours.Joueurs[0].Pointage = partieEnCours.ResultatsDes;
                    textBox_PointageJoueur1.Text = partieEnCours.ResultatsDes.ToString();

                    // Regarde si la valeur est trop haute
                    if (!partieEnCours.enBasDeLaValeur(partieEnCours.ResultatsDes))
                    {
                        partieEnCours.Joueurs[0].NbJetons--;
                        cagnote++;
                    }

                    // Afficher la valeur des dés
                    pictureBox_Joueur1D4.Image = Image.FromFile(Path.Combine(cheminResources, partieEnCours.Joueurs[0].Avatar + "_" + de4 + ".png"));
                    pictureBox_Joueur1D5.Image = Image.FromFile(Path.Combine(cheminResources, partieEnCours.Joueurs[0].Avatar + "_" + de5 + ".png"));
                }
                else if (partieEnCours.TourEnCours == partieEnCours.Joueurs[1].Tour)
                {
                    //Afficher le pointage
                    partieEnCours.Joueurs[1].Pointage = partieEnCours.ResultatsDes;
                    textBox_PointageJoueur2.Text = partieEnCours.ResultatsDes.ToString();

                    // Regarde si la valeur est trop haute
                    if (!partieEnCours.enBasDeLaValeur(partieEnCours.ResultatsDes))
                    {
                        partieEnCours.Joueurs[1].NbJetons--;
                        cagnote++;
                    }

                    // Afficher la valeur des dés
                    pictureBox_Joueur2D4.Image = Image.FromFile(Path.Combine(cheminResources, partieEnCours.Joueurs[1].Avatar + "_" + de4 + ".png"));
                    pictureBox_Joueur2D5.Image = Image.FromFile(Path.Combine(cheminResources, partieEnCours.Joueurs[1].Avatar + "_" + de5 + ".png"));
                }
                else if (partieEnCours.TourEnCours == partieEnCours.Joueurs[2].Tour)
                {
                    //Afficher le pointage
                    partieEnCours.Joueurs[2].Pointage = partieEnCours.ResultatsDes;
                    textBox_PointageJoueur3.Text = partieEnCours.ResultatsDes.ToString();

                    // Regarde si la valeur est trop haute
                    if (!partieEnCours.enBasDeLaValeur(partieEnCours.ResultatsDes))
                    {
                        partieEnCours.Joueurs[2].NbJetons--;
                        cagnote++;
                    }
                    // Afficher la valeur des dés
                    pictureBox_Joueur3D4.Image = Image.FromFile(Path.Combine(cheminResources, partieEnCours.Joueurs[2].Avatar + "_" + de4 + ".png"));
                    pictureBox_Joueur3D5.Image = Image.FromFile(Path.Combine(cheminResources, partieEnCours.Joueurs[2].Avatar + "_" + de5 + ".png"));
                }
                else if (partieEnCours.TourEnCours == partieEnCours.Joueurs[3].Tour)
                {
                    //Afficher le pointage
                    partieEnCours.Joueurs[3].Pointage = partieEnCours.ResultatsDes;
                    textBox_PointageJoueur4.Text = partieEnCours.ResultatsDes.ToString();

                    // Regarde si la valeur est trop haute
                    if (!partieEnCours.enBasDeLaValeur(partieEnCours.ResultatsDes))
                    {
                        partieEnCours.Joueurs[3].NbJetons--;
                        cagnote++;
                    }

                    // Afficher la valeur des dés
                    pictureBox_Joueur4D4.Image = Image.FromFile(Path.Combine(cheminResources, partieEnCours.Joueurs[3].Avatar + "_" + de4 + ".png"));
                    pictureBox_Joueur4D5.Image = Image.FromFile(Path.Combine(cheminResources, partieEnCours.Joueurs[3].Avatar + "_" + de5 + ".png"));
                }

                // Gestion des tours et partie
                if (partieEnCours.NbJoueur == partieEnCours.TourEnCours)
                {
                    gererLeGagnant();
                }
                else
                {
                    partieEnCours.DemarrerNouveauTour();
                    numericUpDown_Tour.Value = partieEnCours.TourEnCours;
                    button_Lancer.Enabled = true;
                }
            }
            if (deT3 != null && deT3.IsAlive)
            {
                // Mettre à jour le flag pour arrêter le thread
                deT3.Interrupt();
                deT3 = null;
                partieEnCours.ResultatsDes = de1 + de2 + de3 + de4 + de5 + de6;

                if (partieEnCours.TourEnCours == partieEnCours.Joueurs[0].Tour)
                {
                    //Afficher le pointage
                    partieEnCours.Joueurs[0].Pointage = partieEnCours.ResultatsDes;
                    textBox_PointageJoueur1.Text = partieEnCours.ResultatsDes.ToString();

                    // Regarde si la valeur est trop haute
                    if (!partieEnCours.enBasDeLaValeur(partieEnCours.ResultatsDes))
                    {
                        partieEnCours.Joueurs[0].NbJetons--;
                        cagnote++;
                    }

                    // Afficher la valeur des dés
                    pictureBox_Joueur1D4.Image = Image.FromFile(Path.Combine(cheminResources, partieEnCours.Joueurs[0].Avatar + "_" + de4 + ".png"));
                    pictureBox_Joueur1D5.Image = Image.FromFile(Path.Combine(cheminResources, partieEnCours.Joueurs[0].Avatar + "_" + de5 + ".png"));
                    pictureBox_Joueur1D6.Image = Image.FromFile(Path.Combine(cheminResources, partieEnCours.Joueurs[0].Avatar + "_" + de6 + ".png"));
                }
                else if (partieEnCours.TourEnCours == partieEnCours.Joueurs[1].Tour)
                {
                    //Afficher le pointage
                    partieEnCours.Joueurs[1].Pointage = partieEnCours.ResultatsDes;
                    textBox_PointageJoueur2.Text = partieEnCours.ResultatsDes.ToString();

                    // Regarde si la valeur est trop haute
                    if (!partieEnCours.enBasDeLaValeur(partieEnCours.ResultatsDes))
                    {
                        partieEnCours.Joueurs[1].NbJetons--;
                        cagnote++;
                    }

                    // Afficher la valeur des dés
                    pictureBox_Joueur2D4.Image = Image.FromFile(Path.Combine(cheminResources, partieEnCours.Joueurs[1].Avatar + "_" + de4 + ".png"));
                    pictureBox_Joueur2D5.Image = Image.FromFile(Path.Combine(cheminResources, partieEnCours.Joueurs[1].Avatar + "_" + de5 + ".png"));
                    pictureBox_Joueur2D6.Image = Image.FromFile(Path.Combine(cheminResources, partieEnCours.Joueurs[1].Avatar + "_" + de6 + ".png"));
                }
                else if (partieEnCours.TourEnCours == partieEnCours.Joueurs[2].Tour)
                {
                    //Afficher le pointage
                    partieEnCours.Joueurs[2].Pointage = partieEnCours.ResultatsDes;
                    textBox_PointageJoueur3.Text = partieEnCours.ResultatsDes.ToString();

                    // Regarde si la valeur est trop haute
                    if (!partieEnCours.enBasDeLaValeur(partieEnCours.ResultatsDes))
                    {
                        partieEnCours.Joueurs[2].NbJetons--;
                        cagnote++;
                    }
                    // Afficher la valeur des dés
                    pictureBox_Joueur3D4.Image = Image.FromFile(Path.Combine(cheminResources, partieEnCours.Joueurs[2].Avatar + "_" + de4 + ".png"));
                    pictureBox_Joueur3D5.Image = Image.FromFile(Path.Combine(cheminResources, partieEnCours.Joueurs[2].Avatar + "_" + de5 + ".png"));
                    pictureBox_Joueur3D6.Image = Image.FromFile(Path.Combine(cheminResources, partieEnCours.Joueurs[2].Avatar + "_" + de6 + ".png"));
                }
                else if (partieEnCours.TourEnCours == partieEnCours.Joueurs[3].Tour)
                {
                    //Afficher le pointage
                    partieEnCours.Joueurs[3].Pointage = partieEnCours.ResultatsDes;
                    textBox_PointageJoueur4.Text = partieEnCours.ResultatsDes.ToString();

                    // Regarde si la valeur est trop haute
                    if (!partieEnCours.enBasDeLaValeur(partieEnCours.ResultatsDes))
                    {
                        partieEnCours.Joueurs[3].NbJetons--;
                        cagnote++;
                    }

                    // Afficher la valeur des dés
                    pictureBox_Joueur4D4.Image = Image.FromFile(Path.Combine(cheminResources, partieEnCours.Joueurs[3].Avatar + "_" + de4 + ".png"));
                    pictureBox_Joueur4D5.Image = Image.FromFile(Path.Combine(cheminResources, partieEnCours.Joueurs[3].Avatar + "_" + de5 + ".png"));
                    pictureBox_Joueur4D6.Image = Image.FromFile(Path.Combine(cheminResources, partieEnCours.Joueurs[3].Avatar + "_" + de6 + ".png"));
                }

                // Gestion des tours et partie
                if (partieEnCours.NbJoueur == partieEnCours.TourEnCours)
                {
                    gererLeGagnant();
                }
                else
                {
                    partieEnCours.DemarrerNouveauTour();
                    numericUpDown_Tour.Value = partieEnCours.TourEnCours;
                    button_Lancer.Enabled = true;
                }
            }

            button_Arreter.Enabled = false;
        }

        private void button_Rejouer1D_Click(object sender, EventArgs e)
        {
            string chemin = Directory.GetParent(path: Environment.CurrentDirectory).Parent.Parent.FullName;
            string cheminResources = Path.Combine(chemin, "Resources");

            deT1 = new Thread(t =>
            {
                try
                {
                    while (deT1.IsAlive)
                    {
                        de4 = aleatoire.Next(1, 7);
                        pictureBox_De1.Image = Image.FromFile(Path.Combine(cheminResources, "Blanc_" + de4 + ".png"));

                        // délai
                        Thread.Sleep(250);
                    }
                }
                catch (Exception ex)
                {
                    // Vous pouvez gérer l'exception ici si nécessaire
                    Console.WriteLine("Une erreur s'est produite lors du chargement des images : " + ex.Message);
                }
            })
            { IsBackground = true };

            // Démarrer Trhead
            deT1.Start();
            button_Arreter.Enabled = true;
            button_Lancer.Enabled = false;
            button_Rejouer1D.Enabled = false;
            button_Rejouer2D.Enabled = false;
            button_Rejouer3D.Enabled = false;
        }

        private void button_Rejouer2D_Click(object sender, EventArgs e)
        {
            string chemin = Directory.GetParent(path: Environment.CurrentDirectory).Parent.Parent.FullName;
            string cheminResources = Path.Combine(chemin, "Resources");

            deT2 = new Thread(t =>
            {
                try
                {
                    while (deT2.IsAlive)
                    {
                        de4 = aleatoire.Next(1, 7);
                        de5 = aleatoire.Next(1, 7);
                        pictureBox_De1.Image = Image.FromFile(Path.Combine(cheminResources, "Blanc_" + de4 + ".png"));
                        pictureBox_De2.Image = Image.FromFile(Path.Combine(cheminResources, "Blanc_" + de5 + ".png"));
                        // délai
                        Thread.Sleep(250);
                    }
                }
                catch (Exception ex)
                {
                    // Vous pouvez gérer l'exception ici si nécessaire
                    Console.WriteLine("Une erreur s'est produite lors du chargement des images : " + ex.Message);
                }
            })
            { IsBackground = true };

            // Démarrer Trhead
            deT2.Start();
            button_Arreter.Enabled = true;
            button_Lancer.Enabled = false;
            button_Rejouer1D.Enabled = false;
            button_Rejouer2D.Enabled = false;
            button_Rejouer3D.Enabled = false;
        }

        private void button_Rejouer3D_Click(object sender, EventArgs e)
        {
            string chemin = Directory.GetParent(path: Environment.CurrentDirectory).Parent.Parent.FullName;
            string cheminResources = Path.Combine(chemin, "Resources");

            deT3 = new Thread(t =>
            {
                try
                {
                    while (deT3.IsAlive)
                    {
                        de4 = aleatoire.Next(1, 7);
                        de5 = aleatoire.Next(1, 7);
                        de6 = aleatoire.Next(1, 7);

                        pictureBox_De1.Image = Image.FromFile(Path.Combine(cheminResources, "Blanc_" + de4 + ".png"));
                        pictureBox_De2.Image = Image.FromFile(Path.Combine(cheminResources, "Blanc_" + de5 + ".png"));
                        pictureBox_De3.Image = Image.FromFile(Path.Combine(cheminResources, "Blanc_" + de6 + ".png"));

                        // délai
                        Thread.Sleep(250);
                    }
                }
                catch (Exception ex)
                {
                    // Vous pouvez gérer l'exception ici si nécessaire
                    Console.WriteLine("Une erreur s'est produite lors du chargement des images : " + ex.Message);
                }
            })
            { IsBackground = true };

            // Démarrer Trhead
            deT3.Start();
            button_Arreter.Enabled = true;
            button_Lancer.Enabled = false;
            button_Rejouer1D.Enabled = false;
            button_Rejouer2D.Enabled = false;
            button_Rejouer3D.Enabled = false;
        }

        private void nouvellePartieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nouvellePartie();
        }

        // Commencer une nouvelle partie
        public void nouvellePartie()
        {
            cagnote = 0;
            for (int i = 0; i < partieEnCours.NbJoueur; i++)
            {
                if (partieEnCours.Joueurs[i].NbJetons <= 0)
                {
                    MessageBox.Show("Le joueur" + partieEnCours.Joueurs[i].Nom + "n'a pas assez de jetons pour commencer la partie.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            button_Rejouer1D.Enabled = false;
            button_Rejouer2D.Enabled = false;
            button_Rejouer3D.Enabled = false;
            pictureBox_De1.Image = null;
            pictureBox_De2.Image = null;
            pictureBox_De3.Image = null;
            pictureBox_Joueur1D1.Image = null;
            pictureBox_Joueur1D2.Image = null;
            pictureBox_Joueur1D3.Image = null;
            pictureBox_Joueur1D4.Image = null;
            pictureBox_Joueur1D5.Image = null;
            pictureBox_Joueur1D6.Image = null;
            pictureBox_Joueur2D1.Image = null;
            pictureBox_Joueur2D2.Image = null;
            pictureBox_Joueur2D3.Image = null;
            pictureBox_Joueur2D4.Image = null;
            pictureBox_Joueur2D5.Image = null;
            pictureBox_Joueur2D6.Image = null;
            pictureBox_Joueur3D1.Image = null;
            pictureBox_Joueur3D2.Image = null;
            pictureBox_Joueur3D3.Image = null;
            pictureBox_Joueur3D4.Image = null;
            pictureBox_Joueur3D5.Image = null;
            pictureBox_Joueur3D6.Image = null;
            pictureBox_Joueur4D1.Image = null;
            pictureBox_Joueur4D2.Image = null;
            pictureBox_Joueur4D3.Image = null;
            pictureBox_Joueur4D4.Image = null;
            pictureBox_Joueur4D5.Image = null;
            pictureBox_Joueur4D6.Image = null;
            textBox_PointageJoueur1.Text = null;
            textBox_PointageJoueur2.Text = null;
            textBox_PointageJoueur3.Text = null;
            textBox_PointageJoueur4.Text = null;
            if (partieEnCours.NbJoueur == 1)
            {
                textBox_JetonsJoueur1.Text = partieEnCours.Joueurs[0].NbJetons.ToString();
            }
            else if (partieEnCours.NbJoueur == 2)
            {
                textBox_JetonsJoueur1.Text = partieEnCours.Joueurs[0].NbJetons.ToString();
                textBox_JetonsJoueur2.Text = partieEnCours.Joueurs[1].NbJetons.ToString();
            }
            else if (partieEnCours.NbJoueur == 3)
            {
                textBox_JetonsJoueur1.Text = partieEnCours.Joueurs[0].NbJetons.ToString();
                textBox_JetonsJoueur2.Text = partieEnCours.Joueurs[1].NbJetons.ToString();
                textBox_JetonsJoueur3.Text = partieEnCours.Joueurs[2].NbJetons.ToString();
            }
            else if (partieEnCours.NbJoueur == 4)
            {
                textBox_JetonsJoueur1.Text = partieEnCours.Joueurs[0].NbJetons.ToString();
                textBox_JetonsJoueur2.Text = partieEnCours.Joueurs[1].NbJetons.ToString();
                textBox_JetonsJoueur3.Text = partieEnCours.Joueurs[2].NbJetons.ToString();
                textBox_JetonsJoueur4.Text = partieEnCours.Joueurs[3].NbJetons.ToString();
            }
            button_Lancer.Enabled = true;
            partieEnCours.TourEnCours = 1;
            numericUpDown_Tour.Value = 1;
            partieEnCours.PartieActuelle++;
            for (int i = 0; i < partieEnCours.NbJoueur; i++)
            {
                partieEnCours.Joueurs[i].NbPartie++;
            }

            SystemSounds.Beep.Play();
        }

        public void gererLeGagnant()
        {
            int joueurGagnant = -1;
            int meilleurScore = -1;

            // Trouver le joueur avec le plus grand pointage, en excluant ceux qui sont supérieurs à 21
            for (int i = 0; i < partieEnCours.NbJoueur; i++)
            {
                int score = partieEnCours.Joueurs[i].Pointage;

                if (score <= 21 && score > meilleurScore)
                {
                    meilleurScore = score;
                    joueurGagnant = i;
                }
            }

            // Si aucun joueur n'est valide (tous les joueurs ont plus de 21), on affiche un message
            if (joueurGagnant == -1)
            {
                MessageBox.Show("Aucun gagnant, tous les joueurs ont plus de 21!", "Résultats des joueurs", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Ajouter des jetons au gagnant
                partieEnCours.Joueurs[joueurGagnant].NbJetons += cagnote + (partieEnCours.NbJoueur - 1);

                if (partieEnCours.NbJoueur > 1)
                {
                    MessageBox.Show("Le gagnant de cette partie est " + partieEnCours.Joueurs[joueurGagnant].Nom, "Résultats des joueurs", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (partieEnCours.Joueurs[0].Pointage <= 21)
                    {
                        partieEnCours.Joueurs[0].NbJetons++;
                    }
                }

                // Faire perdre 1 jeton à tous les autres joueurs sauf le gagnant
                for (int i = 0; i < partieEnCours.NbJoueur; i++)
                {
                    if (i != joueurGagnant)
                    {
                        partieEnCours.Joueurs[i].NbJetons--;
                    }
                }
            }
            nouvellePartie();
        }

        internal void ModificationJoueurs(Joueur[] joueurs)
        {
            partieEnCours.Joueurs = joueurs;
            // Mise à jour des groupBox avec les noms des joueurs
            if (partieEnCours.NbJoueur == 1)
            {
                groupBox_Joueur1.Text = partieEnCours.Joueurs[0].Nom;
                textBox_JetonsJoueur1.Text = partieEnCours.Joueurs[0].NbJetons.ToString();
                partieEnCours.Joueurs[0].Tour = 1;
                groupBox_Joueur2.Text = null;
                groupBox_Joueur3.Text = null;
                groupBox_Joueur4.Text = null;
            }
            else
            if (partieEnCours.NbJoueur == 2)
            {
                groupBox_Joueur1.Text = partieEnCours.Joueurs[0].Nom;
                textBox_JetonsJoueur1.Text = partieEnCours.Joueurs[0].NbJetons.ToString();
                partieEnCours.Joueurs[0].Tour = 1;

                groupBox_Joueur2.Text = partieEnCours.Joueurs[1].Nom;
                textBox_JetonsJoueur2.Text = partieEnCours.Joueurs[1].NbJetons.ToString();
                partieEnCours.Joueurs[1].Tour = 2;

                groupBox_Joueur3.Text = null;
                groupBox_Joueur4.Text = null;
            }
            else
            if (partieEnCours.NbJoueur == 3)
            {
                groupBox_Joueur1.Text = partieEnCours.Joueurs[0].Nom;
                textBox_JetonsJoueur1.Text = partieEnCours.Joueurs[0].NbJetons.ToString();
                partieEnCours.Joueurs[0].Tour = 1;

                groupBox_Joueur2.Text = partieEnCours.Joueurs[1].Nom;
                textBox_JetonsJoueur2.Text = partieEnCours.Joueurs[1].NbJetons.ToString();
                partieEnCours.Joueurs[1].Tour = 2;

                groupBox_Joueur3.Text = partieEnCours.Joueurs[2].Nom;
                textBox_JetonsJoueur3.Text = partieEnCours.Joueurs[2].NbJetons.ToString();
                partieEnCours.Joueurs[2].Tour = 3;

                groupBox_Joueur4.Text = null;
            }
            else
            if (partieEnCours.NbJoueur == 4)
            {
                groupBox_Joueur1.Text = partieEnCours.Joueurs[0].Nom;
                textBox_JetonsJoueur1.Text = partieEnCours.Joueurs[0].NbJetons.ToString();
                partieEnCours.Joueurs[0].Tour = 1;

                groupBox_Joueur2.Text = partieEnCours.Joueurs[1].Nom;
                textBox_JetonsJoueur2.Text = partieEnCours.Joueurs[1].NbJetons.ToString();
                partieEnCours.Joueurs[1].Tour = 2;

                groupBox_Joueur3.Text = partieEnCours.Joueurs[2].Nom;
                textBox_JetonsJoueur3.Text = partieEnCours.Joueurs[2].NbJetons.ToString();
                partieEnCours.Joueurs[2].Tour = 3;

                groupBox_Joueur4.Text = partieEnCours.Joueurs[3].Nom;
                textBox_JetonsJoueur4.Text = partieEnCours.Joueurs[3].NbJetons.ToString();
                partieEnCours.Joueurs[3].Tour = 4;
            }

            // Commencer le premier Tour donc celui du premier Joueur
            numericUpDown_Tour.Value = partieEnCours.TourEnCours;
        }

        private void propriétésDesJoueursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Création de l'objet formulaire d'affichage
            Proprietes formPropriete = new Proprietes(this);

            // Ajouter tous les joueurs de la listBox_Selection à la FenetreJoueur avant d'afficher la fenêtre
            foreach (Joueur joueur in partieEnCours.Joueurs)
            {
                formPropriete.AjouterListe(joueur);  // Ajouter chaque joueur à la FenetreJoueur
            }

            // Afficher la fenêtre pour la création du joueur
            formPropriete.ShowDialog();
        }
    }
}
