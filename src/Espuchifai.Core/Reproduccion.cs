using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Espuchifai.Core
{
    public class Reproduccion
    {   
        public int idreproduccion { get; set; }       
        public int idcliente { get; set; }
        public byte idcancion { get; set; }
        public datetime momreproduccion { get; set; }
        public Reproduccion(int idreproduccion, int idcliente, byte idcancion, datetime momreproduccion)
        {   
            this.idreproduccion = idreproduccion;
            this.idcliente = idcliente;
            this.idcancion = idcancion;
            this.momreproduccion = momreproduccion;
        }
        public Reproduccion()
        {

        }
    }
}