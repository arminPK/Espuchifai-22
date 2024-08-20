using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Espuchifai.Core
{
    public class Cliente
    {   
        public int idcliente { get; set; }       
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }
        public string contrasenia { get; set; }
        public Cliente(int idcliente, string nombre, string apellido, string email, string contrasenia)
        {   
            this.idcliente = idcliente;
            this.nombre = nombre;
            this.apellido = apellido;
            this.email = email;
            this.contrasenia = contrasenia;
        }
        public Cliente()
        {

        }
    }
}