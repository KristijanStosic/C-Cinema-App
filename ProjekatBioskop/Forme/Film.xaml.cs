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


    public partial class Film : Window
    {
        SqlConnection konekcija = Konekcija.KreirajKonekciju();
        public Film()
        {
            InitializeComponent();
            try
            {
                konekcija.Open();
                string vratiZanrFilma = @"select * from tblZanrFilma";
                DataTable dtZanrFilma = new DataTable();
                SqlDataAdapter daZanrFilma = new SqlDataAdapter(vratiZanrFilma, konekcija);
                daZanrFilma.Fill(dtZanrFilma);
                cbZanrFilma.ItemsSource = dtZanrFilma.DefaultView;


                string vratiLokacije = @"select LokacijaID, Adresa + ', ' + Grad as Adresa from tblLokacija";
                DataTable dtLokacija = new DataTable();
                SqlDataAdapter daLokacija = new SqlDataAdapter(vratiLokacije, konekcija);
                daLokacija.Fill(dtLokacija);
                cbLokacija.ItemsSource = dtLokacija.DefaultView;
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
            txtNazivFilma.Focus();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                if (MainWindow.azuriraj)
                {
                    DataRowView red = MainWindow.pomocniRed;
                    DateTime date = (DateTime)dpDatum.SelectedDate;
                    string datum = dpDatum.ToString();
                    string update = @"update tblFilm set NazivFilma='" + txtNazivFilma.Text + "' where FilmID=" + red["ID"]
                      + "update tblFilm set OpisFilma='" + txtOpisFilma.Text + "' where FilmID=" + red["ID"]
                      + "update tblFilm set Trajanje='" + txtTrajanje.Text + "' where FilmID=" + red["ID"]
                      + "update tblFilm set Jezik='" + txtJezik.Text + "' where FilmID=" + red["ID"]
                      + "update tblFilm set Datum='" + datum + "' where FilmID=" + red["ID"]
                      + "update tblFilm set ZanrFilmaID=" + cbZanrFilma.SelectedValue + " where FilmID=" + red["ID"]
                      + "update tblFilm set LokacijaID=" + cbLokacija.SelectedValue + " where FilmID=" + red["ID"];
                    SqlCommand cmd = new SqlCommand(update, konekcija);
                    cmd.ExecuteNonQuery();
                    MainWindow.pomocniRed = null;
                }
                else
                {
                    DateTime date = (DateTime)dpDatum.SelectedDate;
                    string datum = dpDatum.ToString();
                    string insert = @"insert into tblFilm(LokacijaID,ZanrFilmaID,NazivFilma,OpisFilma,Trajanje,Jezik,Datum)
                                    values (" + cbLokacija.SelectedValue
                                        + "," + cbZanrFilma.SelectedValue
                                        + "," + "'" + txtNazivFilma.Text + "'"
                                        + "," + "'" + txtOpisFilma.Text + "'"
                                        + "," + "'" + txtTrajanje.Text + "'"
                                        + "," + "'" + txtJezik.Text + "'"
                                        + "," + "'" + datum + "'" + ");";

                    SqlCommand cmd = new SqlCommand(insert, konekcija);
                    cmd.ExecuteNonQuery();
                }
                this.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Unos odredjenih vrednosti nije validan!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch(InvalidOperationException)
            {
                MessageBox.Show("Niste selektovali datum! Izaberite datum!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
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
