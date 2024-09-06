public class Cadete
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public List<Pedido> ListaPedidos { get; set; } = new List<Pedido>();

    public void AsignarPedido(Pedido pedido)
    {
        ListaPedidos.Add(pedido);
    }

    public void RemoverPedido(Pedido pedido)
    {
        ListaPedidos.Remove(pedido);
    }

    public int JornalACobrar()
    {
        return ListaPedidos.Count * 500;
    }
}
