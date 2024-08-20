using et12.edu.ar.AGBD.Ado;
using Espuchifai.Core;

namespace Espuchifai.Test;

public class AlbumTest
{
    public AdoTest Ado { get; set; }
    public AlbumTest()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        Ado = new AdoTest(adoAGBD);
    }
    [Fact]
    public void AltaAlbum()
    {
        var album = new Album(2, "asdasdasd", "1912-12-16", 3);
        Ado.AltaAlbum(album);
        Assert.Equal(2, album.idalbum);
    }
    [Theory]
    [InlineData(1, "soledad", "1912-09-16", 1)]
    public void TraerAlbumes(byte idalbum, string nombre, DateTime lanzamiento, short idbanda)
    {
        var albumes = Ado.ObtenerAlbumes();
        Assert.Contains(albumes, a => a.idalbum == idalbum && a.nombre == nombre && a.lanzamiento == lanzamiento && a.idbanda == idbanda);
    }
}