using System;
using ClasesPOO;

namespace ConsolaPOO
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Instanciar el catálogo
            Catalogo catalogo = new Catalogo();

            // Creacion de lavadoras y televisores
            Console.WriteLine("Creando lavadoras...");
            Lavadora lavadora1 = new Lavadora(
                id: 1,
                marca: "Samsung",
                modelo: "WA50R5400AV",
                consumoBaseWatts: 500,
                capacidadKilos: 7.5m
            );

            Lavadora lavadora2 = new Lavadora(
                id: 2,
                marca: "LG",
                modelo: "WM3900HWA",
                consumoBaseWatts: 600,
                capacidadKilos: 10.0m,
                tipo: TipoLavadora.SEMIINDUSTRIAL
            );

            Console.WriteLine("Creando televisores...");
            Televisor televisor1 = new Televisor(
                id: 3,
                marca: "Sony",
                modelo: "X90K",
                consumoBaseWatts: 150,
                pulgadas: 65
            );

            Televisor televisor2 = new Televisor(
                id: 4,
                marca: "LG",
                modelo: "C2 OLED",
                consumoBaseWatts: 120,
                pulgadas: 55,
                resolucion: ResolucionTV.ULTRAHD_4K
            );

            // Agregarlos al catálogo
            Console.WriteLine("Agregando electrodomésticos al catálogo...\n");
            catalogo.AgregarElectrodomestico(lavadora1);
            catalogo.AgregarElectrodomestico(lavadora2);
            catalogo.AgregarElectrodomestico(televisor1);
            catalogo.AgregarElectrodomestico(televisor2);

            // Generación y muestra del reporte
            int horasDiarias = 5;
            decimal costoPorWatt = 0.01m;

            Console.WriteLine($"Parámetros del reporte:");
            Console.WriteLine($"- Horas diarias de uso: {horasDiarias}");
            Console.WriteLine($"- Costo por watt: ${costoPorWatt}\n");

            string reporte = catalogo.GenerarReporteDeConsumos(horasDiarias, costoPorWatt);
            Console.WriteLine(reporte);
        }
    }
}
