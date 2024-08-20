using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Espuchifai.Core
{
    public class Album
    {   
        public byte idalbum { get; set; }       
        public string nombre { get; set; }
        public datetime lanzamiento { get; set; }
        public int cantidad { get; set; }
        public short idbanda { get; set; }
        public Album(byte idalbum, string nombre, datetime lanzamiento, int cantidad, short idbanda)
        {   
            this.idcancion = idcancion;
            this.nombre = nombre;
            this.lanzamiento = lanzamiento;
            this.cantidad = cantidad;
            this.idbanda = idbanda;
        }
        public Album()
        {

        }
    }
}