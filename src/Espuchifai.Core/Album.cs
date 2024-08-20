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
        public DateTime lanzamiento { get; set; }
        public int cantidad { get; set; }
        public short idbanda { get; set; }
        public Album(byte idalbum, string nombre, DateTime lanzamiento, short idbanda)
        {   
            this.idalbum = idalbum;
            this.nombre = nombre;
            this.lanzamiento = lanzamiento;
            this.cantidad = cantidad;
            this.idbanda = idbanda;
        }
        public Album()
        {

        }

        public Album(int v1, string v2, string v3, int v4)
        {
        }
    }
}