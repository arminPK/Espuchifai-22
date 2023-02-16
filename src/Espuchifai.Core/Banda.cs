using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Espuchifai.Core
{
    public class Banda
    {
        public int idBanda { get; set; }
        public string Nombre { get; set; }
        public int Fundacion { get; set; }
        public Banda(int idbanda, string nombre, int fundacion)
        {
            this.idBanda=idbanda;
            this.Nombre=nombre;
            this.Fundacion=fundacion;
        }
    }
}