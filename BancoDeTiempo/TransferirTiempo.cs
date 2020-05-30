using System;
using System.Windows.Forms;

namespace BancoDeTiempo
{
    //Formulario hijo de Main que se abre para definir las horas y comentarios de un registro de movimiento
    public partial class TransferirTiempo : Form
    {
        //Variables para enviar valores al formulario padre
        public string comentario { get; set; }
        public double hora { get; set; }

        public TransferirTiempo()
        {
            InitializeComponent();

            //Definir estilo sin borde de los botones
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            comentario = textBox1.Text;

            double d;
            //Bucle que obliga al usuario a poner un número en el campo horas
            while (true) {
                String parsePuntos = textBox3.Text.Replace(".", ","); //Reemplaza los puntos por las comas (aceptadas en la base de datos)
                if (Double.TryParse(parsePuntos, out d)) //Parsea que se trate de un número deicmal
                {
                    hora = d;
                    this.DialogResult = DialogResult.OK; //Devuelve el resultado de este formulario hijo a su padre
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
