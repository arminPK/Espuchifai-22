using et12.edu.ar.AGBD.Ado;
using Espuchifai.Core;

namespace Espuchifai.Test;

public class BandaTest
{
    public AdoTest Ado { get; set; }
    public BandaTest()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        Ado = new AdoTest(adoAGBD);
    }
    [Fact]
    public void AltaBanda()
    {
        var banda = new Banda(4, "gasafs", 1260);
        Ado.AltaBanda(banda);
        Assert.Equal(4, banda.idbanda);
    }
    [Theory]
    [InlineData(1, "insanos", 1960)]
    public void TraerBandas(short idbanda, string nombre, int fundacion)
    {
        var bandas = Ado.ObtenerBandas();
        Assert.Contains(bandas, b => b.idbanda == idbanda && b.nombre == nombre && b.fundacion == fundacion);
    }
}