using System.Data;
using Espuchifai.Core;
using et12.edu.ar.AGBD.Ado;
using et12.edu.ar.AGBD.Mapeadores;

namespace Mapeador;

public class MapBanda : Mapeador<Banda>
{
    public MapBanda(AdoAGBD ado) : base(ado)
    {
        Tabla = "Banda";
    }

    public override Banda ObjetoDesdeFila(DataRow fila)
    => new Banda()
    {
        idbanda = Convert.ToInt16(fila["idbanda"]),
        nombre = Convert.ToString(fila["nombre"])
        fundacion = Convert.ToInt32(fila["fundacion"])
    };
    public void AltaBanda(Banda banda)
        => EjecutarComandoCon("AltaBanda", ConfigurarAltaBanda, PostAltaBanda, banda);

    public void ConfigurarAltaBanda(Banda banda)
    {
        SetComandoSP("AltaBanda");

        BP.CrearParametro("unidbanda")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int16)
        .SetValor(banda.idbanda)
        .AgregarParametro();

        BP.CrearParametro("unnombre")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.String)
        .SetValor(banda.nombre)
        .AgregarParametro();

        BP.CrearParametro("unafundacion")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
        .SetValor(banda.fundacion)
        .AgregarParametro();
    }
    public void PostAltaBanda(Banda banda)
    {
        var paramidbanda = GetParametro("unidbanda");
        banda.idbanda = Convert.ToInt16(paramidbanda.Value);
    }
    public Banda BandaPorId(int idbanda)
    {
        SetComandoSP("BandaPorId");

        BP.CrearParametro("unidbanda")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int16)
        .SetValor(idbanda)
        .AgregarParametro();

        return ElementoDesdeSP();
    }

    public List<Banda> ObtenerBandas() => ColeccionDesdeTabla();