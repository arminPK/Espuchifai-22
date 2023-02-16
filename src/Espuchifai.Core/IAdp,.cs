using Espuchifai.Core;

namespace Espuchifai.adoET12;
public interface IAdo
{
    void AltaBanda(Banda banda);
    List<Banda> ObtenerBanda();
    void AltaAlbum(Album album);
    List<Album> ObtenerAlbum();
    void AltaCancion(Cancion cancion);
    List<Cancion> ObtenerCancion();
    void Reproducir(Reproduccion reproduccion);
    List<Reproduccion> ObtenerReproduccion();
    void registrarCliente(Usuario usuario);
    List<Usuario> ObtenerUsuario();
}