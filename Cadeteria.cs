public class Cadeteria {
    public string Nombre { get; set; }
    public string Telefono { get; set; }
    public List<Cadete> ListaCadetes { get; set; }
    public List<Pedido> ListadoPedidos { get; set; }

    public Cadeteria() {
        ListaCadetes = new List<Cadete>();
        ListadoPedidos = new List<Pedido>();
    }

    // Método para asignar un cadete a un pedido
    public void AsignarCadeteAPedido(int idCadete, int nroPedido) {
        var cadete = ListaCadetes.FirstOrDefault(c => c.Id == idCadete);
        var pedido = ListadoPedidos.FirstOrDefault(p => p.Nro == nroPedido);
        if (cadete != null && pedido != null) {
            pedido.Cadete = cadete;
            Console.WriteLine($"Pedido {pedido.Nro} asignado a cadete {cadete.Nombre}");
        } else {
            Console.WriteLine("Cadete o pedido no encontrado.");
        }
    }

    // Método para calcular el jornal de un cadete
    public decimal JornalACobrar(int idCadete) {
        var pedidosEntregados = ListadoPedidos.Where(p => p.Cadete != null && p.Cadete.Id == idCadete && p.Estado == "Entregado").Count();
        return pedidosEntregados * 500; // $500 por pedido entregado
    }

    // Método para generar informe de la jornada
    public void GenerarInforme() {
        Console.WriteLine("\nInforme de la jornada:");
        decimal totalJornal = 0;
        int totalEnvios = 0;

        foreach (var cadete in ListaCadetes) {
            int pedidosEntregados = ListadoPedidos.Count(p => p.Cadete != null && p.Cadete.Id == cadete.Id && p.Estado == "Entregado");
            decimal jornalCadete = JornalACobrar(cadete.Id);
            totalJornal += jornalCadete;
            totalEnvios += pedidosEntregados;
            Console.WriteLine($"Cadete {cadete.Nombre}: {pedidosEntregados} envíos, Jornal a cobrar: ${jornalCadete}");
        }

        int totalCadetes = ListaCadetes.Count;
        double promedioEnvios = (totalCadetes > 0) ? (double)totalEnvios / totalCadetes : 0;

        Console.WriteLine($"\nTotal a pagar en jornales: ${totalJornal}");
        Console.WriteLine($"Total de envíos: {totalEnvios}");
        Console.WriteLine($"Promedio de envíos por cadete: {promedioEnvios:F2}");
    }
}
