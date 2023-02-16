using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System.Data;
using Espuchifai.Core;

namespace Espuchifai.AdoMySQL.Mapeadores;
public class MapReproduccion : Mapeador<Reproduccion>
{
    public MapReproduccion(AdoAGBD ado) : base(ado)
    {
        Tabla = "Reproduccion";
    }
    public override Reproduccion ObjetoDesdeFila(DataRow fila)
        => new Reproduccion
        (
            idCancion: Convert.ToUInt32(fila["idCancion"]),
            idCliente: Convert.ToUInt32(fila["idCliente"]),
            reproduccion: Convert.ToDateTime(fila["Reproduccion"])
        );

    public void Reproducir(Reproduccion reproduccion)
            => EjecutarComandoCon("reproducir", ConfigurarReproducir, reproduccion);


    public void ConfigurarReproducir(Reproduccion reproduccion)
    {
        SetComandoSP("reproducir");

        BP.CrearParametro("unaReproduccion")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.DateTime)
        .SetValor(reproduccion.Reproduccion)
        .AgregarParametro();

        BP.CrearParametro("unidCliente")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt32)
        .SetValor(reproduccion.IdCliente)
        .AgregarParametro();

        BP.CrearParametro("unidCancion")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt32)
        .SetValor(reproduccion.IdCancion)
        .AgregarParametro();

    }
    public List<Reproduccion> ObtenerReproduccion() => ColeccionDesdeTabla();

}