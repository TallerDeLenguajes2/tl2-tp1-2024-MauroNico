public class Pedido {
    public int Nro { get; set; }
    public string Observacion { get; set; }
    public Cliente Cliente { get; set; }
    public string Estado { get; set; } 
    public Cadete Cadete { get; set; } 

    public string VerDireccionCliente() {
        return this.Cliente.Direccion;
    }

    public string VerDatosCliente() {
        return this.Cliente.DatosReferenciaDireccion;
    }
}