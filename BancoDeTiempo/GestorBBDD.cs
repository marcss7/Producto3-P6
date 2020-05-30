using System;
using System.Linq;

namespace BancoDeTiempo
{
    //Clase que implementa la capa de acceso a los datos almacenados en la base de datos
    class GestorBBDD
    {
        static btEntities bte = new btEntities();

        // CATEGORIAS
        public static void agregarCategoria(Categoria c)
        {
            bte.categorias.Add(c);
            bte.SaveChanges();
        }

        public static Categoria buscarCategoria(String id)
        {
            return bte.categorias.Find(id);
        }

        public static Categoria buscarCatPorNombre(String nombre)
        {
            //Da un único resultado de la búsqueda, si hay más de un resultado, lanza una excepción
            Categoria c = bte.categorias.SingleOrDefault(categoria => categoria.nombre_categoria == nombre);
            return c;
        }

        public static void actualizarCategoria(Categoria c)
        {
            bte.categorias.Attach(c);
            var entry = bte.Entry(c);
            entry.Property(e => e.id_categoria).IsModified = true;
            entry.Property(e => e.nombre_categoria).IsModified = true;
            entry.Property(e => e.ruta_imagen).IsModified = true;
            bte.SaveChanges();
        }

        public static void eliminarCategoria(String id)
        {
            Categoria c = new Categoria();
            c = buscarCategoria(id);
            bte.categorias.Remove(c);
            bte.SaveChanges();
        }

        // FACTURAS
        public static void agregarFactura(Factura f)
        {
            bte.facturas.Add(f);
            bte.SaveChanges();
        }

        public static Factura buscarFactura(String id)
        {
            return bte.facturas.Find(id);
        }

        public static void actualizarFactura(Factura f)
        {
            bte.facturas.Attach(f);
            var entry = bte.Entry(f);
            entry.Property(e => e.id_factura).IsModified = true;
            entry.Property(e => e.usuario_emisor).IsModified = true;
            entry.Property(e => e.usuario_receptor).IsModified = true;
            entry.Property(e => e.concepto).IsModified = true;
            entry.Property(e => e.importe).IsModified = true;
            entry.Property(e => e.fecha).IsModified = true;
            bte.SaveChanges();
        }

        public static void eliminarFactura(String id)
        {
            Factura f = new Factura();
            f = buscarFactura(id);
            bte.facturas.Remove(f);
            bte.SaveChanges();
        }

        // MOVIMIENTOS
        public static void agregarMovimiento(Movimiento m)
        {
            bte.movimientos.Add(m);
            bte.SaveChanges();
        }

        public static Movimiento buscarMovimiento(String id)
        {
            return bte.movimientos.Find(id);
        }

        public static Movimiento buscarMovPorServicio(String id_servicio, String id_usuario)
        {
            //Busca el movimiento por concepto y por el usuario de origen, implementado para repetir facturas de un mismo servicio
            Movimiento m = bte.movimientos.Where(movimiento => movimiento.concepto == id_servicio).SingleOrDefault(movimiento => movimiento.usuario_origen == id_usuario);
            return m;
        }

        public static void actualizarMovimiento(Movimiento m)
        {
            bte.movimientos.Attach(m);
            var entry = bte.Entry(m);
            entry.Property(e => e.id_movimiento).IsModified = true;
            entry.Property(e => e.usuario_origen).IsModified = true;
            entry.Property(e => e.usuario_destino).IsModified = true;
            entry.Property(e => e.concepto).IsModified = true;
            entry.Property(e => e.comentarios).IsModified = true;
            entry.Property(e => e.horas).IsModified = true;
            entry.Property(e => e.fecha).IsModified = true;
            bte.SaveChanges();
        }

        public static void eliminarMovimiento(String id)
        {
            Movimiento m = new Movimiento();
            m = buscarMovimiento(id);
            bte.movimientos.Remove(m);
            bte.SaveChanges();
        }

        // SOLICITUDES
        public static void agregarSolicitud(Solicitud s)
        {
            bte.solicitudes.Add(s);
            bte.SaveChanges();
        }

        public static Solicitud buscarSolicitud(String id)
        {
            return bte.solicitudes.Find(id);
        }

        public static Solicitud buscarSolPorServicio(Servicio servicio)
        {
            //Da un único resultado de la búsqueda, si hay más de un resultado, lanza una excepción
            Solicitud sltd = bte.solicitudes.Where(solicitud => solicitud.concepto == servicio.id_servicio).SingleOrDefault();
            return sltd;
        }

