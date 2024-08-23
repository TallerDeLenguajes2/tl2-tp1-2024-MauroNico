using System;
using System.Collections.Generic;
using System.IO;

enum state {recibido, preparandose, en camino, recibido};
class cliente
{
    public string Nombre {get;set;}
    public string Direccion {get;set;}
    public string Telefono {get;set;}
    public string Datosreferenciadireccion {get;set;}

    public cliente(string nombre, string direccion, string telefono, string datosreferencia){
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
        Datosreferenciadireccion = datosreferencia;
    }
}

public class Pedido
{
    public int NumPedidO {get;set;}
    public string Obs {get;set;}
    public cliente Cliente {get;set;}
    public state Estado; 

    public Pedido(int num, string obs, cliente cliente, state estado){
        NumPedidO=num;
        Obs=obs;
        Cliente=cliente;
        Estado = estado;
    }
    public string VerDireccionCliente(){
        return Cliente.Direccion;
    }
    public string VerDatosCliente(){
        return $"{Cliente.Nombre}, {Cliente.Telefono}, {Cliente.Direccion}";
        
    }
}

class Cadete{
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
        int pedidosEntregados = ListadoPedidos.FindAll(p => p.Estado == "Entregado").Count;
        return pedidosEntregados * 500;
    }
}

class Cadeteria{
    public string Nombre { get; set; }
    public string Telefono { get; set; }
    public List<Cadete> ListadoCadetes { get; set; }

    public Cadeteria(string nombre, string telefono)
    {
        Nombre = nombre;
        Telefono = telefono;
        ListaCadetes = new List<Cadete>();
    }

    public void CargarCSV(string archivoCSV)
    {
        using (var reader = new StreamReader(archivoCSV))
        {
            string headerLine = reader.ReadLine(); // Leer la cabecera
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                Cadete cadete = new Cadete(int.Parse(values[0]), values[1], values[2], values[3]);
                ListaCadetes.Add(cadete);
            }
        }
    }
}

