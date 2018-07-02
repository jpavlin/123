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
    public partial class DodavanjeOruzja : Form
    {

        Classes.Oruzje oruzje = new Classes.Oruzje();
        public Main pom = new Main();

        public DodavanjeOruzja(Main mainParam)
        {
            InitializeComponent();
            pom = mainParam;
        }

        private void DodavanjeOruzja_Load(object sender, EventArgs e)
        {
            //this.ucitavanjeFotografije.Container;
            this.ocistiTooltip.SetToolTip(this.gumbOcistiSve, "Očistite sve podatke iz formi za unos i krenite ispočetka.");
            this.spremiTooltip.SetToolTip(this.gumbSpremiOruzje, "Spremite unesene podatke za oružje u bazu podataka oružja.");
            this.ucitajTooltip.SetToolTip(this.gumbUcitajFoto, "Učitajte fotografiju komada oružja koje se dodaje u bazu podataka oružja.");
            this.povratakTooltip.SetToolTip(this.gumbPovratak, "Vratite se u početni prozor sustava.");
            this.yearPicker.Format = DateTimePickerFormat.Custom;
            this.yearPicker.CustomFormat = "yyyy";
            this.yearPicker.ShowUpDown = true;
            //this.FormClosing += dodavanjeOruzja_FormClosing;
        }

        private void gumbSpremiOruzje_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(formaDuljina.Text) && !string.IsNullOrWhiteSpace(formaDuljinaCijevi.Text) && !string.IsNullOrWhiteSpace(formaVisina.Text)
                && !string.IsNullOrWhiteSpace(formaSirina.Text) && !string.IsNullOrWhiteSpace(formaSerijskiBroj.Text) && !string.IsNullOrWhiteSpace(formaMasa.Text)
                && !string.IsNullOrWhiteSpace(formaModel.Text) && !string.IsNullOrWhiteSpace(formaProizvodac.Text) && !string.IsNullOrWhiteSpace(formaKalibar.Text)
                && !string.IsNullOrWhiteSpace(comboTipOruzja.Text) && !string.IsNullOrWhiteSpace(formaVrijednost.Text) /*|| !string.IsNullOrWhiteSpace(yearPicker.Text)*/
                && !string.IsNullOrWhiteSpace(datotecniPut.Text))
            {
                if (formaSerijskiBroj.Text.Length == 10)
                {
                    if (jeSastavljenOdBrojeva(formaSerijskiBroj.Text))
                    {
                        if (jeDecimalanBroj(this.formaVrijednost.Text) && jeDecimalanBroj(this.formaVisina.Text) && jeDecimalanBroj(this.formaSirina.Text) && jeDecimalanBroj(this.formaDuljina.Text)
                            && jeDecimalanBroj(this.formaDuljinaCijevi.Text) && jeDecimalanBroj(this.formaMasa.Text))
                        {
                            Classes.Oruzje.kreacijaBazeOruzja();
                            dodavanjeOruzjaUBazu();
                        }
                        else
                        {
                            MessageBox.Show("Neispravan format. Molimo provjerite jesu li dimenzije i novčana vrijednost oružja unesene u obliku prirodnog ili decimalnog broja većeg od nule.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Serijski broj mora biti sastavljen od znamenaka. Molimo unesite serijski broj ispravnog formata.");
                    }
                }
                else
                {
                    MessageBox.Show("Serijski broj oružja mora imati točno deset znamenki. Molimo unesite valjan serijski broj oružja.");
                }
            }
            else
            {
                MessageBox.Show("Molimo provjerite jesu li sve forme popunjene.");
            }
        }

        private void dodavanjeOruzja_FormClosing(object sender, FormClosingEventArgs e)
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

        private void dodavanjeOruzja_FormClosed(object sender, FormClosedEventArgs e) { Application.Exit(); }

        private void dodavanjeOruzjaUBazu()
        {
            Image img = new Bitmap(datotecniPut.Text);
            byte[] byteimage = ImageToByte(img, System.Drawing.Imaging.ImageFormat.Jpeg);
            string izvor = "URI=file:evidencija.db";
            SQLiteConnection conn = new SQLiteConnection(izvor);
            conn.Open();
            SQLiteCommand naredba = conn.CreateCommand();
            naredba.CommandText = "INSERT INTO ORUZJE (SERIJSKI_BROJ, MODEL, PROIZVODAC, TIP, KALIBAR, VRIJEDNOST, MASA, VISINA, SIRINA," +
                "DULJINA, DULJINA_CIJEVI, GODINA_PROIZVODNJE, SLIKA) VALUES ('" + this.formaSerijskiBroj.Text + "', '" + this.formaModel.Text +
                "', '" + this.formaProizvodac.Text + "', '" + this.comboTipOruzja.Text + "', '" + this.formaKalibar.Text + "', '" +
                Convert.ToDecimal(this.formaVrijednost.Text) + "', '" + Convert.ToDecimal(this.formaMasa.Text) + "', '" +
                Convert.ToDecimal(this.formaVisina.Text) + "', '" + Convert.ToDecimal(this.formaSirina.Text) + "', '" +
                Convert.ToDecimal(this.formaDuljina.Text) + "', '" + Convert.ToDecimal(this.formaDuljinaCijevi.Text) + "', '" +
                this.yearPicker.Text + "', @imgdata)";
            SQLiteParameter parametar = new SQLiteParameter("@imgdata", System.Data.DbType.Binary);
            parametar.Value = byteimage;
            naredba.Parameters.Add(parametar);
            naredba.ExecuteNonQuery();
            naredba.Dispose();
            oruzje.asocirajPodatkeIzBaze(this.formaSerijskiBroj.Text);
            if(MessageBox.Show("Uspješno ste dodali " + oruzje.Model + " proizvođača " + oruzje.Proizvodjac + " sa serijskim brojem '" + oruzje.SerijskiBroj + "' u bazu podataka oružja. Povratak na početni prozor?", "Uspjeh!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                FormClosed -= dodavanjeOruzja_FormClosed;
                FormClosing -= dodavanjeOruzja_FormClosing;
                pom.Show();
                this.Close();
            }
        }

        private void gumbUcitajFoto_Click(object sender, EventArgs e)
        {
            this.ucitavanjeFotografije.Filter = "Image Files(*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.png;*.jpg";
            if (this.ucitavanjeFotografije.ShowDialog() == DialogResult.OK) { datotecniPut.Text = this.ucitavanjeFotografije.FileName; }
        }

        private void gumbOcistiSve_Click(object sender, EventArgs e)
        {
            this.formaDuljina.Text = "";
            this.formaDuljinaCijevi.Text = "";
            this.formaKalibar.Text = "";
            this.formaMasa.Text = "";
            this.formaModel.Text = "";
            this.formaProizvodac.Text = "";
            this.formaSerijskiBroj.Text = "";
            this.formaSirina.Text = "";
            this.formaVisina.Text = "";
            this.formaVrijednost.Text = "";
            this.comboTipOruzja.Text = "";
            this.datotecniPut.Text = "";
        }

        private void gumbPovratak_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do sada uneseni nespremljeni podaci bit će izgubljeni. Želite li se doista vratiti u početni prozor?", "Povratak početni prozor?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                FormClosed -= dodavanjeOruzja_FormClosed;
                FormClosing -= dodavanjeOruzja_FormClosing;
                pom.Show();
                this.Close();
            }
        }

        private bool jeDecimalanBroj(string stringParam)
        {
            foreach (char c in stringParam)
            {
                if(!char.IsDigit(c) && c!='.')
                    return false;
            }
            return true;
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


    }
}

