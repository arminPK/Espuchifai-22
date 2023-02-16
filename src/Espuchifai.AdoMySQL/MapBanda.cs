using System.Data;
using Espuchifai.Core;
using et12.edu.ar.AGBD.Ado;
using et12.edu.ar.AGBD.Mapeadores;

namespace Espuchifai.AdoMySQL.Mapeadores
{
    public class MapBanda : Mapeador<Banda>
    {
        public MapBanda(AdoAGBD ado) : base(ado)
        {
            Tabla = "Banda";
        }
        public override Banda ObjetoDesdeFila(DataRow fila)
            => new Banda
            (
                idBanda: Convert.ToUInt32(fila["idBanda"]),
                nombre: fila["nombre"].ToString()!,
                fundacion: Convert.ToUInt32(fila["Fundacion"])
            );

        public void AltaBanda(Banda banda)
                => EjecutarComandoCon("altaBanda", ConfigurarAltaBanda, postAltaBanda, banda);

        public void ConfigurarAltaBanda(Banda banda)
        {
            SetComandoSP("altaBanda");

            BP.CrearParametroSalida("unidBanda")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt32)
            .AgregarParametro();

            BP.CrearParametro("unnombre")
            .SetTipoVarchar(45)
            .SetValor(banda.Nombre)
            .AgregarParametro();

            BP.CrearParametro("unafundacion")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .SetValor(banda.Fundacion)
            .AgregarParametro();
        }
        public void postAltaBanda(Banda banda)
        {
            var paramidBanda = GetParametro("unidBanda");
            banda.IdBanda = Convert.ToUInt32(paramidBanda.Value);
        }

        public List<Banda> ObtenerBandas() => ColeccionDesdeTabla();




    }


}