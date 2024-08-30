class Cadete
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public List<Pedido> ListadoPedidos { get; set; }

    public Cadete(int id, string nombre, string direccion, string telefono)
    {
        Id = id;
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
        ListadoPedidos = new List<Pedido>();
    }

    public void AsignarPedido(Pedido pedido)
    {
        ListadoPedidos.Add(pedido);
    }

    public int JornalACobrar()
    {
        int pedidosEntregados = ListadoPedidos.FindAll(p => p.estado == entregado).Count;
        return pedidosEntregados * 500;
    }
}

