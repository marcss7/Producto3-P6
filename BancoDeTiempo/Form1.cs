using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BancoDeTiempo
{
    public partial class Form1 : Form
    {
        btEntities bet = new btEntities();
        Main mainForm;
        public Form1()
        {
            InitializeComponent();
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

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'nombre_usuario.usuarios' Puede moverla o quitarla según sea necesario.
            this.usuariosTableAdapter.Fill(this.nombre_usuario.usuarios);

        }
    }
}
