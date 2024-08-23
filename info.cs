using System;
using System.Collections.Generic;
using System.IO;

enum state {recibido, preparandose, en camino, recibido};
public class cliente
{
    private string Nombre {get;set;}
    private string Direccion {get;set;}
    private string Telefono {get;set;}
    private string Datosreferenciadireccion {get;set;}

    public cliente(string nombre, string direccion, string telefono, string datosreferencia){
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
        Datosreferenciadireccion = datosreferencia;
    }
}

public class Pedido
{
    private int NumPedidO {get;set;}
    private string Obs {get;set;}
    private cliente Cliente {get;set;}
    private state Estado; 
}

