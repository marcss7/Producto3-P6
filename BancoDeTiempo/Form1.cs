using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using BancoDeTiempo.Properties;
using Microsoft.SqlServer;
using Microsoft.SqlServer.Management.Common;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.SqlServer.Management.Smo;

namespace BancoDeTiempo
{
    public partial class Form1 : Form
    {
        btEntities bet = new btEntities();
        Main mainForm;

        public Form1()
        {
            InitializeComponent();
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String usuarioEscogido = comboBox1.Text;
            Usuario uAuth = GestorBBDD.buscarUserPorNombre(usuarioEscogido);
            Program.usuarioAutenticado = uAuth;

            mainForm = new Main();
            mainForm.Show();
            this.Hide();
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var sqlFile = Resources.timebank;

            string sqlConnectionString = @"Data Source=localhost;Integrated Security=True";

            //string script = File.ReadAllText(sqlFile);

            SqlConnection conn = new SqlConnection(sqlConnectionString);

            Server server = new Server(new ServerConnection(conn));

            server.ConnectionContext.ExecuteNonQuery(sqlFile);

            // TODO: esta línea de código carga datos en la tabla 'usernames.usuarios' Puede moverla o quitarla según sea necesario.
            this.usuariosTableAdapter.Fill(this.usernames.usuarios);
        }
    }
}
