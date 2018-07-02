using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MUP_Gun_Record
{
    public partial class Main : Form
    {
        public Classes.Korisnik korisnik { get; set; }
        private Form1 backToLogin;

        public Main()
        {
            InitializeComponent();
        }

        public Main(Classes.Korisnik korisnikParam, Form1 loginParam)
        {
            this.korisnik = korisnikParam;
            this.backToLogin = loginParam;
            InitializeComponent();
        }

        private void Main_Load(object sender, System.EventArgs e)
        {
            this.FormClosing += Main_FormClosing;
            this.FormClosed += Main_FormClosed;
            this.mainOznakaDobrodosao.Text = "Dobrodošli u sustav, " + this.korisnik.KorisnickoIme + "!";
            if (!this.korisnik.isAdmin())
            {
                this.mainGumbDodavanjeOruzja.BackColor = Color.Red;
                this.mainGumbDodavanjeOruzja.Click -= mainGumbDodavanjeOruzja_Click;
                this.mainGumbDodavanjeOruzja.Click += nonAdminInfo;
                this.mainGumbDodavanjeVlasnikaOruzja.BackColor = Color.Red;
                this.mainGumbDodavanjeVlasnikaOruzja.Click -= mainGumbDodavanjeVlasnikaOruzja_Click;
                this.mainGumbDodavanjeVlasnikaOruzja.Click += nonAdminInfo;
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Želite li doista izaći iz aplikacije?", "Izlazak iz aplikacije", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (e.CloseReason == CloseReason.ApplicationExitCall)
                { }
                e.Cancel = false;
            }
            else { e.Cancel = true; }
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void mainGumbDodavanjeVlasnikaOruzja_Click(object sender, EventArgs e)
        {
            DodavanjeVlasnikaOruzja form = new DodavanjeVlasnikaOruzja(this);
            form.Show();
            this.Hide();
        }

        private void mainGumbDodavanjeOruzja_Click(object sender, EventArgs e)
        {
            DodavanjeOruzja form = new DodavanjeOruzja(this);
            form.Show();
            this.Hide();
        }

        private void nonAdminInfo(object sender, EventArgs e)
        {
            MessageBox.Show("Samo korisnici s administratorskim dozvolama imaju mogućnost dodavanja novih zapisa u bazu podataka.");
        }

        private void mainGumbPregledBaze_Click(object sender, EventArgs e)
        {
            PregledBazeVlasnikaOruzja forma = new PregledBazeVlasnikaOruzja(this);
            forma.Show();
            this.Hide();
        }

        private void mainGumbPregledOružja_Click(object sender, EventArgs e)
        {
            PregledBazeOruzja forma = new PregledBazeOruzja(this);
            forma.Show();
            this.Hide();
        }

        private void oznakaOdjava_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("Želite li se doista odjaviti?", "Odjava?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                FormClosed -= this.Main_FormClosed;
                FormClosing -= this.Main_FormClosing;
                Form1 form = new Form1();
                form = this.backToLogin;
                this.korisnik = null;
                this.Close();
                form.Show();
            }            
        }
    }
}
