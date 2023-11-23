using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.NetWork.Dominio
{
    public class Publicacion
    {

        private static int id { get; set; }

        public string titulo { get; set; }

        public DateTime fecha { get; set; }

        public Miembro autor { get; set; }

        public string contenido { get; set; }

        public int GetId()
        {
            return id;
        }

        public string GetTitulo()
        {
            return titulo;
        }

        public string GetContenido()
        {
            return contenido;
        }

        public DateTime GetFecha()
        {
            return fecha;
        }

        public Miembro GetAutor()
        {
            return autor;
        }

        public void SetId()
        {
            id++;
        }

        public void SetTitulo(string titulo)
        {
            this.titulo = titulo;
        }

        public void SetFecha(DateTime _fecha)
        {
            this.fecha = _fecha;
        }

        public void SetAutor(Miembro autor)
        {
            this.autor = autor;
        }

        public void SetContenido(string contenido)
        {
            this.contenido = contenido;
        }

    }
}
