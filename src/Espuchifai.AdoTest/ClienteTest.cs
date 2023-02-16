using Espuchifai.Core;
using et12.edu.ar.AGBD.Ado;

namespace Espuchifai.adoET12.Test
{
    public class ClienteTests
    {
        public AdoEspuchifai Ado { get; set; }
        public ClienteTests()
        {
            var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
            Ado = new(adoAGBD);
        }

        [Fact]
        public void registrarCliente()
        {
            var Cliente = new Cliente("Armin", "Mercado", "armin.mercadoet12d1@gmail.com", "xd", 2);
            Ado.registrarCliente(Cliente);
            Assert.Equal((uint)2, Cliente.IdCliente);
        }

        [Fact]
        public void TraerClientes()
        {
            var Clientes = Ado.ObtenerClientes();
            Assert.Contains(Clientes, x => x.Contrasenia == ("xd") && x.Email == ("armin.mercadoet12d1@gmail.com"));
        }
    }
}