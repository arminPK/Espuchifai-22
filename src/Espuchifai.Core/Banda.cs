using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Espuchifai.Core
{
    public class Banda
    {   
        public short idbanda { get; set; }       
        public string nombre { get; set; }
        public int fundacion { get; set; }
        public Banda(short idbanda, string nombre, int fundacion)
        {   
            this.idbanda = idbanda;
            this.nombre = nombre;
            this.fundacion = fundacion;
        }
        public Banda()
        {

        }
    }
}