using System;
using System.Collections.Generic;
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
using System.Data.SqlClient;
using System.Data;

namespace WPF_CRUD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadGrid();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ITL9QKP\SQLEXPRESS;Initial Catalog=CRUDWPF;Integrated Security=True");
        private object datagrid;

        public void clearData()
        {
            name_txt.Clear();
            age_txt.Clear();
            gender_txt.Clear();
            city_txt.Clear();
            //search_txt.Clear();
        }

        public void LoadGrid()
        {
            SqlCommand cmd = new SqlCommand("Select * from CRUD", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
           // datagrid.ItemsSource = dt.DefaultView;
        }
        private void ClearDataBtn_Click(object sender, RoutedEventArgs e)
        {
            clearData();
        }

        
        public bool isValid()
        {
            if(name_txt.Text == string.Empty)
            {
                MessageBox.Show("Name is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;

            }
            if (age_txt.Text == string.Empty)
            {
                MessageBox.Show("Age is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;

            }
            if (gender_txt.Text == string.Empty)
            {
                MessageBox.Show("Gender is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;

            }
            if (city_txt.Text == string.Empty)
            {
                MessageBox.Show("City is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;

            }
            return true;
        }
        private void InsertBtn_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                if (isValid())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO CRUD VALUES(@Name,@Age,@Gender,@City)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Name", name_txt.Text);
                    cmd.Parameters.AddWithValue("@Age", age_txt.Text);
                    cmd.Parameters.AddWithValue("@Gender", gender_txt.Text);
                    cmd.Parameters.AddWithValue("@City", city_txt.Text);
                    con.Open();                   
                    cmd.ExecuteNonQuery();
                    con.Close();
                    LoadGrid();
                    MessageBox.Show("Sucessfull Registered", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
                    clearData();

                }
            }

                catch (SqlException ex)
                {
                MessageBox.Show(ex.Message);

                }
            }
            private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {/*
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete From CRUD where ID = " +search_txt.Text+ " ",con);
            try
            {
                  cmd.ExecuteNonQuery();
                  MessageBox.Show("Record has been deleted", "Delete", MessageBoxButton.OK, MessageBoxImage.Information);
                  con.Close();
                  clearData();
                  LoadGrid();
                  con.Close();
            }
            catch(SqlException ex)
            {

                 MessageBox.Show("Not Deleted" +ex.Message);

              }
            finally
            {
             con.Close();
            }*/

        }
            private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {/*
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record has been updated sucessfully", "Updated", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                clearData();
                LoadGrid();
            }*/
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }

        private void gender_txt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }
    }
}
