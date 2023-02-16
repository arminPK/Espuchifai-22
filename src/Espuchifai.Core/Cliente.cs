using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Espuchifai.Core
{
    public class Cliente
    {
        public int idcliente{get; set;}
        public string nombre{get; set;}
        public string apellido{get; set;}
        public string email{get; set;}
        public string contrasenia{get; set;}
        public Cliente(int idCliente, string Nombre, string Apellido, string Email, string Contrasenia)
        {
            this.idcliente=idCliente;
            this.nombre=Nomnre;
            this.apellido=Apellido;
            this.email=Email;
            this.contrasenia=Contrasenia;
        }
    }
}