using ProjekatBioskop.Forme;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace ProjekatBioskop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string ucitanaTabela;


        public static bool azuriraj;


        public static DataRowView pomocniRed;


        public static string Login1 = @"select * from tblZaposleni";


        #region Select sa uslovom
        string selectUslovFilm = @"select * from tblFilm where FilmID=";
        string selectUslovKupac = @"select * from tblKupac where KupacID=";
        string selectUslovLokacija = @"select * from tblLokacija where LokacijaID=";
        string selectUslovRezervacija = @"select * from tblRezervacija where RezervacijaID=";
        string selectUslovTipKarte = @"select * from tblTipKarte where TipKarteID=";
        string selectUslovZanrFilma = @"select * from tblZanrFilma where ZanrFilmaID=";
        string selectUslovZaposleni = @"select * from tblZaposleni where ZaposleniID=";
        
        #endregion

        #region Select upiti
        static string kupciSelect = @"select KupacID as ID, ImeKupca + ' ' + PrezKupca as 'Ime i prezime', Kontakt, Godine from tblKupac";
        static string zaposleniSelect = @"select ZaposleniID as ID, ImeZap + ' ' + PrezZap as 'Ime i prezime', KontaktZap as Kontakt, KorisnickoIme as 'Korisnicko ime' from tblZaposleni";
        static string filmoviSelect = @"Select FilmID as ID, NazivFilma as 'Naziv filma', OpisFilma as 'Opis', Grad + ', ' + Adresa as 'Lokacija', Trajanje, Jezik, convert(Varchar(10),Datum,111) as 'Datum prikazivanja',  Zanr
                        from tblFilm join tblLokacija on tblFilm.LokacijaID=tblLokacija.LokacijaID
			                         join tblZanrFilma on tblFilm.ZanrFilmaID=tblZanrFilma.ZanrFilmaID";
        static string rezervacijeSelect = @"Select RezervacijaID as ID, ImeKupca + ' ' + PrezKupca as 'Ime i prezime', NazivFilma as 'Film', Vreme as 'Vreme', Mesto, CenaKarte as 'Cena', NazivTipaKarte as 'Vrsta karte', ImeZap as 'Zaposleni'
                    from tblRezervacija 
                    join tblKupac on tblRezervacija.KupacID = tblKupac.KupacID
					join tblFilm on tblRezervacija.FilmID = tblFilm.FilmID
                    join tblZaposleni on tblRezervacija.ZaposleniID = tblZaposleni.ZaposleniID
                    join tblTipKarte on tblRezervacija.TipKarteID = tblTipKarte.TipKarteID";
        static string lokacijeSelect = @"select LokacijaID as ID, Adresa + ', ' + Grad as 'Adresa' from tblLokacija";
        static string tipKarteSelect = @"select TipKarteID as ID, NazivTipaKarte as 'Tip' from tblTipKarte";
        static string zanrFilmaSelect = @"select ZanrFilmaID as ID, Rejting + ', ' + Zanr as 'Rejting i zanr' from tblZanrFilma";
        #endregion

        #region
        string kupciDelete = @"delete from tblKupac where KupacID=";
        string zaposleniDelete = @"delete from tblZaposleni where ZaposleniID=";
        string filmoviDelete = @"delete from tblFilm where FilmID=";
        string rezervacijeDelete = @"delete from tblRezervacija where RezervacijaID=";
        string lokacijeDelete = @"delete from tblLokacija where LokacijaID=";
        string tipoviKarataDelete = @"delete from tblTipKarte where TipKarteID=";
        string zanroviDelete = @"delete from tblZanrFilma where ZanrFilmaID=";
        #endregion


        static SqlConnection konekcija = Konekcija.KreirajKonekciju();
        public MainWindow()
        {
            InitializeComponent();
            Login l = new Login();
            l.ShowDialog();
            UcitajPodatke(dataGridCentralni, filmoviSelect);
        }

        public static void UcitajPodatke(DataGrid grid, string selectUpit)
        {
            try
            {
                konekcija.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectUpit, konekcija);
                dataAdapter.Fill(dt);
                grid.ItemsSource = dt.DefaultView;
                ucitanaTabela = selectUpit;
            }
            catch (Exception)
            {
                MessageBox.Show("Neuspesno ucitani podaci!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        private void btnKupci_Click(object sender, RoutedEventArgs e)
        {
            btnKupci.Background = Brushes.Black;
            UcitajPodatke(dataGridCentralni, kupciSelect);
        }

        private void btnFilmovi_Click(object sender, RoutedEventArgs e)
        {
            btnFilmovi.Background = Brushes.Black;
            UcitajPodatke(dataGridCentralni, filmoviSelect);
        }

        private void btnZaposleni_Click(object sender, RoutedEventArgs e)
        {
            btnZaposleni.Background = Brushes.Black;
            UcitajPodatke(dataGridCentralni, zaposleniSelect);
        }

        private void btnRezervacije_Click(object sender, RoutedEventArgs e)
        {
            btnRezervacije.Background = Brushes.Black;
            UcitajPodatke(dataGridCentralni, rezervacijeSelect);
        }

        private void btnLokacije_Click(object sender, RoutedEventArgs e)
        {
            btnLokacije.Background = Brushes.Black;
            UcitajPodatke(dataGridCentralni, lokacijeSelect);
        }

        private void btnTipKarte_Click(object sender, RoutedEventArgs e)
        {
            btnTipKarte.Background = Brushes.Black;
            UcitajPodatke(dataGridCentralni, tipKarteSelect);
        }

        private void btnZanrFilma_Click(object sender, RoutedEventArgs e)
        {
            btnZanrFilma.Background = Brushes.Black;
            UcitajPodatke(dataGridCentralni, zanrFilmaSelect);
        }

        

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            Window prozor;

            if (ucitanaTabela.Equals(kupciSelect))
            {
                prozor = new Kupac();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, kupciSelect);
            }
            else if (ucitanaTabela.Equals(zaposleniSelect))
            {
                prozor = new Zaposleni();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, zaposleniSelect);
            }
            else if (ucitanaTabela.Equals(filmoviSelect))
            {
                prozor = new Film();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, filmoviSelect);
            }
            else if (ucitanaTabela.Equals(rezervacijeSelect))
            {
                prozor = new Rezervacija();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, rezervacijeSelect);
            }
            else if (ucitanaTabela.Equals(lokacijeSelect))
            {
                prozor = new Lokacija();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, lokacijeSelect);
            }
            else if (ucitanaTabela.Equals(tipKarteSelect))
            {
                prozor = new TipKarte();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, tipKarteSelect);
            }
            else if (ucitanaTabela.Equals(zanrFilmaSelect))
            {
                prozor = new ZanrFilma();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, zanrFilmaSelect);
            }
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            if (ucitanaTabela.Equals(kupciSelect))
            {
                PopuniFormu(dataGridCentralni, selectUslovKupac);
                UcitajPodatke(dataGridCentralni, kupciSelect);
            }
            else if (ucitanaTabela.Equals(zaposleniSelect))
            {
                PopuniFormu(dataGridCentralni, selectUslovZaposleni);
                UcitajPodatke(dataGridCentralni, zaposleniSelect);
            }
            else if (ucitanaTabela.Equals(filmoviSelect))
            {
                PopuniFormu(dataGridCentralni, selectUslovFilm);
                UcitajPodatke(dataGridCentralni, filmoviSelect);
            }
            else if (ucitanaTabela.Equals(rezervacijeSelect))
            {
                PopuniFormu(dataGridCentralni, selectUslovRezervacija);
                UcitajPodatke(dataGridCentralni, rezervacijeSelect);
            }
            else if (ucitanaTabela.Equals(lokacijeSelect))
            {
                PopuniFormu(dataGridCentralni, selectUslovLokacija);
                UcitajPodatke(dataGridCentralni, lokacijeSelect);
            }
            else if (ucitanaTabela.Equals(tipKarteSelect))
            {
                PopuniFormu(dataGridCentralni, selectUslovTipKarte);
                UcitajPodatke(dataGridCentralni, tipKarteSelect);
            }
            else if (ucitanaTabela.Equals(zanrFilmaSelect))
            {
                PopuniFormu(dataGridCentralni, selectUslovZanrFilma);
                UcitajPodatke(dataGridCentralni, zanrFilmaSelect);
            }
        }
        // IZMENI CLICK
        static void PopuniFormu(DataGrid grid, string selectUslov)
        {
            try
            {
                konekcija.Open();
                azuriraj = true;
                DataRowView red = (DataRowView)grid.SelectedItems[0];
                pomocniRed = red;
                string upit = selectUslov + red["ID"];
                SqlCommand cmd = new SqlCommand(upit, konekcija);
                SqlDataReader citac = cmd.ExecuteReader();
                while (citac.Read())
                {
                    if (ucitanaTabela.Equals(filmoviSelect))
                    {
                        Film prozorFilm = new Film();
                        prozorFilm.cbZanrFilma.SelectedValue = citac["ZanrFilmaID"].ToString();
                        prozorFilm.cbLokacija.SelectedValue = citac["LokacijaID"].ToString();
                        prozorFilm.txtNazivFilma.Text = citac["NazivFilma"].ToString();
                        prozorFilm.txtOpisFilma.Text = citac["OpisFilma"].ToString();
                        prozorFilm.txtTrajanje.Text = citac["Trajanje"].ToString();
                        prozorFilm.txtJezik.Text = citac["Jezik"].ToString();
                        prozorFilm.dpDatum.SelectedDate = (DateTime)citac["Datum"];
                        prozorFilm.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(zanrFilmaSelect))
                    {
                        ZanrFilma prozorZanr = new ZanrFilma();
                        prozorZanr.txtRejting.Text = citac["Rejting"].ToString();
                        prozorZanr.txtZanr.Text = citac["Zanr"].ToString();
                        prozorZanr.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(zaposleniSelect))
                    {
                        Zaposleni prozorZaposleni = new Zaposleni();
                        prozorZaposleni.txtIme.Text = citac["ImeZap"].ToString();
                        prozorZaposleni.txtPrezime.Text = citac["PrezZap"].ToString();
                        prozorZaposleni.txtJMBG.Text = citac["JMBG"].ToString();
                        prozorZaposleni.txtKorisnickoIme.Text = citac["KorisnickoIme"].ToString();
                        prozorZaposleni.txtLozinka.Text = citac["Lozinka"].ToString();
                        prozorZaposleni.txtKontakt.Text = citac["KontaktZap"].ToString();
                        prozorZaposleni.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(tipKarteSelect))
                    {
                        TipKarte prozorTipKarte = new TipKarte();
                        prozorTipKarte.txtTipKarte.Text = citac["NazivTipaKarte"].ToString();
                        prozorTipKarte.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(lokacijeSelect))
                    {
                        Lokacija prozorLokacija = new Lokacija();
                        prozorLokacija.txtAdresa.Text = citac["Adresa"].ToString();
                        prozorLokacija.txtGrad.Text = citac["Grad"].ToString();
                        prozorLokacija.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(kupciSelect))
                    {
                        Kupac prozorKupac = new Kupac();
                        prozorKupac.txtIme.Text = citac["ImeKupca"].ToString();
                        prozorKupac.txtPrezime.Text = citac["PrezKupca"].ToString();
                        prozorKupac.txtKontakt.Text = citac["Kontakt"].ToString();
                        prozorKupac.txtGodine.Text = citac["Godine"].ToString();
                        prozorKupac.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(rezervacijeSelect))
                    {
                        Rezervacija prozorRezervacija = new Rezervacija();
                        prozorRezervacija.txtVreme.Text = citac["Vreme"].ToString();
                        prozorRezervacija.txtMesto.Text = citac["Mesto"].ToString();
                        prozorRezervacija.txtCenaKarte.Text = citac["CenaKarte"].ToString();
                        prozorRezervacija.cbKupac.SelectedValue = citac["KupacID"].ToString();
                        prozorRezervacija.cbZaposleni.SelectedValue = citac["ZaposleniID"].ToString();
                        prozorRezervacija.cbTipKarte.SelectedValue = citac["TipKarteID"].ToString();
                        prozorRezervacija.cbFilm.SelectedValue = citac["FilmID"].ToString();
                        prozorRezervacija.ShowDialog();
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {

                MessageBox.Show("Niste selektovali red!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                azuriraj = false;
            }
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (ucitanaTabela.Equals(filmoviSelect))
            {
                ObrisiZapis(dataGridCentralni, filmoviDelete);
                UcitajPodatke(dataGridCentralni, filmoviSelect);
            }
            else if (ucitanaTabela.Equals(kupciSelect))
            {
                ObrisiZapis(dataGridCentralni, kupciDelete);
                UcitajPodatke(dataGridCentralni, kupciSelect);
            }
            else if (ucitanaTabela.Equals(lokacijeSelect))
            {
                ObrisiZapis(dataGridCentralni, lokacijeDelete);
                UcitajPodatke(dataGridCentralni, lokacijeSelect);
            }
            else if (ucitanaTabela.Equals(rezervacijeSelect))
            {
                ObrisiZapis(dataGridCentralni, rezervacijeDelete);
                UcitajPodatke(dataGridCentralni, rezervacijeSelect);
            }
            else if (ucitanaTabela.Equals(tipKarteSelect))
            {
                ObrisiZapis(dataGridCentralni, tipoviKarataDelete);
                UcitajPodatke(dataGridCentralni, tipKarteSelect);
            }
            else if (ucitanaTabela.Equals(zanrFilmaSelect))
            {
                ObrisiZapis(dataGridCentralni, zanroviDelete);
                UcitajPodatke(dataGridCentralni, zanrFilmaSelect);
            }
            else if (ucitanaTabela.Equals(zaposleniSelect))
            {
                ObrisiZapis(dataGridCentralni, zaposleniDelete);
                UcitajPodatke(dataGridCentralni, zaposleniSelect);
            }
        }

        static void ObrisiZapis(DataGrid grid, string deleteUpit)
        {
            try
            {
                konekcija.Open();
                DataRowView red = (DataRowView)grid.SelectedItems[0];
                string upit = deleteUpit + red["ID"];
                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni da zelite da obrisete?", "Upozorenje!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (rezultat == MessageBoxResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand(upit, konekcija);
                    cmd.ExecuteNonQuery();
                }


            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (SqlException)
            {
                MessageBox.Show("Postoje povezani podaci u drugim tabelama", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }
    }
}
