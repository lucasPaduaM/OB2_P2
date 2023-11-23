using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.NetWork.Dominio
{
    public class Post : Publicacion
    {
        private static int contadorId = -1;

        public EstadoAdmin estadoAdmin { get; set; }
        public int likes { get; set; }
        public int dislikes { get; set; }

        public int id { get; }
        public int valorDeAceptacion { get; set; }
        public string imagen { get; set; }

        private List<Comentario> _listaComentarios = new List<Comentario>();

        public List<Comentario> GetComentarios()
        {
            return this._listaComentarios;
        }

        public List<Reaccion> listaReacciones = new List<Reaccion>();

        public List<Reaccion> GetReacciones()
        {
            return this.listaReacciones;
        }

        public EstadoPost estado { get; set; }

        private static Post instancia;

        public static Post Instancia

        {
            get
            {
                if (instancia == null)
                {
                    instancia = new Post();
                }
                return instancia;
            }
        }
        public Post()
        {
            this._listaComentarios = new List<Comentario>();
            this.fecha = DateTime.Now;
            contadorId++;
            this.id = contadorId;
            this.estadoAdmin = EstadoAdmin.NO_BANEADO;
        }
        public Post(DateTime fecha, Miembro autor, string titulo, string contenido, string imagen, EstadoPost estado, EstadoAdmin estadoAdmin = EstadoAdmin.NO_BANEADO)
        {
            contadorId++;
            id = contadorId;
            this.fecha = fecha;
            this.titulo = titulo;
            this.contenido = contenido;
            this.autor = autor;
            this.imagen = imagen;
            this.estado = estado;
            this.estadoAdmin = estadoAdmin;
        }
        public bool YaReacciono(Miembro miembro)
        {
            bool yaReacciono = false;
            try
            {
                foreach (Reaccion reaccion in listaReacciones)
                {
                    if (reaccion.miembroReaccion.Equals(miembro))
                    {
                        yaReacciono = true;
                    }
                }
            }
            catch (Exception)
            {
                yaReacciono = false;
            }
            return yaReacciono;
        }

        public Reaccion GetUltimaReaccion(Miembro miembro)
        {
            Reaccion reaccionTemp = new Reaccion();
            foreach (Reaccion reaccion in listaReacciones)
            {
                if (reaccion.miembroReaccion.Equals(miembro))
                {
                    reaccionTemp = reaccion;
                }
            }
            return reaccionTemp;
        }

        public int GetPosReaccion(Miembro miembro)
        {
            int pos = 0;
            foreach (Reaccion reaccion in listaReacciones)
            {
                if (reaccion.miembroReaccion.Equals(miembro))
                {
                    return pos;
                }
                pos++;
            }
            return pos;
        }

        public bool DioMeGusta(Miembro usuarioLogueado)
        {
            bool dioMeGusta = false;
            foreach (Reaccion reaccion in listaReacciones)
            {
                if (reaccion.miembroReaccion.Equals(usuarioLogueado) && reaccion.TipoReaccion == Reacciones.Like)
                {
                    dioMeGusta = true;
                }
            }
            return dioMeGusta;
        }
        public int CalcularVA(int l, int d)
        {
            int VA = (l * 5) + (d * -2);
            if (this.estado == EstadoPost.PUBLICO)
            {
                VA += 10;
            }
            return VA;
        }
    }
}