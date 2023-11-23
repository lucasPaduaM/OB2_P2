using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.NetWork.Dominio
{
    public class Comentario : Publicacion
    {
        private static int contadorId = -1;
        public int id { get; }

        public Comentario() 
        {
            contadorId++;
            id = contadorId;
            this.SetId();
        } 
        public Comentario(string titulo, DateTime fecha, Miembro autor, string contenido)
        {
            contadorId++;
            id = contadorId;
            this.SetId();
            this.SetTitulo(titulo);
            this.SetFecha(fecha);
            this.SetAutor(autor);
            this.SetContenido(contenido);
        }
    }
}