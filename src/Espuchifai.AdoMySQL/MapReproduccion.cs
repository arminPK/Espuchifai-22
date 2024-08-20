using System.Data;
using Espuchifai.Core;
using et12.edu.ar.AGBD.Ado;
using et12.edu.ar.AGBD.Mapeadores;

namespace Mapeador
{
    public class MapReproduccion : Mapeador<Reproduccion>
    {
        public MapReproduccion(AdoAGBD ado) : base(ado)
        {
            Tabla = "Reproduccion";
        }
        public override Reproduccion ObjetoDesdeFila(DataRow fila)
        => new Reproduccion()
        {
            idreproduccion = Convert.ToInt32(fila["idreproduccion"]),
            idcliente = Convert.ToInt32(fila["idcliente"]),
            idcancion = Convert.ToByte(fila["idcancion"]),
            momreproduccion = Convert.ToDateTime(fila["momreproduccion"]),
        };
        public void AltaReproduccion(Reproduccion reproduccion)
        => EjecutarComandoCon("AltaReproduccion", ConfigurarAltaReproduccion, PostAltaReproduccion, reproduccion);

        public void ConfigurarAltaReproduccion(Reproduccion reproduccion)
        {
            SetComandoSP("AltaReproduccion");

            BP.CrearParametro("unidreproduccion")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .SetValor(reproduccion.idreproduccion)
            .AgregarParametro();

            BP.CrearParametro("unidcliente")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .SetValor(Reproduccion.idcliente)
            .AgregarParametro();

            BP.CrearParametro("unidcancion")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .SetValor(reproduccion.idcancion)
            .AgregarParametro();

            BP.CrearParametro("unmomreproduccion")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.DateTime)
            .SetValor(reproduccion.momreproduccion)
            .AgregarParametro();
        }
        public void PostAltaReproduccion(Reproduccion reproduccion)
        {
            var paramidreproduccion = GetParametro("unidreproduccion");
            reproduccion.idreproduccion = Convert.ToInt32(paramidreproduccion.Value);
        }
        public Reproduccion ReproduccionPorId(int idreproduccion)
        {
            SetComandoSP("ReproduccionPorId");

            BP.CrearParametro("unidreproduccion")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .SetValor(idreproduccion)
            .AgregarParametro();

            return ElementoDesdeSP();
        }
        public List<Reproduccion> ObtenerReproducciones() => ColeccionDesdeTabla();
    }
}