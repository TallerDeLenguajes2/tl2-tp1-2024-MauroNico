using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Program
{
    static List<Cadete> CargarCadetesDesdeCSV(string path)
    {
        List<Cadete> cadetes = new List<Cadete>();
        using (var reader = new StreamReader(path))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var values = line.Split(',');
                cadetes.Add(new Cadete { Id = int.Parse(values[0]), Nombre = values[1], Direccion = values[2], Telefono = values[3] });
            }
        }
        return cadetes;
    }

    static List<Cliente> CargarClientesDesdeCSV(string path)
    {
        List<Cliente> clientes = new List<Cliente>();
        using (var reader = new StreamReader(path))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var values = line.Split(',');
                clientes.Add(new Cliente(values[0], values[1], values[2], values[3]));
            }
        }
        return clientes;
    }

    static void Main(string[] args)
    {
        // Cargar datos desde CSV
        List<Cadete> cadetes = CargarCadetesDesdeCSV("cadetes.csv");
        List<Cliente> clientes = CargarClientesDesdeCSV("clientes.csv");

        Cadeteria cadeteria = new Cadeteria("MiCadeteria", "123456789");
        cadeteria.ListaCadetes = cadetes;

        // Operaciones: Alta de pedidos, asignación, cambio de estado, reasignación
        Pedido pedido1 = new Pedido(1, "Pedido urgente", clientes[0], "Pendiente");
        cadeteria.ListaCadetes[0].AsignarPedido(pedido1);

        // Mostrar informe final
        cadeteria.MostrarInforme();
    }
}