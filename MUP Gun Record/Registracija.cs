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
    public partial class Registracija : Form
    {

        private Form1 pomocna = new Form1();

        public Registracija(Form1 formaParam)
        {
            InitializeComponent();
            this.pomocna = formaParam;
        }

        private void regGumb_Click(object sender, EventArgs e)
        {
            if (regFormaEmail.Text == "" || regFormaKorisnickoIme.Text == "" || regFormaLozinka.Text == "")
            {
                MessageBox.Show("Molimo pobrinite se da je svaki od podataka ispunjen.");
            }
            else
            {
                if (valjanEmail(regFormaEmail.Text))
                {
                    if (Classes.Korisnik.emailPostoji(regFormaEmail.Text) || Classes.Korisnik.korisnickoImePostoji(regFormaKorisnickoIme.Text))
                    {
                        MessageBox.Show("Korisnik s unesenim korisničkim imenom ili adresom elektroničke pošte već postoji. Probajte koristiti druge podatke.");
                    }
                    else
                    {
                        Classes.Korisnik korisnik = new Classes.Korisnik(regFormaKorisnickoIme.Text, regFormaLozinka.Text, regFormaEmail.Text);
                        if (regAdminCheckbox.Checked) korisnik.setAdmin();
                        korisnik.dodavanjeKorisnikaUBazuPodataka();
                        MessageBox.Show("Uspješno ste dodali korisnika u bazu. Prijavite se u sustav.");
                        FormClosed -= this.Registracija_FormClosed;
                        FormClosing -= this.Registracija_FormClosing;
                        this.pomocna.Show();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Forma adrese elektroničke pošte nije ispravna. Unesite valjanu adresu elektroničke pošte.");
                }
            }
        }



        private void Registracija_FormClosing(object sender, FormClosingEventArgs e)
        {            
            if (MessageBox.Show("Želite li doista izaći iz aplikacije?", "Izlazak iz aplikacije", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
            if (e.CloseReason == CloseReason.ApplicationExitCall)
            { }
            e.Cancel = false;
            }
        }

        private void Registracija_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Registracija_Load(object sender, EventArgs e)
        {
            
        }

        private bool valjanEmail(string emailParam)
        {
            try
            {
                var mail = new System.Net.Mail.MailAddress(emailParam);
                return true;
            }
            catch { return false; }
        }
    }
}
