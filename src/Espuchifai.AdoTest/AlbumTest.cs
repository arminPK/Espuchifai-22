using Espuchifai.Core;
using et12.edu.ar.AGBD.Ado;

namespace Espuchifai.adoET12.Test
{
    public class AlbumTests
    {


        public AdoEspuchifai Ado { get; set; }
        public AlbumTests()
        {
            var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
            Ado = new(adoAGBD);
        }

        [Fact]
        public void AltaAlbum()
        {
            var album = new Album("Metal Resistence", new DateTime(1984, 1, 23), idBanda: 1, idAlbum: 2, cantidad: 1);
            Ado.AltaAlbum(album);
            Assert.Equal((uint)3, album.IdAlbum);
        }

        [Theory]
        [InlineData(1, "Live At The Forum")]
        [InlineData(2, "Live at Wembley")]
        public void TraerAlbunes(byte id, string nombre)
        {
            var album = Ado.ObtenerAlbum();
            Assert.Contains(album, x => x.IdAlbum == id && x.Nombre == nombre);
        }
    }
}