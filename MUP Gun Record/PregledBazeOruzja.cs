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
    public partial class PregledBazeOruzja : Form
    {

        Main main = new Main();

        public PregledBazeOruzja(Main mainParam)
        {
            InitializeComponent();
            this.main = mainParam;
        }

        private void gumbPovratak_Click(object sender, EventArgs e)
        {
            FormClosed -= pregledBazeOruzja_FormClosed;
            FormClosing -= pregledBazeOruzja_FormClosing;
            main.Show();
            this.Close();
        }

        private void pregledBazeOruzja_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pregledBazeOruzja_FormClosing(object sender, FormClosingEventArgs e)
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

        private void ocistiTablicu()
        {
            while (this.oruzjeGridView.Rows.Count > 0)
                this.oruzjeGridView.Rows.RemoveAt(0);
        }

        private void gumbOcistiteFilter_Click(object sender, EventArgs e)
        {
            this.comboSortiranje.SelectedIndex = 0;
            this.comboTip.SelectedIndex = 0;
            ocistiTablicu();
            prikaziSvePodatke();
        }

        private void gumbPrimijeniFilter_Click(object sender, EventArgs e)
        {
            ocistiTablicu();
            filtriranje(this.comboTip.SelectedIndex, this.comboSortiranje.SelectedIndex);
        }

        private void prikaziSvePodatke()
        {
            String izvor = "URI=file:evidencija.db";
            SQLiteConnection conn = new SQLiteConnection(izvor);
            conn.Open();
            SQLiteCommand naredba = conn.CreateCommand();
            naredba.CommandText = "SELECT SERIJSKI_BROJ, PROIZVODAC, MODEL, TIP, KALIBAR, VRIJEDNOST, GODINA_PROIZVODNJE FROM ORUZJE;";
            SQLiteDataReader reader = naredba.ExecuteReader();
            while (reader.Read())
            {
                this.oruzjeGridView.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetDouble(5), reader.GetInt32(6));
            }
            reader.Close();
            naredba.Dispose();
            conn.Close();
        }

        private void PregledBazeOruzja_Load(object sender, EventArgs e)
        {
            this.comboTip.SelectedIndex = 0;
            this.comboSortiranje.SelectedIndex = 0;
            prikaziSvePodatke();
        }

        private void oruzjeGridView_DoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ucitajOruzje(e.RowIndex);
        }

        private void ucitajOruzje(int rowId)
        {
            Classes.Oruzje oruzje = new Classes.Oruzje();
            oruzje.asocirajPodatkeIzBaze(oruzjeGridView.Rows[rowId].Cells[0].Value.ToString());
            OruzjeInfo forma = new OruzjeInfo(oruzje);
            forma.ShowDialog();
        }

        private void filtriranje(int tipIndexParam, int sortIndexParam)
        {
            String izvor = "URI=file:evidencija.db";
            SQLiteConnection conn = new SQLiteConnection(izvor);
            conn.Open();
            SQLiteCommand naredba = conn.CreateCommand();
            if (tipIndexParam == 0)
            { 
                if(sortIndexParam == 0)
                {
                    prikaziSvePodatke();
                    naredba.Dispose();
                    conn.Close();
                    return;
                }
                else if (sortIndexParam == 1)
                {
                    naredba.CommandText = "SELECT SERIJSKI_BROJ, PROIZVODAC, MODEL, TIP, KALIBAR, VRIJEDNOST, GODINA_PROIZVODNJE FROM ORUZJE ORDER BY GODINA_PROIZVODNJE ASC;";
                    SQLiteDataReader reader = naredba.ExecuteReader();
                    while (reader.Read())
                    {
                        this.oruzjeGridView.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetDouble(5), reader.GetInt32(6));
                    }
                    reader.Close();
                    naredba.Dispose();
                    conn.Close();
                    return;
                }
                else if (sortIndexParam == 2)
                {
                    naredba.CommandText = "SELECT SERIJSKI_BROJ, PROIZVODAC, MODEL, TIP, KALIBAR, VRIJEDNOST, GODINA_PROIZVODNJE FROM ORUZJE ORDER BY GODINA_PROIZVODNJE DESC;";
                    SQLiteDataReader reader = naredba.ExecuteReader();
                    while (reader.Read())
                    {
                        this.oruzjeGridView.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetDouble(5), reader.GetInt32(6));
                    }
                    reader.Close();
                    naredba.Dispose();
                    conn.Close();
                    return;
                }
                else if (sortIndexParam == 3)
                {
                    naredba.CommandText = "SELECT SERIJSKI_BROJ, PROIZVODAC, MODEL, TIP, KALIBAR, VRIJEDNOST, GODINA_PROIZVODNJE FROM ORUZJE ORDER BY VRIJEDNOST ASC;";
                    SQLiteDataReader reader = naredba.ExecuteReader();
                    while (reader.Read())
                    {
                        this.oruzjeGridView.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetDouble(5), reader.GetInt32(6));
                    }
                    reader.Close();
                    naredba.Dispose();
                    conn.Close();
                    return;
                }
                else
                {
                    naredba.CommandText = "SELECT SERIJSKI_BROJ, PROIZVODAC, MODEL, TIP, KALIBAR, VRIJEDNOST, GODINA_PROIZVODNJE FROM ORUZJE ORDER BY VRIJEDNOST DESC;";
                    SQLiteDataReader reader = naredba.ExecuteReader();
                    while (reader.Read())
                    {
                        this.oruzjeGridView.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetDouble(5), reader.GetInt32(6));
                    }
                    reader.Close();
                    naredba.Dispose();
                    conn.Close();
                    return;
                }
            }
            else
            {
                if (sortIndexParam == 0)
                {
                    naredba.CommandText = "SELECT SERIJSKI_BROJ, PROIZVODAC, MODEL, TIP, KALIBAR, VRIJEDNOST, GODINA_PROIZVODNJE FROM ORUZJE WHERE TIP = '" + this.comboTip.Text + "' ;";
                    SQLiteDataReader reader = naredba.ExecuteReader();
                    while (reader.Read())
                    {
                        this.oruzjeGridView.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetDouble(5), reader.GetInt32(6));
                    }
                    reader.Close();
                    naredba.Dispose();
                    conn.Close();
                    return;
                }
                else if (sortIndexParam == 1)
                {
                    naredba.CommandText = "SELECT SERIJSKI_BROJ, PROIZVODAC, MODEL, TIP, KALIBAR, VRIJEDNOST, GODINA_PROIZVODNJE FROM ORUZJE WHERE TIP = '" + this.comboTip.Text + "' ORDER BY GODINA_PROIZVODNJE ASC;";
                    SQLiteDataReader reader = naredba.ExecuteReader();
                    while (reader.Read())
                    {
                        this.oruzjeGridView.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetDouble(5), reader.GetInt32(6));
                    }
                    reader.Close();
                    naredba.Dispose();
                    conn.Close();
                    return;

                }
                else if (sortIndexParam == 2)
                {
                    naredba.CommandText = "SELECT SERIJSKI_BROJ, PROIZVODAC, MODEL, TIP, KALIBAR, VRIJEDNOST, GODINA_PROIZVODNJE FROM ORUZJE WHERE TIP='" + this.comboTip.Text + "' ORDER BY GODINA_PROIZVODNJE DESC;";
                    SQLiteDataReader reader = naredba.ExecuteReader();
                    while (reader.Read())
                    {
                        this.oruzjeGridView.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetDouble(5), reader.GetInt32(6));
                    }
                    reader.Close();
                    naredba.Dispose();
                    conn.Close();
                    return;
                }
                else if (sortIndexParam == 3)
                {
                    naredba.CommandText = "SELECT SERIJSKI_BROJ, PROIZVODAC, MODEL, TIP, KALIBAR, VRIJEDNOST, GODINA_PROIZVODNJE FROM ORUZJE WHERE TIP='" + this.comboTip.Text + "' ORDER BY VRIJEDNOST ASC;";
                    SQLiteDataReader reader = naredba.ExecuteReader();
                    while (reader.Read())
                    {
                        this.oruzjeGridView.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetDouble(5), reader.GetInt32(6));
                    }
                    reader.Close();
                    naredba.Dispose();
                    conn.Close();
                    return;
                }
                else
                {
                    naredba.CommandText = "SELECT SERIJSKI_BROJ, PROIZVODAC, MODEL, TIP, KALIBAR, VRIJEDNOST, GODINA_PROIZVODNJE FROM ORUZJE WHERE TIP='" + this.comboTip.Text + "' ORDER BY VRIJEDNOST DESC;";
                    SQLiteDataReader reader = naredba.ExecuteReader();
                    while (reader.Read())
                    {
                        this.oruzjeGridView.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetDouble(5), reader.GetInt32(6));
                    }
                    reader.Close();
                    naredba.Dispose();
                    conn.Close();
                    return;
                }
            }
        }
    }
}
