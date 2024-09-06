public class Cadeteria {
    public string Nombre { get; set; }
    public string Telefono { get; set; }
    public List<Cadete> ListaCadetes { get; set; }

    public Cadeteria() {
        ListaCadetes = new List<Cadete>();
    }

    public void CargarDatosCadeteria(string archivoCSV) {
        using (StreamReader sr = new StreamReader(archivoCSV)) {
            while (!sr.EndOfStream) {
                var linea = sr.ReadLine();
                var valores = linea.Split(',');
                this.Nombre = valores[0];
                this.Telefono = valores[1];
            }
        }
    }

    public void CargarCadetes(string archivoCSV) {
        using (StreamReader sr = new StreamReader(archivoCSV)) {
            while (!sr.EndOfStream) {
                var linea = sr.ReadLine();
                var valores = linea.Split(',');
                var cadete = new Cadete {
                    Id = int.Parse(valores[0]),
                    Nombre = valores[1],
                    Direccion = valores[2],
                    Telefono = valores[3]
                };
                ListaCadetes.Add(cadete);
            }
        }
    }

    // Método para asignar un pedido a un cadete
    public void AsignarPedidoACadete(Pedido pedido, int idCadete) {
        var cadete = ListaCadetes.FirstOrDefault(c => c.Id == idCadete);
        if (cadete != null) {
            cadete.ListadoPedidos.Add(pedido);
            Console.WriteLine($"Pedido {pedido.Nro} asignado a cadete {cadete.Nombre}");
        }
        else {
            Console.WriteLine("Cadete no encontrado.");
        }
    }

    // Método para reasignar un pedido
    public void ReasignarPedido(int nroPedido, int idNuevoCadete) {
        foreach (var cadete in ListaCadetes) {
            var pedido = cadete.ListadoPedidos.FirstOrDefault(p => p.Nro == nroPedido);
            if (pedido != null) {
                cadete.ListadoPedidos.Remove(pedido);
                AsignarPedidoACadete(pedido, idNuevoCadete);
                break;
            }
        }
    }

    // Método para generar informe de la jornada
    public void GenerarInforme() {
        Console.WriteLine("\nInforme de la jornada:");
        decimal totalJornal = 0;
        int totalEnvios = 0;

        foreach (var cadete in ListaCadetes) {
            int pedidosEntregados = cadete.ListadoPedidos.Count(p => p.Estado == "Entregado");
            decimal jornalCadete = cadete.JornalACobrar();
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
