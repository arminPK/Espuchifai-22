using et12.edu.ar.AGBD.Ado;
using Espuchifai.Core;

namespace Espuchifai.Test;

public class CancionTest
{
    public AdoTest Ado { get; set; }
    public CancionTest()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        Ado = new AdoTest(adoAGBD);
    }
    [Fact]
    public void AltaCancion()
    {
        var cancion = new Cancion(2, 'morfSDASDASDeo', 2, 2);
        Ado.AltaCancion(cancion);
        Assert.Equal(2, cancion.idcancion);
    }
    [Theory]
    [InlineData(1, 'morfeo', 1, 1)]
    public void TraerCanciones(byte idcancion, string nombre, int numorden, byte idalbum)
    {
        var canciones = Ado.ObtenerCanciones();
        Assert.Contains(canciones, c => c.idcancion == idcancion && c.nombre == nombre && c.numorden == numorden && c.idalbum == idalbum);
    }
}