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

