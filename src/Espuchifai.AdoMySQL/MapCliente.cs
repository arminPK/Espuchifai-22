using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System.Data;
using Espuchifai.Core;

namespace Espuchifai.AdoMySQL.Mapeadores
{
    public class MapCliente : Mapeador<Cliente>
    {
        public MapCliente(AdoAGBD ado) : base(ado)
        {
            Tabla = "Cliente";
        }
        public override Cliente ObjetoDesdeFila(DataRow fila)
            => new Cliente
            (
                idCliente: Convert.ToUInt32(fila["idCliente"]),
                nombre: fila["nombre"].ToString()!,
                apellido: fila["apellido"].ToString()!,
                contrasenia: fila["contrasenia"].ToString()!,
                email: fila["email"].ToString()!
            );
        public void registrarCliente(Cliente Cliente)
                => EjecutarComandoCon("registrarCliente", ConfigurarRegistrarCliente, postRegistrarCliente, Cliente);

        public void ConfigurarRegistrarCliente(Cliente Cliente)
        {
            SetComandoSP("registrarCliente");

            BP.CrearParametroSalida("unidCliente")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt32)
            .AgregarParametro();

            BP.CrearParametro("unNombre")
            .SetTipoVarchar(45)
            .SetValor(Cliente.Nombre)
            .AgregarParametro();

            BP.CrearParametro("unApellido")
            .SetTipoVarchar(45)
            .SetValor(Cliente.Apellido)
            .AgregarParametro();

            BP.CrearParametro("unaContrasenia")
            .SetTipoVarchar(45)
            .SetValor(Cliente.Contrasenia)
            .AgregarParametro();

            BP.CrearParametro("unEmail")
            .SetTipoVarchar(45)
            .SetValor(Cliente.Email)
            .AgregarParametro();

        }
        public void postRegistrarCliente(Cliente Cliente)
        {
            var paramiCliente = GetParametro("unidCliente");
            Cliente.IdCliente = Convert.ToUInt32(paramiCliente.Value);
        }
        public List<Cliente> ObtenerClientes() => ColeccionDesdeTabla();


        public Cliente? ObtenerClientes(Cliente Cliente)
        {
            SetComandoSP("TraerCliente");

            BP.CrearParametro("unaContrasenia")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt32)
            .SetValor(Cliente.Contrasenia)
            .AgregarParametro();

            BP.CrearParametro("unEmail")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt32)
            .SetValor(Cliente.Email)
            .AgregarParametro();


            return ElementoDesdeSP();

        }


    }

}