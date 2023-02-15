using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Espuchifai.Core
{
    public class Banda
    {
        public int idBanda;
        public string Nombre;
        public int Fundacion;
        public Banda(int idbanda, string nombre, int fundacion)
        {
            this.idBanda=idbanda;
            this.Nombre=nombre;
            this.Fundacion=fundacion;
        }
    }
}