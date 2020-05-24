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
        CrearOferta crearOfertaForm;
        TransferirTiempo transferirTiempoForm;
        Form1 cerrarSesion;
        Usuario usuarioLogeado = Program.usuarioAutenticado;
        static btEntities bte = new btEntities();
        private static Random random = new Random();

        public Main()
        {
            InitializeComponent();
            label1.Text = String.Format("Usuario autenticado: {0}", usuarioLogeado.nombre_usuario);
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void showOfertasPublicadas(DataGridView dgv)
        {
            var ofertasPublicadas = (from s in bte.servicios
                                     join c in bte.categorias
                                     on s.id_categoria equals c.id_categoria
                                     where !s.id_usuario.Contains(usuarioLogeado.id_usuario)
                                     select new
                                     {
                                         s.titulo,
                                         c.nombre_categoria
                                     }).ToList();

            dgv.DataSource = ofertasPublicadas;
            dgv.Update();
            dgv.Refresh();
        }

        private void showMisOfertas(DataGridView dgv)
        {
            var misOfertas = (from s in bte.servicios
                              join c in bte.categorias
                              on s.id_categoria equals c.id_categoria
                              where s.id_usuario == usuarioLogeado.id_usuario
                              select new
                              {
                                  s.titulo,
                                  c.nombre_categoria
                              }).ToList();

            dgv.DataSource = misOfertas;
            dgv.Update();
            dgv.Refresh();
        }

        private void showMisMovimientos(DataGridView dgv)
        {
            var misMovimientos = (from m in bte.movimientos
                                  where m.usuario_origen == usuarioLogeado.id_usuario
                                  select new
                                  {
                                      m.concepto,
                                      m.fecha
                                  }).ToList();

            dgv.DataSource = misMovimientos;
            dgv.Update();
            dgv.Refresh();
        }

        private void showSolicitudesEnviadas(DataGridView dgv)
        {
            var solicitudesEnviadas = (from s in bte.servicios
                                       join c in bte.categorias on s.id_categoria equals c.id_categoria
                                       join sltd in bte.solicitudes on s.id_servicio equals sltd.concepto
                                       where sltd.id_emisor == usuarioLogeado.id_usuario
                                       select new
                                       {
                                           s.titulo,
                                           c.nombre_categoria
                                       }).ToList();

            dgv.DataSource = solicitudesEnviadas;
            dgv.Update();
            dgv.Refresh();
        }

        private void showSolicitudesRecibidas(DataGridView dgv)
        {
            var solicitudesRecibidas = (from sltd in bte.solicitudes
                                        join u in bte.usuarios
                                        on sltd.id_emisor equals u.id_usuario
                                        join s in bte.servicios
                                        on sltd.concepto equals s.id_servicio
                                        where s.id_usuario == usuarioLogeado.id_usuario
                                        select new
                                        {
                                            s.titulo,
                                            u.nombre_usuario
                                        }).ToList();

            dgv.DataSource = solicitudesRecibidas;
            dgv.Update();
            dgv.Refresh();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cerrarSesion = new Form1();
            cerrarSesion.Show();
            this.Hide();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                Solicitud sltd = new Solicitud();
                sltd.id_solicitud = RandomString(10);
                sltd.id_emisor = usuarioLogeado.id_usuario;
                var tituloOferta = this.dataGridView1[e.ColumnIndex+1, e.RowIndex].Value.ToString();
                Servicio servicioDeSolicitud = GestorBBDD.buscarServPorNombre(tituloOferta);
                sltd.concepto = servicioDeSolicitud.id_servicio;
                sltd.fecha_creacion = DateTime.Now;
                sltd.aceptada = false;
                GestorBBDD.agregarSolicitud(sltd);

                showSolicitudesEnviadas(dataGridView4);
            }
        }

        private void Main_Activated(object sender, EventArgs e)
        {
            showOfertasPublicadas(dataGridView1);
            showMisOfertas(dataGridView2);
            showMisMovimientos(dataGridView3);
            showSolicitudesEnviadas(dataGridView4);
            showSolicitudesRecibidas(dataGridView5);
        }

    }
}
