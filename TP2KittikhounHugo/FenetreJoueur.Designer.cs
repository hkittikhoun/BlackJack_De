namespace TP2KittikhounHugo
{
    partial class FenetreJoueur
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            menuStrip_Joueur = new MenuStrip();
            exporterLesDonneesDuJoueurToolStripMenuItem = new ToolStripMenuItem();
            imprimerLesDonneesDuJoueurToolStripMenuItem = new ToolStripMenuItem();
            retourALacceuilToolStripMenuItem = new ToolStripMenuItem();
            button_Sauvegarder = new Button();
            listBox_listeJoueur = new ListBox();
            label_ListeJoueur = new Label();
            button_Nouveau = new Button();
            button_Modifier = new Button();
            button_Supprimer = new Button();
            label_Identifiant = new Label();
            label_Avatar = new Label();
            label_Jetons = new Label();
            textBox_Identifiant = new TextBox();
            numericUpDown_Jetons = new NumericUpDown();
            groupBox_Avatar = new GroupBox();
            radioButton_Vert = new RadioButton();
            radioButton_Bleu = new RadioButton();
            radioButton_Jaune = new RadioButton();
            radioButton_Rouge = new RadioButton();
            pictureBox_Avatar = new PictureBox();
            errorProvider_Identifiant = new ErrorProvider(components);
            printDialogImp = new PrintDialog();
            printDocumentImp = new System.Drawing.Printing.PrintDocument();
            menuStrip_Joueur.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_Jetons).BeginInit();
            groupBox_Avatar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Avatar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider_Identifiant).BeginInit();
            SuspendLayout();
            // 
            // menuStrip_Joueur
            // 
            menuStrip_Joueur.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuStrip_Joueur.Items.AddRange(new ToolStripItem[] { exporterLesDonneesDuJoueurToolStripMenuItem, imprimerLesDonneesDuJoueurToolStripMenuItem, retourALacceuilToolStripMenuItem });
            menuStrip_Joueur.Location = new Point(0, 0);
            menuStrip_Joueur.Name = "menuStrip_Joueur";
            menuStrip_Joueur.Padding = new Padding(9, 3, 0, 3);
            menuStrip_Joueur.Size = new Size(852, 28);
            menuStrip_Joueur.TabIndex = 0;
            menuStrip_Joueur.Text = "menuStrip1";
            // 
            // exporterLesDonneesDuJoueurToolStripMenuItem
            // 
            exporterLesDonneesDuJoueurToolStripMenuItem.Name = "exporterLesDonneesDuJoueurToolStripMenuItem";
            exporterLesDonneesDuJoueurToolStripMenuItem.Size = new Size(210, 22);
            exporterLesDonneesDuJoueurToolStripMenuItem.Text = "Exporter les données du joueur";
            exporterLesDonneesDuJoueurToolStripMenuItem.Click += exporterLesDonneesDuJoueurToolStripMenuItem_Click;
            // 
            // imprimerLesDonneesDuJoueurToolStripMenuItem
            // 
            imprimerLesDonneesDuJoueurToolStripMenuItem.Name = "imprimerLesDonneesDuJoueurToolStripMenuItem";
            imprimerLesDonneesDuJoueurToolStripMenuItem.Size = new Size(211, 22);
            imprimerLesDonneesDuJoueurToolStripMenuItem.Text = "Imprimer les données du joueur";
            imprimerLesDonneesDuJoueurToolStripMenuItem.Click += imprimerLesDonneesDuJoueurToolStripMenuItem_Click;
            // 
            // retourALacceuilToolStripMenuItem
            // 
            retourALacceuilToolStripMenuItem.Name = "retourALacceuilToolStripMenuItem";
            retourALacceuilToolStripMenuItem.Size = new Size(127, 22);
            retourALacceuilToolStripMenuItem.Text = "Retour à l'acceuil";
            retourALacceuilToolStripMenuItem.Click += retourALacceuilToolStripMenuItem_Click;
            // 
            // button_Sauvegarder
            // 
            button_Sauvegarder.Enabled = false;
            button_Sauvegarder.Font = new Font("Comic Sans MS", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button_Sauvegarder.Location = new Point(12, 497);
            button_Sauvegarder.Name = "button_Sauvegarder";
            button_Sauvegarder.Size = new Size(411, 75);
            button_Sauvegarder.TabIndex = 13;
            button_Sauvegarder.Text = "Sauvegarder";
            button_Sauvegarder.UseVisualStyleBackColor = true;
            button_Sauvegarder.Click += button_Sauvegarder_Click;
            // 
            // listBox_listeJoueur
            // 
            listBox_listeJoueur.FormattingEnabled = true;
            listBox_listeJoueur.ItemHeight = 23;
            listBox_listeJoueur.Location = new Point(429, 268);
            listBox_listeJoueur.Name = "listBox_listeJoueur";
            listBox_listeJoueur.Size = new Size(411, 142);
            listBox_listeJoueur.TabIndex = 12;
            // 
            // label_ListeJoueur
            // 
            label_ListeJoueur.AutoSize = true;
            label_ListeJoueur.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_ListeJoueur.Location = new Point(429, 236);
            label_ListeJoueur.Name = "label_ListeJoueur";
            label_ListeJoueur.Size = new Size(180, 29);
            label_ListeJoueur.TabIndex = 11;
            label_ListeJoueur.Text = "Liste des joueurs";
            // 
            // button_Nouveau
            // 
            button_Nouveau.Enabled = false;
            button_Nouveau.Font = new Font("Comic Sans MS", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button_Nouveau.Location = new Point(429, 416);
            button_Nouveau.Name = "button_Nouveau";
            button_Nouveau.Size = new Size(411, 75);
            button_Nouveau.TabIndex = 14;
            button_Nouveau.Text = "Nouveau joueur";
            button_Nouveau.UseVisualStyleBackColor = true;
            button_Nouveau.Click += button_Nouveau_Click;
            // 
            // button_Modifier
            // 
            button_Modifier.Font = new Font("Comic Sans MS", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button_Modifier.Location = new Point(12, 416);
            button_Modifier.Name = "button_Modifier";
            button_Modifier.Size = new Size(411, 75);
            button_Modifier.TabIndex = 15;
            button_Modifier.Text = "Modifier";
            button_Modifier.UseVisualStyleBackColor = true;
            button_Modifier.Click += button_Modifier_Click;
            // 
            // button_Supprimer
            // 
            button_Supprimer.Enabled = false;
            button_Supprimer.Font = new Font("Comic Sans MS", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button_Supprimer.Location = new Point(429, 497);
            button_Supprimer.Name = "button_Supprimer";
            button_Supprimer.Size = new Size(411, 75);
            button_Supprimer.TabIndex = 16;
            button_Supprimer.Text = "Supprimer";
            button_Supprimer.UseVisualStyleBackColor = true;
            button_Supprimer.Click += button_Supprimer_Click;
            // 
            // label_Identifiant
            // 
            label_Identifiant.AutoSize = true;
            label_Identifiant.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Identifiant.Location = new Point(27, 87);
            label_Identifiant.Name = "label_Identifiant";
            label_Identifiant.Size = new Size(124, 29);
            label_Identifiant.TabIndex = 17;
            label_Identifiant.Text = "Identifiant";
            // 
            // label_Avatar
            // 
            label_Avatar.AutoSize = true;
            label_Avatar.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Avatar.Location = new Point(27, 166);
            label_Avatar.Name = "label_Avatar";
            label_Avatar.Size = new Size(81, 29);
            label_Avatar.TabIndex = 18;
            label_Avatar.Text = "Avatar";
            // 
            // label_Jetons
            // 
            label_Jetons.AutoSize = true;
            label_Jetons.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Jetons.Location = new Point(27, 329);
            label_Jetons.Name = "label_Jetons";
            label_Jetons.Size = new Size(197, 29);
            label_Jetons.TabIndex = 19;
            label_Jetons.Text = "Nombres de jetons";
            // 
            // textBox_Identifiant
            // 
            textBox_Identifiant.Enabled = false;
            textBox_Identifiant.Location = new Point(157, 89);
            textBox_Identifiant.Name = "textBox_Identifiant";
            textBox_Identifiant.Size = new Size(252, 30);
            textBox_Identifiant.TabIndex = 20;
            textBox_Identifiant.TextChanged += textBox_Identifiant_TextChanged;
            textBox_Identifiant.Validating += textBox_Identifiant_Validating;
            textBox_Identifiant.Validated += textBox_Identifiant_Validated;
            // 
            // numericUpDown_Jetons
            // 
            numericUpDown_Jetons.Enabled = false;
            numericUpDown_Jetons.Location = new Point(299, 332);
            numericUpDown_Jetons.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDown_Jetons.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown_Jetons.Name = "numericUpDown_Jetons";
            numericUpDown_Jetons.Size = new Size(110, 30);
            numericUpDown_Jetons.TabIndex = 21;
            numericUpDown_Jetons.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // groupBox_Avatar
            // 
            groupBox_Avatar.Controls.Add(radioButton_Vert);
            groupBox_Avatar.Controls.Add(radioButton_Bleu);
            groupBox_Avatar.Controls.Add(radioButton_Jaune);
            groupBox_Avatar.Controls.Add(radioButton_Rouge);
            groupBox_Avatar.Enabled = false;
            groupBox_Avatar.Location = new Point(125, 156);
            groupBox_Avatar.Name = "groupBox_Avatar";
            groupBox_Avatar.Size = new Size(284, 132);
            groupBox_Avatar.TabIndex = 22;
            groupBox_Avatar.TabStop = false;
            // 
            // radioButton_Vert
            // 
            radioButton_Vert.AutoSize = true;
            radioButton_Vert.Location = new Point(32, 80);
            radioButton_Vert.Name = "radioButton_Vert";
            radioButton_Vert.Size = new Size(61, 27);
            radioButton_Vert.TabIndex = 3;
            radioButton_Vert.TabStop = true;
            radioButton_Vert.Text = "Vert";
            radioButton_Vert.UseVisualStyleBackColor = true;
            radioButton_Vert.CheckedChanged += radioButton_Vert_CheckedChanged;
            // 
            // radioButton_Bleu
            // 
            radioButton_Bleu.AutoSize = true;
            radioButton_Bleu.Location = new Point(174, 29);
            radioButton_Bleu.Name = "radioButton_Bleu";
            radioButton_Bleu.Size = new Size(59, 27);
            radioButton_Bleu.TabIndex = 2;
            radioButton_Bleu.TabStop = true;
            radioButton_Bleu.Text = "Bleu";
            radioButton_Bleu.UseVisualStyleBackColor = true;
            radioButton_Bleu.CheckedChanged += radioButton_Bleu_CheckedChanged;
            // 
            // radioButton_Jaune
            // 
            radioButton_Jaune.AutoSize = true;
            radioButton_Jaune.Location = new Point(174, 80);
            radioButton_Jaune.Name = "radioButton_Jaune";
            radioButton_Jaune.Size = new Size(71, 27);
            radioButton_Jaune.TabIndex = 1;
            radioButton_Jaune.TabStop = true;
            radioButton_Jaune.Text = "Jaune";
            radioButton_Jaune.UseVisualStyleBackColor = true;
            radioButton_Jaune.CheckedChanged += radioButton_Jaune_CheckedChanged;
            // 
            // radioButton_Rouge
            // 
            radioButton_Rouge.AutoSize = true;
            radioButton_Rouge.Location = new Point(32, 29);
            radioButton_Rouge.Name = "radioButton_Rouge";
            radioButton_Rouge.Size = new Size(71, 27);
            radioButton_Rouge.TabIndex = 0;
            radioButton_Rouge.TabStop = true;
            radioButton_Rouge.Text = "Rouge";
            radioButton_Rouge.UseVisualStyleBackColor = true;
            radioButton_Rouge.CheckedChanged += radioButton_Rouge_CheckedChanged;
            // 
            // pictureBox_Avatar
            // 
            pictureBox_Avatar.Location = new Point(500, 31);
            pictureBox_Avatar.Name = "pictureBox_Avatar";
            pictureBox_Avatar.Size = new Size(252, 202);
            pictureBox_Avatar.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_Avatar.TabIndex = 23;
            pictureBox_Avatar.TabStop = false;
            // 
            // errorProvider_Identifiant
            // 
            errorProvider_Identifiant.ContainerControl = this;
            // 
            // printDialogImp
            // 
            printDialogImp.UseEXDialog = true;
            // 
            // printDocumentImp
            // 
            printDocumentImp.PrintPage += printDocumentImp_PrintPage;
            // 
            // FenetreJoueur
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(852, 584);
            Controls.Add(pictureBox_Avatar);
            Controls.Add(groupBox_Avatar);
            Controls.Add(numericUpDown_Jetons);
            Controls.Add(textBox_Identifiant);
            Controls.Add(label_Jetons);
            Controls.Add(label_Avatar);
            Controls.Add(label_Identifiant);
            Controls.Add(button_Supprimer);
            Controls.Add(button_Modifier);
            Controls.Add(button_Nouveau);
            Controls.Add(button_Sauvegarder);
            Controls.Add(listBox_listeJoueur);
            Controls.Add(label_ListeJoueur);
            Controls.Add(menuStrip_Joueur);
            Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MainMenuStrip = menuStrip_Joueur;
            Margin = new Padding(4, 5, 4, 5);
            Name = "FenetreJoueur";
            Text = "Collège - Hugo Kittikhoun";
            menuStrip_Joueur.ResumeLayout(false);
            menuStrip_Joueur.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_Jetons).EndInit();
            groupBox_Avatar.ResumeLayout(false);
            groupBox_Avatar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Avatar).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider_Identifiant).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip_Joueur;
        private ToolStripMenuItem exporterLesDonneesDuJoueurToolStripMenuItem;
        private ToolStripMenuItem imprimerLesDonneesDuJoueurToolStripMenuItem;
        private ToolStripMenuItem retourALacceuilToolStripMenuItem;
        private Button button_Sauvegarder;
        private ListBox listBox_listeJoueur;
        private Label label_ListeJoueur;
        private Button button_Nouveau;
        private Button button_Modifier;
        private Button button_Supprimer;
        private Label label_Identifiant;
        private Label label_Avatar;
        private Label label_Jetons;
        private TextBox textBox_Identifiant;
        private NumericUpDown numericUpDown_Jetons;
        private GroupBox groupBox_Avatar;
        private RadioButton radioButton_Rouge;
        private RadioButton radioButton_Vert;
        private RadioButton radioButton_Bleu;
        private RadioButton radioButton_Jaune;
        private PictureBox pictureBox_Avatar;
        private ErrorProvider errorProvider_Identifiant;
        private PrintDialog printDialogImp;
        private System.Drawing.Printing.PrintDocument printDocumentImp;
    }
}