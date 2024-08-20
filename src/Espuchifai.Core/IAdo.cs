namespace Cine.Core.Ado;

public interface IAdo
{
    void AltaAlbum(Album album);
    List<Album> ObtenerAlbumes();
    void AltaBanda(Banda banda);
    List<Banda> ObtenerBandas();
    void AltaCancion(Cancion cancion);
    List<Cancion> ObtenerCanciones();
    void AltaReproduccion(Reproduccion reproduccion);
    List<Reproduccion> ObtenerReproducciones();
    void AltaCliente(Cliente cliente);
    List<Cliente> RegistrarClientes();
}