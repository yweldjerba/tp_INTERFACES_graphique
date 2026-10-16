namespace TP_ClientPanier
{
    partial class Form2
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
            this.cbClient = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lvPanier = new System.Windows.Forms.ListView();
            this.produit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.prix = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.quantite = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.total = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbClient
            // 
            this.cbClient.FormattingEnabled = true;
            this.cbClient.Location = new System.Drawing.Point(37, 45);
            this.cbClient.Name = "cbClient";
            this.cbClient.Size = new System.Drawing.Size(609, 21);
            this.cbClient.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(690, 80);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 317);
            this.button1.TabIndex = 1;
            this.button1.Text = "charger";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lvPanier
            // 
            this.lvPanier.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.produit,
            this.prix,
            this.quantite,
            this.total});
            this.lvPanier.HideSelection = false;
            this.lvPanier.Location = new System.Drawing.Point(69, 120);
            this.lvPanier.Name = "lvPanier";
            this.lvPanier.Size = new System.Drawing.Size(441, 230);
            this.lvPanier.TabIndex = 2;
            this.lvPanier.UseCompatibleStateImageBehavior = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(355, 374);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "ajouter";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lvPanier);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbClient);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbClient;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView lvPanier;
        private System.Windows.Forms.ColumnHeader produit;
        private System.Windows.Forms.ColumnHeader prix;
        private System.Windows.Forms.ColumnHeader quantite;
        private System.Windows.Forms.ColumnHeader total;
        private System.Windows.Forms.Button button2;
    }
}