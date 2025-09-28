namespace TP2KittikhounHugo
{
    public partial class Form_Acceuil : Form
    {
        Joueur[] joueursParticipant = new Joueur[4];
        int indiceJoueur = 0;

        public Form_Acceuil()
        {
            InitializeComponent();
        }

        private void Form_Acceuil_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Message de fermeture d'application
            DialogResult resultat = MessageBox.Show("�tes-vous s�r de vouloir quitter?", "Fermeture de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (resultat == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void button_Quitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void creerUnJoueurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Cr�ation de l'objet formulaire d'affichage
            FenetreJoueur formJoueur = new FenetreJoueur(this);

            // Ajouter tous les joueurs de la listBox_Selection � la FenetreJoueur avant d'afficher la fen�tre
            foreach (Joueur joueur in listBox_Selection.Items)
            {
                formJoueur.AjouterListe(joueur);  // Ajouter chaque joueur � la FenetreJoueur
            }

            // Afficher la fen�tre pour la cr�ation du joueur
            formJoueur.ShowDialog();
        }

        private void demarrerUnePartieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // cr�ation l'objet formulaire d'affichage
            // pour passer le form1, on utilise this
            FenetreJeu formJeu = new FenetreJeu(this);

            // afficher la fen�tre d'affichage du client
            formJeu.ShowDialog();
        }

        public void AjouterJoueurListe(Joueur joueur)
        {
            listBox_Selection.Items.Add(joueur);
        }

        public void EffacerJoueurListe(int indice)
        {
            listBox_Selection.Items.RemoveAt(indice);
        }

        private void button_Confirmation_Click(object sender, EventArgs e)
        {
            int totalJoueurs = listBox_Selection.SelectedItems.Count + listBox_Participants.Items.Count;
            // V�rifier si le nombre de joueurs s�lectionn�s est <= 4
            if (listBox_Selection.SelectedItems.Count > 4)
            {
                MessageBox.Show("Vous ne pouvez s�lectionner que 4 joueurs au maximum.", "Limite de joueurs", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Si la listBox_Participants contient d�j� des joueurs, v�rifier s'il y en a moins de 4
            if (totalJoueurs <= 4)
            {
                // Ajouter les joueurs s�lectionn�s � listBox_Participants et au tableau joueursParticipant
                foreach (var joueur in listBox_Selection.SelectedItems)
                {
                    // Ajouter chaque joueur � la listBox_Participants si ce n'est pas d�j� ajout�
                    if (!listBox_Participants.Items.Contains(joueur))
                    {
                        listBox_Participants.Items.Add(joueur);

                        // Ajouter le joueur au tableau des participants
                        if (indiceJoueur < joueursParticipant.Length)
                        {
                            joueursParticipant[indiceJoueur] = (Joueur)joueur;
                            indiceJoueur++; // Incr�menter l'indice
                        }
                    }
                }
            }
            else
            {
                // Si la listBox_Participants contient d�j� 4 �l�ments, on remplace tous les joueurs
                listBox_Participants.Items.Clear();
                Array.Clear(joueursParticipant, 0, joueursParticipant.Length);  // Vider le tableau

                // Ajouter les joueurs s�lectionn�s � listBox_Participants et au tableau joueursParticipant
                foreach (var joueur in listBox_Selection.SelectedItems)
                {
                    listBox_Participants.Items.Add(joueur); // Ajouter dans la listBox

                    // Ajouter le joueur au tableau des participants
                    if (indiceJoueur < joueursParticipant.Length)
                    {
                        joueursParticipant[indiceJoueur] = (Joueur)joueur;
                        indiceJoueur++; // Incr�menter l'indice
                    }
                }
            }

            // D�s�lectionner les joueurs apr�s confirmation
            listBox_Selection.ClearSelected();
        }

        public Joueur[] GetJoueursSelectionnes()
        {
            Joueur[] joueursSelectionnes = new Joueur[listBox_Participants.Items.Count];
            int indice = 0;

            if (listBox_Participants.Items.Count > 0)
            {
                foreach (var joueur in listBox_Participants.Items)
                {
                    joueursSelectionnes[indice] = (Joueur)joueur;
                    indice++;
                }
            }
            return joueursSelectionnes;
        }
    }
}