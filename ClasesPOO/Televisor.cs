using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesPOO
{
    internal class Televisor : Electrodomestico
    {
        //Atributos

        int pulgadas;
        ResolucionTV resolucion;

        // Constante
        double FACTOR_PANTALLA = 0.05;

        //Constructores

        public Televisor(string marca, string modelo, decimal consumoBaseWatts, int pulgadas)
          : base(marca, modelo, consumoBaseWatts)
        {
            pulgadas = Pulgadas;
            resolucion = ResolucionTV.FULLHD;
        }

        public Televisor(string marca, string modelo, decimal consumoBaseWatts, int pulgadas)
  : base(marca, modelo, consumoBaseWatts)
        {
            Pulgadas = pulgadas;
            resolucion = Resolucion;
        }

        // Propiedad abstracta del padre

        public override string CategoriaEnergetica
        {
            get
            {
                if (pulgadas > 55)
                {
                    return "B";
                }

                else 
                {
                    return "A";
                }
            }
        }

        //Metodo abstracto del padre

        public override decimal CalcularCostoMensual(int horasDiarias, decimal costoPorWatt, double ValorResolucion)
        {
            decimal consumoTotal = consumoBaseWatts + (decimal)(pulgadas * FACTOR_PANTALLA * ValorResolucion);

            decimal costoMensual = consumoTotal * horasDiarias * 30 * costoPorWatt;
            return costoMensual;
        }

        // Metodo Extra

        public string ConfigurarCanales()
        {
            string txt = $"Pulgadas: {pulgadas}\nResolución: {resolucion}";
        }
    }
}
