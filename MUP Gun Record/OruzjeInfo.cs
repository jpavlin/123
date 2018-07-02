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
    public partial class OruzjeInfo : Form
    {
        Classes.Oruzje oruzje;

        public OruzjeInfo(Classes.Oruzje oruzjeParam)
        {
            this.oruzje = oruzjeParam;
            InitializeComponent();
        }

        private void gumbOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OruzjeInfo_Load(object sender, EventArgs e)
        {
            this.serijskiBroj.Text = this.oruzje.SerijskiBroj;
            this.proizvodac.Text = this.oruzje.Proizvodjac;
            this.model.Text = this.oruzje.Model;
            this.tip.Text = this.oruzje.Tip;
            this.kalibar.Text = this.oruzje.Kalibar;
            this.vrijednost.Text = this.oruzje.VrijednostUHRK.ToString() + " kn";
            this.godinaProizvodnje.Text = this.oruzje.GodinaProizvodnje.ToString() + ".";
            this.masa.Text = this.oruzje.MasaUG.ToString() + " g";
            this.duljina.Text = this.oruzje.DuljinaUCM.ToString() + " cm";
            this.duljinaCijevi.Text = this.oruzje.DuljinaCijeviUCM.ToString() + " cm";
            this.sirina.Text = this.oruzje.SirinaUCM.ToString() + " cm";
            this.visina.Text = this.oruzje.VisinaUCM.ToString() + " cm";
            ucitajFotografijuOruzja(this.oruzje.SerijskiBroj);
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

    }
}
