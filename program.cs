using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Program {
    static void Main() {
        Cadeteria cadeteria = new Cadeteria();

        
        cadeteria.CargarDatosCadeteria("cadeteria.csv");
        cadeteria.CargarCadetes("cadetes.csv");

        
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
                    Console.Write("Ingrese el número del pedido a cambiar de estado: ");
                    int nroPedidoEstado = int.Parse(Console.ReadLine());
                    Console.Write("Ingrese el nuevo estado (Pendiente, Enviado, Entregado): ");
                    string nuevoEstado = Console.ReadLine();

                    var pedidoEstado = cadeteria.ListadoPedidos.FirstOrDefault(p => p.Nro == nroPedidoEstado);
                    if (pedidoEstado != null) {
                        pedidoEstado.Estado = nuevoEstado;
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