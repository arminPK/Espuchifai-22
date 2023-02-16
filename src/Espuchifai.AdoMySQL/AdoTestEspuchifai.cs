using Espuchifai.AdoMySQL.Mapeadores;
using Espuchifai.Core;
using et12.edu.ar.AGBD.Ado;

namespace Espuchifai.adoET12;
public class AdoEspuchifai
{
    public AdoAGBD Ado { get; set; }
    public MapBanda MapBanda { get; set; }
    public MapAlbum MapAlbum { get; set; }
    public MapCancion MapCancion { get; set; }
    public MapCliente MapCliente { get; set; }

    public MapReproducciones MapReproducciones { get; set; }
    public AdoEspuchifai(AdoAGBD ado)
    {
        Ado = ado;
        MapBanda = new MapBanda(Ado);
        MapAlbum = new MapAlbum(Ado);
        MapCancion = new MapCancion(Ado);
        MapCliente = new MapCliente(Ado);
        MapReproducciones = new MapReproducciones(Ado);
    }
    public void AltaBanda(Banda banda) => MapBanda.AltaBanda(banda);
    public List<Banda> ObtenerBandas() => MapBanda.ColeccionDesdeTabla();

    public void AltaAlbum(Album album) => MapAlbum.AltaAlbum(album);
    public List<Album> ObtenerAlbum() => MapAlbum.ColeccionDesdeTabla();

    public void AltaCancion(Cancion cancion) => MapCancion.AltaCancion(cancion);

    public List<Cancion> ObtenerCancion() => MapCancion.ColeccionDesdeTabla();

    public void registrarCliente(Cliente Cliente) => MapCliente.registrarCliente(Cliente);
    public List<Cliente> ObtenerClientes() => MapCliente.ColeccionDesdeTabla();

    public void Reproducir(Reproducciones reproducciones) => MapReproducciones.Reproducir(reproducciones);
    public List<Reproducciones> ObtenerReproduccion() => MapReproducciones.ColeccionDesdeTabla();
}