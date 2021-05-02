
namespace HeavyClient
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbdepart = new System.Windows.Forms.TextBox();
            this.tbarrive = new System.Windows.Forms.TextBox();
            this.btnvalider = new System.Windows.Forms.Button();
            this.btnreset = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.listbitineraire = new System.Windows.Forms.ListBox();
            this.Listvutil = new System.Windows.Forms.ListView();
            this.pdepart = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.parrive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sdepart = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sarrive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.distance = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.duree = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dateheure = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnafficher = new System.Windows.Forms.Button();
            this.btnexport = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbldistance = new System.Windows.Forms.Label();
            this.lbldure = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Depart :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Arrivée :";
            // 
            // tbdepart
            // 
            this.tbdepart.AccessibleName = "";
            this.tbdepart.Location = new System.Drawing.Point(116, 43);
            this.tbdepart.Name = "tbdepart";
            this.tbdepart.Size = new System.Drawing.Size(121, 20);
            this.tbdepart.TabIndex = 2;
            // 
            // tbarrive
            // 
            this.tbarrive.AccessibleName = "";
            this.tbarrive.Location = new System.Drawing.Point(116, 92);
            this.tbarrive.Name = "tbarrive";
            this.tbarrive.Size = new System.Drawing.Size(121, 20);
            this.tbarrive.TabIndex = 3;
            // 
            // btnvalider
            // 
            this.btnvalider.AccessibleName = "";
            this.btnvalider.Location = new System.Drawing.Point(36, 138);
            this.btnvalider.Name = "btnvalider";
            this.btnvalider.Size = new System.Drawing.Size(66, 23);
            this.btnvalider.TabIndex = 4;
            this.btnvalider.Text = "Valider";
            this.btnvalider.UseVisualStyleBackColor = true;
            this.btnvalider.Click += new System.EventHandler(this.btnvalider_Click);
            // 
            // btnreset
            // 
            this.btnreset.AccessibleName = "";
            this.btnreset.Location = new System.Drawing.Point(158, 138);
            this.btnreset.Name = "btnreset";
            this.btnreset.Size = new System.Drawing.Size(66, 23);
            this.btnreset.TabIndex = 5;
            this.btnreset.Text = "Reset";
            this.btnreset.UseVisualStyleBackColor = true;
            this.btnreset.Click += new System.EventHandler(this.btnreset_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "formulaire de demande d\'itineraire";
            // 
            // listbitineraire
            // 
            this.listbitineraire.FormattingEnabled = true;
            this.listbitineraire.Location = new System.Drawing.Point(12, 187);
            this.listbitineraire.Name = "listbitineraire";
            this.listbitineraire.Size = new System.Drawing.Size(290, 251);
            this.listbitineraire.TabIndex = 8;
            // 
            // Listvutil
            // 
            this.Listvutil.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.pdepart,
            this.parrive,
            this.sdepart,
            this.sarrive,
            this.distance,
            this.duree,
            this.dateheure});
            this.Listvutil.FullRowSelect = true;
            this.Listvutil.GridLines = true;
            this.Listvutil.HideSelection = false;
            this.Listvutil.Location = new System.Drawing.Point(417, 43);
            this.Listvutil.Name = "Listvutil";
            this.Listvutil.Size = new System.Drawing.Size(718, 236);
            this.Listvutil.TabIndex = 9;
            this.Listvutil.UseCompatibleStateImageBehavior = false;
            this.Listvutil.View = System.Windows.Forms.View.Details;
            // 
            // pdepart
            // 
            this.pdepart.Text = "Point Depart";
            this.pdepart.Width = 104;
            // 
            // parrive
            // 
            this.parrive.Text = "Point arrivée";
            this.parrive.Width = 97;
            // 
            // sdepart
            // 
            this.sdepart.Text = "Station depart";
            this.sdepart.Width = 112;
            // 
            // sarrive
            // 
            this.sarrive.Text = "Station arrivée";
            this.sarrive.Width = 107;
            // 
            // distance
            // 
            this.distance.Text = "Distance";
            this.distance.Width = 95;
            // 
            // duree
            // 
            this.duree.Text = "Durée";
            this.duree.Width = 88;
            // 
            // dateheure
            // 
            this.dateheure.Text = "Date-Heure";
            this.dateheure.Width = 111;
            // 
            // btnafficher
            // 
            this.btnafficher.Location = new System.Drawing.Point(447, 314);
            this.btnafficher.Name = "btnafficher";
            this.btnafficher.Size = new System.Drawing.Size(75, 23);
            this.btnafficher.TabIndex = 10;
            this.btnafficher.Text = "Afficher";
            this.btnafficher.UseVisualStyleBackColor = true;
            this.btnafficher.Click += new System.EventHandler(this.btnafficher_Click);
            // 
            // btnexport
            // 
            this.btnexport.Location = new System.Drawing.Point(648, 314);
            this.btnexport.Name = "btnexport";
            this.btnexport.Size = new System.Drawing.Size(75, 23);
            this.btnexport.TabIndex = 11;
            this.btnexport.Text = "Exporter";
            this.btnexport.UseVisualStyleBackColor = true;
            this.btnexport.Click += new System.EventHandler(this.btnexport_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(417, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(279, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "Details essentiels de l\'enssemble des requetes effectuées";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(833, 340);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Distance moyenne parcourue  :";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(833, 406);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Durée moyenne des parcours  :";
            // 
            // lbldistance
            // 
            this.lbldistance.AutoSize = true;
            this.lbldistance.Location = new System.Drawing.Point(1043, 340);
            this.lbldistance.Name = "lbldistance";
            this.lbldistance.Size = new System.Drawing.Size(22, 13);
            this.lbldistance.TabIndex = 15;
            this.lbldistance.Text = "0.0";
            // 
            // lbldure
            // 
            this.lbldure.AutoSize = true;
            this.lbldure.Location = new System.Drawing.Point(1043, 406);
            this.lbldure.Name = "lbldure";
            this.lbldure.Size = new System.Drawing.Size(22, 13);
            this.lbldure.TabIndex = 16;
            this.lbldure.Text = "0.0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 466);
            this.Controls.Add(this.lbldure);
            this.Controls.Add(this.lbldistance);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnexport);
            this.Controls.Add(this.btnafficher);
            this.Controls.Add(this.Listvutil);
            this.Controls.Add(this.listbitineraire);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnreset);
            this.Controls.Add(this.btnvalider);
            this.Controls.Add(this.tbarrive);
            this.Controls.Add(this.tbdepart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Let\'s go biking";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbdepart;
        private System.Windows.Forms.TextBox tbarrive;
        private System.Windows.Forms.Button btnvalider;
        private System.Windows.Forms.Button btnreset;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listbitineraire;
        private System.Windows.Forms.ListView Listvutil;
        private System.Windows.Forms.ColumnHeader pdepart;
        private System.Windows.Forms.ColumnHeader parrive;
        private System.Windows.Forms.ColumnHeader sdepart;
        private System.Windows.Forms.ColumnHeader sarrive;
        private System.Windows.Forms.ColumnHeader distance;
        private System.Windows.Forms.ColumnHeader duree;
        private System.Windows.Forms.ColumnHeader dateheure;
        private System.Windows.Forms.Button btnafficher;
        private System.Windows.Forms.Button btnexport;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbldistance;
        private System.Windows.Forms.Label lbldure;
    }
}

