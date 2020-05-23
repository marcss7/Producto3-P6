using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BancoDeTiempo
{
    static class Program
    {
        private static Usuario usuarioAuth = null;

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

        public static Usuario usuarioAutenticado
        {
            get { return usuarioAuth; }
            set { usuarioAuth = value; }
        }
    }
}
