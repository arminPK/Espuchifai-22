using Espuchifai.Core;
using et12.edu.ar.AGBD.Ado;
namespace Espuchifai.adoET12.Test
{
    public class CancionTests
    {
        public AdoEspuchifai Ado { get; set; }
        public CancionTests()
        {
            var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
            Ado = new(adoAGBD);
        }

        [Fact]
        public void AltaCancion()
        {
            var cancion = new Cancion("Gimme Chocolate!", orden: 1, idAlbum: 2, idCancion: 1, cantidad: 2);
            Ado.AltaCancion(cancion);
            Assert.Equal((uint)7, cancion.IdCancion);
        }

        [Theory]
        [InlineData(1, "Doki Doki Morning")]
        public void TraerCanciones(byte id, string nombre)
        {
            var cancions = Ado.ObtenerCancion();
            Assert.Contains(cancions, x => x.IdCancion == id && x.Nombre == nombre);
        }
    }
}