using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP2KittikhounHugo
{
    public partial class Proprietes : Form
    {
        // Création de la variable des numéros de joueurs et un de tableau de 4 joueurs;
        Joueur[] joueurs = new Joueur[4];
        int pointage = 0;
        int tour = 0;
        int nbPartie = 0;

        // Joueur sélectionner
        private Joueur joueurTemp = new Joueur();

        public Proprietes(FenetreJeu pFormulaire)
        {
            InitializeComponent();

            // attribuer le paramètre form1 à la variable locale
            this.fenetrePro = pFormulaire;
        }

        // variable locale du formulaire principal (form1)
        private FenetreJeu fenetrePro;

        private void button_Quitter_Click(object sender, EventArgs e)
        {
            fenetrePro.ModificationJoueurs(joueurs);
            this.Close();
        }

        private void textBox_Identifiant_Validated(object sender, EventArgs e)
        {
            // Si la validation est OK, on efface l'errorProvider
            errorProvider_Identifiant.SetError(textBox_Identifiant, "");
        }

        private void textBox_Identifiant_Validating(object sender, CancelEventArgs e)
        {
            string msg_erreur;

            if (!ValidationIdentifiant(textBox_Identifiant.Text, out msg_erreur))
            {
                // Annuler l'évènement
                e.Cancel = true;
                textBox_Identifiant.Select(0, textBox_Identifiant.Text.Length);

                // Affficher l'errorProvider
                this.errorProvider_Identifiant.SetError(textBox_Identifiant, msg_erreur);
            }
        }

        private bool ValidationIdentifiant(string p_identifiant, out string p_msg_erreur)
        {
            p_msg_erreur = "L'identifiant est requis";
            bool validation = false;

            // Validation si non vide
            if (p_identifiant.Length != 0)
            {
                validation = true;
            }

            return validation;
        }

        private void radioButton_Rouge_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Rouge.Checked)
            {
                pictureBox_Avatar.Image = Image.FromFile("..\\..\\..\\Resources\\avatarRouge.png");
            }
        }

        private void radioButton_Bleu_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Bleu.Checked)
            {
                pictureBox_Avatar.Image = Image.FromFile("..\\..\\..\\Resources\\avatarBleu.png");
            }
        }

        private void radioButton_Vert_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Vert.Checked)
            {
                pictureBox_Avatar.Image = Image.FromFile("..\\..\\..\\Resources\\avatarVert.png");

            }
        }

        private void radioButton_Jaune_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Jaune.Checked)
            {
                pictureBox_Avatar.Image = Image.FromFile("..\\..\\..\\Resources\\avatarJaune.png");

            }
        }

        private void button_Sauvegarder_Click(object sender, EventArgs e)
        {
            // Vérifie que tous les champs obligatoires sont remplis
            if (string.IsNullOrWhiteSpace(textBox_Identifiant.Text))
            {
                MessageBox.Show("Veuillez entrer un identifiant pour le joueur.", "Champ manquant", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Détermine l'avatar sélectionné
            string avatar = "";
            if (radioButton_Rouge.Checked)
                avatar = "Rouge";
            else if (radioButton_Bleu.Checked)
                avatar = "Bleu";
            else if (radioButton_Vert.Checked)
                avatar = "Vert";
            else if (radioButton_Jaune.Checked)
                avatar = "Jaune";

            if (string.IsNullOrEmpty(avatar))
            {
                MessageBox.Show("Veuillez sélectionner un avatar.", "Champ manquant", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            joueurTemp.Nom = textBox_Identifiant.Text;
            joueurTemp.Avatar = avatar;
            joueurTemp.NbJetons = (int)numericUpDown_Jetons.Value;

            // Vérifie si un joueur est sélectionné dans la liste
            if (listBox_listeJoueur.SelectedIndex >= 0)
            {
                // Modification du joueur sélectionné
                int index = listBox_listeJoueur.SelectedIndex;
                joueurs[index] = joueurTemp;

                // Met à jour l'affichage dans la listBox
                listBox_listeJoueur.Items[index] = joueurs[index];

                MessageBox.Show("Le joueur a été modifié avec succès.", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Vérifie si la limite de joueurs est atteinte
                if (listBox_listeJoueur.Items.Count >= joueurs.Length)
                {
                    MessageBox.Show("Vous ne pouvez pas ajouter plus de joueurs.", "Limite atteinte", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Ajout d'un nouveau joueur
                Joueur nouveauJoueur = new Joueur(
                    listBox_listeJoueur.Items.Count + 1,
                    textBox_Identifiant.Text,
                    avatar,
                    (int)numericUpDown_Jetons.Value,
                    pointage,
                    tour,
                    nbPartie
                );
                // Mise à jour du tableau des joueurs
                joueurs[listBox_listeJoueur.Items.Count] = nouveauJoueur;

                // Ajout du joueur dans la ListBox
                listBox_listeJoueur.Items.Add(nouveauJoueur);

                MessageBox.Show("Le joueur a été ajouté avec succès.", "Ajout", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Réinitialise les champs pour une nouvelle saisie
            ResetFormulaire();
        }

        private void ResetFormulaire()
        {
            button_Supprimer.Enabled = true;
            textBox_Identifiant.Clear();
            pictureBox_Avatar.Image = null;
            radioButton_Rouge.Checked = false;
            radioButton_Bleu.Checked = false;
            radioButton_Vert.Checked = false;
            radioButton_Jaune.Checked = false;
            numericUpDown_Jetons.Value = 1;
        }

        private void button_Modifier_Click(object sender, EventArgs e)
        {
            textBox_Identifiant.Enabled = true;
            groupBox_Avatar.Enabled = true;
            numericUpDown_Jetons.Enabled = true;
            button_Nouveau.Enabled = true;
            button_Sauvegarder.Enabled = true;
        }

        private void button_Supprimer_Click(object sender, EventArgs e)
        {
            try
            {
                // Vérifier qu'un joueur est sélectionné
                if (listBox_listeJoueur.SelectedIndex != -1)
                {
                    // Obtenir l'index du joueur sélectionné
                    int indice = listBox_listeJoueur.SelectedIndex;

                    // Confirmation de la suppression
                    DialogResult resultat = MessageBox.Show(
                        "Êtes-vous sûr de vouloir supprimer ce joueur ?",
                        "Confirmation",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (resultat == DialogResult.Yes)
                    {
                        // Supprimer le joueur sélectionné dans la liste
                        listBox_listeJoueur.Items.RemoveAt(indice);

                        // Mettre à jour le tableau des joueurs
                        for (int i = indice; i < listBox_listeJoueur.Items.Count - 1; i++)
                        {
                            joueurs[i] = joueurs[i + 1];
                            joueurs[i].NoJoueur = i + 1; // Réassigner les numéros de joueur
                        }

                        joueurs[listBox_listeJoueur.Items.Count - 1] = null;
                        MessageBox.Show("Le joueur a été supprimé avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(
                        "Veuillez sélectionner un joueur à supprimer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // Attraper l'exception null
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Élément null :" + ex.Message);
            }
            // Pour attraper d'autres exceptions potentielles
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void button_Nouveau_Click(object sender, EventArgs e)
        {
            ResetFormulaire();
            listBox_listeJoueur.SelectedIndex = -1;
        }

        private void listBox_listeJoueur_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_listeJoueur.SelectedIndex != -1)
            {
                textBox_Identifiant.Enabled = true;
                groupBox_Avatar.Enabled = true;
                numericUpDown_Jetons.Enabled = true;
                button_Nouveau.Enabled = true;
                button_Sauvegarder.Enabled = true;
                button_Supprimer.Enabled = true;

                joueurTemp = (Joueur)listBox_listeJoueur.SelectedItem;

                if (joueurTemp != null)
                {
                    textBox_Identifiant.Text = joueurTemp.Nom;
                    numericUpDown_Jetons.Value = joueurTemp.NbJetons;
                    if (joueurTemp.Avatar == "Rouge")
                    {
                        radioButton_Rouge.Checked = true;
                    }
                    else if (joueurTemp.Avatar == "Bleu")
                    {
                        radioButton_Bleu.Checked = true;
                    }
                    else if (joueurTemp.Avatar == "Vert")
                    {
                        radioButton_Vert.Checked = true;
                    }
                    else if (joueurTemp.Avatar == "Jaune")
                    {
                        radioButton_Jaune.Checked = true;
                    }
                }
            }
            else
            {
                joueurTemp = new Joueur();
            }
        }

        internal void AjouterListe(Joueur joueur)
        {
            listBox_listeJoueur.Items.Add(joueur);
        }
    }
}
