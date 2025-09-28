namespace TP2KittikhounHugo
{
    partial class Form_Acceuil
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Acceuil));
            menuStrip_Acceuil = new MenuStrip();
            creerUnJoueurToolStripMenuItem = new ToolStripMenuItem();
            demarrerUnePartieToolStripMenuItem = new ToolStripMenuItem();
            quitterToolStripMenuItem = new ToolStripMenuItem();
            pictureBox_Acceuil = new PictureBox();
            label_Blackjack = new Label();
            button_Creation = new Button();
            button_Quitter = new Button();
            label_Selection = new Label();
            label_Participants = new Label();
            listBox_Selection = new ListBox();
            listBox_Participants = new ListBox();
            button_Confirmation = new Button();
            button_Demarrer = new Button();
            menuStrip_Acceuil.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Acceuil).BeginInit();
            SuspendLayout();
            // 
            // menuStrip_Acceuil
            // 
            menuStrip_Acceuil.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuStrip_Acceuil.Items.AddRange(new ToolStripItem[] { creerUnJoueurToolStripMenuItem, demarrerUnePartieToolStripMenuItem, quitterToolStripMenuItem });
            menuStrip_Acceuil.Location = new Point(0, 0);
            menuStrip_Acceuil.Name = "menuStrip_Acceuil";
            menuStrip_Acceuil.Padding = new Padding(9, 3, 0, 3);
            menuStrip_Acceuil.Size = new Size(1028, 28);
            menuStrip_Acceuil.TabIndex = 0;
            menuStrip_Acceuil.Text = "menuStrip1";
            // 
            // creerUnJoueurToolStripMenuItem
            // 
            creerUnJoueurToolStripMenuItem.Name = "creerUnJoueurToolStripMenuItem";
            creerUnJoueurToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.A;
            creerUnJoueurToolStripMenuItem.Size = new Size(124, 22);
            creerUnJoueurToolStripMenuItem.Text = "Créer un joueur...";
            creerUnJoueurToolStripMenuItem.Click += creerUnJoueurToolStripMenuItem_Click;
            // 
            // demarrerUnePartieToolStripMenuItem
            // 
            demarrerUnePartieToolStripMenuItem.Name = "demarrerUnePartieToolStripMenuItem";
            demarrerUnePartieToolStripMenuItem.Size = new Size(151, 22);
            demarrerUnePartieToolStripMenuItem.Text = "Démarrer une partie...";
            demarrerUnePartieToolStripMenuItem.Click += demarrerUnePartieToolStripMenuItem_Click;
            // 
            // quitterToolStripMenuItem
            // 
            quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            quitterToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Q;
            quitterToolStripMenuItem.Size = new Size(65, 22);
            quitterToolStripMenuItem.Text = "Quitter";
            quitterToolStripMenuItem.Click += button_Quitter_Click;
            // 
            // pictureBox_Acceuil
            // 
            pictureBox_Acceuil.Image = (Image)resources.GetObject("pictureBox_Acceuil.Image");
            pictureBox_Acceuil.Location = new Point(13, 33);
            pictureBox_Acceuil.Margin = new Padding(4, 5, 4, 5);
            pictureBox_Acceuil.Name = "pictureBox_Acceuil";
            pictureBox_Acceuil.Size = new Size(169, 158);
            pictureBox_Acceuil.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_Acceuil.TabIndex = 1;
            pictureBox_Acceuil.TabStop = false;
            // 
            // label_Blackjack
            // 
            label_Blackjack.AutoSize = true;
            label_Blackjack.Font = new Font("Comic Sans MS", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Blackjack.Location = new Point(189, 88);
            label_Blackjack.Name = "label_Blackjack";
            label_Blackjack.Size = new Size(188, 52);
            label_Blackjack.TabIndex = 2;
            label_Blackjack.Text = "Blackjack";
            // 
            // button_Creation
            // 
            button_Creation.Font = new Font("Comic Sans MS", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button_Creation.Location = new Point(429, 66);
            button_Creation.Name = "button_Creation";
            button_Creation.Size = new Size(277, 106);
            button_Creation.TabIndex = 3;
            button_Creation.Text = "Créer un joueur";
            button_Creation.UseVisualStyleBackColor = true;
            button_Creation.Click += creerUnJoueurToolStripMenuItem_Click;
            // 
            // button_Quitter
            // 
            button_Quitter.Font = new Font("Comic Sans MS", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button_Quitter.Location = new Point(712, 66);
            button_Quitter.Name = "button_Quitter";
            button_Quitter.Size = new Size(277, 106);
            button_Quitter.TabIndex = 4;
            button_Quitter.Text = "Quitter";
            button_Quitter.UseVisualStyleBackColor = true;
            button_Quitter.Click += button_Quitter_Click;
            // 
            // label_Selection
            // 
            label_Selection.AutoSize = true;
            label_Selection.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Selection.Location = new Point(12, 225);
            label_Selection.Name = "label_Selection";
            label_Selection.Size = new Size(233, 29);
            label_Selection.TabIndex = 5;
            label_Selection.Text = "Sélectionner un joueur";
            // 
            // label_Participants
            // 
            label_Participants.AutoSize = true;
            label_Participants.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Participants.Location = new Point(517, 225);
            label_Participants.Name = "label_Participants";
            label_Participants.Size = new Size(248, 29);
            label_Participants.TabIndex = 6;
            label_Participants.Text = "Les joueurs participants";
            // 
            // listBox_Selection
            // 
            listBox_Selection.FormattingEnabled = true;
            listBox_Selection.ItemHeight = 23;
            listBox_Selection.Location = new Point(12, 257);
            listBox_Selection.Name = "listBox_Selection";
            listBox_Selection.SelectionMode = SelectionMode.MultiExtended;
            listBox_Selection.Size = new Size(499, 142);
            listBox_Selection.TabIndex = 7;
            // 
            // listBox_Participants
            // 
            listBox_Participants.FormattingEnabled = true;
            listBox_Participants.ItemHeight = 23;
            listBox_Participants.Location = new Point(517, 257);
            listBox_Participants.Name = "listBox_Participants";
            listBox_Participants.Size = new Size(499, 142);
            listBox_Participants.TabIndex = 8;
            // 
            // button_Confirmation
            // 
            button_Confirmation.Font = new Font("Comic Sans MS", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button_Confirmation.Location = new Point(13, 416);
            button_Confirmation.Name = "button_Confirmation";
            button_Confirmation.Size = new Size(498, 83);
            button_Confirmation.TabIndex = 9;
            button_Confirmation.Text = "Confirmer votre sélection";
            button_Confirmation.UseVisualStyleBackColor = true;
            button_Confirmation.Click += button_Confirmation_Click;
            // 
            // button_Demarrer
            // 
            button_Demarrer.Font = new Font("Comic Sans MS", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button_Demarrer.Location = new Point(517, 416);
            button_Demarrer.Name = "button_Demarrer";
            button_Demarrer.Size = new Size(499, 83);
            button_Demarrer.TabIndex = 10;
            button_Demarrer.Text = "Démarrer la partie";
            button_Demarrer.UseVisualStyleBackColor = true;
            button_Demarrer.Click += demarrerUnePartieToolStripMenuItem_Click;
            // 
            // Form_Acceuil
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1028, 519);
            Controls.Add(button_Demarrer);
            Controls.Add(button_Confirmation);
            Controls.Add(listBox_Participants);
            Controls.Add(listBox_Selection);
            Controls.Add(label_Participants);
            Controls.Add(label_Selection);
            Controls.Add(button_Quitter);
            Controls.Add(button_Creation);
            Controls.Add(label_Blackjack);
            Controls.Add(pictureBox_Acceuil);
            Controls.Add(menuStrip_Acceuil);
            Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MainMenuStrip = menuStrip_Acceuil;
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form_Acceuil";
            Text = "Collège - Hugo Kittikhoun";
            FormClosing += Form_Acceuil_FormClosing;
            menuStrip_Acceuil.ResumeLayout(false);
            menuStrip_Acceuil.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Acceuil).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip_Acceuil;
        private ToolStripMenuItem creerUnJoueurToolStripMenuItem;
        private ToolStripMenuItem demarrerUnePartieToolStripMenuItem;
        private ToolStripMenuItem quitterToolStripMenuItem;
        private PictureBox pictureBox_Acceuil;
        private Label label_Blackjack;
        private Button button_Creation;
        private Button button_Quitter;
        private Label label_Selection;
        private Label label_Participants;
        private ListBox listBox_Selection;
        private ListBox listBox_Participants;
        private Button button_Confirmation;
        private Button button_Demarrer;
    }
}
