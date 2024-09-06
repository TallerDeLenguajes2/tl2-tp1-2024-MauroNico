public class Pedido
{
    public int Nro { get; set; }
    public string Obs { get; set; }
    public Cliente Cliente { get; set; }
    public string Estado { get; set; }

    public Pedido(int nro, string obs, Cliente cliente, string estado)
    {
        Nro = nro;
        Obs = obs;
        Cliente = cliente;
        Estado = estado;
    }

    public void VerDireccionCliente()
    {
        Console.WriteLine($"Dirección del cliente: {Cliente.Direccion}");
    }

    public void VerDatosCliente()
    {
        Console.WriteLine($"Datos del cliente: {Cliente.Nombre}, Tel: {Cliente.Telefono}, Dirección: {Cliente.Direccion}");
    }
}
