using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using et12.edu.ar.AGBD.Ado;
using Mapeador;
using Espuchifai.Core;
using Espuchifai.Core.Ado;

namespace Espuchifai.Test
{
    public class AdoTest : IAdo
    {
        public AdoTest(AdoAGBD ado, MapBanda MapBanda, MapReproduccion MapReproduccion, MapCancion MapCancion)
        {
            this.Ado = ado;
            this.MapBanda = MapBanda;
            this.MapReproduccion = MapReproduccion;
            this.MapCancion = MapCancion;

        }
        public AdoAGBD Ado { get; set; }
        public MapAlbum MapAlbum { get; set; }
        public MapBanda MapBanda { get; set; }
        public MapReproduccion MapReproduccion { get; set; }
        public MapCancion MapCancion { get; set; }
        public MapCliente MapCliente { get; set; }
        public AdoTest(AdoAGBD ado)
        {
            Ado = ado;
            MapAlbum = new MapAlbum(Ado);
            MapBanda = new MapBanda(Ado);
            MapReproduccion = new MapReproduccion(Ado);
            MapCancion = new MapCancion(Ado);
            MapCliente = new MapCliente(Ado);
        }
        public void AltaAlbum(Album album) => MapAlbum.AltaAlbum(album);
        public List<Album> ObtenerAlbumes() => MapAlbum.ObtenerAlbumes();
        public void AltaBanda(Banda banda) => MapBanda.AltaBanda(banda);
        public List<Banda> ObtenerBandas() => MapBanda.ObtenerBandas();
        public void AltaReproduccion(Reproduccion reproduccion) => MapReproduccion.AltaReproduccion(reproduccion);
        public List<Reproduccion> ObtenerReproducciones() => MapReproduccion.ObtenerReproducciones();
        public void AltaCancion(Cancion cancion) => MapCancion.AltaCancion(cancion);
        public List<Cancion> ObtenerCanciones() => MapCancion.ObtenerCanciones();
        public void AltaCliente(Cliente cliente) => MapCliente.AltaCliente(cliente);
        public List<Cliente> RegistrarClientes() => MapCliente.RegistrarClientes();
        public Cliente? BuscarCliente(string email, string contrasena) => MapCliente.BuscarCliente(email, contrasena);
    }
}