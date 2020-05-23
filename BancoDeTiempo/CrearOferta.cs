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
    public partial class CrearOferta : Form
    {

        public CrearOferta()
        {
            InitializeComponent();
        }

        private void CrearOferta_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'nombre_tipo_servicio.tipo_servicio' Puede moverla o quitarla según sea necesario.
            this.tipo_servicioTableAdapter.Fill(this.nombre_tipo_servicio.tipo_servicio);
            // TODO: esta línea de código carga datos en la tabla 'nombre_usuario.usuarios' Puede moverla o quitarla según sea necesario.
            this.usuariosTableAdapter.Fill(this.nombre_usuario.usuarios);
            // TODO: esta línea de código carga datos en la tabla 'nombre_categoria.categorias' Puede moverla o quitarla según sea necesario.
            this.categoriasTableAdapter.Fill(this.nombre_categoria.categorias);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Servicio s = new Servicio();
            s.id_servicio = textBox1.Text;
            s.titulo = textBox2.Text;
            s.descripcion = textBox3.Text;

            //Asignar como ID de usuario el ID del usuario escogido en el ComboBox.
            String nombre_usuario = comboBox2.Text;
            Usuario u = GestorBBDD.buscarUserPorNombre(nombre_usuario);
            s.id_usuario = u.id_usuario;

            String nombre_categoria = comboBox1.Text;
            Categoria c = GestorBBDD.buscarCatPorNombre(nombre_categoria);
            s.id_categoria = c.id_categoria;

            s.fecha_creacion = DateTime.Now;

            String nombre_tipo_servicio = comboBox3.Text;
            TipoServicio ts = GestorBBDD.buscarTipoPorNombre(nombre_tipo_servicio);
            s.tipo_servicio = ts.id_tipo_servicio;

            GestorBBDD.agregarServicio(s);

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
