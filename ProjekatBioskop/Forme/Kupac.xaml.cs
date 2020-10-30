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
    /// Interaction logic for Kupac.xaml
    /// </summary>
    public partial class Kupac : Window
    {
        SqlConnection konekcija = Konekcija.KreirajKonekciju();
        public Kupac()
        {
            InitializeComponent();
            txtIme.Focus();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                if (MainWindow.azuriraj)
                {
                    DataRowView red = MainWindow.pomocniRed;
                    string update = @"update tblKupac
                                       set ImeKupca='" + txtIme.Text + "' where KupacID=" + red["ID"]
                    + "update tblKupac set PrezKupca='" + txtPrezime.Text + "' where KupacID=" + red["ID"]
                    + "update tblKupac set Kontakt='" + txtKontakt.Text + "' where KupacID=" + red["ID"]
                    + "update tblKupac set Godine='" + txtGodine.Text + "' where KupacID=" + red["ID"];
                    SqlCommand cmd = new SqlCommand(update, konekcija);
                    cmd.ExecuteNonQuery();
                    MainWindow.pomocniRed = null;
                }
                else
                {
                    string insert = @"insert into tblKupac(ImeKupca,PrezKupca,Kontakt,Godine)
                                    values ('" + txtIme.Text + "','" + txtPrezime.Text +
                                                        "','" + txtKontakt.Text +
                                                        "','" + txtGodine.Text + "')";
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
