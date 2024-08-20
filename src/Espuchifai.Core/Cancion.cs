using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Espuchifai.Core
{
    public class Cancion
    {   
        public byte idcancion { get; set; }       
        public string nombre { get; set; }
        public int numorden { get; set; }
        public int cantidad { get; set; }
        public byte idalbum { get; set; }
        public Cancion(byte idcancion, string nombre, int numorden, int cantidad, byte idalbum)
        {   
            this.idcancion = idcancion;
            this.nombre = nombre;
            this.numorden = numorden;
            this.cantidad = cantidad;
            this.idalbum = idalbum;
        }
        public Cancion()
        {

        }
    }
}