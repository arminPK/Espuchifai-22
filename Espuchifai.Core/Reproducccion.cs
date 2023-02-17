using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Espuchifai.Core
{
    public class Reproduccion
    {
        public int idcliente{get; set;}
        public int idcancion{get; set;}
        public DateTime reproduccion{get; set;}
        public Reproduccion(int idCliente,int idCancion, DateTime Reproduccion)
        {
            this.idcancion=idCancion;
            this.idcliente=idCliente;
            this.reproduccion=Reproduccion;
        }
        
    }
}