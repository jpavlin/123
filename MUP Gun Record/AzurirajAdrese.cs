using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MUP_Gun_Record
{
    public partial class AzurirajAdrese : Form
    {
        private string oib;
        private bool provjera = false;
        VlasnikInfo pomocnaForma = new VlasnikInfo();

        public AzurirajAdrese(string oibParam, VlasnikInfo formaParam)
        {
            this.pomocnaForma = formaParam;
            this.oib = oibParam;
            InitializeComponent();
        }


        private void gumbAzuriraj_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(this.formaAdresaPrebivalista.Text)&&!string.IsNullOrWhiteSpace(this.formaDrzavaPrebivalista.Text) && !string.IsNullOrWhiteSpace(this.formaMjestoPrebivalista.Text)&&!string.IsNullOrWhiteSpace(this.formaPostanskiBrojPrebivalista.Text)&&
                    !string.IsNullOrWhiteSpace(this.formaAdresaBoravista.Text) && !string.IsNullOrWhiteSpace(this.formaDrzavaBoravista.Text) && !string.IsNullOrWhiteSpace(this.formaMjestoBoravista.Text) && !string.IsNullOrWhiteSpace(this.formaPostanskiBrojBoravista.Text))
            {
                if(this.formaPostanskiBrojBoravista.Text.Length == 5 && this.formaPostanskiBrojPrebivalista.Text.Length == 5)
                {
                    if(jeSastavljenOdBrojeva(this.formaPostanskiBrojPrebivalista.Text) && jeSastavljenOdBrojeva(this.formaPostanskiBrojBoravista.Text))
                    {
                        string izvor = "URI=file:evidencija.db";
                        SQLiteConnection conn = new SQLiteConnection(izvor);
                        conn.Open();
                        SQLiteCommand naredba = conn.CreateCommand();
                        naredba.CommandText = "UPDATE VLASNIK_ORUZJA SET ADRESA_PREBIVALISTA = '" + this.formaAdresaPrebivalista.Text + "', MJESTO_PREBIVALISTA = '" + this.formaMjestoPrebivalista.Text + "', POSTANSKI_BROJ_PREBIVALISTA = '" + this.formaPostanskiBrojPrebivalista.Text + "', DRZAVA_PREBIVALISTA = '" + this.formaDrzavaPrebivalista.Text +
                            "', ADRESA_BORAVISTA = '" + this.formaAdresaBoravista.Text + "', MJESTO_BORAVISTA = '" + this.formaMjestoBoravista.Text + "', POSTANSKI_BROJ_BORAVISTA = '" + this.formaPostanskiBrojBoravista.Text + "', DRZAVA_BORAVISTA = '" + this.formaDrzavaBoravista.Text + "' WHERE OIB = '" + this.oib + "';";
                        MessageBox.Show("Uspješno ste ažurirali adrese boravišta i prebivališta vlasnika oružja!");
                        naredba.ExecuteNonQuery();
                        naredba.Dispose();
                        conn.Close();
                        this.pomocnaForma.vlasnik.asocirajPodatkeIzBazeVlasnika(this.oib);
                        this.pomocnaForma.ucitajPodatke();
                        this.Close();
                        
                    }
                    else
                    {
                        MessageBox.Show("Poštanski broj mora biti sastavljen od znamenaka. Molimo da unesete poštanski broj ispravne forme.");
                    }
                }
                else
                {
                    MessageBox.Show("Poštanski broj treba biti sastavljen od pet znamenki. Molimo da unesete poštanski broj validne forme.");
                }
            }
            else
            {
                MessageBox.Show("Molimo provjerite jeste li unijeli sve podatke.");
            }
        }

        private void gumbPovratak_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Jeste li sigurni da se želite vratiti? Svi nespremljeni podaci bit će izgubljeni.", "Povratak?", MessageBoxButtons.YesNo)== DialogResult.Yes)
                this.Close();
        }

        private void checkboxJednak_CheckedChanged(object sender, EventArgs e)
        {
            if (!provjera)
            {
                this.formaAdresaBoravista.Text = this.formaAdresaPrebivalista.Text;
                this.formaMjestoBoravista.Text = this.formaMjestoPrebivalista.Text;
                this.formaPostanskiBrojBoravista.Text = this.formaPostanskiBrojPrebivalista.Text;
                this.formaDrzavaBoravista.Text = this.formaDrzavaPrebivalista.Text;
                provjera = true;
            }
            else
            {
                this.formaAdresaBoravista.Text = "";
                this.formaMjestoBoravista.Text = "";
                this.formaPostanskiBrojBoravista.Text = "";
                this.formaDrzavaBoravista.Text = "";
                provjera = false;
            }
        }

        private bool jeSastavljenOdBrojeva(string stringParam)
        {
            foreach (char c in stringParam)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }
    }
}