        public static void actualizarSolicitud(Solicitud s)
        {
            bte.solicitudes.Attach(s);
            var entry = bte.Entry(s);
            entry.Property(e => e.id_solicitud).IsModified = true;
            entry.Property(e => e.id_emisor).IsModified = true;
            entry.Property(e => e.concepto).IsModified = true;
            entry.Property(e => e.fecha_creacion).IsModified = true;
            entry.Property(e => e.aceptada).IsModified = true;
            bte.SaveChanges();
        }

        public static void eliminarSolicitud(String id)
        {
            Solicitud s = new Solicitud();
            s = buscarSolicitud(id);
            bte.solicitudes.Remove(s);
            bte.SaveChanges();
        }

        // SERVICIOS
        public static void agregarServicio(Servicio s)
        {
            bte.servicios.Add(s);
            bte.SaveChanges();
        }

        public static Servicio buscarServicio(String id)
        {
            return bte.servicios.Find(id);
        }

        public static Servicio buscarServPorNombre(String nombre)
        {
            //Da un único resultado de la búsqueda, si hay más de un resultado, lanza una excepción
            Servicio s = bte.servicios.SingleOrDefault(servicio => servicio.titulo == nombre);
            return s;
        }

        public static void actualizarServicio(Servicio s)
        {
            bte.servicios.Attach(s);
            var entry = bte.Entry(s);
            entry.Property(e => e.id_servicio).IsModified = true;
            entry.Property(e => e.titulo).IsModified = true;
            entry.Property(e => e.descripcion).IsModified = true;
            entry.Property(e => e.id_usuario).IsModified = true;
            entry.Property(e => e.id_categoria).IsModified = true;
            entry.Property(e => e.fecha_creacion).IsModified = true;
            entry.Property(e => e.tipo_servicio).IsModified = true;
            bte.SaveChanges();
        }

        public static void eliminarServicio(String id)
        {
            Servicio s = new Servicio();
            s = buscarServicio(id);
            bte.servicios.Remove(s);
            bte.SaveChanges();
        }

        // TIPO_SERVICIO
        public static void agregarTipoServicio(TipoServicio ts)
        {
            bte.tipo_servicio.Add(ts);
            bte.SaveChanges();
        }

        public static TipoServicio buscarTipoServicio(String id)
        {
            return bte.tipo_servicio.Find(id);
        }

        public static TipoServicio buscarTipoPorNombre(String nombre)
        {
            //Da un único resultado de la búsqueda, si hay más de un resultado, lanza una excepción
            TipoServicio ts = bte.tipo_servicio.SingleOrDefault(t_servicio => t_servicio.tipo_servicio == nombre);
            return ts;
        }

        public static void actualizarTipoServicio(TipoServicio ts)
        {
            bte.tipo_servicio.Attach(ts);
            var entry = bte.Entry(ts);
            entry.Property(e => e.id_tipo_servicio).IsModified = true;
            entry.Property(e => e.tipo_servicio).IsModified = true;
            bte.SaveChanges();
        }

        public static void eliminarTipoServicio(String id)
        {
            TipoServicio ts = new TipoServicio();
            ts = buscarTipoServicio(id);
            bte.tipo_servicio.Remove(ts);
            bte.SaveChanges();
        }

        // USUARIOS
        public static void agregarUsuario(Usuario u)
        {
            bte.usuarios.Add(u);
            bte.SaveChanges();
        }

        public static Usuario buscarUsuario(String id)
        {
            return bte.usuarios.Find(id);
        }

        public static Usuario buscarUserPorNombre(String nombre)
        {
            //Da un único resultado de la búsqueda, si hay más de un resultado, lanza una excepción
            Usuario u = bte.usuarios.SingleOrDefault(usuario => usuario.nombre_usuario == nombre);
            return u;
        }

        public static void actualizarUsuario(Usuario u)
         {
            bte.usuarios.Attach(u);
            var entry = bte.Entry(u);
            entry.Property(e => e.id_usuario).IsModified = true;
            entry.Property(e => e.nombre_usuario).IsModified = true;
            entry.Property(e => e.pass).IsModified = true;
            entry.Property(e => e.alias).IsModified = true;
            entry.Property(e => e.descripcion).IsModified = true;
            entry.Property(e => e.email).IsModified = true;
            entry.Property(e => e.telefono).IsModified = true;
            entry.Property(e => e.fecha_nacimiento).IsModified = true;
            entry.Property(e => e.balance).IsModified = true;
            bte.SaveChanges();
        }

        public static void eliminarUsuario(String id)
        {
            Usuario u = new Usuario();
            u = buscarUsuario(id);
            bte.usuarios.Remove(u);
            bte.SaveChanges();
        }

        public static void listarUsuarios()
        {
            var users = bte.usuarios;
        }

    }
}
