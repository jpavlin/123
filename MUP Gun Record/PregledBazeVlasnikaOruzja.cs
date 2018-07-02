using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MUP_Gun_Record
{
    public partial class PregledBazeVlasnikaOruzja : Form
    {
        Main main = new Main();
        bool ulaz = true;

        public PregledBazeVlasnikaOruzja(Main mainParam)
        {
            InitializeComponent();
            this.main = mainParam;
        }

        private void gumbPovratak_Click(object sender, EventArgs e)
        {
            FormClosed -= pregledBazeVlasnikaOruzja_FormClosed;
            FormClosing -= pregledBazeVlasnikaOruzja_FormClosing;
            main.Show();
            this.Close();
        }

        private void pregledBazeVlasnikaOruzja_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pregledBazeVlasnikaOruzja_FormClosing(object sender, FormClosingEventArgs e)
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

        private void PregledBazeVlasnikaOruzja_Load(object sender, EventArgs e)
        {
            prikaziSvePodatke();
        }

        private void prikaziSvePodatke()
        {
            double days;
            double daysLijecnicki;
            String izvor = "URI=file:evidencija.db";
            SQLiteConnection conn = new SQLiteConnection(izvor);
            conn.Open();
            SQLiteCommand naredba = conn.CreateCommand();
            naredba.CommandText = "SELECT OIB, JMBG, IME, PREZIME, SERIJSKI_BROJ_ORUZJA, DATUM_ISTEKA_LIJECNICKOG_PREGLEDA, DATUM_ISTEKA_DOZVOLE  FROM VLASNIK_ORUZJA;";
            SQLiteDataReader reader = naredba.ExecuteReader();
            while (reader.Read())
            {
                SQLiteCommand naredbaOruzje = conn.CreateCommand();
                naredbaOruzje.CommandText = "SELECT MODEL, PROIZVODAC, TIP FROM ORUZJE WHERE SERIJSKI_BROJ ='" + reader.GetString(4) + "';";
                SQLiteDataReader readerOruzje = naredbaOruzje.ExecuteReader();
                while (readerOruzje.Read())
                {
                    //this.pregledBazeVlasnikaOruzjaListbox.Items.Add("OIB: " + reader.GetString(0) + "  |  JMBG: " + reader.GetString(1) + "  |  " + reader.GetString(2) + "  " + reader.GetString(3) + "  |  Serijski broj oružja: " + reader.GetString(4) + "  |  Proizvođač: " + readerOruzje.GetString(0) + "  |  Model: " + readerOruzje.GetString(1));
                    string datumIstekaLijecnickog = reader.GetString(5).Substring(0, 11);
                    string datumIstekaDozvole = reader.GetString(6).Substring(0, 11);
                    if (datumIstekaLijecnickog.Substring(datumIstekaLijecnickog.Length-1, 1) != " " || datumIstekaLijecnickog.Substring(datumIstekaLijecnickog.Length - 1, 1) != ".")
                    {
                        datumIstekaLijecnickog = datumIstekaLijecnickog.Substring(0, 10);
                    }
                    if (datumIstekaDozvole.Substring(datumIstekaDozvole.Length - 1, 1) != " " || datumIstekaDozvole.Substring(datumIstekaDozvole.Length - 1, 1) != ".")
                    {
                        datumIstekaDozvole = datumIstekaDozvole.Substring(0, 10);
                    }
                    this.vlasniciGridView.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2) + " " + reader.GetString(3), reader.GetString(4), readerOruzje.GetString(1), readerOruzje.GetString(0), readerOruzje.GetString(2), datumIstekaLijecnickog, datumIstekaDozvole);
                    days = (Convert.ToDateTime(reader.GetString(5)).Date - DateTime.Today).TotalDays;
                    daysLijecnicki = (Convert.ToDateTime(reader.GetString(6)).Date - DateTime.Today).TotalDays;
                    Console.WriteLine("Broj dana do isteka liječničkog: " + daysLijecnicki + ".");
                    Console.WriteLine("Broj dana do isteka dozvole: " + days+".");
                    if((days <= 180&&daysLijecnicki<=180) && ulaz)
                    {
                        MessageBox.Show("U bazi podataka vlasnika oružja nalaze se neki vlasnici kojima dozvola za posjedovanje oružja i liječnički ističe u idućih 180 dana. Polja koja se odnose na takve vlasnike istaknuta su crvenom bojom.", "Upozorenje o isteku dozvole", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ulaz = false;
                    }else if((days<=180&&daysLijecnicki>180) && ulaz)
                    {
                        MessageBox.Show("U bazi podataka vlasnika oružja nalaze se neki vlasnici kojima dozvola za posjedovanje oružja ističe u idućih 180 dana. Polja koja se odnose na takve vlasnike istaknuta su crvenom bojom.", "Upozorenje o isteku dozvole", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ulaz = false;
                    }else if((days>180&&daysLijecnicki<=180) && ulaz)
                    {
                        MessageBox.Show("U bazi podataka vlasnika oružja nalaze se neki vlasnici kojima liječnički ističe u idućih 180 dana. Polja koja se odnose na takve vlasnike istaknuta su crvenom bojom.", "Upozorenje o isteku dozvole", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ulaz = false;
                    }
                }
                readerOruzje.Close();
                naredbaOruzje.Dispose();
            }
            reader.Close();
            naredba.Dispose();
            conn.Close();
            foreach (DataGridViewRow row in this.vlasniciGridView.Rows)
            {
                string datumIstekaDozvole = row.Cells[7].Value.ToString();
                string datumIstekaLijecnickog = row.Cells[8].Value.ToString();
                if ((Convert.ToDateTime(datumIstekaDozvole).Date - DateTime.Today).TotalDays <= 180 || (Convert.ToDateTime(datumIstekaLijecnickog).Date - DateTime.Today).TotalDays <= 180 ){
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }

        private void ocistiTablicu()
        {
            while (this.vlasniciGridView.Rows.Count > 0)
                this.vlasniciGridView.Rows.RemoveAt(0);
        }

        private void vlasniciGridView_DoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ucitajVlasnika(e.RowIndex);
        }

        private void ucitajVlasnika(int rowId)
        {
            Classes.Osoba vlasnik = new Classes.Osoba();
            Console.WriteLine("OIB odabranog vlasnika oružja: "+vlasniciGridView.Rows[rowId].Cells[0].Value.ToString());
            vlasnik.asocirajPodatkeIzBazeVlasnika(vlasniciGridView.Rows[rowId].Cells[0].Value.ToString());
            VlasnikInfo forma = new VlasnikInfo(vlasnik);
            forma.ShowDialog();
        }
    }
}
