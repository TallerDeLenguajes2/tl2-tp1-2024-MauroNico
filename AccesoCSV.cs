

public class AccesoCSV : AccesoADatos {
    public override void CargarDatosCadeteria(Cadeteria cadeteria, string archivo) {
        using (StreamReader sr = new StreamReader(archivo)) {
            while (!sr.EndOfStream) {
                var linea = sr.ReadLine();
                var valores = linea.Split(',');
                cadeteria.Nombre = valores[0];
                cadeteria.Telefono = valores[1];
            }
        }
    }

    public override void CargarCadetes(Cadeteria cadeteria, string archivo) {
        using (StreamReader sr = new StreamReader(archivo)) {
            while (!sr.EndOfStream) {
                var linea = sr.ReadLine();
                var valores = linea.Split(',');
                var cadete = new Cadete {
                    Id = int.Parse(valores[0]),
                    Nombre = valores[1],
                    Direccion = valores[2],
                    Telefono = valores[3]
                };
                cadeteria.ListaCadetes.Add(cadete);
            }
        }
    }
}