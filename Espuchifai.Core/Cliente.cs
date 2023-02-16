using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Espuchifai.Core
{
    public class Cliente
    {
        public int idcliente{get; set;}
        public string Nombre{get; set;}
        public string Apellido{get; set;}
        public string Email{get; set;}
        public string Contrasenia{get; set;}
        public Cliente(int idCliente, string nombre, string apellido, string email, string contrasenia)
        {
            this.idcliente=idCliente;
            this.Nombre=nomnre;
            this.Apellido=apellido;
            this.Email=email;
            this.Contrasenia=contrasenia;
        }
    }
}