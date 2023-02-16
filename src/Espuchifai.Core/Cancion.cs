using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Espuchifai.Core
{
    public class Cancion
    {
        public int idalbum{get; set;}
        public int idcancion{get; set;}
        public string Nombre{get; set;}
        public int Posicion{get; set;}
        public int Cantidad{get; set;}
        public Cancion(int idAlbum, int idCancion, string nombre, int posicion, int cantidad)
        {
            this.idalbum=idAlbum;
            this.idcancion=idCancion;
            this.Nombre=nombre;
            this.Posicion=posicion;
            this.Cantidad=cantidad;
        }
        
    }
}