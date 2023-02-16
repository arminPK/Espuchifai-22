using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Espuchifai.Core
{
    public class Album
    {
        public int idalbum { get; set; }
        public int idbanda { get; set; }
        public string Nombre { get; set; }
        public DateTime Lanzamiento { get; set; }
        piblic Album(int idAlbum, int idBanda, string nombre,DateTime lanzamiento)
        {
            this.idalbum=idAlbum;
            this.idbanda=idBanda;
            this.Nombre=nombre;
            this.Lanzamiento=lanzamiento;
        }
        //hhhh

    }
}