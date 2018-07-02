using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUP_Gun_Record.Classes
{
    public class Korisnik
    {
        private string korisnickoIme, email, lozinka;
        private bool admin = false;

        public bool isAdmin()
        {
            if (this.admin == true) return true;
            else return false;
        }

        public void setAdmin()
        {
            this.admin = true;
        }

        public void removeAdmin()
        {
            this.admin = false;
        }

        public string KorisnickoIme { get { return this.korisnickoIme; } set { this.korisnickoIme = value; } }
        public string Email { get { return this.email; } set { this.email = value; } }
        public string Lozinka { get { return this.lozinka; } set { this.lozinka = value; } }

        public Korisnik()
        {

        }

        public Korisnik(string usernameParam, string passwordParam, string emailParam)
        {
            this.korisnickoIme = usernameParam;
            this.lozinka = passwordParam;
            this.email = emailParam;
        }

        public static void kreacijaBazePodataka()
        {
            string izvor = "URI=file:evidencija.db";
            SQLiteConnection conn = new SQLiteConnection(izvor);
            conn.Open();
            SQLiteCommand naredba = conn.CreateCommand();
            naredba.CommandText = "CREATE TABLE IF NOT EXISTS KORISNIK(ID INTEGER PRIMARY KEY AUTOINCREMENT, " +
                "KORISNICKO_IME VARCHAR (50) UNIQUE NOT NULL, EMAIL VARCHAR(50) UNIQUE NOT NULL, " +
                "LOZINKA VARCHAR (100) NOT NULL, ADMIN INTEGER NOT NULL);";
            naredba.ExecuteNonQuery();
            naredba.Dispose();
            conn.Close();
        }

        public void dodavanjeKorisnikaUBazuPodataka()
        {
            int pom;
            if (this.admin) pom = 1;
            else pom = 0;
            string izvor = "URI=file:evidencija.db";
            SQLiteConnection conn = new SQLiteConnection(izvor);
            conn.Open();
            SQLiteCommand naredba = conn.CreateCommand();
            naredba.CommandText = "INSERT INTO KORISNIK (KORISNICKO_IME, EMAIL, LOZINKA, ADMIN) VALUES ('"+this.korisnickoIme+"', '"+this.email+"', '"+this.lozinka+"', '"+pom+"');";
            naredba.ExecuteNonQuery();
            naredba.Dispose();
            conn.Close();
        }

        public static bool korisnickoImePostoji(string usernameParam)
        {
            bool pom = false;
            string izvor = "URI=file:evidencija.db";
            SQLiteConnection conn = new SQLiteConnection(izvor);
            conn.Open();
            SQLiteCommand naredba = conn.CreateCommand();
            naredba.CommandText = "SELECT COUNT(*) FROM KORISNIK WHERE KORISNICKO_IME = '" + usernameParam + "'";
            int broj = Convert.ToInt32(naredba.ExecuteScalar());
            Console.WriteLine("Broj postojećih redova u tablici: "+broj+".");
            if (broj != 0)
                pom = true;               
            naredba.Dispose();
            conn.Close();
            return pom;
        }

        public static bool emailPostoji(string emailParam)
        {
            bool pom = false;
            string izvor = "URI=file:evidencija.db";
            SQLiteConnection conn = new SQLiteConnection(izvor);
            conn.Open();
            SQLiteCommand naredba = conn.CreateCommand();
            naredba.CommandText = "SELECT COUNT(*) FROM KORISNIK WHERE EMAIL = '" + emailParam + "'";
            int broj = Convert.ToInt32(naredba.ExecuteScalar());
            Console.WriteLine("Broj postojećih redova u tablici: " + broj + ".");
            if (broj != 0)
                pom = true;
            naredba.Dispose();
            conn.Close();
            return pom;
        }

        public static string ucitajLozinku(string stringParam)
        {
            string lozinka = "";
            string izvor = "URI=file:evidencija.db";
            SQLiteConnection conn = new SQLiteConnection(izvor);
            conn.Open();
            SQLiteCommand naredba = conn.CreateCommand();
            naredba.CommandText = "SELECT * FROM KORISNIK WHERE KORISNICKO_IME = '" + stringParam + "';";
            SQLiteDataReader reader = naredba.ExecuteReader();
            while (reader.Read()) lozinka = Convert.ToString(reader.GetValue(3));
            naredba.Dispose();
            reader.Close();
            conn.Close();
            return lozinka;
        }

        public void ucitajKorisnika(string usernameParam)
        {
            string izvor = "URI=file:evidencija.db";
            SQLiteConnection conn = new SQLiteConnection(izvor);
            conn.Open();
            SQLiteCommand naredba = conn.CreateCommand();
            naredba.CommandText = "SELECT * FROM KORISNIK WHERE KORISNICKO_IME = '" + usernameParam + "';";
            SQLiteDataReader reader = naredba.ExecuteReader();
            while (reader.Read())
            {
                this.korisnickoIme = reader.GetString(1);
                this.email = reader.GetString(2);
                this.lozinka = reader.GetString(3);
                this.admin = Convert.ToBoolean(reader.GetValue(4));
            }
            naredba.Dispose();
            conn.Close();

        }
    }
}
