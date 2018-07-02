namespace MUP_Gun_Record
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.formaKorisnickoIme = new System.Windows.Forms.TextBox();
            this.formaLozinka = new System.Windows.Forms.TextBox();
            this.oznakaKorisnickoIme = new System.Windows.Forms.Label();
            this.oznakaLozinka = new System.Windows.Forms.Label();
            this.logotip = new System.Windows.Forms.PictureBox();
            this.gumbPrijava = new System.Windows.Forms.Button();
            this.gumbRegistracija = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.logotip)).BeginInit();
            this.SuspendLayout();
            // 
            // formaKorisnickoIme
            // 
            this.formaKorisnickoIme.Location = new System.Drawing.Point(294, 77);
            this.formaKorisnickoIme.Name = "formaKorisnickoIme";
            this.formaKorisnickoIme.Size = new System.Drawing.Size(227, 20);
            this.formaKorisnickoIme.TabIndex = 0;
            // 
            // formaLozinka
            // 
            this.formaLozinka.Location = new System.Drawing.Point(294, 125);
            this.formaLozinka.Name = "formaLozinka";
            this.formaLozinka.Size = new System.Drawing.Size(227, 20);
            this.formaLozinka.TabIndex = 1;
            this.formaLozinka.UseSystemPasswordChar = true;
            // 
            // oznakaKorisnickoIme
            // 
            this.oznakaKorisnickoIme.AutoSize = true;
            this.oznakaKorisnickoIme.Location = new System.Drawing.Point(291, 61);
            this.oznakaKorisnickoIme.Name = "oznakaKorisnickoIme";
            this.oznakaKorisnickoIme.Size = new System.Drawing.Size(78, 13);
            this.oznakaKorisnickoIme.TabIndex = 2;
            this.oznakaKorisnickoIme.Text = "Korisničko ime:";
            // 
            // oznakaLozinka
            // 
            this.oznakaLozinka.AutoSize = true;
            this.oznakaLozinka.Location = new System.Drawing.Point(291, 109);
            this.oznakaLozinka.Name = "oznakaLozinka";
            this.oznakaLozinka.Size = new System.Drawing.Size(44, 13);
            this.oznakaLozinka.TabIndex = 3;
            this.oznakaLozinka.Text = "Lozinka";
            // 
            // logotip
            // 
            this.logotip.Image = ((System.Drawing.Image)(resources.GetObject("logotip.Image")));
            this.logotip.Location = new System.Drawing.Point(12, 12);
            this.logotip.Name = "logotip";
            this.logotip.Size = new System.Drawing.Size(254, 238);
            this.logotip.TabIndex = 4;
            this.logotip.TabStop = false;
            // 
            // gumbPrijava
            // 
            this.gumbPrijava.Location = new System.Drawing.Point(294, 166);
            this.gumbPrijava.Name = "gumbPrijava";
            this.gumbPrijava.Size = new System.Drawing.Size(75, 23);
            this.gumbPrijava.TabIndex = 5;
            this.gumbPrijava.Text = "Prijava";
            this.gumbPrijava.UseVisualStyleBackColor = true;
            this.gumbPrijava.Click += new System.EventHandler(this.gumbPrijava_Click);
            // 
            // gumbRegistracija
            // 
            this.gumbRegistracija.Location = new System.Drawing.Point(446, 166);
            this.gumbRegistracija.Name = "gumbRegistracija";
            this.gumbRegistracija.Size = new System.Drawing.Size(75, 23);
            this.gumbRegistracija.TabIndex = 6;
            this.gumbRegistracija.Text = "Registracija";
            this.gumbRegistracija.UseVisualStyleBackColor = true;
            this.gumbRegistracija.Click += new System.EventHandler(this.gumbRegistracija_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 262);
            this.Controls.Add(this.gumbRegistracija);
            this.Controls.Add(this.gumbPrijava);
            this.Controls.Add(this.logotip);
            this.Controls.Add(this.oznakaLozinka);
            this.Controls.Add(this.oznakaKorisnickoIme);
            this.Controls.Add(this.formaLozinka);
            this.Controls.Add(this.formaKorisnickoIme);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Prijava u sustav";
            ((System.ComponentModel.ISupportInitialize)(this.logotip)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox formaKorisnickoIme;
        private System.Windows.Forms.TextBox formaLozinka;
        private System.Windows.Forms.Label oznakaKorisnickoIme;
        private System.Windows.Forms.Label oznakaLozinka;
        private System.Windows.Forms.PictureBox logotip;
        private System.Windows.Forms.Button gumbPrijava;
        private System.Windows.Forms.Button gumbRegistracija;
    }
}

