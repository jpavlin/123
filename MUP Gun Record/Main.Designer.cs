using System.Drawing;

namespace MUP_Gun_Record
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.mainOznakaDobrodosao = new System.Windows.Forms.Label();
            this.mainGumbPregledBaze = new System.Windows.Forms.Button();
            this.mainGumbPregledOružja = new System.Windows.Forms.Button();
            this.mainGumbDodavanjeVlasnikaOruzja = new System.Windows.Forms.Button();
            this.mainGumbDodavanjeOruzja = new System.Windows.Forms.Button();
            this.vlasniciOruzjaGroupbox = new System.Windows.Forms.GroupBox();
            this.oruzjeGroupbox = new System.Windows.Forms.GroupBox();
            this.oznakaOdjava = new System.Windows.Forms.LinkLabel();
            this.vlasniciOruzjaGroupbox.SuspendLayout();
            this.oruzjeGroupbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainOznakaDobrodosao
            // 
            this.mainOznakaDobrodosao.AutoSize = true;
            this.mainOznakaDobrodosao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainOznakaDobrodosao.Location = new System.Drawing.Point(12, 9);
            this.mainOznakaDobrodosao.Name = "mainOznakaDobrodosao";
            this.mainOznakaDobrodosao.Size = new System.Drawing.Size(120, 15);
            this.mainOznakaDobrodosao.TabIndex = 0;
            this.mainOznakaDobrodosao.Text = "Dobrodošli u sustav, ";
            // 
            // mainGumbPregledBaze
            // 
            this.mainGumbPregledBaze.Location = new System.Drawing.Point(6, 19);
            this.mainGumbPregledBaze.Name = "mainGumbPregledBaze";
            this.mainGumbPregledBaze.Size = new System.Drawing.Size(220, 38);
            this.mainGumbPregledBaze.TabIndex = 1;
            this.mainGumbPregledBaze.Text = "Pregled baze podataka vlasnika oružja";
            this.mainGumbPregledBaze.UseVisualStyleBackColor = true;
            this.mainGumbPregledBaze.Click += new System.EventHandler(this.mainGumbPregledBaze_Click);
            // 
            // mainGumbPregledOružja
            // 
            this.mainGumbPregledOružja.Location = new System.Drawing.Point(6, 19);
            this.mainGumbPregledOružja.Name = "mainGumbPregledOružja";
            this.mainGumbPregledOružja.Size = new System.Drawing.Size(220, 38);
            this.mainGumbPregledOružja.TabIndex = 2;
            this.mainGumbPregledOružja.Text = "Pregled baze podataka oružja";
            this.mainGumbPregledOružja.UseVisualStyleBackColor = true;
            this.mainGumbPregledOružja.Click += new System.EventHandler(this.mainGumbPregledOružja_Click);
            // 
            // mainGumbDodavanjeVlasnikaOruzja
            // 
            this.mainGumbDodavanjeVlasnikaOruzja.Location = new System.Drawing.Point(6, 63);
            this.mainGumbDodavanjeVlasnikaOruzja.Name = "mainGumbDodavanjeVlasnikaOruzja";
            this.mainGumbDodavanjeVlasnikaOruzja.Size = new System.Drawing.Size(220, 38);
            this.mainGumbDodavanjeVlasnikaOruzja.TabIndex = 3;
            this.mainGumbDodavanjeVlasnikaOruzja.Text = "Dodajte vlasnika oružja";
            this.mainGumbDodavanjeVlasnikaOruzja.UseVisualStyleBackColor = true;
            this.mainGumbDodavanjeVlasnikaOruzja.Click += new System.EventHandler(this.mainGumbDodavanjeVlasnikaOruzja_Click);
            // 
            // mainGumbDodavanjeOruzja
            // 
            this.mainGumbDodavanjeOruzja.Location = new System.Drawing.Point(6, 63);
            this.mainGumbDodavanjeOruzja.Name = "mainGumbDodavanjeOruzja";
            this.mainGumbDodavanjeOruzja.Size = new System.Drawing.Size(220, 38);
            this.mainGumbDodavanjeOruzja.TabIndex = 4;
            this.mainGumbDodavanjeOruzja.Text = "Dodajte oružje ";
            this.mainGumbDodavanjeOruzja.UseVisualStyleBackColor = true;
            this.mainGumbDodavanjeOruzja.Click += new System.EventHandler(this.mainGumbDodavanjeOruzja_Click);
            // 
            // vlasniciOruzjaGroupbox
            // 
            this.vlasniciOruzjaGroupbox.Controls.Add(this.mainGumbPregledBaze);
            this.vlasniciOruzjaGroupbox.Controls.Add(this.mainGumbDodavanjeVlasnikaOruzja);
            this.vlasniciOruzjaGroupbox.Location = new System.Drawing.Point(15, 44);
            this.vlasniciOruzjaGroupbox.Name = "vlasniciOruzjaGroupbox";
            this.vlasniciOruzjaGroupbox.Size = new System.Drawing.Size(232, 111);
            this.vlasniciOruzjaGroupbox.TabIndex = 5;
            this.vlasniciOruzjaGroupbox.TabStop = false;
            this.vlasniciOruzjaGroupbox.Text = "Vlasnici oružja:";
            // 
            // oruzjeGroupbox
            // 
            this.oruzjeGroupbox.Controls.Add(this.mainGumbDodavanjeOruzja);
            this.oruzjeGroupbox.Controls.Add(this.mainGumbPregledOružja);
            this.oruzjeGroupbox.Location = new System.Drawing.Point(253, 44);
            this.oruzjeGroupbox.Name = "oruzjeGroupbox";
            this.oruzjeGroupbox.Size = new System.Drawing.Size(232, 111);
            this.oruzjeGroupbox.TabIndex = 6;
            this.oruzjeGroupbox.TabStop = false;
            this.oruzjeGroupbox.Text = "Oružje:";
            // 
            // oznakaOdjava
            // 
            this.oznakaOdjava.AutoSize = true;
            this.oznakaOdjava.Location = new System.Drawing.Point(400, 9);
            this.oznakaOdjava.Name = "oznakaOdjava";
            this.oznakaOdjava.Size = new System.Drawing.Size(86, 13);
            this.oznakaOdjava.TabIndex = 7;
            this.oznakaOdjava.TabStop = true;
            this.oznakaOdjava.Text = "Odjava korisnika";
            this.oznakaOdjava.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.oznakaOdjava_LinkClicked);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 171);
            this.Controls.Add(this.oznakaOdjava);
            this.Controls.Add(this.oruzjeGroupbox);
            this.Controls.Add(this.vlasniciOruzjaGroupbox);
            this.Controls.Add(this.mainOznakaDobrodosao);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "MUP Evidencija Naoružanja";
            this.Load += new System.EventHandler(this.Main_Load);
            this.vlasniciOruzjaGroupbox.ResumeLayout(false);
            this.oruzjeGroupbox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label mainOznakaDobrodosao;
        private System.Windows.Forms.Button mainGumbPregledBaze;
        private System.Windows.Forms.Button mainGumbPregledOružja;
        private System.Windows.Forms.Button mainGumbDodavanjeVlasnikaOruzja;
        private System.Windows.Forms.Button mainGumbDodavanjeOruzja;
        private System.Windows.Forms.GroupBox vlasniciOruzjaGroupbox;
        private System.Windows.Forms.GroupBox oruzjeGroupbox;
        private System.Windows.Forms.LinkLabel oznakaOdjava;
    }
}