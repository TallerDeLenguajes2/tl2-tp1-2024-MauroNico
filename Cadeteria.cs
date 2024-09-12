public class Cadeteria {
    public string Nombre { get; set; }
    public string Telefono { get; set; }
    public List<Cadete> ListaCadetes { get; set; }
    public List<Pedido> ListadoPedidos { get; set; }

    public Cadeteria() {
        ListaCadetes = new List<Cadete>();
        ListadoPedidos = new List<Pedido>();
    }

    
    public void AsignarCadeteAPedido(int idCadete, int nroPedido) {
        var cadete = ListaCadetes.FirstOrDefault(c => c.Id == idCadete);
        var pedido = ListadoPedidos.FirstOrDefault(p => p.Nro == nroPedido);
        if (cadete != null && pedido != null) {
            pedido.Cadete = cadete;
        }
    }

    
    public decimal JornalACobrar(int idCadete) {
        var pedidosEntregados = ListadoPedidos
            .Where(p => p.Cadete != null && p.Cadete.Id == idCadete && p.Estado == "Entregado")
            .Count();
        return pedidosEntregados * 500;
    }

    
    public void CrearPedido(int nroPedido, string observacion, string estado, string nombreCliente, string direccionCliente, string telefonoCliente) {
        var nuevoPedido = new Pedido {
            Nro = nroPedido,
            Observacion = observacion,
            Estado = estado,
            Cliente = new Cliente {
                Nombre = nombreCliente,
                Direccion = direccionCliente,
                Telefono = telefonoCliente
            }
        };

        ListadoPedidos.Add(nuevoPedido);
    }

    
    public void CambiarEstadoPedido(int nroPedido, string nuevoEstado) {
        var pedido = ListadoPedidos.FirstOrDefault(p => p.Nro == nroPedido);
        if (pedido != null) {
            pedido.Estado = nuevoEstado;
        }
    }

    
    public (decimal totalJornal, int totalEnvios, double promedioEnvios) GenerarInforme() {
        decimal totalJornal = 0;
        int totalEnvios = 0;

        foreach (var cadete in ListaCadetes) {
            int pedidosEntregados = ListadoPedidos
                .Count(p => p.Cadete != null && p.Cadete.Id == cadete.Id && p.Estado == "Entregado");
            decimal jornalCadete = JornalACobrar(cadete.Id);
            totalJornal += jornalCadete;
            totalEnvios += pedidosEntregados;
        }

        int totalCadetes = ListaCadetes.Count;
        double promedioEnvios = (totalCadetes > 0) ? (double)totalEnvios / totalCadetes : 0;

        return (totalJornal, totalEnvios, promedioEnvios);
    }
}