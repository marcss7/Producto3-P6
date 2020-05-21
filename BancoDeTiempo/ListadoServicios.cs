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
    public partial class ListadoServicios : Form
    {
        public ListadoServicios()
        {
            InitializeComponent();
        }

        private void ListadoServicios_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'servicios._servicios' Puede moverla o quitarla según sea necesario.
            this.serviciosTableAdapter.Fill(this.servicios._servicios);

        }
    }
}
