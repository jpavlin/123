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
    public partial class VlasnikInfo : Form
    {
        public Classes.Osoba vlasnik = new Classes.Osoba();

        public VlasnikInfo()
        {

        }

        public VlasnikInfo(Classes.Osoba vlasnikParam)
        {
            this.vlasnik = vlasnikParam;
            InitializeComponent();
        }

        private void VlasnikInfo_Load(object sender, EventArgs e)
        {
            ucitajPodatke();
        }

        private void gumbOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ucitajFotografijuVlasnika(string oibParam)
        {
            byte[] byteImage;
            String izvor = "URI=file:evidencija.db";
            SQLiteConnection conn = new SQLiteConnection(izvor);
            conn.Open();
            SQLiteCommand naredba = conn.CreateCommand();
            naredba.CommandText = "SELECT FOTOGRAFIJA FROM VLASNIK_ORUZJA WHERE OIB='" + oibParam + "';";
            SQLiteDataReader reader = naredba.ExecuteReader();
            while (reader.Read())
            {
                byteImage = (System.Byte[])reader[0];
                this.vlasnikPictureBox.Image = ByteToImage(byteImage);
                this.vlasnikPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            reader.Close();
            naredba.Dispose();
            conn.Close();
        }

        public Image ByteToImage(byte[] imageBytes)
        {
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = new Bitmap(ms);
            return image;
        }

        public void ucitajFotografijuOruzja(string serijskiBrojParam)
        {
            byte[] byteImage;
            String izvor = "URI=file:evidencija.db";
            SQLiteConnection conn = new SQLiteConnection(izvor);
            conn.Open();
            SQLiteCommand naredba = conn.CreateCommand();
            naredba.CommandText = "SELECT Slika FROM ORUZJE WHERE SERIJSKI_BROJ='" + serijskiBrojParam + "';";
            SQLiteDataReader reader = naredba.ExecuteReader();
            while (reader.Read())
            {
                byteImage = (System.Byte[])reader[0];
                this.oruzjePicturebox.Image = ByteToImage(byteImage);
                this.oruzjePicturebox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            reader.Close();
            naredba.Dispose();
            conn.Close();
        }

        private void oznakaUredi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AzurirajAdrese forma = new AzurirajAdrese(this.vlasnik.OIB, this);
            forma.ShowDialog();
            ucitajPodatke();
        }

        public void ucitajPodatke()
        {
            string datumZahtjevaDozvole, datumIstekaDozvole, datumLijecnickog, datumIstekaLijecnickog;
            datumZahtjevaDozvole = this.vlasnik.DatumZahtjevaZaIzdavanjeDozvole.ToString().Substring(0, 11);
            datumIstekaDozvole = this.vlasnik.DatumIstekaDozvole.ToString().Substring(0, 11);
            datumLijecnickog = this.vlasnik.DatumLijecnickog.ToString().Substring(0, 11);
            datumIstekaLijecnickog = this.vlasnik.DatumIstekaLijecnickog.ToString().Substring(0, 11);
            if (datumZahtjevaDozvole.Substring(datumZahtjevaDozvole.Length - 1, 1) != " " || datumZahtjevaDozvole.Substring(datumZahtjevaDozvole.Length - 1, 1) != ".")
            {
                datumZahtjevaDozvole = datumZahtjevaDozvole.Substring(0, 10);
            }
            if (datumIstekaDozvole.Substring(datumIstekaDozvole.Length - 1, 1) != " " || datumIstekaDozvole.Substring(datumIstekaDozvole.Length - 1, 1) != ".")
            {
                datumIstekaDozvole = datumIstekaDozvole.Substring(0, 10);
            }
            if (datumLijecnickog.Substring(datumLijecnickog.Length - 1, 1) != " " || datumLijecnickog.Substring(datumLijecnickog.Length - 1, 1) != ".")
            {
                datumLijecnickog = datumLijecnickog.Substring(0, 10);
            }
            if (datumIstekaLijecnickog.Substring(datumIstekaLijecnickog.Length - 1, 1) != " " || datumIstekaLijecnickog.Substring(datumIstekaLijecnickog.Length - 1, 1) != ".")
            {
                datumIstekaLijecnickog = datumIstekaLijecnickog.Substring(0, 10);
            }
            this.imeiprezime.Text = this.vlasnik.Ime + " " + this.vlasnik.Prezime;
            this.oib.Text = this.vlasnik.OIB;
            this.jmbg.Text = this.vlasnik.JMBG;
            this.spol.Text = this.vlasnik.SpolOsobe.ToString();
            this.rod.Text = this.vlasnik.RodOsobe.ToString();
            this.datumLijecnickog.Text = datumLijecnickog;
            this.datumIstekaLijecnickog.Text = datumIstekaLijecnickog;
            this.datumZahtjevaDozvole.Text = datumZahtjevaDozvole;
            this.datumIstekaDozvole.Text = datumIstekaDozvole;
            this.drzavljanstvo.Text = this.vlasnik.Drzavljanstvo.ToString();
            this.drzavaRodenja.Text = this.vlasnik.DrzavaRodenja.ToString();
            this.mjestoRodenja.Text = this.vlasnik.MjestoRodenja.ToString();
            this.adresaBoravista.Text = this.vlasnik.AdresaBoravista.ToString() + ",\n" + this.vlasnik.PostanskiBrojBoravista.ToString() + ", " +
                this.vlasnik.MjestoBoravista.ToString() + ",\n" + this.vlasnik.DrzavaBoravista.ToString();
            this.adresaPrebivalista.Text = this.vlasnik.AdresaPrebivalista.ToString() + ",\n" + this.vlasnik.PostanskiBrojPrebivalista.ToString() + ", " +
                this.vlasnik.MjestoPrebivalista.ToString() + ",\n" + this.vlasnik.DrzavaPrebivalista.ToString();
            this.serijskiBroj.Text = this.vlasnik.Oruzje.SerijskiBroj;
            this.proizvodac.Text = this.vlasnik.Oruzje.Proizvodjac;
            this.model.Text = this.vlasnik.Oruzje.Model;
            this.tip.Text = this.vlasnik.Oruzje.Tip;
            this.kalibar.Text = this.vlasnik.Oruzje.Kalibar;
            this.vrijednost.Text = this.vlasnik.Oruzje.VrijednostUHRK.ToString() + " kn";
            this.godinaProizvodnje.Text = this.vlasnik.Oruzje.GodinaProizvodnje.ToString() + ".";
            this.masa.Text = this.vlasnik.Oruzje.MasaUG.ToString() + " g";
            this.duljina.Text = this.vlasnik.Oruzje.DuljinaUCM.ToString() + " cm";
            this.duljinaCijevi.Text = this.vlasnik.Oruzje.DuljinaCijeviUCM.ToString() + " cm";
            this.sirina.Text = this.vlasnik.Oruzje.SirinaUCM.ToString() + " cm";
            this.visina.Text = this.vlasnik.Oruzje.VisinaUCM.ToString() + " cm";
            ucitajFotografijuVlasnika(this.vlasnik.OIB);
            ucitajFotografijuOruzja(this.vlasnik.Oruzje.SerijskiBroj);
        }
    }
}
