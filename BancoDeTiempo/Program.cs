using System;
using System.Windows.Forms;

namespace BancoDeTiempo
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        //Variable global que define el usuario logeado
        public static Usuario usuarioAutenticado { get; set; } = null;
    }
}
