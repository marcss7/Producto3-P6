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
    public partial class TransferirTiempo : Form
    {
        public TransferirTiempo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Movimiento m = new Movimiento();
            m.id_movimiento = textBox4.Text;

            //Asignar como ID del usuario dador el ID del usuario escogido en el ComboBox.
            String usuario_dador = comboBox1.Text;
            Usuario u1 = GestorBBDD.buscarUserPorNombre(usuario_dador);
            m.usuario_origen = u1.id_usuario;

            //Asignar como ID del usuario destinatario el ID del usuario escogido en el ComboBox.
            String usuario_destinatario = comboBox2.Text;
            Usuario u2 = GestorBBDD.buscarUserPorNombre(usuario_destinatario);
            m.usuario_destino = u2.id_usuario;

            String titulo_servicio = comboBox3.Text;
            Servicio s = GestorBBDD.buscarServPorNombre(titulo_servicio);
            m.concepto = s.id_servicio;

            m.comentarios = textBox1.Text;

            double d;
            while (true) {
                String parsePuntos = textBox3.Text.Replace(".", ",");
                if (Double.TryParse(parsePuntos, out d))
                {
                    m.horas = d;
                    m.fecha = DateTime.Now;

                    GestorBBDD.agregarMovimiento(m);
                    this.Close();
                    break;
                }
                else
                {
                    MessageBox.Show("Por favor, introduzca un número decimal para las horas");
                    return;
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TransferirTiempo_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'concepto_servicios.servicios' Puede moverla o quitarla según sea necesario.
            this.serviciosTableAdapter.Fill(this.concepto_servicios.servicios);
            // TODO: esta línea de código carga datos en la tabla 'nombre_usuario.usuarios' Puede moverla o quitarla según sea necesario.
            this.usuariosTableAdapter.Fill(this.nombre_usuario.usuarios);

        }

    }
}
