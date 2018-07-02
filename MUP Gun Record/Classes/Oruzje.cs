using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MUP_Gun_Record.Classes
{
    public class Oruzje
    {
        private float dimenDuljinaUCM, dimenSirinaUCM, dimenVisinaUCM, dimenMasaUG, dimenDuljinaCijeviUCM;
        private int godinaProizvodnje;
        private double vrijednostUHRK;
        private string specTip, specKalibar, serijskiBroj, model, proizvodjac;
        

        public float DuljinaUCM { get { return this.dimenDuljinaUCM; } set { this.dimenDuljinaUCM = value; } }
        public float DuljinaCijeviUCM { get { return this.dimenDuljinaCijeviUCM; } set { this.dimenDuljinaCijeviUCM = value; } }
        public float SirinaUCM { get { return this.dimenSirinaUCM; } set { this.dimenSirinaUCM = value; } }
        public float VisinaUCM { get { return this.dimenVisinaUCM; } set { this.dimenVisinaUCM = value; } }
        public float MasaUG { get { return this.dimenMasaUG; } set { this.dimenMasaUG = value; } }
        public int GodinaProizvodnje { get { return this.godinaProizvodnje; } set { this.godinaProizvodnje = value; } }
        public double VrijednostUHRK { get { return this.vrijednostUHRK; } set { this.vrijednostUHRK = value; } }
        public string Tip { get { return this.specTip; } set { this.specTip = value; } }
        public string Kalibar { get { return this.specKalibar; } set { this.specKalibar = value; } }
        public string SerijskiBroj { get { return this.serijskiBroj; } set { this.serijskiBroj = value; } }
        public string Model { get { return this.model; } set { this.model = value; } }
        public string Proizvodjac { get { return this.proizvodjac; } set { this.proizvodjac = value; } }

        public static void kreacijaBazeOruzja()
        {
            string izvor = "URI=file:evidencija.db";
            SQLiteConnection conn = new SQLiteConnection(izvor);
            conn.Open();
            SQLiteCommand naredba = conn.CreateCommand();
            naredba.CommandText = "CREATE TABLE IF NOT EXISTS ORUZJE(SERIJSKI_BROJ VARCHAR(10) PRIMARY KEY, " +
                "MODEL VARCHAR (50) NOT NULL, PROIZVODAC VARCHAR(50) NOT NULL, " +
                "TIP VARCHAR (50) NOT NULL, KALIBAR VARCHAR (20) NOT NULL, VRIJEDNOST REAL NOT NULL, MASA REAL NOT NULL," +
                "VISINA REAL NOT NULL, SIRINA REAL NOT NULL, DULJINA REAL NOT NULL, DULJINA_CIJEVI REAL NOT NULL, GODINA_PROIZVODNJE INTEGER NOT NULL, SLIKA BLOB NOT NULL);";
            naredba.ExecuteNonQuery();
            naredba.Dispose();
            conn.Close();
        }

        public void asocirajPodatkeIzBaze(string serijskiBrojParam)
        {
            String izvor = "URI=file:evidencija.db";
            SQLiteConnection conn = new SQLiteConnection(izvor);
            conn.Open();
            SQLiteCommand naredba = conn.CreateCommand();
            naredba.CommandText = "SELECT * FROM ORUZJE WHERE SERIJSKI_BROJ='" + serijskiBrojParam + "';";
            SQLiteDataReader reader = naredba.ExecuteReader();
            while (reader.Read())
            {
                this.serijskiBroj = reader.GetString(0);
                this.model = reader.GetString(1);
                this.proizvodjac = reader.GetString(2);
                this.specTip = reader.GetString(3);
                this.specKalibar = reader.GetString(4);
                this.vrijednostUHRK = reader.GetDouble(5);
                this.dimenMasaUG = reader.GetFloat(6);
                this.dimenVisinaUCM = reader.GetFloat(7);
                this.dimenSirinaUCM = reader.GetFloat(8);
                this.dimenDuljinaUCM = reader.GetFloat(9);
                this.dimenDuljinaCijeviUCM = reader.GetFloat(10);
                this.godinaProizvodnje = reader.GetInt32(11);
            }
            reader.Close();
            naredba.Dispose();
            conn.Close();
        }

        
    }
}
