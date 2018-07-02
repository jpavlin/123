using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUP_Gun_Record.Classes
{
    public enum Spol
    {
        Muški, Ženski
    }

    public enum Rod
    {
        Muški, Ženski, Drugo
    }

    public class Osoba
    {


        private string ime, prezime, adresaBoravista, mjestoBoravista, postanskiBrojBoravista, drzavaBoravista, adresaPrebivalista, mjestoPrebivalista, postanskiBrojPrebivalista, drzavaPrebivalista, mjestoRodenja, drzavaRodenja, drzavljanstvo, oib, jmbg;
        private Spol spol;
        private Rod rod;
        private DateTime datumRodenja;
        private Oruzje oruzje;
        private DateTime datumIstekaDozvole, datumZahtjevaZaIzdavanjeDozvole, datumIstekaLijecnickog, datumLijecnickog;

        public string Ime{ get{ return this.ime; } set {this.ime = value;} }
        public string Prezime { get { return this.prezime; } set { this.prezime = value; } }
        public string AdresaBoravista { get { return this.adresaBoravista; } set { this.adresaBoravista = value; } }
        public string MjestoBoravista { get { return this.mjestoBoravista; } set { this.mjestoBoravista = value; } }
        public string PostanskiBrojBoravista { get { return this.postanskiBrojBoravista; } set { this.postanskiBrojBoravista = value; } }
        public string DrzavaBoravista { get { return this.drzavaBoravista; } set { this.drzavaBoravista = value; } }
        public string AdresaPrebivalista { get { return this.adresaPrebivalista; } set { this.adresaPrebivalista = value; } }
        public string MjestoPrebivalista { get { return this.mjestoPrebivalista; } set { this.mjestoPrebivalista = value; } }
        public string PostanskiBrojPrebivalista { get { return this.postanskiBrojPrebivalista; } set { this.postanskiBrojPrebivalista = value; } }
        public string DrzavaPrebivalista { get { return this.drzavaPrebivalista; } set { this.drzavaPrebivalista = value; } }
        public string MjestoRodenja { get { return this.mjestoRodenja; } set { this.mjestoRodenja = value; } }
        public string DrzavaRodenja { get { return this.drzavaRodenja; } set { this.drzavaRodenja = value; } }
        public string OIB { get { return this.oib; } set { this.oib = value; } }
        public string JMBG { get { return this.jmbg; } set { this.jmbg = value; } }
        public string Drzavljanstvo { get { return this.drzavljanstvo; } set { this.drzavljanstvo = value; } }
        public Rod RodOsobe { get { return this.rod; } set { this.rod = value; } }
        public Spol SpolOsobe { get { return this.spol; } set { this.spol = value; } }
        public DateTime DatumRodenja { get { return this.datumRodenja; } set { this.datumRodenja = value; } }
        public Oruzje Oruzje { get { return this.oruzje; } set { this.oruzje = value; } }
        public DateTime DatumIstekaDozvole { get { return this.datumIstekaDozvole; } set { this.datumIstekaDozvole = value; } }
        public DateTime DatumZahtjevaZaIzdavanjeDozvole { get { return this.datumZahtjevaZaIzdavanjeDozvole; } set { this.datumZahtjevaZaIzdavanjeDozvole = value; } }
        public DateTime DatumIstekaLijecnickog { get { return this.datumIstekaLijecnickog; } set { this.datumIstekaLijecnickog = value; } }
        public DateTime DatumLijecnickog { get { return this.datumLijecnickog; } set { this.datumLijecnickog = value; } }

        public static void kreacijaBazeVlasnikaOruzja()
        {
            string izvor = "URI=file:evidencija.db";
            SQLiteConnection conn = new SQLiteConnection(izvor);
            conn.Open();
            SQLiteCommand naredba = conn.CreateCommand();
            naredba.CommandText = "CREATE TABLE IF NOT EXISTS VLASNIK_ORUZJA(OIB VARCHAR (11) PRIMARY KEY, JMBG VARCHAR (13) UNIQUE NOT NULL, IME VARCHAR (50) NOT NULL, " +
                "PREZIME VARCHAR(70) NOT NULL, SPOL VARCHAR(10) NOT NULL, ROD VARCHAR (10) NOT NULL, DRZAVLJANSTVO VARCHAR (50) NOT NULL, MJESTO_RODENJA VARCHAR (50) NOT NULL, " +
                "DRZAVA_RODENJA VARCHAR (50) NOT NULL, DATUM_RODENJA DATETIME NOT NULL, ADRESA_PREBIVALISTA VARCHAR (100) NOT NULL, MJESTO_PREBIVALISTA VARCHAR (50) NOT NULL, " +
                "POSTANSKI_BROJ_PREBIVALISTA INTEGER NOT NULL, DRZAVA_PREBIVALISTA VARCHAR (50) NOT NULL, ADRESA_BORAVISTA VARCHAR (100) NOT NULL, MJESTO_BORAVISTA VARCHAR (50) NOT NULL, " +
                "POSTANSKI_BROJ_BORAVISTA INTEGER NOT NULL, DRZAVA_BORAVISTA VARCHAR (50) NOT NULL, SERIJSKI_BROJ_ORUZJA VARCHAR (10) NOT NULL, DATUM_ZAHTJEVA_DOZVOLE DATETIME NOT NULL, " +
                "DATUM_ISTEKA_DOZVOLE DATETIME NOT NULL, DATUM_LIJECNICKOG_PREGLEDA DATETIME NOT NULL, DATUM_ISTEKA_LIJECNICKOG_PREGLEDA DATETIME NOT NULL, FOTOGRAFIJA BLOB NOT NULL, " +
                "FOREIGN KEY(SERIJSKI_BROJ_ORUZJA) REFERENCES ORUZJE(SERIJSKI_BROJ));";
            naredba.ExecuteNonQuery();
            naredba.Dispose();
            conn.Close();
        }

        public void asocirajPodatkeIzBazeVlasnika(string oibParam)
        {
            this.oruzje = new Classes.Oruzje();
            String izvor = "URI=file:evidencija.db";
            SQLiteConnection conn = new SQLiteConnection(izvor);
            conn.Open();
            SQLiteCommand naredba = conn.CreateCommand();
            naredba.CommandText = "SELECT * FROM VLASNIK_ORUZJA WHERE OIB='" + oibParam + "';";
            SQLiteDataReader reader = naredba.ExecuteReader();
            while (reader.Read())
            {
                this.oib = reader.GetString(0);
                this.jmbg = reader.GetString(1);
                this.ime = reader.GetString(2);
                this.prezime = reader.GetString(3);
                this.spol = pronadiSpol(reader.GetString(4));
                this.rod = pronadiRod(reader.GetString(5));
                this.drzavljanstvo = reader.GetString(6);
                this.mjestoRodenja = reader.GetString(7);
                this.drzavaRodenja = reader.GetString(8);
                this.datumRodenja = Convert.ToDateTime(reader.GetString(9));
                this.adresaPrebivalista = reader.GetString(10);
                this.mjestoPrebivalista = reader.GetString(11);
                this.postanskiBrojPrebivalista = Convert.ToString(reader.GetInt32(12));
                this.drzavaPrebivalista = reader.GetString(13);
                this.adresaBoravista = reader.GetString(14);
                this.mjestoBoravista = reader.GetString(15);
                this.postanskiBrojBoravista = Convert.ToString(reader.GetInt32(16));
                this.drzavaBoravista = reader.GetString(17);
                this.oruzje.asocirajPodatkeIzBaze(reader.GetString(18));
                this.datumZahtjevaZaIzdavanjeDozvole = Convert.ToDateTime(reader.GetString(19));
                this.datumIstekaDozvole = Convert.ToDateTime(reader.GetString(20));
                this.datumLijecnickog = Convert.ToDateTime(reader.GetString(21));
                this.datumIstekaLijecnickog = Convert.ToDateTime(reader.GetString(22));
            }
            reader.Close();
            naredba.Dispose();
            conn.Close();
        }

        private Spol pronadiSpol(string stringParam)
        {
            if (stringParam == "Muški")
            {
                return Spol.Muški;
            }
            else
                return Spol.Ženski;
        }

        private Rod pronadiRod(string stringParam)
        {
            if (stringParam == "Muški")
                return Rod.Muški;
            else if (stringParam == "Ženski")
                return Rod.Ženski;
            else
                return Rod.Drugo;
        }
    }    
}

