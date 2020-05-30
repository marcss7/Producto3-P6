using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace BancoDeTiempo
{
    //Formulario principal donde se desarrolla toda la lógica de la aplicación
    public partial class Main : Form
    {
        //Variables para abrir formularios
        MostrarFactura mostrarFacturaForm;
        Form1 cerrarSesion;

        //Obtenemos el usuario autenticado en el formulario Form1
        Usuario usuarioLogeado = Program.usuarioAutenticado;

        static btEntities bte = new btEntities(); //Contexto Entity Framework
        private static Random random = new Random(); //Utilizado para la función RandomString

        //Variables públicas para pasar valores al formulario hijo MostrarFactura
        public static string MF_id_factura { get; set; }
        public static string MF_usuario_emisor { get; set; }
        public static string MF_usuario_receptor { get; set; }
        public static string MF_concepto { get; set; }
        public static double MF_importe { get; set; }
        public static Nullable<System.DateTime> MF_fecha { get; set; }

        public Main()
        {
            InitializeComponent();

            //Definir estilo sin borde de los botones
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.FlatAppearance.BorderSize = 0;

            label1.Text = String.Format("Usuario autenticado: {0}", usuarioLogeado.nombre_usuario); //Label que muestra el usuario autenticado en Form1
            label7.Text = String.Format("Saldo del usuario: {0} h", usuarioLogeado.balance); //Label que muestra el saldo del usuario autenticado

            //Muestra los datos fuente asignados a cada dataGridView
            showOfertasPublicadas(dataGridView1);
            showMisOfertas(dataGridView2);
            showMisMovimientos(dataGridView3);
            showSolicitudesEnviadas(dataGridView4);
            showSolicitudesRecibidas(dataGridView5);
        }

        //Función que genera una cadena alfanumérica aleatoria de la longitud determinada
        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        //Función que muestra las ofertas publicadas por todos los usuarios menos las creadas por el usuario autenticado
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

        //Función que muestra las ofertas publicadas por el usuario autenticado
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

        //Función que muestra los movimientos creados por el usuario autenticado
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

        //Función que muestra las solicitudes enviadas por el usuario autenticado
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

        //Función que muestra las solicitudes que ha recibido el usuario autenticado
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
            //Si cierras la ventana se sale de la aplicación
            System.Windows.Forms.Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Ocultamos el formulario Main y mostramos el formulario Form1
            cerrarSesion = new Form1();
            cerrarSesion.Show();
            this.Hide();
        }

        //Botón con el que crearemos ofertas
        private void button2_Click(object sender, EventArgs e)
        {
            Servicio s = new Servicio();
            s.id_servicio = RandomString(10);
            s.id_usuario = usuarioLogeado.id_usuario;
            s.fecha_creacion = DateTime.Now;

            using (var crearOfertaForm = new CrearOferta()) //Abrimos formulario hijo CrearOferta
            {
                var resultado = crearOfertaForm.ShowDialog();
                if (resultado == DialogResult.OK) //Si el formulario hijo devuelve una respuesta...
                {
                    s.titulo = crearOfertaForm.titulo;
                    s.descripcion = crearOfertaForm.descripcion;
                    s.id_categoria = crearOfertaForm.categoria;
                    s.tipo_servicio = crearOfertaForm.tipoServicio;
                    GestorBBDD.agregarServicio(s);
                }
            }
            //Refresca mis ofertas publicadas
            showMisOfertas(dataGridView2);
        }

        //Botón con el que enviaremos solicitudes
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0) //Si hay alguna fila seleccionada (Multiselect = false)
            {
                DataGridViewRow fila = this.dataGridView1.SelectedRows[0]; //Obtenemos la fila seleccionada (FullRowSelect)
                Solicitud sltd = new Solicitud();
                sltd.id_solicitud = RandomString(10);
                sltd.id_emisor = usuarioLogeado.id_usuario;

                //Obtenemos el objeto solicitud a través del titulo de la oferta
                var tituloOferta = fila.Cells["titulo"].Value.ToString();
                Servicio servicioDeSolicitud = GestorBBDD.buscarServPorNombre(tituloOferta);
                sltd.concepto = servicioDeSolicitud.id_servicio;

                sltd.fecha_creacion = DateTime.Now;
                sltd.aceptada = false; //Por defecto las solicitudes se crean como no aceptadas
                GestorBBDD.agregarSolicitud(sltd);

                //Refresca las solicitudes enviadas
                showSolicitudesEnviadas(dataGridView4);
            }
        }

        //Botón con el que creamos y mostramos facturas
        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count != 0) //Si hay alguna fila seleccionada (Multiselect = false)
            {
                DataGridViewRow fila = this.dataGridView3.SelectedRows[0]; //Obtenemos la fila seleccionada (FullRowSelect)
                Factura f = new Factura();
                f.id_factura = RandomString(10);
                f.usuario_emisor = usuarioLogeado.id_usuario;

                //Obtenemos el objeto servicio a través del titulo de la oferta
                var tituloOferta = fila.Cells["titulo"].Value.ToString();
                Servicio servicioDeFactura = GestorBBDD.buscarServPorNombre(tituloOferta);
                f.usuario_receptor = servicioDeFactura.id_usuario;
                f.concepto = servicioDeFactura.id_servicio;

                //Obtenemos el objeto movimiento a través del ID de la oferta
                Movimiento movimientoDeFactura = GestorBBDD.buscarMovPorServicio(servicioDeFactura.id_servicio, usuarioLogeado.id_usuario);
                f.usuario_receptor = movimientoDeFactura.usuario_destino;
                f.importe = movimientoDeFactura.horas;

                f.fecha = DateTime.Now;
                GestorBBDD.agregarFactura(f);

                //Obtenemos los objetos de los usuarios emisor y receptor de la factura a través de su ID
                Usuario usuarioEmisor = GestorBBDD.buscarUsuario(f.usuario_emisor);
                Usuario usuarioReceptor = GestorBBDD.buscarUsuario(f.usuario_receptor);

                //Asignamos los valores de la factura a las variables públicas que mostraremos en el formulario MostrarFactura
                MF_id_factura = f.id_factura;
                MF_usuario_emisor = usuarioEmisor.nombre_usuario;
                MF_usuario_receptor = usuarioReceptor.nombre_usuario;
                MF_concepto = servicioDeFactura.titulo;
                MF_importe = f.importe;
                MF_fecha = f.fecha;

                //Mostramos el formulario MostrarFactura
                mostrarFacturaForm = new MostrarFactura();
                mostrarFacturaForm.ShowDialog();
                   
            }
        }

        //Botón con el que aceptaremos o rechazaremos las solicitudes recibidas
        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView5.SelectedRows.Count != 0) //Si hay alguna fila seleccionada (Multiselect = false)
            {
                DataGridViewRow fila = this.dataGridView5.SelectedRows[0]; //Obtenemos la fila seleccionada (FullRowSelect)

                //Muestra un mensaje sobre aceptar la solicitud seleccionada al pulsar el botón
                DialogResult dialogResult = MessageBox.Show("¿Aceptas la solicitud seleccionada?", "Estado de la solicitud recibida", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes) //Si pulsas sí...
                {
                    //Obtenemos el objeto servicio a través del titulo de la oferta
                    var tituloOferta = fila.Cells["titulo"].Value.ToString();
                    Servicio servicioDeSolicitud = GestorBBDD.buscarServPorNombre(tituloOferta);

                    //Obtenemos el objeto solicitud a través del titulo de la oferta
                    Solicitud sltd = GestorBBDD.buscarSolPorServicio(servicioDeSolicitud);
                    sltd.aceptada = true; //Aceptamos la solicitud

                    //Actualizamos el registro en la base de datos
                    GestorBBDD.actualizarSolicitud(sltd);

                    //Refresca las solicitudes recibidas
                    showSolicitudesRecibidas(dataGridView5);
                }
                else if (dialogResult == DialogResult.No) //Si pulsas no...
                {
                    //Obtenemos el objeto servicio a través del titulo de la oferta
                    var tituloOferta = fila.Cells["titulo"].Value.ToString();
                    Servicio servicioDeSolicitud = GestorBBDD.buscarServPorNombre(tituloOferta);

                    //Obtenemos el objeto solicitud a través del titulo de la oferta
                    Solicitud sltd = GestorBBDD.buscarSolPorServicio(servicioDeSolicitud);
                    sltd.aceptada = false; //Rechazamos la solicitud

                    //Actualizamos el registro en la base de datos
                    GestorBBDD.actualizarSolicitud(sltd);

                    //Refresca las solicitudes recibidas
                    showSolicitudesRecibidas(dataGridView5);
                }
            }
        }

        //Botón con el que transferimos tiempo
        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView4.SelectedRows.Count != 0) //Si hay alguna fila seleccionada (Multiselect = false)
            {
                DataGridViewRow fila = this.dataGridView4.SelectedRows[0]; //Obtenemos la fila seleccionada (FullRowSelect)
                Movimiento m = new Movimiento();
                m.id_movimiento = RandomString(10);
                m.usuario_origen = usuarioLogeado.id_usuario;

                //Obtenemos el objeto servicio a través del titulo de la oferta
                var tituloOferta = fila.Cells["titulo"].Value.ToString();
                Servicio servicioDeMovimiento = GestorBBDD.buscarServPorNombre(tituloOferta);
                m.usuario_destino = servicioDeMovimiento.id_usuario;
                m.concepto = servicioDeMovimiento.id_servicio;

                using (var transferirTiempoForm = new TransferirTiempo()) //Abrimos formulario hijo TransferirTiempo
                {
                    var resultado = transferirTiempoForm.ShowDialog();
                    if (resultado == DialogResult.OK) //Si el formulario hijo devuelve una respuesta...
                    {
                        m.comentarios = transferirTiempoForm.comentario;
                        m.horas = transferirTiempoForm.hora;
                        m.fecha = DateTime.Now;
                        GestorBBDD.agregarMovimiento(m);

                        //Obtenemos los objetos de los usuarios origen y destino del movimiento a través de su ID
                        Usuario usuarioOrigen = GestorBBDD.buscarUsuario(m.usuario_origen);
                        Usuario usuarioDestino = GestorBBDD.buscarUsuario(m.usuario_destino);

                        //Restamos al saldo del usuario autenticado el importe establecido
                        usuarioOrigen.balance = Decimal.Subtract(Convert.ToDecimal(usuarioOrigen.balance), Convert.ToDecimal(m.horas));
                        //Sumamos al saldo del usuario destinatario el importe establecido
                        usuarioDestino.balance = Decimal.Add(Convert.ToDecimal(usuarioDestino.balance), Convert.ToDecimal(m.horas));

                        //Actualizamos los registros en la base de datos
                        GestorBBDD.actualizarUsuario(usuarioOrigen);
                        GestorBBDD.actualizarUsuario(usuarioDestino);
                    }
                }

                //Refresca el label con la actualización del saldo del usuario autenticado
                label7.Text = String.Format("Saldo del usuario: {0} h", usuarioLogeado.balance);

                //Refresca mis movimientos realizados
                showMisMovimientos(dataGridView3);
            }
        }
    }
}
