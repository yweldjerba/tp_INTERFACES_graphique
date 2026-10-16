namespace TP_ClientPanier
{
    partial class Form1
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
            this.cbClients = new System.Windows.Forms.ComboBox();
            this.lblTotal = new System.Windows.Forms.ListView();
            this.btnChargerPanier = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbClients
            // 
            this.cbClients.FormattingEnabled = true;
            this.cbClients.Location = new System.Drawing.Point(62, 36);
            this.cbClients.Name = "cbClients";
            this.cbClients.Size = new System.Drawing.Size(690, 21);
            this.cbClients.TabIndex = 0;
            // 
            // lblTotal
            // 
            this.lblTotal.HideSelection = false;
            this.lblTotal.Location = new System.Drawing.Point(62, 94);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(602, 304);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.UseCompatibleStateImageBehavior = false;
            // 
            // btnChargerPanier
            // 
            this.btnChargerPanier.Location = new System.Drawing.Point(677, 94);
            this.btnChargerPanier.Name = "btnChargerPanier";
            this.btnChargerPanier.Size = new System.Drawing.Size(75, 304);
            this.btnChargerPanier.TabIndex = 2;
            this.btnChargerPanier.Text = "button1";
            this.btnChargerPanier.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnChargerPanier);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.cbClients);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbClients;
        private System.Windows.Forms.ListView lblTotal;
        private System.Windows.Forms.Button btnChargerPanier;
    }
}