using System.Data;
using Espuchifai.Core;
using et12.edu.ar.AGBD.Ado;
using et12.edu.ar.AGBD.Mapeadores;

namespace Espuchifai.AdoMySQL.Mapeadores
{
    public class MapAlbum : Mapeador<Album>
    {
        public MapAlbum(AdoAGBD ado) : base(ado)
        {
            Tabla = "Album";
        }
        public override Album ObjetoDesdeFila(DataRow fila)
            => new Album
            (
                idAlbum: Convert.ToUInt32(fila["IdAlbum"]),
                cantidad: Convert.ToUInt32(fila["Cantidad"]),
                idBanda: Convert.ToUInt32(fila["IdBanda"]),
                lanzamiento: Convert.ToDateTime(fila["Lanzamiento"]),
                nombre: Convert.ToString(fila["Nombre"])!
            );

        public void AltaAlbum(Album album)
            => EjecutarComandoCon("altaAlbum", ConfigurarAltaAlbum, postAltaAlbum, album);

        public void ConfigurarAltaAlbum(Album album)
        {
            SetComandoSP("altaAlbum");

            BP.CrearParametro("unidBanda")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt32)
            .SetValor(album.IdBanda)
            .AgregarParametro();

            BP.CrearParametroSalida("unidAlbum")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt32)
            .AgregarParametro();

            BP.CrearParametro("unnombre")
            .SetTipoVarchar(45)
            .SetValor(album.Nombre)
            .AgregarParametro();

            BP.CrearParametro("unLanzamiento")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.DateTime)
            .SetValor(album.Lanzamiento)
            .AgregarParametro();
        }
        public void postAltaAlbum(Album album)
        {
            var paramidAlbum = GetParametro("unidAlbum");
            album.IdAlbum = Convert.ToUInt32(paramidAlbum.Value);
        }

        public List<Album> ObtenerAlbum() => ColeccionDesdeTabla();


    }


}