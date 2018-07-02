using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MUP_Gun_Record
{
    public partial class DodavanjeVlasnikaOruzja : Form
    {

        Main main = new Main();
        Classes.Osoba osoba = new Classes.Osoba();
        bool odabran = false;

        public DodavanjeVlasnikaOruzja(Main mainParam)
        {
            InitializeComponent();
            this.main = mainParam;
        }


        private void dodavanjeVlasnikaOruzja_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.ApplicationExitCall)
            {
                if (MessageBox.Show("Želite li doista izaći iz aplikacije?", "Izlazak iz aplikacije", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    e.Cancel = false;
                }
                else { e.Cancel = true; }
            }
        }

        private void dodavanjeVlasnikaOruzja_FormClosed(object sender, FormClosedEventArgs e) { Application.Exit(); }

        private void DodavanjeVlasnikaOruzja_Load(object sender, EventArgs e)
        {
            prikazPodatakaOruzja();
            prikazPodatakaRoda();
            prikazPodatakaSpola();
            this.povratakTooltip.SetToolTip(this.gumbPovratak, "Vratite se u početni prozor sustava.");
            this.ocistiTooltip.SetToolTip(this.gumbOcisti, "Očistite sve podatke iz formi za unos i krenite ispočetka.");
            this.spremiTooltip.SetToolTip(this.gumbSpremiPodatke, "Spremite unesene podatke za vlasnika oružja u bazu podataka vlasnika oružja.");
            this.ucitajTooltip.SetToolTip(this.gumbUcitavanjeFoto, "Učitajte fotografiju vlasnika oružja koji se dodaje u bazu podataka vlasnika oružja.");
        }

        private void gumbPovratak_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do sada uneseni nespremljeni podaci bit će izgubljeni. Želite li se doista vratiti u početni prozor?", "Povratak početni prozor?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                FormClosed -= this.dodavanjeVlasnikaOruzja_FormClosed;
                FormClosing -= this.dodavanjeVlasnikaOruzja_FormClosing;
                this.main.Show();
                this.Close();
            }
        }

        private void prebivalisteCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (!odabran)
            {
                this.formaMjestoBoravista.Text = this.formaMjestoPrebivalista.Text;
                this.formaDrzavaBoravista.Text = this.formaDrzavaPrebivalista.Text;
                this.formaPostanskiBrojBoravista.Text = this.formaPostanskiBrojPrebivalista.Text;
                this.formaAdresaBoravista.Text = this.formaAdresaPrebivalista.Text;
                odabran = true;
            }
            else
            {
                this.formaMjestoBoravista.Text = "";
                this.formaDrzavaBoravista.Text = "";
                this.formaPostanskiBrojBoravista.Text = "";
                this.formaAdresaBoravista.Text = "";
                odabran = false;
            }
        }

        private void gumbUcitavanjeFoto_Click(object sender, EventArgs e)
        {
            this.ucitavanjeFotografije.Filter = "Image Files(*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.png;*.jpg";
            if (this.ucitavanjeFotografije.ShowDialog() == DialogResult.OK) { datotecniPut.Text = this.ucitavanjeFotografije.FileName; }
        }

        public void prikazPodatakaOruzja()
        {
            String izvor = "URI=file:evidencija.db";
            SQLiteConnection conn = new SQLiteConnection(izvor);
            conn.Open();
            SQLiteCommand naredba = conn.CreateCommand();
            naredba.CommandText = "SELECT SERIJSKI_BROJ, PROIZVODAC, MODEL FROM ORUZJE;";
            SQLiteDataReader reader = naredba.ExecuteReader();
            while (reader.Read())
            {
                this.comboPodaciZaOruzje.Items.Add("Broj: " + reader.GetString(0) + " | " + reader.GetString(1) + " | " + reader.GetString(2));
            }
            reader.Close();
            naredba
                .Dispose();
            conn.Close();
        }

        public void prikazPodatakaSpola()
        {
            this.comboSpol.DataSource = Enum.GetValues(typeof(Classes.Spol));
        }

        public void prikazPodatakaRoda()
        {
            this.comboRod.DataSource = Enum.GetValues(typeof(Classes.Rod));
        }

        public string serijskiBroj(string stringParam)
        {
            return stringParam.Substring(6, 10);
        }

        private void comboPodaciZaOruzje_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Serijski broj: " + this.comboPodaciZaOruzje.Text.Substring(6, 10));
        }

        private void gumbSpremiPodatke_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(this.formaIme.Text) && !string.IsNullOrWhiteSpace(formaPrezime.Text) && !string.IsNullOrWhiteSpace(this.formaAdresaBoravista.Text) 
                && !string.IsNullOrWhiteSpace(this.formaAdresaPrebivalista.Text) && !string.IsNullOrWhiteSpace(this.formaDrzavaBoravista.Text) && !string.IsNullOrWhiteSpace(this.formaDrzavaPrebivalista.Text)
                && !string.IsNullOrWhiteSpace(this.formaDrzavaRodenja.Text) && !string.IsNullOrWhiteSpace(this.formaDrzavljanstvo.Text) && !string.IsNullOrWhiteSpace(this.formaJMBG.Text)
                && !string.IsNullOrWhiteSpace(this.formaMjestoBoravista.Text) && !string.IsNullOrWhiteSpace(this.formaMjestoPrebivalista.Text) && !string.IsNullOrWhiteSpace(this.formaMjestoRodenja.Text)
                && !string.IsNullOrWhiteSpace(this.formaOIB.Text) && !string.IsNullOrWhiteSpace(this.formaPostanskiBrojBoravista.Text) && !string.IsNullOrWhiteSpace(this.formaPostanskiBrojPrebivalista.Text)
                && !string.IsNullOrWhiteSpace(this.datotecniPut.Text) && !string.IsNullOrWhiteSpace(this.comboPodaciZaOruzje.Text))
            {
                if (this.formaOIB.Text.Length == 11)
                {
                    if (jeSastavljenOdBrojeva(this.formaOIB.Text))
                    {
                        if (this.formaJMBG.Text.Length == 13)
                        {
                            if (jeSastavljenOdBrojeva(this.formaJMBG.Text))
                            {
                                if (jeSastavljenOdBrojeva(this.formaPostanskiBrojBoravista.Text) && jeSastavljenOdBrojeva(this.formaPostanskiBrojPrebivalista.Text))
                                {
                                    if (this.formaPostanskiBrojBoravista.Text.Length == 5 && this.formaPostanskiBrojPrebivalista.Text.Length == 5)
                                    {
                                        Classes.Osoba.kreacijaBazeVlasnikaOruzja();
                                        dodavanjeVlasnikaOruzjaUBazu();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Poštanski broja mora se sastojati od točno pet znamenaka. Molimo unesite poštanski broj validnog formata.");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Poštanski broj mora biti sastavljen od znamenaka. Molimo unesite poštanski broj boravišta i prebivališta u valjanom formatu.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Jedinstveni matični broj građana mora biti sastavljen od znamenaka. Molimo unesite jedinstveni matični broj građana valjanog formata.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Jedinstveni matični broj građana sastoji se od trinaest znamenaka. Molimo provjerite broj znamenaka za JMBG.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Osobni identifikacijski broj mora biti sastavljen od znamenaka. Molimo unesite osobni identifikacijski broj valjanog formata.");
                    }
                    
                }
                else
                {
                    MessageBox.Show("Osobni identifikacijski broj sastoji se od jedanaest znamenaka. Molimo provjerite broj znamenaka za OIB.");
                }
            }
            else
            {
                MessageBox.Show("Molimo provjerite jesu li sve forme popunjene.");
            }
            
        }

        private void dodavanjeVlasnikaOruzjaUBazu()
        {
            Image img = new Bitmap(datotecniPut.Text);
            byte[] byteimage = ImageToByte(img, System.Drawing.Imaging.ImageFormat.Jpeg);
            string izvor = "URI=file:evidencija.db";
            SQLiteConnection conn = new SQLiteConnection(izvor);
            conn.Open();
            SQLiteCommand naredba = conn.CreateCommand();
            naredba.CommandText = "INSERT INTO VLASNIK_ORUZJA (OIB, JMBG, IME, PREZIME, SPOL, ROD, DRZAVLJANSTVO, MJESTO_RODENJA, " +
                "DRZAVA_RODENJA, DATUM_RODENJA, ADRESA_PREBIVALISTA, MJESTO_PREBIVALISTA, POSTANSKI_BROJ_PREBIVALISTA, DRZAVA_PREBIVALISTA, ADRESA_BORAVISTA," +
                "MJESTO_BORAVISTA, POSTANSKI_BROJ_BORAVISTA, DRZAVA_BORAVISTA, SERIJSKI_BROJ_ORUZJA, DATUM_ZAHTJEVA_DOZVOLE, DATUM_ISTEKA_DOZVOLE," +
                " DATUM_LIJECNICKOG_PREGLEDA, DATUM_ISTEKA_LIJECNICKOG_PREGLEDA, FOTOGRAFIJA) VALUES ('" + this.formaOIB.Text + "', '" +
                this.formaJMBG.Text + "', '" + this.formaIme.Text + "', '" + this.formaPrezime.Text + "', '" + this.comboSpol.Text + "', '" +
                this.comboRod.Text + "', '" + this.formaDrzavljanstvo.Text + "', '" + this.formaMjestoRodenja.Text + "', '" +
                this.formaDrzavaRodenja.Text + "', '" + this.datumRodenjaPicker.Value + "', '" + this.formaAdresaPrebivalista.Text + "', '" +
                this.formaMjestoPrebivalista.Text + "', '" + Convert.ToInt32(this.formaPostanskiBrojPrebivalista.Text) + "', '" +
                this.formaDrzavaPrebivalista.Text + "', '" + this.formaAdresaBoravista.Text + "', '" + this.formaMjestoBoravista.Text + "', '" +
                Convert.ToInt32(this.formaPostanskiBrojBoravista.Text) + "', '" + this.formaDrzavaBoravista.Text + "', '" +
                serijskiBroj(this.comboPodaciZaOruzje.Text) + "', '" + this.datumZahtjevaZaIzdavanjemDozvolePicker.Value + "', '" +
                this.datumIstekaDozvolePicker.Value + "', '" + this.datumLijecnickogPicker.Value + "', '" + this.datumIstekaLijecnickogPicker.Value + "', @imgdata);";
            SQLiteParameter parametar = new SQLiteParameter("@imgdata", System.Data.DbType.Binary);
            parametar.Value = byteimage;
            naredba.Parameters.Add(parametar);
            naredba.ExecuteNonQuery();
            naredba.Dispose();
            osoba.asocirajPodatkeIzBazeVlasnika(this.formaOIB.Text);
            if (MessageBox.Show("Vlasnik oružja "+osoba.Ime+" "+osoba.Prezime+" s komadom oružja '"+ osoba.Oruzje.Proizvodjac +" "+osoba.Oruzje.Model + 
                "' sa serijskim brojem '"+osoba.Oruzje.SerijskiBroj+"' uspješno je dodan u bazu podataka vlasnika oružja. Želite li se vratiti u početni prozor?", 
                "Uspjeh!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                FormClosed -= dodavanjeVlasnikaOruzja_FormClosed;
                FormClosing -= dodavanjeVlasnikaOruzja_FormClosing;
                main.Show();
                this.Close();
            }
        }

        private byte[] ImageToByte(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();
                return imageBytes;
            }
        }

        public Image ByteToImage(byte[] imageBytes)
        {
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = new Bitmap(ms);
            return image;
        }

        private void gumbOcisti_Click(object sender, EventArgs e)
        {
            this.formaAdresaBoravista.Text = "";
            this.formaAdresaPrebivalista.Text = "";
            this.formaDrzavaBoravista.Text = "";
            this.formaDrzavaPrebivalista.Text = "";
            this.formaDrzavaRodenja.Text = "";
            this.formaDrzavljanstvo.Text = "";
            this.formaIme.Text = "";
            this.formaJMBG.Text = "";
            this.formaMjestoBoravista.Text = "";
            this.formaMjestoPrebivalista.Text = "";
            this.formaMjestoRodenja.Text = "";
            this.formaOIB.Text = "";
            this.formaPostanskiBrojBoravista.Text = "";
            this.formaPostanskiBrojPrebivalista.Text = "";
            this.formaPrezime.Text = "";
            this.datotecniPut.Text = "";
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
