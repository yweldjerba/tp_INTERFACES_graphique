namespace TP_ClientPanier
{
    partial class FormAjout
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
            this.cbProduits = new System.Windows.Forms.ComboBox();
            this.tbQuantite = new System.Windows.Forms.TextBox();
            this.btnValider = new System.Windows.Forms.Button();
            this.mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            this.SuspendLayout();
            // 
            // cbProduits
            // 
            this.cbProduits.FormattingEnabled = true;
            this.cbProduits.Location = new System.Drawing.Point(66, 59);
            this.cbProduits.Name = "cbProduits";
            this.cbProduits.Size = new System.Drawing.Size(354, 21);
            this.cbProduits.TabIndex = 0;
            // 
            // tbQuantite
            // 
            this.tbQuantite.Location = new System.Drawing.Point(602, 59);
            this.tbQuantite.Name = "tbQuantite";
            this.tbQuantite.Size = new System.Drawing.Size(100, 20);
            this.tbQuantite.TabIndex = 1;
            // 
            // btnValider
            // 
            this.btnValider.Location = new System.Drawing.Point(150, 172);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(461, 167);
            this.btnValider.TabIndex = 2;
            this.btnValider.Text = "ajouter";
            this.btnValider.UseVisualStyleBackColor = true;
            // 
            // mySqlCommand1
            // 
            this.mySqlCommand1.CacheAge = 0;
            this.mySqlCommand1.Connection = null;
            this.mySqlCommand1.EnableCaching = false;
            this.mySqlCommand1.Transaction = null;
            // 
            // FormAjout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnValider);
            this.Controls.Add(this.tbQuantite);
            this.Controls.Add(this.cbProduits);
            this.Name = "FormAjout";
            this.Text = "FormAjout";
            this.Load += new System.EventHandler(this.FormAjout_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbProduits;
        private System.Windows.Forms.TextBox tbQuantite;
        private System.Windows.Forms.Button btnValider;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
    }
}