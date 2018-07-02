namespace MUP_Gun_Record
{
    partial class Registracija
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Registracija));
            this.regFormaKorisnickoIme = new System.Windows.Forms.TextBox();
            this.regOznakaKorisnickoIme = new System.Windows.Forms.Label();
            this.regOznakaLozinka = new System.Windows.Forms.Label();
            this.regFormaLozinka = new System.Windows.Forms.TextBox();
            this.regOznakaEmail = new System.Windows.Forms.Label();
            this.regFormaEmail = new System.Windows.Forms.TextBox();
            this.regAdminCheckbox = new System.Windows.Forms.CheckBox();
            this.regGumb = new System.Windows.Forms.Button();
            this.regLogotip = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.regLogotip)).BeginInit();
            this.SuspendLayout();
            // 
            // regFormaKorisnickoIme
            // 
            this.regFormaKorisnickoIme.Location = new System.Drawing.Point(70, 100);
            this.regFormaKorisnickoIme.Name = "regFormaKorisnickoIme";
            this.regFormaKorisnickoIme.Size = new System.Drawing.Size(171, 20);
            this.regFormaKorisnickoIme.TabIndex = 1;
            // 
            // regOznakaKorisnickoIme
            // 
            this.regOznakaKorisnickoIme.AutoSize = true;
            this.regOznakaKorisnickoIme.Location = new System.Drawing.Point(67, 81);
            this.regOznakaKorisnickoIme.Name = "regOznakaKorisnickoIme";
            this.regOznakaKorisnickoIme.Size = new System.Drawing.Size(116, 13);
            this.regOznakaKorisnickoIme.TabIndex = 6;
            this.regOznakaKorisnickoIme.Text = "Unesite korisničko ime:";
            // 
            // regOznakaLozinka
            // 
            this.regOznakaLozinka.AutoSize = true;
            this.regOznakaLozinka.Location = new System.Drawing.Point(67, 123);
            this.regOznakaLozinka.Name = "regOznakaLozinka";
            this.regOznakaLozinka.Size = new System.Drawing.Size(82, 13);
            this.regOznakaLozinka.TabIndex = 7;
            this.regOznakaLozinka.Text = "Unesite lozinku:";
            // 
            // regFormaLozinka
            // 
            this.regFormaLozinka.Location = new System.Drawing.Point(70, 139);
            this.regFormaLozinka.Name = "regFormaLozinka";
            this.regFormaLozinka.Size = new System.Drawing.Size(171, 20);
            this.regFormaLozinka.TabIndex = 2;
            this.regFormaLozinka.UseSystemPasswordChar = true;
            // 
            // regOznakaEmail
            // 
            this.regOznakaEmail.AutoSize = true;
            this.regOznakaEmail.Location = new System.Drawing.Point(67, 42);
            this.regOznakaEmail.Name = "regOznakaEmail";
            this.regOznakaEmail.Size = new System.Drawing.Size(171, 13);
            this.regOznakaEmail.TabIndex = 5;
            this.regOznakaEmail.Text = "Unesite adresu elektroničke pošte:";
            // 
            // regFormaEmail
            // 
            this.regFormaEmail.Location = new System.Drawing.Point(70, 58);
            this.regFormaEmail.Name = "regFormaEmail";
            this.regFormaEmail.Size = new System.Drawing.Size(171, 20);
            this.regFormaEmail.TabIndex = 0;
            // 
            // regAdminCheckbox
            // 
            this.regAdminCheckbox.AutoSize = true;
            this.regAdminCheckbox.Location = new System.Drawing.Point(70, 165);
            this.regAdminCheckbox.Name = "regAdminCheckbox";
            this.regAdminCheckbox.Size = new System.Drawing.Size(169, 17);
            this.regAdminCheckbox.TabIndex = 3;
            this.regAdminCheckbox.Text = "Dodati administratorske ovlasti";
            this.regAdminCheckbox.UseVisualStyleBackColor = true;
            // 
            // regGumb
            // 
            this.regGumb.Location = new System.Drawing.Point(119, 188);
            this.regGumb.Name = "regGumb";
            this.regGumb.Size = new System.Drawing.Size(75, 23);
            this.regGumb.TabIndex = 4;
            this.regGumb.Text = "Registracija";
            this.regGumb.UseVisualStyleBackColor = true;
            this.regGumb.Click += new System.EventHandler(this.regGumb_Click);
            // 
            // regLogotip
            // 
            this.regLogotip.Image = ((System.Drawing.Image)(resources.GetObject("regLogotip.Image")));
            this.regLogotip.Location = new System.Drawing.Point(309, 12);
            this.regLogotip.Name = "regLogotip";
            this.regLogotip.Size = new System.Drawing.Size(256, 230);
            this.regLogotip.TabIndex = 9;
            this.regLogotip.TabStop = false;
            // 
            // Registracija
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 258);
            this.Controls.Add(this.regLogotip);
            this.Controls.Add(this.regGumb);
            this.Controls.Add(this.regAdminCheckbox);
            this.Controls.Add(this.regFormaEmail);
            this.Controls.Add(this.regOznakaEmail);
            this.Controls.Add(this.regFormaLozinka);
            this.Controls.Add(this.regOznakaLozinka);
            this.Controls.Add(this.regOznakaKorisnickoIme);
            this.Controls.Add(this.regFormaKorisnickoIme);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Registracija";
            this.Text = "Registracija korisnika";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Registracija_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Registracija_FormClosed);
            this.Load += new System.EventHandler(this.Registracija_Load);
            ((System.ComponentModel.ISupportInitialize)(this.regLogotip)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox regFormaKorisnickoIme;
        private System.Windows.Forms.Label regOznakaKorisnickoIme;
        private System.Windows.Forms.Label regOznakaLozinka;
        private System.Windows.Forms.TextBox regFormaLozinka;
        private System.Windows.Forms.Label regOznakaEmail;
        private System.Windows.Forms.TextBox regFormaEmail;
        private System.Windows.Forms.CheckBox regAdminCheckbox;
        private System.Windows.Forms.Button regGumb;
        private System.Windows.Forms.PictureBox regLogotip;
    }
}