using System.Data;
using Espuchifai.Core;
using et12.edu.ar.AGBD.Ado;
using et12.edu.ar.AGBD.Mapeadores;

namespace Mapeador
{
    public class MapAlbum : Mapeador<Album>
    {
        public MapAlbum(AdoAGBD ado) : base(ado)
        {
            Tabla = "Album";
        }
        public override Album ObjetoDesdeFila(DataRow fila)
        => new Album()
        {
            idalbum = Convert.ToByte(fila["idalbum"]),
            nombre = Convert.ToString(fila["nombre"]),
            lanzamiento = Convert.ToDateTime(fila["lanzamiento"]),
            cantidad = Convert.ToInt32(fila["cantidad"]),
            idbanda = Convert.ToInt16(fila["idbanda"])
        };
        public void AltaAlbum(Album album)
        => EjecutarComandoCon("AltaAlbum", ConfigurarAltaAlbum, PostAltaAlbum, album);

        public void ConfigurarAltaAlbum(Album album)
        {
            SetComandoSP("AltaAlbum");

            BP.CrearParametro("unidalbum")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .SetValor(album.idalbum)
            .AgregarParametro();

            BP.CrearParametro("unnombre")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.String)
            .SetValor(album.nombre)
            .AgregarParametro();

            BP.CrearParametro("unlanzamiento")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.DateTime)
            .SetValor(album.lanzamiento)
            .AgregarParametro();

            BP.CrearParametro("unacantidad")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .SetValor(album.cantidad)
            .AgregarParametro();

            BP.CrearParametro("unidbanda")
            .SetValor(MySql.Data.MySqlClient.MySqlDbType.Int16)
            .SetValor(album.idbanda)
            .AgregarParametro();
        }
        public void PostAltaAlbum(Album album)
        {
            var paramidalbum = GetParametro("unidalbum");
            album.idalbum = Convert.ToByte(paramidalbum.Value);
        }
        public Album AlbumPorId(Byte idalbum)
        {
            SetComandoSP("AlbumPorId");

            BP.CrearParametro("unidalbum")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .SetValor(idalbum)
            .AgregarParametro();

            return ElementoDesdeSP();
        }
        public List<Album> ObtenerAlbumes() => ColeccionDesdeTabla();
    }
}