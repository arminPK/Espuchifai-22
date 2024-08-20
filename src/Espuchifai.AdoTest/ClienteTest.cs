using et12.edu.ar.AGBD.Ado;
using Espuchifai.Core;

namespace Espuchifai.Test;
public class ClienteTest
{
    public AdoTest Ado { get; set; }
    public ClienteTest()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        Ado = new AdoTest(adoAGBD);
    }
    [Fact]
    public void AltaCliente()
    {
        var cliente = new Cliente(4, "gonzalo", "arancibia", "gonzaloarancibia@gmail.com", "gonzi");
        Ado.AltaCliente(cliente);
        Assert.Equal(4, cliente.idcliente);
    }

    [Theory]
    [InlineData(1)]
    public void TraerClientes(int idcliente)
    {
        var clientes = Ado.RegistrarClientes();
        Assert.Contains(clientes, c => c.idcliente == idcliente);
    }

    public void TrearBuscarCLiente(int idcliente)
    {
        var clientes = Ado.RegistrarClientes();
        Assert.Contains(clientes, c => c.idcliente == idcliente);
    }


    [Fact]
    public void ObtenerBuscarCliente()
    {
        var cliente = Ado.BuscarCliente("gonzaloarancibia@gmail.com", "gonzi");
        Assert.Equal("gonzaloarancibia@gmail.com", cliente.email);
    }
}