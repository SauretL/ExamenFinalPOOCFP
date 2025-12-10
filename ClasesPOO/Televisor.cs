using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesPOO
{
    public class Televisor : Electrodomestico
    {
        //Atributos

        public int pulgadas;
        public ResolucionTV resolucion;

        // Constante
        private const double FACTOR_PANTALLA = 0.05;

        //Constructores

        public Televisor(string marca, string modelo, decimal consumoBaseWatts, int pulgadas)
          : base(marca, modelo, consumoBaseWatts)
        {
            this.pulgadas = pulgadas;
            this.resolucion = ResolucionTV.FULLHD;
        }

        public Televisor(string marca, string modelo, decimal consumoBaseWatts, int pulgadas, ResolucionTV resolucion)
  : base(marca, modelo, consumoBaseWatts)
        {
            this.pulgadas = pulgadas;
            this.resolucion = resolucion;
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

        public override decimal CalcularCostoMensual(int horasDiarias, decimal costoPorWatt)
        {
            decimal consumoTotal = consumoBaseWatts + (decimal)(pulgadas * FACTOR_PANTALLA * (int)resolucion);

            decimal costoMensual = consumoTotal * horasDiarias * 30 * costoPorWatt;
            return costoMensual;
        }

        // Metodo Extra

        public string ConfigurarCanales()
        {
            string txt = $"\"===CONFIGURANDO CANALES===\nPulgadas: {pulgadas}\nResolución: {resolucion}";
            return txt ;
        }
    }
}
