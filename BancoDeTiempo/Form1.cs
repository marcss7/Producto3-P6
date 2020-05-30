using System;
using System.Data.SqlClient;
using BancoDeTiempo.Properties;
using Microsoft.SqlServer.Management.Common;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;

namespace BancoDeTiempo
{
    //Formulario inicial, sirve para iniciar sesión como uno de los usuarios
    public partial class Form1 : Form
    {
        Main mainForm;

        public Form1()
        {
            InitializeComponent();

            //Definir estilo sin borde del botón
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String usuarioEscogido = comboBox1.Text;
            
            //Obtenemos el objeto usuario a través de su nombre
            Usuario uAuth = GestorBBDD.buscarUserPorNombre(usuarioEscogido);
            //Asignamos el usuario escogido en el comboBox a la variable global
            Program.usuarioAutenticado = uAuth;

            //Mostramos el formulario Main
            mainForm = new Main();
            mainForm.Show();

            //Escondemos en vez de cerrar ya que es el formulario inicial que corre la clase Program
            this.Hide();
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Si cierras la ventana se sale de la aplicación
            System.Windows.Forms.Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Obtenemos el contenido del script sql timebank que está en los recursos del proyecto
            var sqlFile = Resources.timebank;

            //String de conexión a localhost
            string sqlConnectionString = @"Data Source=localhost;Integrated Security=True";

            SqlConnection conn = new SqlConnection(sqlConnectionString);

            Server server = new Server(new ServerConnection(conn));

            //Ejecutamos todas las sentencias definidas en el archivo timebank.sql
            server.ConnectionContext.ExecuteNonQuery(sqlFile);

            // TODO: esta línea de código carga datos en la tabla 'usernames.usuarios' Puede moverla o quitarla según sea necesario.
            this.usuariosTableAdapter.Fill(this.usernames.usuarios);
        }
    }
}
