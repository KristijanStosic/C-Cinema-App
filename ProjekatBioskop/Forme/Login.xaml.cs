using System;
using System.Collections.Generic;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        SqlConnection konekcija = Konekcija.KreirajKonekciju();
        static bool usao = false;
        
        public Login()
        {
            InitializeComponent();
            txtKorisnicko_ime.Focus();
        }

        private void btnUloguj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                SqlCommand cmd = new SqlCommand(MainWindow.Login1, konekcija);
                SqlDataReader citac = cmd.ExecuteReader();
                while (citac.Read())
                {
                    if(txtKorisnicko_ime.Text == citac["KorisnickoIme"].ToString() && txtLozinka.Password == citac["Lozinka"].ToString())
                    {

                        this.Close();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Niste uneli podatke!", "Greska", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            finally
            {
                if(konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

       

        private void btnOtkazi_Click_1(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnRegistrujSe_Click(object sender, RoutedEventArgs e)
        {
            Zaposleni registrujZaposlenog = new Zaposleni();
            registrujZaposlenog.ShowDialog();
        }
    }
}
