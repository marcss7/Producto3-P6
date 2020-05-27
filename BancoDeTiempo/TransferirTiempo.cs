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
        public string comentario { get; set; }
        public double hora { get; set; }

        public TransferirTiempo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            comentario = textBox1.Text;

            double d;
            while (true) {
                String parsePuntos = textBox3.Text.Replace(".", ",");
                if (Double.TryParse(parsePuntos, out d))
                {
                    hora = d;
                    this.DialogResult = DialogResult.OK;
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

    }
}
