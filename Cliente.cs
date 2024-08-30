public class Cliente
{
    public string Nombre {get;set;}
    public string Direccion {get;set;}
    public string Telefono {get;set;}
    public string Datosreferenciadireccion {get;set;}

    public Cliente(string nombre, string direccion, string telefono, string datosreferencia){
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
        Datosreferenciadireccion = datosreferencia;
    }
}