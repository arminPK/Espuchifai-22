using Espuchifai.Core;
using et12.edu.ar.AGBD.Ado;
namespace Espuchifai.adoET12.Test
{
    public class ReproduccionTests
    {
        public AdoEspuchifai Ado { get; set; }
        public ReproduccionTests()
        {
            var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
            Ado = new(adoAGBD);
        }


        [Fact]
        public void Reproducir()
        {
            var reproducciones = new Reproducciones(new DateTime(2022, 1, 23), 1, 2);
            Ado.Reproducir(reproducciones);
            Assert.Equal((uint)1, reproducciones.IdCancion);
        }

        [Fact]
        public void ObtenerReproduccion()
        {
            var canciones = Ado.ObtenerReproduccion();
            Assert.Contains(canciones, x => x.IdCancion == 3 && x.IdCliente == 1);
        }

    }
}