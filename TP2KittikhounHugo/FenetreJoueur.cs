using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP2KittikhounHugo
{
    // constructeur du formulaire d'affichage : ajoute paramètre form1
    public partial class FenetreJoueur : Form
    {
        // Création de la variable des numéros de joueurs et un de tableau de 10 joueurs et de l'avatar;
        private int ctr_no = 0;
        Joueur[] joueurs = new Joueur[10];
        string avatar;
        int pointage = 0;
        int tour = 0;
        int nbPartie = 0;

        // variables pour impression
        //nom du fichier
        string nomFichierImpression = "joueursBlackJack";

        // portion du document à imprimer
        string portionDocImpression;

        // police de caractères pour l'impression
        Font policeImpression;

        // L'indice de joueur a imprimer
        private int indexJoueurImpression = 0;

        public FenetreJoueur(Form_Acceuil pFormulaire)
        {
            InitializeComponent();

            // attribuer le paramètre form1 à la variable locale
            this.fenetreJoueur = pFormulaire;
        }

        // variable locale du formulaire principal (form1)
        private Form_Acceuil fenetreJoueur;

        private void retourALacceuilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // fermer la fenêtre - important utilisation de close
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
            // Vérifier si un avatar est sélectionné
            if (!radioButton_Rouge.Checked &&
                !radioButton_Bleu.Checked &&
                !radioButton_Vert.Checked &&
                !radioButton_Jaune.Checked)
            {
                MessageBox.Show("Veuillez sélectionner un avatar avant de sauvegarder.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (ctr_no >= joueurs.Length)
            {
                MessageBox.Show("Le maximum de joueurs est atteint.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Déterminer l'avatar sélectionné
            if (radioButton_Rouge.Checked)
            {
                avatar = "Rouge";
            }
            else if (radioButton_Bleu.Checked)
            {
                avatar = "Bleu";
            }
            else if (radioButton_Vert.Checked)
            {
                avatar = "Vert";
            }
            else if (radioButton_Jaune.Checked)
            {
                avatar = "Jaune";
            }

            // Ajouter le joueur au tableau
            joueurs[ctr_no] = new Joueur(ctr_no + 1, textBox_Identifiant.Text, avatar, (int)numericUpDown_Jetons.Value, pointage, tour, nbPartie);

            // Ajouter le joueur à la liste
            listBox_listeJoueur.Items.Add(joueurs[ctr_no]);
            fenetreJoueur.AjouterJoueurListe(joueurs[ctr_no]);

            // Incrémenter le compteur après l'ajout
            ctr_no++;

            // Réinitialiser les champs du formulaire
            button_Supprimer.Enabled = true;
            textBox_Identifiant.Clear();
            pictureBox_Avatar.Image = null;
            radioButton_Rouge.Checked = false;
            radioButton_Bleu.Checked = false;
            radioButton_Vert.Checked = false;
            radioButton_Jaune.Checked = false;
            numericUpDown_Jetons.Value = 1;
        }


        private void exporterLesDonneesDuJoueurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Vérifier si des joueurs existent
            if (ctr_no == 0)
            {
                MessageBox.Show("Aucun joueur à exporter.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Nom du fichier JSON : par défaut -> sauvegarde dans Application,StartupPath
            string nomFichier = "joueurs.json";
            object listeJoueurJson = joueurs;

            try
            {
                // Options du fichier json
                var options = new JsonSerializerOptions
                {
                    // Affichage plus lisible
                    WriteIndented = true,

                    // Encodage pour caractères accentuées
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };

                // Sérialisation en fichier json
                var jsonString = JsonSerializer.Serialize(listeJoueurJson, options);

                // Sauvegarde dans le fichier avec encodage UTF-8
                File.WriteAllText(nomFichier, jsonString, System.Text.Encoding.UTF8);

                // Message d'affichage de sauvegarde : à faire avec plus d'options
                MessageBox.Show("Fichier est sauvegardé");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur dans l'exportation des données : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button_Modifier_Click(object sender, EventArgs e)
        {
            textBox_Identifiant.Enabled = true;
            groupBox_Avatar.Enabled = true;
            numericUpDown_Jetons.Enabled = true;
        }

        private void textBox_Identifiant_TextChanged(object sender, EventArgs e)
        {
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
                        fenetreJoueur.EffacerJoueurListe(indice);

                        // Mettre à jour le tableau des joueurs
                        for (int i = indice; i < ctr_no - 1; i++)
                        {
                            joueurs[i] = joueurs[i + 1];
                            joueurs[i].NoJoueur = i + 1; // Réassigner les numéros de joueur
                        }

                        joueurs[ctr_no - 1] = null;
                        ctr_no--;
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
            textBox_Identifiant.Clear();
            pictureBox_Avatar.Image = null;
            radioButton_Rouge.Checked = false;
            radioButton_Bleu.Checked = false;
            radioButton_Vert.Checked = false;
            radioButton_Jaune.Checked = false;
            numericUpDown_Jetons.Value = 1;
        }

        public void AjouterListe(Joueur joueur)
        {
            listBox_listeJoueur.Items.Add(joueur);
        }

        private void imprimerLesDonneesDuJoueurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ctr_no == 0)
            {
                MessageBox.Show("Aucun joueur à imprimer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            policeImpression = new Font("Courier New", 10);
            printDocumentImp.DocumentName = nomFichierImpression;

            // Créer une chaîne contenant les informations des joueurs
            StringBuilder sb = new StringBuilder();
            foreach (var joueur in joueurs.Where(j => j != null))
            {
                sb.AppendLine($"ID: {joueur.NoJoueur}, Nom: {joueur.Nom}, Avatar: {joueur.Avatar}, Jetons: {joueur.NbJetons}");
            }

            portionDocImpression = sb.ToString();

            if (printDialogImp.ShowDialog() == DialogResult.OK)
            {
                printDocumentImp.Print();
            }
        }

        private void printDocumentImp_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int caracteresParPage = 0;
            int lignesParPage = 0;
            policeImpression = new Font("Courier New", 14);

            // Vérifier si l'index dépasse le nombre de joueurs
            if (indexJoueurImpression >= ctr_no)
            {
                e.HasMorePages = false; // Plus de pages à imprimer
                return;
            }

            // Prendre le joueur à imprimer
            var joueur = joueurs[indexJoueurImpression];
            if (joueur == null)
            {
                e.HasMorePages = false;
                return;
            }

            // Créer une chaîne contenant les informations du joueur actuel
            string texteImpression = $"ID: {joueur.NoJoueur}, Nom: {joueur.Nom}, Avatar: {joueur.Avatar}, Jetons: {joueur.NbJetons}";

            // Déterminer le nombre de caractères et de lignes par page
            e.Graphics.MeasureString(texteImpression, policeImpression,
                e.MarginBounds.Size, StringFormat.GenericTypographic,
                out caracteresParPage, out lignesParPage);

            // Dessiner l'impression
            e.Graphics.DrawString(texteImpression, policeImpression,
                Brushes.Black, e.MarginBounds, StringFormat.GenericTypographic);

            // Mettre à jour l'index du joueur pour la page suivante
            indexJoueurImpression++;

            // Vérifier si d'autres pages sont nécessaires
            e.HasMorePages = (indexJoueurImpression < ctr_no);
        }
    }
}
