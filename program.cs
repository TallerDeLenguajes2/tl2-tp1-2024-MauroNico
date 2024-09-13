using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;


public class Program {
    static void Main() {
        Cadeteria cadeteria = new Cadeteria();
        AccesoADatos accesoDatos;

        
        Console.WriteLine("Seleccione el tipo de acceso a datos:");
        Console.WriteLine("1. CSV");
        Console.WriteLine("2. JSON");
        Console.Write("Opción: ");
        string opcionAcceso = Console.ReadLine();

        switch (opcionAcceso) {
            case "1":
                accesoDatos = new AccesoCSV();
                accesoDatos.CargarDatosCadeteria(cadeteria, "cadeteria.csv");
                accesoDatos.CargarCadetes(cadeteria, "cadetes.csv");
                break;
            case "2":
                accesoDatos = new AccesoJSON();
                accesoDatos.CargarDatosCadeteria(cadeteria, "cadeteria.json");
                accesoDatos.CargarCadetes(cadeteria, "cadetes.json");
                break;
            default:
                Console.WriteLine("Opción no válida. Se utilizará CSV por defecto.");
                accesoDatos = new AccesoCSV();
                break;
        }
        
        bool salir = false;
        while (!salir) {
            Console.WriteLine("\nSistema de Gestión de Pedidos");
            Console.WriteLine("1. Dar de alta un pedido");
            Console.WriteLine("2. Asignar cadete a pedido");
            Console.WriteLine("3. Cambiar estado de un pedido");
            Console.WriteLine("4. Mostrar informe al finalizar jornada");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion) {
                case "1":
                    Pedido nuevoPedido = new Pedido();
                    Console.Write("Ingrese el número del pedido: ");
                    nuevoPedido.Nro = int.Parse(Console.ReadLine());
                    Console.Write("Ingrese la observación del pedido: ");
                    nuevoPedido.Observacion = Console.ReadLine();
                    nuevoPedido.Estado = "Pendiente";

                    nuevoPedido.Cliente = new Cliente();
                    Console.Write("Ingrese el nombre del cliente: ");
                    nuevoPedido.Cliente.Nombre = Console.ReadLine();
                    Console.Write("Ingrese la dirección del cliente: ");
                    nuevoPedido.Cliente.Direccion = Console.ReadLine();
                    Console.Write("Ingrese el teléfono del cliente: ");
                    nuevoPedido.Cliente.Telefono = Console.ReadLine();

                    cadeteria.ListadoPedidos.Add(nuevoPedido);
                    Console.WriteLine("Pedido creado con éxito.");
                    break;

                case "2":
                    Console.Write("Ingrese el número del pedido a asignar: ");
                    int nroPedidoAsignar = int.Parse(Console.ReadLine());
                    Console.Write("Ingrese el ID del cadete a asignar: ");
                    int idCadeteAsignar = int.Parse(Console.ReadLine());

                    cadeteria.AsignarCadeteAPedido(idCadeteAsignar, nroPedidoAsignar);
                    break;

                case "3":
                    Console.Write("Ingrese el número del pedido para cambiar su estado: ");
                    int nroPedidoCambiar = int.Parse(Console.ReadLine());
                    var pedidoCambiar = cadeteria.ListadoPedidos.FirstOrDefault(p => p.Nro == nroPedidoCambiar);
                    if (pedidoCambiar != null) {
                        Console.WriteLine("Seleccione el nuevo estado: 1. Pendiente, 2. Enviado, 3. Entregado");
                        string nuevoEstado = Console.ReadLine();
                        switch (nuevoEstado) {
                            case "1":
                                pedidoCambiar.Estado = "Pendiente";
                                break;
                            case "2":
                                pedidoCambiar.Estado = "Enviado";
                                break;
                            case "3":
                                pedidoCambiar.Estado = "Entregado";
                                break;
                            default:
                                Console.WriteLine("Estado no válido.");
                                break;
                        }
                        Console.WriteLine("Estado del pedido actualizado.");
                    } else {
                        Console.WriteLine("Pedido no encontrado.");
                    }
                    break;

                case "4":
                    cadeteria.GenerarInforme();
                    break;

                case "5":
                    salir = true;
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
}