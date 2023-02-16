using System.Data;
using Espuchifai.Core;
using et12.edu.ar.AGBD.Ado;
using et12.edu.ar.AGBD.Mapeadores;

namespace Espuchifai.AdoMySQL.Mapeadores
{
    public class MapCancion : Mapeador<Cancion>
    {
        public MapCancion(AdoAGBD ado) : base(ado)
        {
            Tabla = "Cancion";
        }
        public override Cancion ObjetoDesdeFila(DataRow fila)
            => new Cancion
            (
                idCancion: Convert.ToUInt32(fila["idCancion"]),
                nombre: fila["nombre"].ToString()!,
                posicion: Convert.ToUInt32(fila["posicion"]),
                cantidad: Convert.ToUInt32(fila["Cantidad"]),
                idAlbum: Convert.ToUInt32(fila["idAlbum"])
            );

        public void AltaCancion(Cancion cancion)
            => EjecutarComandoCon("altaCancion", ConfigurarAltaCancion, postAltaCancion, cancion);


        public void ConfigurarAltaCancion(Cancion cancion)
        {
            SetComandoSP("altaCancion");

            BP.CrearParametroSalida("unidCancion")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt32)
            .AgregarParametro();

            BP.CrearParametro("unidAlbum")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt32)
            .SetValor(cancion.IdAlbum)
            .AgregarParametro();

            BP.CrearParametro("unnombre")
            .SetTipoVarchar(45)
            .SetValor(cancion.Nombre)
            .AgregarParametro();

            BP.CrearParametro("unposicion")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt32)
            .SetValor(cancion.posicion)
            .AgregarParametro();

        }
        public void postAltaCancion(Cancion cancion)
        {
            var paramidCancion = GetParametro("unidCancion");
            cancion.IdCancion = Convert.ToUInt32(paramidCancion.Value);
            var paramidAlbum = GetParametro("unidAlbum");
            cancion.IdAlbum = Convert.ToUInt32(paramidAlbum.Value);
        }
        public List<Cancion> ObtenerCanciones() => ColeccionDesdeTabla();

    }

}
