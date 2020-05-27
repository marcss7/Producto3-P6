using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BancoDeTiempo
{
    public partial class Main : Form
    {
        CrearOferta crearOfertaForm;
        Form1 cerrarSesion;
        Usuario usuarioLogeado = Program.usuarioAutenticado;
        static btEntities bte = new btEntities();
        private static Random random = new Random();

        public Main()
        {
            InitializeComponent();
            label1.Text = String.Format("Usuario autenticado: {0}", usuarioLogeado.nombre_usuario);
            label7.Text = String.Format("Saldo del usuario: {0} h", usuarioLogeado.balance);
            showOfertasPublicadas(dataGridView1);
            showMisOfertas(dataGridView2);
            showMisMovimientos(dataGridView3);
            showSolicitudesEnviadas(dataGridView4);
            showSolicitudesRecibidas(dataGridView5);
        }

        private static string RandomString(int length)
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
                                  join s in bte.servicios
                                  on m.concepto equals s.id_servicio
                                  where m.usuario_origen == usuarioLogeado.id_usuario
                                  select new
                                  {
                                      s.titulo,
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
                                            u.nombre_usuario,
                                            sltd.aceptada
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

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                Factura f = new Factura();
                f.id_factura = RandomString(10);
                f.usuario_emisor = usuarioLogeado.id_usuario;
                var tituloOferta = this.dataGridView3[e.ColumnIndex + 1, e.RowIndex].Value.ToString();
                Servicio servicioDeFactura = GestorBBDD.buscarServPorNombre(tituloOferta);
                f.usuario_receptor = servicioDeFactura.id_usuario;
                f.concepto = servicioDeFactura.id_servicio;
                Movimiento movimientoDeFactura = GestorBBDD.buscarMovPorServicio(servicioDeFactura.id_servicio);
                f.usuario_receptor = movimientoDeFactura.usuario_destino;
                f.importe = movimientoDeFactura.horas;
                f.fecha = DateTime.Now;
                GestorBBDD.agregarFactura(f);

            }
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                Movimiento m = new Movimiento();
                m.id_movimiento = RandomString(10);
                m.usuario_origen = usuarioLogeado.id_usuario;
                var tituloOferta = this.dataGridView4[e.ColumnIndex + 1, e.RowIndex].Value.ToString();
                Servicio servicioDeMovimiento = GestorBBDD.buscarServPorNombre(tituloOferta);
                m.usuario_destino = servicioDeMovimiento.id_usuario;
                m.concepto = servicioDeMovimiento.id_servicio;

                using (var transferirTiempoForm = new TransferirTiempo())
                {
                    var resultado = transferirTiempoForm.ShowDialog();
                    if (resultado == DialogResult.OK)
                    {
                        m.comentarios = transferirTiempoForm.comentario;
                        m.horas = transferirTiempoForm.hora;
                    }
                }
                m.fecha = DateTime.Now;
                GestorBBDD.agregarMovimiento(m);

                Usuario usuarioOrigen = GestorBBDD.buscarUsuario(m.usuario_origen);
                Usuario usuarioDestino = GestorBBDD.buscarUsuario(m.usuario_destino);
                
                usuarioOrigen.balance = Decimal.Subtract(Convert.ToDecimal(usuarioOrigen.balance),Convert.ToDecimal(m.horas));
                usuarioDestino.balance = Decimal.Add(Convert.ToDecimal(usuarioDestino.balance), Convert.ToDecimal(m.horas));
                GestorBBDD.actualizarUsuario(usuarioOrigen);
                GestorBBDD.actualizarUsuario(usuarioDestino);

                label7.Text = String.Format("Saldo del usuario: {0} h", usuarioLogeado.balance);

                showMisMovimientos(dataGridView3);
            }
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                DialogResult dialogResult = MessageBox.Show("¿Aceptas la solicitud seleccionada?", "Estado de la solicitud recibida", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    var tituloOferta = this.dataGridView5[e.ColumnIndex + 1, e.RowIndex].Value.ToString();
                    Servicio servicioDeSolicitud = GestorBBDD.buscarServPorNombre(tituloOferta);
                    Solicitud sltd = GestorBBDD.buscarSolPorServicio(servicioDeSolicitud);
                    sltd.aceptada = true;
                    GestorBBDD.actualizarSolicitud(sltd);
                    GestorBBDD.eliminarSolicitud(sltd.id_solicitud);
                    showSolicitudesRecibidas(dataGridView5);
                }
                else if (dialogResult == DialogResult.No)
                {
                    var tituloOferta = this.dataGridView5[e.ColumnIndex + 1, e.RowIndex].Value.ToString();
                    Servicio servicioDeSolicitud = GestorBBDD.buscarServPorNombre(tituloOferta);
                    Solicitud sltd = GestorBBDD.buscarSolPorServicio(servicioDeSolicitud);
                    GestorBBDD.eliminarSolicitud(sltd.id_solicitud);
                    showSolicitudesRecibidas(dataGridView5);
                }
            }
        }

    }
}
