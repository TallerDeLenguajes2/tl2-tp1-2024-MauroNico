public class Cadete {
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public List<Pedido> ListadoPedidos { get; set; }

    public Cadete() {
        ListadoPedidos = new List<Pedido>();
    }

    public decimal JornalACobrar() {
        // Asumimos que cada pedido entregado genera un jornal de $500
        return ListadoPedidos.Count(p => p.Estado == "Entregado") * 500;
    }
}