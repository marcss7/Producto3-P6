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
    public partial class Main : Form
    {
        ListadoServicios listaServiciosForm;
        CrearOferta crearOfertaForm;
        TransferirTiempo transferirTiempoForm;
        ListadoMovimientos listaMovimientosForm;
        public Main()
        {
            InitializeComponent();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listaServiciosForm = new ListadoServicios();
            listaServiciosForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            crearOfertaForm = new CrearOferta();
            crearOfertaForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            transferirTiempoForm = new TransferirTiempo();
            transferirTiempoForm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listaMovimientosForm = new ListadoMovimientos();
            listaMovimientosForm.ShowDialog();
        }
    }
}
