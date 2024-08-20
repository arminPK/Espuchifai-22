using System.Data;
using Espuchifai.Core;
using et12.edu.ar.AGBD.Ado;
using et12.edu.ar.AGBD.Mapeadores;

namespace Mapeador
{
    public class MapCliente : Mapeador<Cliente>
    {
        public MapCliente(AdoAGBD ado) : base(ado)
        {
            Tabla = "Cliente";
        }
        public override Cliente ObjetoDesdeFila(DataRow fila)
            => new Cliente()
            {
                idcliente = Convert.ToInt32(fila["idcliente"]),
                nombre = Convert.ToString(fila["nombre"]),
                apellido = Convert.ToString(fila["apellido"]),
                email = Convert.ToString(fila["email"]),
                contrasenia = Convert.ToString(fila["contrasenia"])
            };
        public void AltaCliente(Cliente cliente)
    => EjecutarComandoCon("RegistrarCliente", ConfigurarAltaCliente, cliente);

        public void ConfigurarAltaCliente(Cliente cliente)
        {
            SetComandoSP("RegistrarCliente");

            BP.CrearParametro("unidcliente")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .SetValor(cliente.idcliente)
            .AgregarParametro();

            BP.CrearParametro("unnombre")
            .SetTipoVarchar(50)
            .SetValor(cliente.nombre)
            .AgregarParametro();

            BP.CrearParametro("unapellido")
            .SetTipoVarchar(50)
            .SetValor(cliente.apellido)
            .AgregarParametro();

            BP.CrearParametro("unemail")
            .SetTipoVarchar(50)
            .SetValor(cliente.emailail)
            .AgregarParametro();

            BP.CrearParametro("unacontrasenia")
            .SetTipoVarchar(50)
            .SetValor(cliente.contrasenia)
            .AgregarParametro();
        }
        public Cliente ClienteporId(int idcliente)
        {
            SetComandoSP("ClienteporId");

            BP.CrearParametro("unidcliente")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .SetValor(idcliente)
            .AgregarParametro();

            return ElementoDesdeSP();
        }
        public Cliente? BuscarCliente(string email, string contrasenia)
        {
            SetComandoSP("BuscarCliente");

            BP.CrearParametro("unemail")
            .SetTipoVarchar(60)
            .SetValor(email)
            .AgregarParametro();


            BP.CrearParametro("unacontrasenia")
                .SetTipoVarchar(64)
                .SetValor(contrasenia)
                .AgregarParametro();

            Cliente? cliente;

            try
            {
                cliente = ElementoDesdeSP();
            }
            catch (System.Exception)
            {
                cliente = null;
            }

            return cliente;

        }

        public List<Cliente> RegistrarClientes() => ColeccionDesdeTabla();
    }
}