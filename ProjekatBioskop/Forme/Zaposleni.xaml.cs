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
    /// Interaction logic for Zaposleni.xaml
    /// </summary>
    public partial class Zaposleni : Window
    {
        SqlConnection konekcija = Konekcija.KreirajKonekciju();
        public Zaposleni()
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
                    string update =
                        @"update tblZaposleni set ImeZap='" + txtIme.Text + "' where ZaposleniID=" + red["ID"]
                          + "update tblZaposleni set PrezZap='" + txtPrezime.Text + "' where ZaposleniID=" + red["ID"]
                          + "update tblZaposleni set JMBG='" + txtJMBG.Text + "' where ZaposleniID=" + red["ID"]
                          + "update tblZaposleni set KorisnickoIme='" + txtKorisnickoIme.Text + "' where ZaposleniID=" + red["ID"]
                          + "update tblZaposleni set Lozinka='" + txtLozinka.Text + "' where ZaposleniID=" + red["ID"]
                          + "update tblZaposleni set KontaktZap='" + txtKontakt.Text + "' where ZaposleniID=" + red["ID"];
                    SqlCommand cmd = new SqlCommand(update, konekcija);
                    cmd.ExecuteNonQuery();
                    MainWindow.pomocniRed = null;
                }
                else
                {
                    string insert = @"insert into tblZaposleni(ImeZap,PrezZap,JMBG,KorisnickoIme,Lozinka,KontaktZap)
                                    values ('" + txtIme.Text + "','" + txtPrezime.Text
                                    + "','" + txtJMBG.Text
                                    + "','" + txtKorisnickoIme.Text
                                    + "','" + txtLozinka.Text
                                    + "','" + txtKontakt.Text + "')";
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
