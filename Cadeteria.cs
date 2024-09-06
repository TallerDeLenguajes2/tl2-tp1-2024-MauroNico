public class Cadeteria
{
    public string Nombre { get; set; }
    public string Telefono { get; set; }
    public List<Cadete> ListaCadetes { get; set; } = new List<Cadete>();

    public Cadeteria(string nombre, string telefono)
    {
        Nombre = nombre;
        Telefono = telefono;
    }

    public void MostrarInforme()
    {
        int totalPedidos = 0;
        foreach (var cadete in ListaCadetes)
        {
            int jornal = cadete.JornalACobrar();
            int cantidadPedidos = cadete.ListaPedidos.Count;
            totalPedidos += cantidadPedidos;
            Console.WriteLine($"Cadete {cadete.Nombre}: {cantidadPedidos} pedidos - Jornal: ${jornal}");
        }

        double promedioPedidos = (double)totalPedidos / ListaCadetes.Count;
        Console.WriteLine($"Total de envíos: {totalPedidos}, Promedio por cadete: {promedioPedidos}");
    }
}
