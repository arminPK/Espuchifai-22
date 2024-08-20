using System.Data;
using Espuchifai.Core;
using et12.edu.ar.AGBD.Ado;
using et12.edu.ar.AGBD.Mapeadores;

namespace Mapeador
{
    public class MapCancion : Mapeador<Cancion>
    {
        public MapCancion(AdoAGBD ado) : base(ado)
        {
            Tabla = "Cancion";
        }
        public override Cancion ObjetoDesdeFila(DataRow fila)
        => new Cancion()
        {
            idcancion = Convert.ToByte(fila["idcancion"]),
            nombre = Convert.ToString(fila["nombre"]),
            numorden = Convert.ToInt32(fila["numorden"]),
            cantidad = Convert.ToInt32(fila["cantidad"]),
            idalbum = Convert.ToByte(fila["idalbum"])
        };
        public void AltaCancion(Cancion cancion)
        => EjecutarComandoCon("AltaCancion", ConfigurarAltaCancion, PostAltaCancion, cancion);

        public void ConfigurarAltaCancion(Cancion cancion)
        {
            SetComandoSP("AltaCancion");

            BP.CrearParametro("unidcancion")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .SetValor(cancion.idcancion)
            .AgregarParametro();

            BP.CrearParametro("unnombre")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.String)
            .SetValor(cancion.nombre)
            .AgregarParametro();

            BP.CrearParametro("unnumorden")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .SetValor(cancion.numorden)
            .AgregarParametro();

            BP.CrearParametro("unacantidad")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .SetValor(cancion.cantidad)
            .AgregarParametro();

            BP.CrearParametro("unidalbum")
            .SetValor(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .SetValor(cancion.idalbum)
            .AgregarParametro();
        }
        public void PostAltaCancion(Cancion cancion)
        {
            var paramidcancion = GetParametro("unidcancion");
            cancion.idcancion = Convert.ToByte(paramidcancion.Value);
        }
        public Cancion CancionPorId(Byte idcancion)
        {
            SetComandoSP("CancionPorId");

            BP.CrearParametro("unidcancion")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .SetValor(idcancion)
            .AgregarParametro();

            return ElementoDesdeSP();
        }
        public List<Cancion> ObtenerCanciones() => ColeccionDesdeTabla();
    }
}