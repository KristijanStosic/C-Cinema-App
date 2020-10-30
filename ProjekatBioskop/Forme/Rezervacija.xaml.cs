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
using System.Windows.Shapes;

namespace ProjekatBioskop.Forme
{
    /// <summary>
    /// Interaction logic for Rezervacija.xaml
    /// </summary>
    public partial class Rezervacija : Window
    {
        SqlConnection konekcija = Konekcija.KreirajKonekciju();
        public Rezervacija()
        {
            InitializeComponent();
            try
            {
                konekcija.Open();
                string vratiKupce = @"select KupacID, ImeKupca + ' ' + PrezKupca as Kupac from tblKupac";
                DataTable dtKupci = new DataTable();
                SqlDataAdapter daKupci = new SqlDataAdapter(vratiKupce, konekcija);
                daKupci.Fill(dtKupci);
                cbKupac.ItemsSource = dtKupci.DefaultView;

                string vratiZaposlene = @"select * from tblZaposleni";
                DataTable dtZaposleni = new DataTable();
                SqlDataAdapter daZaposleni = new SqlDataAdapter(vratiZaposlene, konekcija);
                daZaposleni.Fill(dtZaposleni);
                cbZaposleni.ItemsSource = dtZaposleni.DefaultView;

                string vratiTipKarte = @"select * from tblTipKarte";
                DataTable dtTipKarte = new DataTable();
                SqlDataAdapter daTipKarte = new SqlDataAdapter(vratiTipKarte, konekcija);
                daTipKarte.Fill(dtTipKarte);
                cbTipKarte.ItemsSource = dtTipKarte.DefaultView;

                string vratiFilmove = @"select * from tblFilm";
                DataTable dtFilmovi = new DataTable();
                SqlDataAdapter daFilmovi = new SqlDataAdapter(vratiFilmove, konekcija);
                daFilmovi.Fill(dtFilmovi);
                cbFilm.ItemsSource = dtFilmovi.DefaultView;


            }
            catch (Exception)
            {
                MessageBox.Show("Padajuce liste nisu popunjene!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }

            txtVreme.Focus();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                if (MainWindow.azuriraj)
                {
                    DataRowView red = MainWindow.pomocniRed;
                    string update = @"update tblRezervacija set Vreme='" + txtVreme.Text + "' where RezervacijaID=" + red["ID"]
                      + "update tblRezervacija set Mesto='" + txtMesto.Text + "' where RezervacijaID=" + red["ID"]
                      + "update tblRezervacija set CenaKarte='" + txtCenaKarte.Text + "' where RezervacijaID=" + red["ID"]
                      + "update tblRezervacija set KupacID='" + cbKupac.SelectedValue + "' where RezervacijaID=" + red["ID"]
                      + "update tblRezervacija set ZaposleniID='" + cbZaposleni.SelectedValue + "' where RezervacijaID=" + red["ID"]
                      + "update tblRezervacija set TipKarteID='" + cbTipKarte.SelectedValue + "' where RezervacijaID=" + red["ID"]
                      + "update tblRezervacija set FilmID='" + cbFilm.SelectedValue + "' where RezervacijaID=" + red["ID"];
                    SqlCommand cmd = new SqlCommand(update, konekcija);
                    cmd.ExecuteNonQuery();
                    MainWindow.pomocniRed = null;
                }
                else
                {
                    string insert = @"insert into tblRezervacija(Vreme,Mesto,CenaKarte, KupacID, ZaposleniID, TipKarteID, FilmID)
                                    values ('" + txtVreme.Text + "','" + txtMesto.Text
                                        + "','" + txtCenaKarte.Text + "',"
                                        + cbKupac.SelectedValue
                                        + "," + cbZaposleni.SelectedValue
                                        + "," + cbTipKarte.SelectedValue
                                        + "," + cbFilm.SelectedValue + ")";
                    SqlCommand cmd = new SqlCommand(insert, konekcija);
                    cmd.ExecuteNonQuery();
                }
                this.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Unos odredjenih vrednosti nije validan!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }

        }
        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

