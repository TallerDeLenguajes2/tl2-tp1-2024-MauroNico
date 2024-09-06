using Newtonsoft.Json;
public class AccesoJSON : AccesoADatos {
    public override void CargarDatosCadeteria(Cadeteria cadeteria, string archivo) {
        var json = File.ReadAllText(archivo);
        var datosCadeteria = JsonConvert.DeserializeObject<Cadeteria>(json);
        cadeteria.Nombre = datosCadeteria.Nombre;
        cadeteria.Telefono = datosCadeteria.Telefono;
    }

    public override void CargarCadetes(Cadeteria cadeteria, string archivo) {
        var json = File.ReadAllText(archivo);
        var listaCadetes = JsonConvert.DeserializeObject<List<Cadete>>(json);
        cadeteria.ListaCadetes.AddRange(listaCadetes);
    }
}
