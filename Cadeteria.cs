class Cadeteria
{
    public string Nombre { get; set; }
    public string Telefono { get; set; }
    public List<Cadete> listadoCadetes { get; set; }

    public Cadeteria(string nombre, string telefono)
    {
        Nombre = nombre;
        Telefono = telefono;
        listadoCadetes = new List<Cadete>();
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
                listadoCadetes.Add(cadete);
            }
        }
    }
}

