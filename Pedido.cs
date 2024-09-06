public class Pedido {
    public int Nro { get; set; }
    public string Observacion { get; set; }
    public Cliente Cliente { get; set; }
    public string Estado { get; set; } // Pendiente, Enviado, Entregado

    public void VerDireccionCliente() {
        Console.WriteLine($"Dirección del cliente: {Cliente.Direccion}");
    }

    public void VerDatosCliente() {
        Console.WriteLine($"Datos del cliente: {Cliente.Nombre}, Tel: {Cliente.Telefono}");
    }
}