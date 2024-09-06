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
        
        return ListadoPedidos.Count(p => p.Estado == "Entregado") * 500;
    }
}