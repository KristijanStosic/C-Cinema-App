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
    /// Interaction logic for ZanrFilma.xaml
    /// </summary>
    public partial class ZanrFilma : Window
    {
        SqlConnection konekcija = Konekcija.KreirajKonekciju();
        public ZanrFilma()
        {
            InitializeComponent();
            txtRejting.Focus();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                if (MainWindow.azuriraj)
                {
                    DataRowView red = MainWindow.pomocniRed;
                    string update = @"update tblZanrFilma
                            set Rejting='" + txtRejting.Text + "' where ZanrFilmaID=" + red["ID"]
                            + "update tblZanrFilma " + "set Zanr='" + txtZanr.Text + "' where ZanrFilmaID=" + red["ID"];
                    SqlCommand cmd = new SqlCommand(update, konekcija);
                    cmd.ExecuteNonQuery();
                    MainWindow.pomocniRed = null;
                }
                else
                {
                    string insert = @"insert into tblZanrFilma(Rejting, Zanr)
                                    values ('" + txtRejting.Text + "','"
                                              + txtZanr.Text + "')";
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
