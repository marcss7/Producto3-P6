using System;
using System.Windows.Forms;

namespace BancoDeTiempo
{
    //Formulario hijo de Main que se abre para definir el titulo, la descripcion, la categoria y el tipo de servicio de un registro de servicio
    public partial class CrearOferta : Form
    {
        //Variables públicas a las que se accederá desde Main para crear un registro de servicios
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public string categoria { get; set; }
        public string tipoServicio { get; set; }

        public CrearOferta()
        {
            InitializeComponent();

            //Definir estilo sin borde de los botones
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
        }

        private void CrearOferta_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'nombre_tipo_servicio.tipo_servicio' Puede moverla o quitarla según sea necesario.
            this.tipo_servicioTableAdapter.Fill(this.nombre_tipo_servicio.tipo_servicio);
            // TODO: esta línea de código carga datos en la tabla 'nombre_categoria.categorias' Puede moverla o quitarla según sea necesario.
            this.categoriasTableAdapter.Fill(this.nombre_categoria.categorias);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            titulo = textBox2.Text;
            descripcion = textBox3.Text;

            //Obtenemos el objeto categoria a través de su nombre
            String nombre_categoria = comboBox1.Text;
            Categoria c = GestorBBDD.buscarCatPorNombre(nombre_categoria);
            categoria = c.id_categoria;

            //Obtenemos el objeto tipo_servicio a través de su nombre
            String nombre_tipo_servicio = comboBox3.Text;
            TipoServicio ts = GestorBBDD.buscarTipoPorNombre(nombre_tipo_servicio);
            tipoServicio = ts.id_tipo_servicio;

            //Devuelve el resultado de este formulario hijo a su padre
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
