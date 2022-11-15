using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;


namespace CapaVista
{

    public partial class LogIn : Form
    {

        

        public LogIn()
        {
            InitializeComponent();
        }

        private void LogIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }

        //string conn = "server=localhost;uid=root;pwd=12345;database=prototipoefbd";
        //MySqlConnection con = new MySqlConnection();

        SqlConnection con = new SqlConnection(@"server=localhost;uid=root;pwd=12345;database=prototipoefbd;Integrated Security=True");


        public void logear(string usuario, string contrasena)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Nombre, Tipo_usuario FROM usuarios WHERE Usuario = @usuario AND Contraseña = @pass", con);
                cmd.Parameters.AddWithValue("Usuario", usuario);
                cmd.Parameters.AddWithValue("Contraseña", contrasena);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    //Que tipo de usuario ingresa
                    this.Hide();
                    if(dt.Rows[0][1].ToString() == "Admin")
                    {

                        new MenuPrincipal().Show();

                    } else if (dt.Rows[0][1].ToString() == "Usuario")
                    {
                        new MenuPrincipal().Show();
                    }
                }
                else {
                    MessageBox.Show("Usuario y/o contraseña incorrecta");
                }

            } catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnIngesoLogin_Click(object sender, EventArgs e)
        {
            logear(this.tbxUsuario.Text, this.tbxContraseña.Text);
        }
    }
}
