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
    public partial class Form1 : Form
    {
        public Form1()
        {
            Classes.Korisnik.kreacijaBazePodataka();
            Classes.Oruzje.kreacijaBazeOruzja();
            Classes.Osoba.kreacijaBazeVlasnikaOruzja();
            InitializeComponent();
        }

        private void gumbRegistracija_Click(object sender, EventArgs e)
        {
            Registracija reg = new Registracija(this);
            this.Hide();
            reg.Show();
        }

        private void gumbPrijava_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(formaKorisnickoIme.Text))
            {
                if (Classes.Korisnik.korisnickoImePostoji(formaKorisnickoIme.Text))
                {
                    if (formaLozinka.Text == Classes.Korisnik.ucitajLozinku(formaKorisnickoIme.Text))
                    {
                        Classes.Korisnik korisnik = new Classes.Korisnik();
                        korisnik.ucitajKorisnika(formaKorisnickoIme.Text);
                        Console.WriteLine(formaKorisnickoIme);
                        Main main = new Main(korisnik, this);
                        this.formaKorisnickoIme.Text = "";
                        this.formaLozinka.Text = "";
                        main.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Korisničko ime i lozinka ne podudaraju se. Probajte drugu kombinaciju.");
                    }
                }
                else
                {
                    MessageBox.Show("Ne postoji korisnik s takvim korisničkim imenom. Registrirajte novi korisnički račun.");
                }
            }
            else
            {
                MessageBox.Show("Forma za unos korisničkog imena je prazna. Unesite korisničko ime s kojim s želite prijaviti u sustav.");
            }
        }
    }
}
