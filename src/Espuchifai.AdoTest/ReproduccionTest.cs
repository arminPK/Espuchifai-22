using et12.edu.ar.AGBD.Ado;
using Espuchifai.Core;

namespace Espuchifai.Test;

public class ReproduccionTest
{
    public AdoTest Ado { get; set; }
    public ReproduccionTest()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        Ado = new AdoTest(adoAGBD);
    }
    [Fact]
    public void AltaReproduccion()
    {
        var reproduccion = new Reproduccion(2, 4, 2, DateTime.Today);
        Ado.AltaReproduccion(reproduccion);
        Assert.Equal(2, reproduccion.idreproduccion);
    }
    [Theory]
    [InlineData(1, 1, 1, "2024-08-11 10:00:00")]
    public void TraerReproducciones(int idreproduccion, int idcliente, byte idcancion, DateTime momreproduccion)
    {
        var reproducciones = Ado.ObtenerReproducciones();
        Assert.Contains(reproducciones, r => r.idreproduccion == idreproduccion && r.idcliente == idcliente && r.idcancion == idcancion && r.momreproduccion == momreproduccion);
    }
}