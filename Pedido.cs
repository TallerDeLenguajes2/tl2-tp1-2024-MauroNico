
public class Pedido
{
    public int NumPedidO {get;set;}
    public string Obs {get;set;}
    public Cliente Cliente {get;set;}
    public State estado; 

    public Pedido(int num, string obs, Cliente cliente, State estado){
        NumPedidO=num;
        Obs=obs;
        Cliente=cliente;
        this.estado = estado;
    }
    public string VerDireccionCliente(){
        return Cliente.Direccion;
    }
    public string VerDatosCliente(){
        return $"{Cliente.Nombre}, {Cliente.Telefono}, {Cliente.Direccion}";
        
    }
}

