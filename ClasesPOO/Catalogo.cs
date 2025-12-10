using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesPOO
{
    public class Catalogo
    {
        private List<Electrodomestico> electrodomesticos;
        public Catalogo()
        {
            electrodomesticos = new List<Electrodomestico>();
        }

        // Metodos
        public void AgregarElectrodomestico(Electrodomestico electrodomestico)
        {
            if (electrodomestico == null) {
                throw new ArgumentNullException(nameof(electrodomestico));
            }

            if (!electrodomesticos.Any(e => e.Id == electrodomestico.Id))
            {
                electrodomesticos.Add(electrodomestico);
            }
        
        }

        public string GenerarReporteDeConsumos(int horasDiarias, decimal costoWatts)
        {
            if (electrodomesticos.Count == 0)
            {
                string reporteVacio = "=== REPORTE DE CONSUMOS ===\nEl catálogo está vacío.\n";
                return reporteVacio;
            }

            StringBuilder reporte = new StringBuilder();
            reporte.AppendLine("=== REPORTE DE CONSUMOS ===");

            foreach (Electrodomestico electrodomestico in electrodomesticos)
            {
                string infoBase = electrodomestico.ObtenerInformacionBase();

                reporte.AppendLine(infoBase);
                reporte.AppendLine($"Categoría: {electrodomestico.CategoriaEnergetica}");

                decimal costoMensual = electrodomestico.CalcularCostoMensual(horasDiarias, costoWatts);
                reporte.AppendLine($"Costo mensual: ${costoMensual}");

                if (electrodomestico is Lavadora lavadora)
                {
                    string infoLavadora = lavadora.IniciarCicloLavado();
                    reporte.AppendLine(infoLavadora);
                }

                else if (electrodomestico is Televisor televisor)
                {
                    string infoTelevisor = televisor.ConfigurarCanales();
                    reporte.AppendLine(infoTelevisor);
                }

                    reporte.AppendLine("---");
            }

            return reporte.ToString();


        }
    }
}
