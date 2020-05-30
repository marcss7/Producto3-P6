using System;
using System.Windows.Forms;

namespace BancoDeTiempo
{
    //Formulario hijo de Main que se abre para mostrar todos los valores del registro de factura creado
    public partial class MostrarFactura : Form
    {

        public MostrarFactura()
        {
            InitializeComponent();
            
            //Muestra en las labels las variables públicas de la factura definidas en Main
            label2.Text = String.Format("ID de la factura: {0}", Main.MF_id_factura);
            label3.Text = String.Format("Usuario dador: {0}", Main.MF_usuario_emisor);
            label4.Text = String.Format("Usuario receptor: {0}", Main.MF_usuario_receptor);
            label5.Text = String.Format("Concepto: {0}", Main.MF_concepto);
            label6.Text = String.Format("Importe: {0} horas", Main.MF_importe);
            label7.Text = String.Format("Fecha: {0:dd/MM/yy H:mm}", Main.MF_fecha);
        }
    }
}
